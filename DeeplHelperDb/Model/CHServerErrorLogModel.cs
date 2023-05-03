namespace DeeplHelperDb.Model { 
public class CHServerErrorLogModel { 
 public int id {get; set;}   
 public string ErrorTitle {get; set;}   
 public string ErrorContent {get; set;}   
 public DateTime addTime {get; set;}   
 public int ErrorLevel {get; set;}   
 public int chServerId {get; set;}   
 public int isDelete {get; set;}   
 } 
}