namespace DpApiServer.WeiXinOpen.Model
{
    public class WxUserInfoM
    {
        public string openid { get; set; }
        public string nickname { get; set; }
        public int sex { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string headimgurl { get; set; }
        public string unionid { get; set; } 
        public int errcode { get; set; }
        public string errmsg { get; set; }
    }
}
