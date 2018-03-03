using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake
{
    [Serializable]
    public class Score
    {
        int level, score;
        public Score() { }
        public Score(int score, int level){
            this.score = score;
            this.level = level;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Score: 0");
            Console.WriteLine("Level: 1");//initial line
        }
        public void Ser(int score)
        {
            File.WriteAllText("score.xml", score.ToString());
        }
        public void Ser1(int level)
        {
            File.WriteAllText("level.xml", level.ToString());
        }
        public string Des1()
        {
            string ss = File.ReadAllText("level.xml");
            return ss;
        }
        public string Des()
        {
            string ss =File.ReadAllText("score.xml");
            return ss;
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
