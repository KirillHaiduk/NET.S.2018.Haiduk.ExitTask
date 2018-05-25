using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    /// <summary>
    /// Describes position in labyrinth including properties of walls
    /// </summary>
    public class Position
    {
        public bool Top { get; set; }
        public bool Bottom { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool IsVisited { get; set; }
        public Position Previous { get; set; }
        public Position Next { get; set; }

        public Position()
        { }

        public Position(bool top, bool bottom, bool left, bool right)
        {
            Top = top;
            Bottom = bottom;
            Left = left;
            Right = right;
            IsVisited = false;
        }        
    }
}
