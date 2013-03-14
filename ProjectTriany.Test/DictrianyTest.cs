using NUnit.Framework;

namespace ProjectTriany.Test
{
    [TestFixture]
    public class DictrianyTest
    {
        private Dictriany _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Dictriany();
        }

        [TestCase]
        public void 格納されていない値には0を返す()
        {
            _sut = new Dictriany();

            _sut.FindEntry(100).Is(0);
        }

        [TestCase]
        public void キーに0を設定して値を登録しても何も起こらない()
        {
            _sut.SetEntry(0, 100);
            _sut.FindEntry(100).Is(0);
        }

        [TestCase]
        public void キーに3を設定して値を登録すると保存されている()
        {
            _sut.SetEntry(3, 100);
            _sut.FindEntry(3).Is(100);
        }

        [TestCase]
        public void 二つのキーを登録するとそれぞれの値が取得できる()
        {
            _sut.SetEntry(3, 100);
            _sut.SetEntry(5, 200);

            _sut.FindEntry(3).Is(100);
            _sut.FindEntry(5).Is(200);
        }

        [TestCase]
        public void キーを上書きすると最新の値を取得する()
        {
            _sut.SetEntry(3, 100);
            _sut.SetEntry(5, 200);
            _sut.SetEntry(3, 50);
            _sut.SetEntry(5, 100);

            _sut.FindEntry(3).Is(50);
            _sut.FindEntry(5).Is(100);
        }

        [TestCase]
        public void サンプルコードを実行する()
        {
            int n;
            int sum = 0;

            set_entry(123, 1);
            set_entry(456, 2);
            set_entry(789, 3);

            n = find_entry(123);
            n.Is(1);
            sum += n;

            n = find_entry(999);
            n.Is(0);
            sum += n;

            n = find_entry(789);
            n.Is(3);
            sum += n;

            set_entry(456, 90);
            n = find_entry(456);
            n.Is(90);
            sum += n;

            set_entry(456, 6);
            n = find_entry(456);
            n.Is(6);
            sum += n;

            sum.Is(100);
        }

        private int find_entry(int key)
        {
            return _sut.FindEntry(key);
        }

        private void set_entry(int key, int value)
        {
            _sut.SetEntry(key, value);
        }
    }
}