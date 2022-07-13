using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAIM
{
    public class Generation
    {
        public int id { get; set; }
        public Generation parent { get; set; }
        public List<byte> dna { get; set; }
        public List<byte> target { get; set; }
        public int mutations = 0;

        public Generation(int id, List<byte> dna, List<byte> target)
        {
            this.id = id;
            this.dna = dna;
            this.target = target;
        }

        public bool run()
        {
            foreach (byte b in this.dna)
            {
                foreach (byte t in this.target)
                {
                    if (b != t)
                    {
                        return (false);
                    }
                }
            }

            return (true);
        }

        public List<byte> mutate(int index, byte value)
        {
            this.dna[index] = value;

            return (this.dna);
        }
    }
}
