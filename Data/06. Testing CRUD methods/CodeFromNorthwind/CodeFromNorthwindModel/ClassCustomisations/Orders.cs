using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFromNorthwindModel
{
	public partial class Orders
	{
		public override string ToString()
		{
			return $"{OrderId} - {OrderDate}";
		}
	}
}
