using System;
using System.Collections.Generic;
		
namespace DeeplHelperDb.Model
{
	public class Pay_Order_List
	{
		
		
		///<summary>
		///
		///</summary>
		public int id { get; set; }
		
		///<summary>
		///
		///</summary>
		public Guid uid { get; set; }
		
		///<summary>
		///
		///</summary>
		public string cOrder_Name { get; set; }
		
		///<summary>
		///
		///</summary>
		public string cOrder_Number { get; set; }
		
		///<summary>
		///
		///</summary>
		public DateTime dCreate_Time { get; set; }
		
		///<summary>
		///
		///</summary>
		public decimal fPayAmount { get; set; }
		
		///<summary>
		///
		///</summary>
		public byte iStatus { get; set; }
		
		///<summary>
		///
		///</summary>
		public string cRemark { get; set; }
		
	}
}
