using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectTriany
{
    public class TrianyRepository
    {
        private const int ROOT_ID = 1;
        readonly Dictionary<int, Triany> TrianyStore = new Dictionary<int, Triany>();

        public TrianyRepository()
        {
            TrianyStore.Add(ROOT_ID,new Triany());
        }

        public int GetRootTorianyId()
        {
            return ROOT_ID;
        }

        public void SetA(int id, int u)
        {
            TrianyStore[id].A = u;
        }

        public int GetA(int id)
        {
            return TrianyStore.ContainsKey(id) ? TrianyStore[id].A : -1;
        }

        public void SetB(int id, int u)
        {
            TrianyStore[id].B = u;
        }

        public int GetB(int id)
        {
            return TrianyStore.ContainsKey(id) ? TrianyStore[id].B : -1;
        }

        public void SetC(int id, int u)
        {
            TrianyStore[id].C = u;
        }

        public int GetC(int id)
        {
            return TrianyStore.ContainsKey(id) ? TrianyStore[id].C : -1;
        }

        public int AllocateTriany()
        {
            var newId = Enumerable.Range(2, int.MaxValue - 2).First(i => !TrianyStore.ContainsKey(i));
            TrianyStore.Add(newId, new Triany());

            return newId;
        }

        public string ToString(int id)
        {
            var triany = TrianyStore[id];
            return string.Format("{0}:{1}",id,triany );
        }
    }

    internal class Triany
    {
        public int A { get; set; }

        public int B { get; set; }

        public int C { get; set; }

        public override string ToString()
        {
            return string.Format("[{0},{1},{2}]",A,B,C);
        }
    }
}
