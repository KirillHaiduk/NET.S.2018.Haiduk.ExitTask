using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public class Program
    {
        static void Main()
        {
            var labyrinth = new Labyrinth();
            foreach (var s in labyrinth.Pass(labyrinth.Positions[0, 0], 0, 0))
            {
                Console.WriteLine($"{s.Top} {s.Bottom} {s.Left} {s.Right}");
            }

            Console.ReadLine();
        }
    }
}
