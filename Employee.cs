using System;
namespace ToDoApp
{
	public class Employee
	{

		public static Dictionary<int, string> employee = new();

		static Employee()
        {
			employee.Add(10001, "John Richards");
			employee.Add(10002, "Ahmet Malik");
			employee.Add(10003, "Colin Johnson");
			employee.Add(10004, "George Luis");
			employee.Add(10005, "Amy Dona");

		}
	}
}

