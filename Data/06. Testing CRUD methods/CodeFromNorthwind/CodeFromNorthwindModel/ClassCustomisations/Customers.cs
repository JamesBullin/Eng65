using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFromNorthwindModel
{
	public partial class Customers
	{
		public override string ToString()
		{
			return $"{CustomerId} - {ContactName} - {City}";
		}
	}
}
