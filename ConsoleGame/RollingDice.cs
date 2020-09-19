using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
   public class RollingDice
    {
        private readonly Random _random = new Random();

        public int D4 ()
        {
            return _random.Next(0,5);
            Console.WriteLine(_random);
            Console.ReadKey();
        }

    }
}
