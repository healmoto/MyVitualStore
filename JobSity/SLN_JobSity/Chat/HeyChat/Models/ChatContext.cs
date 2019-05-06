using System;
using System.Data.Entity;
namespace HeyChat.Models
{
    public class ChatContext: DbContext
    {
        public ChatContext() : base("DefaultConnection")
        {
        }

		public static ChatContext Create()
		{
			return new ChatContext();
		}

        public DbSet<User> Users { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
    }
}
