using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemFocusPanel : MonoBehaviour
{

    public TextMeshProUGUI textBox;
    public SpriteRenderer spriteSlot;

    private InventoryGUI initiator;
    private InventoryItem item;

    public void Initialize(InventoryItem item, InventoryGUI initiator)
    {
        this.initiator = initiator;
        this.item = item;
        this.spriteSlot.sprite = item.sprite;
        this.textBox.text = item.description;

        gameObject.SetActive(true);
    }

    public void Close()
    {
        Debug.Log("Closed focus");
        initiator.UnFocusItem();
        gameObject.SetActive(false);

    }
}
