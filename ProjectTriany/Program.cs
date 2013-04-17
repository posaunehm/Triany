using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTriany
{
    class Program
    {
        private static readonly Dictriany  _dict = new Dictriany();

        static void Main(string[] args)
        {
            var loader = new TestDataLoader();
            var sum = 0;
            foreach (var procedure in loader.LoadProcedures(@"Data\testdata.txt"))
            {
                if (procedure.Kind == ProcedureKind.SetEntry)
                {
                    Console.WriteLine("Loaded Data: {0},{1},{2}", procedure.Kind,procedure.Args[0],procedure.Args[1]);
                    _dict.SetEntry(procedure.Args[0], procedure.Args[1]);
                }
                else if (procedure.Kind == ProcedureKind.FindEntry)
                {
                    Console.WriteLine("Loaded Data: {0},{1}", procedure.Kind, procedure.Args[0]);
                    sum += _dict.FindEntry(procedure.Args[0]);
                }
            }
            Console.WriteLine("Summarize: {0}", sum);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void set_entry(int key, int value)
        {
            _dict.SetEntry(key,value);
        }

        private static int find_entry(int key)
        {
            return _dict.FindEntry(key);
        }
    }
}
