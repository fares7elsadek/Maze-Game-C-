using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Exit:IMazeObject
    {
        public char Icon => 'E';

        public bool isSolid => false;
    }
}
