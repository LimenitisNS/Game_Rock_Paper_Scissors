using System;

namespace Rock_Paper_Scissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(10);
            game.Start();
        }
    }
}
