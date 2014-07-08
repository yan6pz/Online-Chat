using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineChat.Models;

namespace OnlineChat.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // ajax query - add message
        public JsonResult AddMessage(Messages message)
        {
            Messages newMessage = new Messages();
            newMessage.Username = message.Username;
            newMessage.MessageBody = message.MessageBody;
            newMessage.PostDate = DateTime.Now;

            Messages.messages.Add(newMessage);
            var result = new { message = "Success" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // ajax query - get top ten message sorted by date desc
        [NoCache]
        [HandleError]
        public JsonResult GetMessages()
        {
            //Messages newMessage = new Messages();
            //newMessage.Username = "System";
            //newMessage.MessageBody = "Hello";
            //newMessage.PostDate = DateTime.Now;
            //Messages.messages.Add(newMessage);
            var messages = Messages.messages
                .OrderByDescending(x => x.PostDate)
                .TakeWhile(x => x != null);

            if(Messages.messages.Count>10)
            {
                Messages.messages.RemoveRange(0,2);
            }

            var result = new LinkedList<object>();

            foreach (var message in messages)
            {
                result.AddLast(new
                {
                    Username = message.Username,
                    PostDate = message.PostDate.ToString(),
                    MessageBody = message.MessageBody
                });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
