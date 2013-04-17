using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProjectTriany;

namespace ProjectTriany.Test
{
    [TestFixture]
    public class TestDataRoaderTest
    {
        [TestCase]
        public void set_entryのみのテストデータを読み込むことができる()
        {
            var sut = new TestDataLoader();

            var result = sut.LoadProcedures(@"TestData\テスト用データ_全部入り.txt").ToArray();
            result.Count().Is(6);
            result.Take(3).All(procedeure => procedeure.Kind == ProcedureKind.SetEntry).Is(true);
            result.Take(3).Select(procedure => procedure.Args.Length).All(i => i == 2).Is(true);

            result.Skip(3).All(procedeure => procedeure.Kind == ProcedureKind.FindEntry).Is(true);
            result.Skip(3).Select(procedure => procedure.Args.Length).All(i => i == 1).Is(true);
        }
    }

    [TestFixture]
    class ProcedureTest
    {
        [TestCase]
        public void シャープから始まる文字はコメントなのでCreateしてもnull()
        {
            Procedure.CreateFrom("#s 100 200").IsNull();
        }

        [TestCase]
        public void 冒頭sから始まるデータはSetEntryのデータ()
        {
            var result = Procedure.CreateFrom("s 100 200");
            result.Kind.Is(ProcedureKind.SetEntry);
            result.Args[0].Is(100);
            result.Args[1].Is(200);
        }


        [TestCase]
        public void 冒頭fから始まるデータはFindEntryのデータ()
        {
            var result = Procedure.CreateFrom("f 100");
            result.Kind.Is(ProcedureKind.FindEntry);
            result.Args.Length.Is(1);
            result.Args[0].Is(100);
        }
    }


}
