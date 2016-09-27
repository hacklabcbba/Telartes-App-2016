using System;
namespace  Telartes
{
	public class CallFilterItem
	{
		private string my_name;
		private bool my_value;

		public CallFilterItem(string name, bool value)
		{
			my_name = name;
			my_value = value;
		}

		public string name { 
			get { 
				return my_name; 
			} 
			set { 
				my_name = value; 
			} 
		}

		public bool value { 
			get { 
				return my_value; 
			} 
			set { 
				my_value = value; 
			}
		}
	}
}

