namespace DeeplHelperDb.Model
{
    public class AccountM
    {
        public string id { get; set; }
        public string wxOpenId { get;set; }
        public string? wxNick { get;set; }
        public string? wxHeadImgUrl { get;set; }
        public string wx_unionid { get;set; }
        public int wx_sex { get;set; }
        public string wx_city { get;set; }
        public string wx_province { get;set; }  
        public int BindServerId { get;set; }
        public string BindServer { get;set; }   
        public string? refreshTokenExe { get;set; }
        public string? refreshTokenChrome { get;set; }

        public DateTime regTime { get; set; }
        public int State { get; set; }
        public int abnormalId { get; set; }
        
    }
}
