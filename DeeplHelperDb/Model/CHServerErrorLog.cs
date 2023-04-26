using System;
using System.Collections.Generic;
		
namespace DeeplHelperDb.Model
{
	public class CHServerErrorLog
	{

		///<summary>
		///
		///</summary>
		public int id { get; set; }
		
		///<summary>
		///
		///</summary>
		public string ErrorTitle { get; set; }
		
		///<summary>
		///
		///</summary>
		public string ErrorContent { get; set; }
		
		///<summary>
		///
		///</summary>
		public DateTime addTime { get; set; }
		
		///<summary>
		///
		///</summary>
		public int ErrorLevel { get; set; }
		
		///<summary>
		///
		///</summary>
		public int chServerId { get; set; }
		
		///<summary>
		///
		///</summary>
		public int isDelete { get; set; }
		
	}
}
