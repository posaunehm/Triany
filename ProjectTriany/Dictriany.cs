using System;

namespace ProjectTriany
{
    public class Dictriany
    {
        private TrianyRepository _trianyRepository = new TrianyRepository();
        private int _rootId;

        public Dictriany()
        {
            _rootId = root_triany();
        }

        public int FindEntry(int key)
        {
            if (key <= 0) return 0;

            var currentId = SearchKey(key, _rootId);

            return currentId == 0 ? 0 : get_b(currentId);
        }

        public void SetEntry(int key, int value)
        {
            if (key <= 0) return;

            var currentId = SearchKey(key, _rootId,
                                  id =>
                                  {
                                      var newId = allocate_triany();
                                      set_c(id, newId);
                                      set_a(newId, key);
                                      set_b(newId, value);
                                  });

            if (currentId != 0)
            {
                set_b(currentId, value);
            }
        }

        private int SearchKey(int key, int startId, Action<int> keyNotFoundAction = null)
        {
            while (startId != 0)
            {
                var currentKey = get_a(startId);
                if (currentKey == key) { break; }

                if (get_c(startId) == 0 && keyNotFoundAction != null)
                {
                    keyNotFoundAction(startId);
                }

                startId = get_c(startId);
            }
            return startId;
        }

        private int root_triany()
        {
            return _trianyRepository.GetRootTorianyId();
        }

        private int allocate_triany()
        {
            return _trianyRepository.AllocateTriany();
        }

        private void set_a(int id, int value)
        {
            _trianyRepository.SetA(id, value);
        }

        private void set_b(int id, int value)
        {
            _trianyRepository.SetB(id, value);
        }

        private void set_c(int id, int value)
        {
            _trianyRepository.SetC(id, value);
        }

        private int get_a(int id)
        {
            return _trianyRepository.GetA(id);
        }

        private int get_b(int id)
        {
            return _trianyRepository.GetB(id);
        }

        private int get_c(int id)
        {
            return _trianyRepository.GetC(id);
        }
    }
}