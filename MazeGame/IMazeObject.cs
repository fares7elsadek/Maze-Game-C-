using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public interface IMazeObject
    {
        public char Icon { get;}
        public bool isSolid { get;}
    }
}
