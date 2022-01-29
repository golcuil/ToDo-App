using System;
using System.Collections;
using System.Collections.Generic;

namespace ToDoApp 
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("ToDo Uygulamasına Hoşgeldiniz...");
            int userInput = -1;

            while (userInput != 0)
            {
                Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Seçiniz");
                Console.WriteLine("(1) Kart Ekle.");
                Console.WriteLine("(2) Kart Güncelle.");
                Console.WriteLine("(3) Kart Sil.");
                Console.WriteLine("(4) Kart Taşı.");
                Console.WriteLine("(5) Board Listele.");
                Console.WriteLine("(0) Çıkış.");

                userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        BoardManager.AddCard();
                        break;
                    case 2:
                        BoardManager.UpdateCards();
                        break;
                    case 3:
                        BoardManager.DeleteCard();
                        break;
                    case 4:                   
                        BoardManager.MoveCard();
                        break;
                    case 5:
                        BoardManager.DisplayCards();
                        break;
                    case 0:
                        Console.WriteLine("Çıkış yapılıyor.");
                        break;

                    default:
                        Console.WriteLine("Hatalı Giriş...");
                        break;
                }


            }


        }
    }
}

