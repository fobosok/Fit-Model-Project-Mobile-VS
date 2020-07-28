using System;
using System.Collections.Generic;
using System.Text;

namespace Fit_Model_Project.connections
{
	public class workoutPost
	{
		public string id { get; set; }
		public string name { get; set; }
		public string photo { get; set; }
		public string description { get; set; }
		public List<videoPost> free { get; set; }
		public List<videoPost> paid { get; set; }
	}
}
