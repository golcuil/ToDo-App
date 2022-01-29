using System;
namespace ToDoApp
{
	public class BoardManager
	{

		public static void AddCard()
        {
			
            Console.Write("Başlık Giriniz: ");
			string title = Console.ReadLine();

            Console.Write("İçerik Giriniz: ");
			string content = Console.ReadLine();

            Console.Write("Büyüklük Seçiniz --> (1)XS, (2)S, (3)M, (4)L, (5)XL : ");
			int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Çalışacak Kişinin ID'sini Giriniz: ");
			int employeeID = int.Parse(Console.ReadLine());
			bool isAssigned = false;

			for(int i = 0; i < Board.done.Count; i++)
            {
				if (Employee.employee[employeeID] == Board.done[i].AssignedEmployee)
                {
					isAssigned = true;
					break;
                }
			}

			for(int i = 0; i< Board.inProgress.Count; i++)
            {
				if (Employee.employee[employeeID] == Board.inProgress[i].AssignedEmployee)
				{
					isAssigned = true;
					break;
				}
			}

			for (int i = 0; i < Board.toDo.Count; i++)
			{
				if (Employee.employee[employeeID] == Board.toDo[i].AssignedEmployee)
				{
					isAssigned = true;
					break;
				}
			}

            if (isAssigned)
            {
                Console.WriteLine("Çalışan başka bir task için görevli. Lütfen farklı çalışan atayınız.");
            }
            else
            {
                Console.WriteLine("Ekleme Başarılı.");
				Board.toDo.Add(new Card(title, content, employeeID, size));
            }


		}

		public static void MoveCard()
        {
            Console.WriteLine("Güncellemek İstediğiniz Kartı Seçin");
            Console.Write("Kart Başlığı: ");
			string cardTitle = Console.ReadLine();

			List<Card> cards = new();
			bool isCardFound = false;
			string fromWhere = "";

			for (int i = 0; i < Board.done.Count; i++)
			{
				if (cardTitle == Board.done[i].Title)
				{
					cards.Add(Board.done[i]);
					Board.done.RemoveAt(i);
					isCardFound = true;
					fromWhere = "Done";
					break;
				}
			}

			for (int i = 0; i < Board.inProgress.Count; i++)
			{
				if (cardTitle == Board.inProgress[i].Title)
				{
					cards.Add(Board.inProgress[i]);
					Board.inProgress.RemoveAt(i);
					isCardFound = true;
					fromWhere = "In Progress";
					break;
				}
			}

			for (int i = 0; i < Board.toDo.Count; i++)
			{
				if (cardTitle == Board.toDo[i].Title)
				{
					cards.Add(Board.toDo[i]);
					Board.toDo.RemoveAt(i);
					isCardFound = true;
					fromWhere = "To Do";
					break;
				}
			}

			if (isCardFound)
			{
                Console.WriteLine("Kart Bilgileri: ");
                Console.WriteLine("Başlık: " + cards[0].Title);
                Console.WriteLine("İçerik: " + cards[0].Content);
                Console.WriteLine("Atanan Kişi: "+ cards[0].AssignedEmployee);
                Console.WriteLine("Büyüklük: " + cards[0].ProjectSize);
                Console.WriteLine("Line: "+ fromWhere);

                Console.WriteLine("Taşımak İstediğiniz Line'ı Seçiniz: ");
                Console.WriteLine("(1) To Do");
                Console.WriteLine("(2) In Progress");
                Console.WriteLine("(3) Done");

				isCardFound = false;
				fromWhere = "";
				int answer = int.Parse(Console.ReadLine());

				if(answer == 1)
                {
					Board.toDo.Add(cards[0]);
					cards.Clear();
                }
				else if(answer == 2)
                {
					Board.inProgress.Add(cards[0]);
					cards.Clear();
				}
				else if(answer == 3)
                {
					Board.done.Add(cards[0]);
					cards.Clear();
				}

                Console.WriteLine("Taşıma Başarılı.");
			}
			else
			{
                Console.WriteLine("Aradığınız kart bulunamadı. Tekrar denemek ister misiniz (y/n)");
				string search = Console.ReadLine();

				if(search == "y")
                {
					MoveCard();
                }
                else
                {
                    Console.WriteLine("Ana Menüye Dönülüyor...");
                }
			}

		}

		public static void DeleteCard()
        {
			Console.WriteLine("Silmek İstediğiniz Kartı Seçin");
			Console.Write("Kart Başlığı: ");
			string cardTitle = Console.ReadLine();

			List<Card> cards = new();
			bool isCardFound = false;
			string fromWhere = "";

			for (int i = 0; i < Board.done.Count; i++)
			{
				if (cardTitle == Board.done[i].Title)
				{
					Board.done.RemoveAt(i);
					isCardFound = true;
					break;
				}
			}

			for (int i = 0; i < Board.inProgress.Count; i++)
			{
				if (cardTitle == Board.inProgress[i].Title)
				{
					Board.inProgress.RemoveAt(i);
					isCardFound = true;
					break;
				}
			}

			for (int i = 0; i < Board.toDo.Count; i++)
			{
				if (cardTitle == Board.toDo[i].Title)
				{
					Board.toDo.RemoveAt(i);
					isCardFound = true;
					break;
				}
			}

			if (isCardFound)
			{
                Console.WriteLine("Silme İşlemi Tamamlandı.");
				isCardFound = false;
			}
			else
			{
				Console.WriteLine("Aradığınız kart bulunamadı. Tekrar denemek ister misiniz (y/n)");
				string search = Console.ReadLine();

				if (search == "y")
				{
					DeleteCard();
				}
				else
				{
					Console.WriteLine("Ana Menüye Dönülüyor...");
				}
			}
		}

		public static void DisplayCards()
        {
            Console.WriteLine("TO DO LINE");
            Console.WriteLine("******************");

			for(int i = 0; i<Board.toDo.Count; i++)
            {
				Console.WriteLine("Başlık: " + Board.toDo[i].Title);
				Console.WriteLine("İçerik: " + Board.toDo[i].Content);
				Console.WriteLine("Atanan Kişi: " + Board.toDo[i].AssignedEmployee);
				Console.WriteLine("Büyüklük: " + Board.toDo[i].ProjectSize);
				Console.WriteLine("-----");

			}
            Console.WriteLine("IN PROGRESS LINE");
			Console.WriteLine("******************");
			for (int i = 0; i < Board.inProgress.Count; i++)
			{
				Console.WriteLine("Başlık: " + Board.inProgress[i].Title);
				Console.WriteLine("İçerik: " + Board.inProgress[i].Content);
				Console.WriteLine("Atanan Kişi: " + Board.inProgress[i].AssignedEmployee);
				Console.WriteLine("Büyüklük: " + Board.inProgress[i].ProjectSize);
				Console.WriteLine("-----");

			}

			Console.WriteLine("DONE LINE");
			Console.WriteLine("******************");

			for (int i = 0; i < Board.done.Count; i++)
			{
				Console.WriteLine("Başlık: " + Board.done[i].Title);
				Console.WriteLine("İçerik: " + Board.done[i].Content);
				Console.WriteLine("Atanan Kişi: " + Board.done[i].AssignedEmployee);
				Console.WriteLine("Büyüklük: " + Board.done[i].ProjectSize);
				Console.WriteLine("-----");

			}



		}

		public static void UpdateCards()
        {
            Console.WriteLine("Update Ediliyor.");
        }
    }
	
}

/* Kart Ekle
Kart Güncelle
Kart Sil
Kart Taşı
Board Listeleme */
