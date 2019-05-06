using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bot
{
    public class BotChat : IBot
    {
        string IBot.ResponseBot(string code)
        {
            string URL = string.Format(Properties.Settings.Default.URL, code);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            string response = string.Empty;
            try
            {
                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                response = responseReader.ReadToEnd();
                Console.Out.WriteLine(response);
                responseReader.Close();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }
            string message = string.Empty;
            try
            {
                string[] responseSplited = response.Split(',');
                string removeNewLine = Regex.Replace(responseSplited[7], @"\t|\n|\r", "-");
                if (removeNewLine.Contains("-"))
                {
                    message = String.Format("{0} quote is ${1} per share", removeNewLine.Split('-')[2], responseSplited[11]);
                }
                else 
                    message = String.Format("{0} quote is ${1} per share", removeNewLine, responseSplited[11]);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
