using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class DataManagement
    {

        public List<User> GetAllUsers(string userName)
        {
            List<User> list = new List<User>();
            using (var db = new ChatContext())
            {
                list = db.Users.Where(u => u.name != userName)
                                 .ToList();
            }
            return list;
        }

        public List<Conversation> GetConversations(User currentUser, int contact)
        {
            List<Conversation> list = new List<Conversation>();
            using (var db = new ChatContext())
            {
                list = db.Conversations.
                                  Where(c => (c.receiver_id == currentUser.id && c.sender_id == contact) || (c.receiver_id == contact && c.sender_id == currentUser.id))
                                  .OrderBy(c => c.created_at)
                                  .ToList();
            }
            return list.Take(50).ToList();
        }

        public void SaveConversation(Conversation convo)
        {
            using (var db = new ChatContext())
            {
                db.Conversations.Add(convo);
                db.SaveChanges();
            }
        }

        public Conversation MessageDelivered(int message_id)
        {
            Conversation convo = new Conversation();
            using (var db = new ChatContext())
            {
                convo = db.Conversations.FirstOrDefault(c => c.id == message_id);
                if (convo != null)
                {
                    convo.status = Conversation.messageStatus.Delivered;
                    db.Entry(convo).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return convo;
        }

        public User GetUser(string user_name)
        {
            User user = new User();
            using (var db = new ChatContext())
            {

                user = db.Users.FirstOrDefault(u => u.name == user_name);

                if (user == null)
                {
                    user = new User { name = user_name };

                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            return user;
        }

    }
}
