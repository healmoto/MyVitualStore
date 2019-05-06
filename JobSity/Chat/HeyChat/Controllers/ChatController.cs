using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PusherServer;
using Entities;
using DAL;
using Bot;

namespace HeyChat.Controllers
{

    static class Global
    {

        public static List<String> GetCommandList ()
        {
            List<String> list = new List<string>();
            list.Add("/stock");
            return list;
        }
    }

    public class ChatController : Controller
    {
        private Pusher pusher;
        public ChatController() 
        {
            var options = new PusherOptions();
            options.Cluster = "PUSHER_APP_CLUSTER";
            pusher = new Pusher(
              "PUSHER_APP_ID",
              "PUSHER_APP_KEY",
              "PUSHER_APP_SECRET", options);
        }
        public ActionResult Index()
        {
            if (Session["user"] == null) {
                return Redirect("/");
            }
            var currentUser = (User) Session["user"];
            DataManagement dm = new DataManagement();
            ViewBag.allUsers = dm.GetAllUsers(currentUser.name);
            ViewBag.currentUser = currentUser;
            return View ();
        }
        
        public JsonResult ConversationWithContact(int contact)
        {
            if (Session["user"] == null)
            {
                return Json(new { status = "error", message = "User is not logged in" });
            }
            var currentUser = (User)Session["user"];
            var conversations = new List<Conversation>();
            DataManagement dm = new DataManagement();
            conversations = dm.GetConversations(currentUser, contact);
            return Json(new { status = "success", data = conversations }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SendMessage() 
        {
            DataManagement dm = new DataManagement();
            if (Session["user"] == null)
            {
                return Json(new { status = "error", message = "User is not logged in" });
            }
            var currentUser = (User)Session["user"];
            var contact = Convert.ToInt32(Request.Form["contact"]);
            string socket_id = Request.Form["socket_id"];
            string userMessage = String.Empty;
            int userId= currentUser.id;
            if (!Global.GetCommandList().Contains(Request.Form["message"].Split('=')[0]))
            {
                userMessage = Request.Form["message"];
            }
            else
            {
                //Llamar bot
                IBot MyBot = BotFactory.GiveResponse();
                userMessage = MyBot.ResponseBot(Request.Form["message"].Split('=')[1].ToString());
                userId = dm.GetUser("BOT").id;
            }
            Conversation convo = new Conversation
            {
                sender_id = userId,
                message = userMessage,
                receiver_id = contact
            };
            dm.SaveConversation(convo);
            var conversationChannel = getConvoChannel( currentUser.id, contact);
            pusher.TriggerAsync(
              conversationChannel,
              "new_message",
              convo,
              new TriggerOptions() { SocketId = socket_id });
            return Json(convo);
        }


        [HttpPost]
        public JsonResult MessageDelivered( int message_id)
        {
            Conversation convo = null;
            DataManagement dm = new DataManagement();
            convo = dm.MessageDelivered(message_id);
            string socket_id = Request.Form["socket_id"];
            var conversationChannel = getConvoChannel(convo.sender_id, convo.receiver_id);
            pusher.TriggerAsync(
              conversationChannel,
              "message_delivered",
              convo,
              new TriggerOptions() { SocketId = socket_id });
            return Json(convo);
        }
        private String getConvoChannel(int user_id, int contact_id)
        {
            if (user_id > contact_id)
            {
                return "private-chat-" + contact_id + "-" + user_id;
            }
            return "private-chat-" + user_id + "-" + contact_id;
        }
    }
}
