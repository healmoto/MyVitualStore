using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    public class BotFactory
    {
        public static IBot GiveResponse()
        {
            return new BotChat();
        }
    }
}
