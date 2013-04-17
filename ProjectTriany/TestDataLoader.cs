using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProjectTriany
{
    public class TestDataLoader
    {
        public IEnumerable<Procedure> LoadProcedures(string filename)
        {
            return File.ReadAllLines(filename).Select(Procedure.CreateFrom).Where(procedure => procedure != null);
        }
    }

    public class Procedure
    {
        public Procedure(ProcedureKind procedureKind, int[] args)
        {
            Kind = procedureKind;
            Args = args;
        }

        public ProcedureKind Kind { get; private set; }

        public int[] Args { get; private set; }

        public static Procedure CreateFrom(string s)
        {
            if (s.TrimStart().First() == '#')
            {
                return null;
            }

            var regEx = new Regex(@"(?<procedure>[sf])\s+(?<arg1>\d+)(?<arg2>\s+\d+)?\s*$");

            if (!regEx.IsMatch(s))
            {
                return null;
            }

            var match = regEx.Match(s);

            var kind = match.Groups["procedure"].Value;
            var arg1 = match.Groups["arg1"].Value;
            var arg2 = match.Groups["arg2"].Value;

            if (kind == "s" && arg2 != string.Empty)
            {
                return new Procedure(ProcedureKind.SetEntry,
                                     new[] {int.Parse(arg1), int.Parse(arg2)});
            }

            return new Procedure(ProcedureKind.FindEntry, new[] {int.Parse(arg1)});
        }
    }

    public enum ProcedureKind
    {
        SetEntry,
        FindEntry
    }
}
