using System;
using System.Collections.Generic;
		
namespace DeeplHelperDb.Model
{
	public class A_Account
	{
	
		
		///<summary>
		///
		///</summary>
		public Guid cUid { get; set; }
		
		///<summary>
		///
		///</summary>
		public int iAuto_ID { get; set; }
		
		///<summary>
		///
		///</summary>
		public byte? iAccount_Type { get; set; }
		
		///<summary>
		///
		///</summary>
		public byte iStatus { get; set; }
		
		///<summary>
		///
		///</summary>
		public string cWx_Openid { get; set; }
		
		///<summary>
		///
		///</summary>
		public string cWx_Unionid { get; set; }
		
		///<summary>
		///
		///</summary>
		public string cWx_Nick { get; set; }
		
		///<summary>
		///
		///</summary>
		public string cWx_Img { get; set; }
		
		///<summary>
		///
		///</summary>
		public int? cWx_Sex { get; set; }
		
		///<summary>
		///
		///</summary>
		public DateTime? dRegTime { get; set; }
		
		///<summary>
		///
		///</summary>
		public DateTime? dLast_login { get; set; }
		
		///<summary>
		///
		///</summary>
		public DateTime? dLast_TranslateTime { get; set; }
		
	}
}
