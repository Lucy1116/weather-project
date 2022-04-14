using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewProject.Models
{
	public class WeatherInfo
	{

		public List<ConsolidatedWeather> Consolidated_Weather { get; set; }

		public DateTime Time { get; set; }

		public string Title { get; set; }

		public string Location_Type { get; set; }

		public int Woeid { get; set; }

		public string Latt_Long { get; set; }

		public string Timezone { get; set; }

	}

	public class ConsolidatedWeather
	{

		public long Id { get; set; }

		public string Applicable_Date { get; set; }

		public decimal Min_Temp { get; set; }

		public decimal Max_Temp { get; set; }

		public decimal The_Temp { get; set; }

		public int Humidity { get; set; }

		public int Predictability { get; set; }

	}
}
