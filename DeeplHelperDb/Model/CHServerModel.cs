namespace DeeplHelperDb.Model { 
public class CHServerModel { 
 public int id {get; set;}   
 public string remarks {get; set;}   
 public string ip {get; set;}   
 public string port {get; set;}   
 public byte[] deeplUser {get; set;}   
 public byte[] deeplPsd {get; set;}   
 public int state {get; set;}   
 public DateTime addTime {get; set;}   
 public DateTime activeTime {get; set;}   
 public string LastExceptionContent {get; set;}   
 public int isDelete {get; set;}   
 } 
}