using System;
using System.Collections.Generic;
		
namespace DeeplHelperDb.Model
{
	public class CHServer
	{
	
		///<summary>
		///
		///</summary>
		public int id { get; set; }
		
		///<summary>
		///
		///</summary>
		public string remarks { get; set; }
		
		///<summary>
		///
		///</summary>
		public string ip { get; set; }
		
		///<summary>
		///
		///</summary>
		public string port { get; set; }
		
		///<summary>
		///
		///</summary>
		public byte[] deeplUser { get; set; }
		
		///<summary>
		///
		///</summary>
		public byte[] deeplPsd { get; set; }
		
		///<summary>
		///
		///</summary>
		public int state { get; set; }
		
		///<summary>
		///
		///</summary>
		public DateTime addTime { get; set; }
		
		///<summary>
		///
		///</summary>
		public DateTime? activeTime { get; set; }
		
		///<summary>
		///
		///</summary>
		public string LastExceptionContent { get; set; }
		
		///<summary>
		///
		///</summary>
		public int isDelete { get; set; }
		
	}
}
