using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatePdfFile.Models
{
	public class PersonalDetails
	{
		public string Name{ get; set; }

		public DateTime Date_birth{ get; set; }
		public string Email { get; set; }

		public string Phone { get; set; }

		public string Address { get; set; }
		public string Country { get; set; }
		public string State { get; set; }
		public string City { get; set; }
	}
}
