using System;
using System.Collections.Generic;
		
namespace DeeplHelperDb.Model
{
	public class Doc_Doc_Comments
	{

		
		///<summary>
		///
		///</summary>
		public int id { get; set; }
		
		///<summary>
		///
		///</summary>
		public string cContent { get; set; }
		
		///<summary>
		///
		///</summary>
		public Guid? cUid { get; set; }
		
		///<summary>
		///
		///</summary>
		public DateTime dCreate_Time { get; set; }
		
		///<summary>
		///
		///</summary>
		public bool bIs_Show { get; set; }
		
		///<summary>
		///
		///</summary>
		public bool bIs_Examine { get; set; }
		
	}
}
