namespace DpApiServer.Global.RsMsg
{
    public class RsMsgSimple
    {
        public int Code { get; set; }
        public string? Content { get; set; }
        public RsMsgSimple(int code, string? content)
        {
            Code = code;
            Content = content;
        }   
    }
}
