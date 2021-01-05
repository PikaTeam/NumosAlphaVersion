using System;
using UnityEngine;

public class ExampleInventoryItem : InventoryItem
{
    public ExampleInventoryItem(Sprite sprite)
        : base(sprite, 1, 1, "Example Item", "Description of item")
    {
        
    }

}

