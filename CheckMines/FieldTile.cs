using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeButton
{
    class FieldTile
    {
        public bool Mines { get;  set; }
        public bool Opened { get;  set; }
        public bool Marked { get;  set; }
        public int Values { get;  set; }
        public int Index { get; set; }
        public Boolean check {get; set;}
        public Coord Coordi { get; set; }
    }
}
