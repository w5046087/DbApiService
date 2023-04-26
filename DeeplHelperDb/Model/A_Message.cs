using System;
using System.Collections.Generic;
		
namespace DeeplHelperDb.Model
{
	public class A_Message
	{
	
		///<summary>
		///
		///</summary>
		public int id { get; set; }
		
		///<summary>
		///
		///</summary>
		public Guid cUid { get; set; }
		
		///<summary>
		///
		///</summary>
		public string cTitle { get; set; }
		
		///<summary>
		///
		///</summary>
		public string cContent { get; set; }
		
		///<summary>
		///
		///</summary>
		public DateTime dAddTime { get; set; }
		
		///<summary>
		///
		///</summary>
		public bool bIs_Delete { get; set; }
		
		///<summary>
		///
		///</summary>
		public bool bIs_Read { get; set; }
		
		///<summary>
		///
		///</summary>
		public byte iMessage_Type { get; set; }
		
		///<summary>
		///
		///</summary>
		public DateTime? dRead_Time { get; set; }
		
	}
}
