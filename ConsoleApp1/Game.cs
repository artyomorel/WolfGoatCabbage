using System;
using System.Linq;

namespace ConsoleApp1
{
    public class Game
    {
        private GameObject[] GameObjects { get; set; } =
            {new GameObject("You"), new GameObject("Wolf"), new GameObject("Goat"), new GameObject("Cabbage")};

        public bool EndGame { get; set; } = false;
        public bool WinGame { get; set; } = false;
        
        public void StateCoast()
        {
            var leftCoast = "Левый берег:\n ";
            var rightCoast = "Правый берег: \n";

            foreach (var gameObject in GameObjects)
            {
                if (gameObject.GetPosition())
                {
                    rightCoast += gameObject.GetName() + "\n";
                }
                else
                {
                    leftCoast += gameObject.GetName() + "\n";
                }
            }

            Console.Write(leftCoast + "\n");
            Console.Write(rightCoast + "\n");
        }


        public void MoveYou() => GameObjects[0].Move();
        
        public void MoveObject(int numberObject)
        {
            if (CanMoveObject(GameObjects[numberObject]))
            {
                GameObjects[0].Move();
                GameObjects[numberObject].Move();
                CheckEndGame();
                CheckWinGame();
                CheckStateGame();
            }
            else
            {
                Console.WriteLine("You're on the other side");
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
            }
        }
        
        private bool CanMoveObject(GameObject anotherObject)
        {
            return GameObjects[0].GetPosition() == anotherObject.GetPosition();
        }
        
        
        private void CheckWinGame()
        {
            WinGame = GameObjects[1].GetPosition() 
                   && GameObjects[2].GetPosition() 
                   && GameObjects[3].GetPosition() 
                   && GameObjects[0].GetPosition();
        }

        private void CheckEndGame()
        {
            if ((GameObjects[1].GetPosition() == GameObjects[2].GetPosition() &&
                 GameObjects[1].GetPosition() != GameObjects[0].GetPosition()) ||
                (GameObjects[2].GetPosition() == GameObjects[3].GetPosition() &&
                 GameObjects[2].GetPosition() != GameObjects[0].GetPosition()))
            {
                EndGame = true;
            }
            else
            {
                EndGame = false;
            }
            
        }

        private void CheckStateGame()
        {
            if (EndGame)
            {
                Console.WriteLine("\nYou Lose");
            }

            if (WinGame)
            {
                Console.WriteLine("\nYou Win");
            }
        }
    }
}