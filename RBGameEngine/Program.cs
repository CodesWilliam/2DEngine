using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;

namespace RBGameEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Toolkit.Init())
            {
                new TestGame(1248, 900, "2D Game Engine");
            }
        }
    }
}
