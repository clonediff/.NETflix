using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
	public class PersonProffessionInMovie
	{
		public Person Person { get; set; }
		public int PersonId { get; set; }
		public MovieInfo Movie { get; set; }
		public int MovieId { get; set; }
		public string Proffession { get; set; }	// maxLength = 15
	}
}
