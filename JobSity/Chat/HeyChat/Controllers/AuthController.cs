using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PusherServer;
using Entities;
using DAL;

namespace HeyChat.Controllers
{
    public class AuthController : Controller
    {
    
    	
	private Pusher pusher;

	//class constructor
	public AuthController() 
	{

	    var options = new PusherOptions();
	    options.Cluster = "PUSHER_APP_CLUSTER";

	    pusher = new Pusher(
	       "PUSHER_APP_ID",
	       "PUSHER_APP_KEY",
	       "PUSHER_APP_SECRET",
	       options
	   );
	}
		[HttpPost]
		public ActionResult Login()
		{
            
			string user_name = Request.Form["username"];

			if (user_name.Trim() == "") {
				return Redirect("/");
			}

            DataManagement dm = new DataManagement();
            Session["user"] = dm.GetUser(user_name);

			return Redirect("/chat");
		}

        public JsonResult AuthForChannel(string channel_name, string socket_id)
        {
            if (Session["user"] == null)
            {
                return Json(new { status = "error", message = "User is not logged in" });
            }

            var currentUser = (User)Session["user"];

            if ( channel_name.IndexOf("presence") >= 0 ) {

				var channelData = new PresenceChannelData()
				{
					user_id = currentUser.id.ToString(),
					user_info = new
					{
						id = currentUser.id,
						name = currentUser.name
					},
				};

				var presenceAuth = pusher.Authenticate(channel_name, socket_id, channelData);

				return Json(presenceAuth);

            }

	    if (channel_name.IndexOf(currentUser.id.ToString()) == -1)
	    {
		return Json(new { status = "error", message = "User cannot join channel" });
	    }

	    var auth = pusher.Authenticate(channel_name, socket_id);

	    return Json(auth);


        }
    }
}
