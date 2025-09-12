using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryUI;
    public Transform content;
    InventoryCell[] cells;
    // Start is called before the first frame update
    void Awake()
    {
        cells = GetComponentsInChildren<InventoryCell>();
        foreach(var cell in cells)
        {
            cell.gameObject.SetActive(false);
        }

        inventoryUI.gameObject.SetActive(false);
        EventPool.OptIn("inventoryChanged", onUpdateInventory);
    }

    void onUpdateInventory()
    {
        inventoryUI.gameObject.SetActive(true);
        int i=0;
        for (;i<Mathf.Min( Inventory.Instance.itemList.Count, cells.Length); i++)
        {
            cells[i].gameObject.SetActive(true);
            cells[i].init(i, Inventory.Instance.itemList[i]);
        }
        for (; i < cells.Length; i++)
        {
            cells[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
