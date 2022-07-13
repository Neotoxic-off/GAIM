using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAIM
{
    public class Model
    {
        private Settings settings { get; set; }
        private List<Generation> children { get; set; }
        private Generation parent { get; set; }
        private List<bool> results = new List<bool>();

        public Model(Settings settings, Generation parent)
        {
            this.settings = settings;
            this.parent = parent;

            Setup(this.parent);
        }

        public Generation train()
        {
            bool status = false;
            Generation current = null;
            
            Console.WriteLine($"[-] target '{display_bytes(this.settings.target)}'");
            while (status != true)
            {
                current = Setup(parent);

                Console.WriteLine($"[.] starting generation '{current.id}'");
                Console.WriteLine($"[.] running all children");
                foreach (Generation generation in children)
                {
                    results.Add(generation.run());
                }
                Console.WriteLine($"[+] all children ran");

                Console.WriteLine($"[.] checking results");
                status = check_results(results);

                Console.WriteLine($"[-] status '{status}'");
                Console.WriteLine($"[-] end of this generation");
                Console.WriteLine($"[-] generation '{current.id}'");
                Console.WriteLine($"[-] mutations '{current.mutations}'");
            }

            return (null);
        }

        private bool check_results(List<bool> results)
        {
            foreach (bool r in results)
            {
                if (r == true)
                {
                    return (true);
                }
            }

            return (false);
        }

        private string display_bytes(List<byte> bytes)
        {
            string buffer = "";

            foreach (byte b in bytes)
            {
                buffer += $"0x{b}";
            }

            return (buffer);
        }

        private Generation Setup(Generation parent)
        {
            int id = parent.id + 1;
            List<byte> dna = parent.dna;

            Console.WriteLine($"[.] building '{settings.children}' children for generation '{id}'");
            for (int i = 0; i < settings.children; i++)
            {
                children.Add(new Generation(id, dna, settings.target));
            }
            Console.WriteLine($"[+] children built");

            Console.WriteLine($"[.] cleanning previous generation results");
            results.Clear();
            Console.WriteLine($"[+] previous results cleanned");

            return (new Generation(id, dna, settings.target));
        }
    }
}
