using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnswerToRiddleNormal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请回答迷底：言多必失！打一成语");
            bool isRight = true;
            while (isRight)
            {
                string answer=Console.ReadLine();
                if (answer == "祸从口出")
                {
                    Console.WriteLine("恭喜！回答正确，程序将退出");
                    isRight = false;
                }
                else
                {
                    Console.WriteLine("回答错误，请重新回答");
                }
            }
        }
    }
}
