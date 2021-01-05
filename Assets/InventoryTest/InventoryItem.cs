using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem 
{
    public readonly Sprite sprite;
    public int quantity = 1;
    public readonly int capacity = 1;
    public readonly string description;
    public readonly string shortDescription;

    public InventoryItem(Sprite sprite, int quantity, int capacity, string shortDescription, string description) 
    {
        this.sprite = sprite;
        this.quantity = quantity;
        this.capacity = capacity;
        this.description = description;
        this.shortDescription = shortDescription;
    }
}
