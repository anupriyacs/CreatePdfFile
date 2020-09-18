using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatePdfFile.Models
{
	public class PersonalDetails
	{
		public string Name{ get; set; }

		public string Date_birth{ get; set; }
		public string Email { get; set; }

		public string Phone { get; set; }

		public string Address { get; set; }
		public string Country { get; set; }
		public string State { get; set; }
		public string City { get; set; }

		public string Masters_Degree   { get; set; }
		public string Bachelors_Degree { get; set; }

		public string Higher_secondary { get; set; }
		public string Matriulationlty { get; set; }

		public string Experience { get; set; }
		public string Achievements { get; set; }

		public string Projects{ get; set; }
		public string Technical_skills { get; set; }

		public string Additional_skills{ get; set; }
		
	}
}
