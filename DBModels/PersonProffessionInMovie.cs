using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
	public class PersonProffessionInMovie
	{
		public int PersonId { get; set; }
		public int MovieInfoId { get; set; }
		public string Proffession { get; set; }	// maxLength = 15
	}
}
