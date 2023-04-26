using System;
using System.Collections.Generic;
		
namespace DeeplHelperDb.Model
{
	public class Applist
	{

		
		///<summary>
		///
		///</summary>
		public int id { get; set; }
		
		///<summary>
		///
		///</summary>
		public byte[] title { get; set; }
		
		///<summary>
		///
		///</summary>
		public byte[] version { get; set; }
		
		///<summary>
		///
		///</summary>
		public string simpleDesc { get; set; }
		
		///<summary>
		///
		///</summary>
		public string detailedDesc { get; set; }
		
		///<summary>
		///
		///</summary>
		public string usingTutorials { get; set; }
		
		///<summary>
		///
		///</summary>
		public DateTime subDateTime { get; set; }
		
		///<summary>
		///
		///</summary>
		public string downUrl { get; set; }
		
		///<summary>
		///
		///</summary>
		public int apptype { get; set; }
		
	}
}
