using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryGUI : MonoBehaviour
{
    public int rows = 3;
    public int columns = 2;
    public GameObject inventoryCell;
    public InventoryItemGUI inventoryItemGUI;
    public GameObject inventoryCellItemText;
    public Grid grid;
    public ItemFocusPanel itemFocusPanel;

    // temp
    public SpriteRenderer[] itemObj;

    private Inventory inventory;
    private List<GameObject> cells;
    private List<TextMeshProUGUI> itemTexts;
    

    // Start is called before the first frame update
    void Start()
    {
        // for testing purposes
        inventory = new Inventory(5);
        foreach(var item in itemObj)
        {
            var inventoryItem = new ExampleInventoryItem(item.sprite);
            inventory.Add(inventoryItem);
        }

        cells = new List<GameObject>();
        CreateCells();
        PopulateCells();
        itemFocusPanel.gameObject.SetActive(false);

        //FocusItem(inventory[0]);

    }

    void CreateCells()
    {
        cells.Clear();

        for (int r=0; r<rows; ++r)
        {
            for(int c=0; c<columns; ++c)
            {
                if ((r * columns) + c >= inventory.capacity)
                    return;

                Vector3Int cellGridPosition = new Vector3Int(c, -r, 0);
                Vector3 cellWorldPosition = grid.GetCellCenterWorld(cellGridPosition);
                GameObject instantiatedInventoryCell =  Instantiate(inventoryCell, cellWorldPosition, new Quaternion(), grid.transform);
                ResizeCellSpriteToFit(instantiatedInventoryCell, 1);

                cells.Add(instantiatedInventoryCell);

              
            }
            
        }
    }

    private void Update()
    {
        transform.position = (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, +10)));

    }



    void PopulateCells()
    {
        
        for(int i=0;i<inventory.Count();++i)
        {
            var item = inventory[i];
            var cell = cells[i];


            GameObject instantiatedInventoryItemGUI = Instantiate(inventoryItemGUI.gameObject, cell.transform, false);
            instantiatedInventoryItemGUI.transform.position = instantiatedInventoryItemGUI.transform.position + Vector3.up * 0.2f;
            instantiatedInventoryItemGUI.GetComponent<InventoryItemGUI>().Initialize(item, this);

            //this is mange the pic size
            ResizeSpriteToFit(instantiatedInventoryItemGUI, 0.5f);
            
            GameObject instantiatedInventoryItemText = Instantiate(inventoryCellItemText ,cell.transform, false);
            instantiatedInventoryItemText.transform.localPosition += Vector3.down * grid.cellSize.y * 1f;
            instantiatedInventoryItemText.GetComponentInChildren<TextMeshProUGUI>().text = item.shortDescription;
        }
    }

    void ResizeCellSpriteToFit(GameObject instantiatedCell, float scale)
    {
        Vector3 spriteSize = instantiatedCell.GetComponent<SpriteRenderer>().bounds.size;
        Vector3 gridCellSize = this.grid.cellSize;
        float temp = transform.localScale.x;
        

        instantiatedCell.transform.localScale = temp *scale * new Vector3(
                                                            gridCellSize.x / spriteSize.x,
                                                            gridCellSize.y / spriteSize.y,
                                                            spriteSize.z
                                                           );

    }

    void ResizeSpriteToFit(GameObject instantiatedCell, float scale)
    {
        Vector3 spriteSize = instantiatedCell.GetComponent<SpriteRenderer>().bounds.size;
        float maxLengthWidth = Mathf.Max(spriteSize.x, spriteSize.y);
        Vector3 gridCellSize = this.grid.cellSize;
        float temp = transform.localScale.x;

        instantiatedCell.transform.localScale = temp *scale * new Vector3(
                                                            gridCellSize.x / maxLengthWidth,
                                                            gridCellSize.y / maxLengthWidth,
                                                            spriteSize.z
                                                           );

    }


    public void FocusItem(InventoryItem item)
    {
        grid.gameObject.SetActive(false);
        itemFocusPanel.Initialize(item, this);
    }

    public void UnFocusItem()
    {
        grid.gameObject.SetActive(true);
    }

    public void Close()
    {
        Debug.Log("Closing inventory");
        Destroy(gameObject);
    }
}
