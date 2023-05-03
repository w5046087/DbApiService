namespace DeeplHelperDb.Model { 
public class A_MessageModel { 
 public int id {get; set;}   
 public Guid cUid {get; set;}   
 public string cTitle {get; set;}   
 public string cContent {get; set;}   
 public DateTime dAddTime {get; set;}   
 public bool bIs_Delete {get; set;}   
 public bool bIs_Read {get; set;}   
 public byte iMessage_Type {get; set;}   
 public DateTime dRead_Time {get; set;}   
 } 
}