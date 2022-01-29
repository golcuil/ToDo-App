using System;
namespace ToDoApp
{
	public class Card
	{
        public string Title { get; set; }
        public string Content { get; set; }
        public string AssignedEmployee { get; set; }
        public Size ProjectSize { get; set; }

        public Card(string title, string content, int employeeID, int size)
		{
            this.Title = title;
            this.Content = content;
            this.AssignedEmployee = Employee.employee[employeeID];
            this.ProjectSize = (Size)size;

		}
	}
}

