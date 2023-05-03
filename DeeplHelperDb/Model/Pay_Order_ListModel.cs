namespace DeeplHelperDb.Model { 
public class Pay_Order_ListModel { 
 public int id {get; set;}   
 public Guid uid {get; set;}   
 public string cOrder_Name {get; set;}   
 public string cOrder_Number {get; set;}   
 public DateTime dCreate_Time {get; set;}   
 public decimal fPayAmount {get; set;}   
 public byte iStatus {get; set;}   
 public string cRemark {get; set;}   
 } 
}