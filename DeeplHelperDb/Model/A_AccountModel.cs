namespace DeeplHelperDb.Model { 
public class A_AccountModel { 
 public Guid cUid {get; set;}
 
 public int? iAuto_ID {get; set;}   
 public byte? iAccount_Type {get; set;}   
 public byte? iStatus {get; set;}   
 public string cWx_Openid {get; set;}   
 public string cWx_Unionid {get; set;}   
 public string cWx_Nick {get; set;}   
 public string cWx_Img {get; set;}   
 public bool cWx_Sex {get; set;}   
 public DateTime? dRegTime {get; set;}   
 public DateTime? dLast_login {get; set;}   
 public DateTime? dLast_TranslateTime {get; set;}   
 } 
}