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
    public class DictrianyTest
    {
        [TestCase]
        public void 格納されていない値には0を返す()
        {
            var sut = new Dictriany();

            sut.FindEntry(100).Is(0);
        }

        [TestCase]
        public void キーに0を設定して値を登録しても何も起こらない()
        {
            var sut = new Dictriany();
            sut.SetEntry(0,100);
            sut.FindEntry(100).Is(0);
        }
    }

}
