using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Score
    {
        public Score(){
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Score: 0");
            Console.WriteLine("Level: 1");//initial line
        }
        public void Draw(int score, int level)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Score: " + score+ "  ");
            Console.WriteLine("Level: " + level+ "  " );//to update score and level
        }
    }
}
