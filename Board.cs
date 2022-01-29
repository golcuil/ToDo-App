using System;
namespace ToDoApp
{
	public class Board
	{
		public static List<Card> toDo = new();
		public static List<Card> inProgress = new();
		public static List<Card> done = new();

		
				

		static Board()
		{
			toDo.Add(new Card("Raporlama", "Forecast",10001,4));
			toDo.Add(new Card("Algoritma Geliştirme", "AI", 10002, 5));
			done.Add(new Card("Temizlik", "Ofis Temizliği",10005, 2));
			inProgress.Add(new Card("Oyun", "Oyun Programlama", 10003, 3));		
			
		}

	}
}

