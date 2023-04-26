using Microsoft.AspNetCore.Mvc;
using DpApiServer.DbHelper;
using DeeplHelperDb.Service;
using DeeplHelperDb.Model;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace DpApiServer.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
   
        private readonly A_MessageService messageService;
        public MessageController(A_MessageService messageService)
        {
            this.messageService = messageService;
        }
        [HttpGet]
        [Route("/getUserMsg")]
        public IEnumerable<A_Message> GetUserMsg(HttpContext httpContext,int _page, int _pageNum, int _msgType) {
            string? userId = httpContext.User.Claims?.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Name)?.Value;
          return  messageService.GetList(_page, _pageNum, _msgType, userId);
        }
        [HttpGet]
        [Route("/deleteMsg")]
        public int DeleteMsg(HttpContext httpContext,int msgID) { 
            string? userId = httpContext.User.Claims?.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Name)?.Value;

            return messageService.Delete(msgID, userId);
        }
        [HttpGet]
        [Route("/setReadMsg")]
        public int SetReadMsg(HttpContext httpContext, int msgID) {
            string? userId = httpContext.User.Claims?.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Name)?.Value;
            return messageService.SetMsgRead(msgID, userId);
        }


    }
}
