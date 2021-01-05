using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemGUI : MonoBehaviour
{
    public bool isClickable = true;

    private InventoryItem item;
    private InventoryGUI initiator;

    private void Start()
    {
        
    }

    public void Initialize(InventoryItem item, InventoryGUI initiator)
    {
        this.initiator = initiator;
        this.item = item;

        var sprRendrerer = GetComponent<SpriteRenderer>();
        sprRendrerer.sprite = item.sprite;

    }

    private void OnMouseDown()
    {
        if (!isClickable)
            return;
        initiator.FocusItem(item);
        Debug.Log("MOUSE CLICKED");
    }

    


}
