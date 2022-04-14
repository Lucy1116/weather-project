using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewProject.Models
{
	public class Location
	{
		//[{"title":"London","location_type":"City","woeid":44418,"latt_long":"51.506321,-0.12714"}]

		public string Title { get; set; }

		public string Location_Type { get; set; }

		public int Woeid { get; set; }

		public string Latt_Long { get; set; }
	}
}
