using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Player : IMazeObject
    {
        public char Icon => '@';

        public bool isSolid => false;

        public int X { get; set; }
        public int Y { get; set; }
    }
}
