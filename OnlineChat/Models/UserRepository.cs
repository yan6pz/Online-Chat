using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineChat.Models
{
    public class UserRepository
    {
        static public bool CheckUserLogin(string username, string password)
        {
            switch (username)
            {
                case "mama":
                case "yanis":
                case "sisi":
                    if (password == "1234")
                        return true;
                    else
                        return false;
                default:
                    return false;
            }
        }

        static public string GetUserName(string username)
        {
            switch (username)
            {
                case "trey":
                    return "Trey Gourley";
                case "bill":
                    return "Bill Smith";
                case "mike":
                    return "Mike Somebody";
                default:
                    return string.Empty;
            }
        }
    }
}