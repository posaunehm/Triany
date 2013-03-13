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
    public class TrianyRepositoryTest
    {
        [TestCase]
        public void ルートトリアニーのIDを取得する()
        {
            var sut = new TrianyRepository();

            sut.RootTorianyId().Is(1u);
        }
            
        [TestCase]
        public void ルートトリアニーのAに値が設定できる()
        {
            var sut = new TrianyRepository();

            var rootID = sut.RootTorianyId();

            sut.SetA(rootID, 1u);
            sut.GetA(rootID).Is(1u);
        }


        [TestCase]
        public void ルートトリアニーのBに値が設定できる()
        {
            var sut = new TrianyRepository();

            var rootID = sut.RootTorianyId();

            sut.SetB(rootID, 1u);
            sut.GetB(rootID).Is(1u);
        }

        [TestCase]
        public void ルートトリアニーのCに値が設定できる()
        {
            var sut = new TrianyRepository();

            var rootID = sut.RootTorianyId();

            sut.SetC(rootID, 1u);
            sut.GetC(rootID).Is(1u);
        }
    }
}
