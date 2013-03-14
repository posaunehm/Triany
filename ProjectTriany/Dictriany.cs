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

            var currentId = _rootId;

            while (currentId != 0)
            {
                if (get_a(currentId) == key)
                {
                    break;
                }

                currentId = get_c(currentId);
            }

            if (currentId == 0)
            {
                return 0;
            }
            else
            {
                return get_b(currentId);
            }
        }

        public void SetEntry(int key, int value)
        {
            if (key <= 0) return;

            var currentId = _rootId;
            int preId = _rootId;

            while (currentId != 0)
            {
                var currentKey = get_a(currentId);
                if (currentKey == key) { break; }
                preId = currentId;
                currentId = get_c(currentId);
            }

            if (currentId == 0)
            {
                var newId = allocate_triany();
                set_c(preId, newId);
                set_a(newId, key);
                set_b(newId, value);
            }
            else
            {
                set_b(currentId, value);
            }
        }

        private int allocate_triany()
        {
            return _trianyRepository.AllocateTriany();
        }

        private void set_a(int id, int value)
        {
            _trianyRepository.SetA(id, value);
        }

        private int root_triany()
        {
            return _trianyRepository.GetRootTorianyId();
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