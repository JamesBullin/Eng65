using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFromNorthwindModel
{
	public partial class Employees
	{
		public override string ToString()
		{
			return $"{FirstName} {LastName}";
		}
	}
}
