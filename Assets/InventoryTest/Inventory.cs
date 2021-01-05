using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    public readonly int capacity;
    private readonly List<InventoryItem> items;

    public Inventory(int capacity)
    {
        this.capacity = capacity;
        this.items = new List<InventoryItem>();
    }

    public InventoryItem this[int index]
    {
        get => items[index];
    }

    public void Remove(InventoryItem item)
    {
        this.items.Remove(item);
    }

    public void Add(InventoryItem item)
    {
        if(items.Count < capacity)
            this.items.Add(item);
    }

    public int Count()
    {
        return this.items.Count;
    }

}
