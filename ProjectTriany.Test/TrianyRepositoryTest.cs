using NUnit.Framework;

namespace ProjectTriany.Test
{
    [TestFixture]
    public class TrianyRepositoryTest
    {
        [TestFixture]
        private class 初期状態
        {
            private TrianyRepository _sut;
            private string _printBuffer;

            [SetUp]
            public void Setup()
            {
                _sut = new TrianyRepository();
                _printBuffer = string.Empty;
            }

            [TestCase]
            public void ルートトリアニーのIDを取得する()
            {
                _sut.GetRootTorianyId().Is(1);
            }

            [TestCase]
            public void ルートトリアニーのAに値が設定する()
            {
                var rootID = _sut.GetRootTorianyId();

                _sut.SetA(rootID, 10);
                _sut.GetA(rootID).Is(10);
            }

            [TestCase]
            public void ルートトリアニーのBに値が設定する()
            {
                var rootID = _sut.GetRootTorianyId();

                _sut.SetB(rootID, 10);
                _sut.GetB(rootID).Is(10);
            }

            [TestCase]
            public void ルートトリアニーのCに値が設定する()
            {
                var rootID = _sut.GetRootTorianyId();

                _sut.SetC(rootID, 10);
                _sut.GetC(rootID).Is(10);
            }

            [TestCase]
            public void まだ割り当てられていないトリアニーにアクセスするとマイナス１が返る()
            {
                _sut.GetA(100).Is(-1);
                _sut.GetB(100).Is(-1);
                _sut.GetC(100).Is(-1);
            }

            [TestCase]
            public void サンプルコードを実行できる()
            {
                int x = root_triany();
                int y = allocate_triany(); // y の値を仮に 8 とする
                int z = allocate_triany(); // z の値を仮に 4 とする

                set_a(x, 31);
                set_b(x, 41);
                set_c(x, y);

                _sut.ToString(x).Is(string.Format("{0}:[31,41,{1}]", x, y));

                set_a(y, 59);
                set_b(y, 26);
                set_c(y, z);

                _sut.ToString(y).Is(string.Format("{0}:[59,26,{1}]", y, z));

                set_a(z, 53);
                set_b(z, 58);
                set_c(z, 0);

                _sut.ToString(z).Is(string.Format("{0}:[53,58,0]", z));

                int t = root_triany();
                while (t != 0)
                {
                    int a = get_a(t);
                    int b = get_b(t);
                    printf("{0},", a);
                    printf("{0},", b);
                    t = get_c(t);
                }

                _printBuffer.Is("31,41,59,26,53,58,");
            }

            private void printf(string format, params object[] val)
            {
                _printBuffer += string.Format(format, val);
            }

            private int get_a(int id)
            {
                return _sut.GetA(id);
            }

            private int get_b(int id)
            {
                return _sut.GetB(id);
            }

            private int get_c(int id)
            {
                return _sut.GetC(id);
            }

            private void set_a(int id, int val)
            {
                _sut.SetA(id,val);
            }

            private void set_b(int id, int val)
            {
                _sut.SetB(id, val);
            }

            private void set_c(int id, int val)
            {
                _sut.SetC(id, val);
            }

            private int allocate_triany()
            {
                return _sut.AllocateTriany();
            }

            private int root_triany()
            {
                return _sut.GetRootTorianyId();
            }
        }

        [TestFixture]
        private class 一つメモリがアロケートされた状態
        {
            private TrianyRepository _sut;
            private int _allocatedId;

            [SetUp]
            public void SetUp()
            {
                _sut = new TrianyRepository();
                _allocatedId = _sut.AllocateTriany();
            }

            [TestCase]
            public void トリアニーを割り当てたIDの値が0ではない()
            {
                _sut.GetA(_allocatedId).IsNot(-1);
            }


            [TestCase]
            public void 割り当てたトリアニーのAに値が設定する()
            {
                _sut.SetA(_allocatedId, 10);
                _sut.GetA(_allocatedId).Is(10);
            }

            [TestCase]
            public void 割り当てたトリアニーのBに値が設定する()
            {
                _sut.SetB(_allocatedId, 10);
                _sut.GetB(_allocatedId).Is(10);
            }

            [TestCase]
            public void 割り当てたトリアニーのCに値が設定する()
            {
                _sut.SetC(_allocatedId, 10);
                _sut.GetC(_allocatedId).Is(10);
            }

            [TestCase]
            public void 割り当てたトリアニーを文字列として取得する()
            {
                _sut.SetA(_allocatedId, 3);
                _sut.SetB(_allocatedId, 4);
                _sut.SetC(_allocatedId, 5);

                _sut.ToString(_allocatedId).Is(string.Format("{0}:[3,4,5]", _allocatedId));
            }
        }
    }
}