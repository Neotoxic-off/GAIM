using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAIM
{
    public class Settings
    {
        public int children { get; set; }
        public List<byte> target { get; set; }

        public Settings(int children, List<byte> target)
        {
            this.children = children;
            this.target = target;
        }
    }
}
