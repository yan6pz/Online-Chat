using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineChat.Models
{
    public class Messages
    {
        public int Id { get; set; }
        public string MessageBody { get; set; }
        public DateTime PostDate { get; set; }
        public string Username { get; set; }

        public static List<Messages> messages
        {
            get { return messagess; }

            set { messagess = value; }
        }

        private static List<Messages> messagess = new List<Messages>(); 
    }
}