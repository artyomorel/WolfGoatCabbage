using System;

namespace ConsoleApp1
{
    /*
     * Написать консольное приложение-игру
     * 
        Крестьянину нужно перевезти через реку волка, козу и капусту. 
        Но лодка такова, что в ней может поместиться только крестьянин, а с ним или один волк, или одна коза, или одна капуста. 
        Но если оставить волка с козой, то волк съест козу, а если оставить козу с капустой, то коза съест капусту. 
        Как перевез свой груз крестьянин?
     */

    static class Program
    {
        private static void Main(string[] args)
        {

            var game = new Game();


            while (!game.EndGame && !game.WinGame)
            {
                Console.Clear();
                Console.WriteLine("Возможные команды:");
                Console.WriteLine("1-Переплыть на другой берег, 2 - Перевести Волка на другой берег");
                Console.WriteLine("3-Перевести козу на другой берег, 4 - Перевести Капусту на другой берег\n");
                game.StateCoast();
                Console.WriteLine("Введите команду");
                Int32.TryParse(Console.ReadLine(), out int number);
                switch (number)
                {
                    case (int) TypeObject.You:
                        game.MoveYou();
                        break;
                    case (int) TypeObject.Wolf:
                        game.MoveObject(number-1);
                        break;
                    case (int) TypeObject.Goat:
                        game.MoveObject(number-1);
                        break;
                    case (int) TypeObject.Cabbage:
                        game.MoveObject(number-1);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong Command");
                        break;
                }

            }
            Console.ReadKey();
        }
        
       

       

        
        

       
    }
}