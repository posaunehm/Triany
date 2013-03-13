using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectTriany
{
    public class TrianyRepository
    {
        private const int ROOT_ID = 1;
        Dictionary<uint, Triany> TrianyStore = new Dictionary<uint, Triany>();

        public TrianyRepository()
        {
            TrianyStore.Add(ROOT_ID,new Triany());
        }

        public uint RootTorianyId()
        {
            return ROOT_ID;
        }

        public void SetA(uint id, uint u)
        {
            TrianyStore[id].A = u;
        }

        public uint GetA(uint id)
        {
            return TrianyStore[id].A;
        }

        public void SetB(uint id, uint u)
        {
            TrianyStore[id].B = u;
        }

        public uint GetB(uint id)
        {
            return TrianyStore[id].B;
        }

        public void SetC(uint id, uint u)
        {
            TrianyStore[id].C = u;
        }

        public uint GetC(uint id)
        {
            return TrianyStore[id].C;
        }
    }

    internal class Triany
    {
        public uint A { get; set; }

        public uint B { get; set; }

        public uint C { get; set; }
    }
}
