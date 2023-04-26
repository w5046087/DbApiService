namespace DpApiServer.WeiXinLib.wxModel
{
    public class TemMsgSysWarn
    {
        public string touser { get; set; }  
        public string template_id { get; set; }
        public string? url { get; set; }
        public TemMsgSysWarnData data { get; set; }
    }
    public class tmp_first { 
    
        public string value { get; set; }
        public string color { get; set; }
    }
    public class tmp_keyWord1 { 
    
        public string value { get; set; }
        public string color { get; set; }
    }
    public class tmp_keyWord2
    {

        public string value { get; set; }
        public string color { get; set; }
    }
    public class tmp_keyWord3
    {

        public string value { get; set; }
        public string color { get; set; }
    }
    public class tmp_remark
    {

        public string value { get; set; }
        public string color { get; set; }
    }
    public class TemMsgSysWarnData { 
    
        public tmp_first first { get; set; }
        public tmp_keyWord1 keyword1 { get; set; }
        public tmp_keyWord2 keyword2 { get; set; }
        public tmp_keyWord3 keyword3 { get; set; }
        public tmp_remark remark { get; set; }
    }
}
