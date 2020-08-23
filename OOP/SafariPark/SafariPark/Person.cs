using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text;

namespace SafariPark
{
	public class Person
	{
		private string _firstName;
		private string _lastName;
		
		private int _age;
		public int Age
		{
			get { return _age; }
			set { if (value >= 0) _age = value; }
		}




		public Person(string fName, string lName, int aAge)
		{
			_firstName = fName;
			_lastName = lName;
			_age = aAge;
		}

		public Person(string fName, string lName)
		{
			_firstName = fName;
			_lastName = lName;
		}

		public string GetFullName()
		{
			return $"{_firstName} {_lastName}";
		}

		public sealed override string ToString()
		{
			return base.ToString();
		}


	}
}
