﻿using System.Collections.Generic;
using System.Linq;

namespace ProjectTriany
{
public class TrianyRepository
{
    private const int ROOT_ID = 1;
    private readonly Dictionary<int, Triany> TrianyStore = new Dictionary<int, Triany>();

    public TrianyRepository()
    {
        TrianyStore.Add(ROOT_ID, new Triany());
    }

    public int GetRootTorianyId()
    {
        return ROOT_ID;
    }

    public void SetA(int id, int value)
    {
        TrianyStore[id].A = value;
    }

    public int GetA(int id)
    {
        return TrianyStore.ContainsKey(id) ? TrianyStore[id].A : -1;
    }

    public void SetB(int id, int value)
    {
        TrianyStore[id].B = value;
    }

    public int GetB(int id)
    {
        return TrianyStore.ContainsKey(id) ? TrianyStore[id].B : -1;
    }

    public void SetC(int id, int value)
    {
        TrianyStore[id].C = value;
    }

    public int GetC(int id)
    {
        return TrianyStore.ContainsKey(id) ? TrianyStore[id].C : -1;
    }

    public int AllocateTriany()
    {
        var newId = Enumerable.Range(1, int.MaxValue).First(i => !TrianyStore.ContainsKey(i));
        TrianyStore.Add(newId, new Triany());

        return newId;
    }

    public string ToString(int id)
    {
        var triany = TrianyStore[id];
        return string.Format("{0}:{1}", id, triany);
    }
}
}