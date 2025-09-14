using System;
using LitJson;
using PixelCrushers.DialogueSystem;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBase
{
    public string name;
    public string displayName;
    public string description;
}
public class ItemInfo: InfoBase
{
    public int amount;
    public int startValue;
}
public class AllItemInfo
{
    public List<ItemInfo> resources;
    public List<ItemInfo> tool; 
}
public class Inventory : Singleton<Inventory>
{
    //public Dictionary<string, ItemInfo> itemDict = new Dictionary<string, ItemInfo>();
    public List<string> itemList = new List<string>();
    public int inventoryUnlockedCellCount = 5;
    public int selectedItemIndex;
    public bool startInventory;
    public int maxCount = 6;
    public bool checkMaxCount = false;
    //bool canUseItemOutRange = true;
    private BugablePlayer player;
    public bool canAddItem(string itemName, int value = 1)
    {
        return true;
        //if (itemValueDict.ContainsKey(itemName))
        //{
        //    return true;
        //}
        //if (itemValueDict.Count < inventoryUnlockedCellCount)
        //{
        //    return true;
        //}
        //return false;
    }


    //public void updateSelectedItem(string name)
    //{
    //    selectedItemName = name;

    //    DialogueLua.SetVariable("holdingItem", name);
    //}

    //public void sendGift()
    //{
    //    if (selectedItemName == "")
    //    {
    //        Debug.LogError("you send what a you send");
    //        return;
    //    }
    //    //sometimes should not be able to send
    //    consumeItem(selectedItemName, 1);

    //    selectedItemName = "";

    //    EventPool.Trigger("inventoryChanged");
    //}

    public void select(int index)
    {
        selectedItemIndex= index;
        EventPool.Trigger("inventoryChanged");
    }

    //public void addItem(string itemName)
    //{
    //    addItem(itemName, 1);
    //}
    public void addItem(string itemName)
    {
        SFXManager.Instance.PlaySFX("openchest");
        if (checkMaxCount && itemList.Count >= maxCount)
        {
            DialogueManager.ShowAlert("Your bag is full");
            return;
        }
        startInventory = true;
        itemList.Add(itemName);

        EventPool.Trigger("inventoryChanged");
    }

    void OnBugFixed(int id)
    {
        if (id == 5)
        {
            itemList = Utils.removeDuplicationOfItem(itemList, "sword");
            EventPool.Trigger("inventoryChanged");
            return;
        }
        if (id == 6)
        {
            checkMaxCount = true;

            bool hasSword = false;
            bool hasSwordInFirstItems = false;
            int swordId = -1;
            for(int i  = 0;i<itemList.Count;i++)
            {
                var item = itemList[i];
                if (item == "sword")
                {
                    hasSword=true;
                    if (i < maxCount)
                    {
                        hasSwordInFirstItems = true;
                        swordId = i;
                    }
                }
            }
            if (hasSword && !hasSwordInFirstItems)
            {
                var t = itemList[0];
                itemList[0] = itemList[swordId];
                itemList[swordId] = t;
            }

            itemList.RemoveRange(maxCount, itemList.Count - maxCount);
            EventPool.Trigger("inventoryChanged");
            return;
        }

    }
    public void consumeItem(int index)
    {
        
        if(index>= itemList.Count)
        {
            if (BugManager.Instance.fixedBugs[7] == BugStatus.BugFixed)
            {
                return;
                
            }
            else
            {
                BugManager.Instance.fixBug(7);
                ErrorPopup.Instance.ShowError("ArgumentOutOfRangeException: Index was out of range. ");
                CSDialogManager.Instance.StartConversation("useItemNotExisted");
                return;
            }
        }

        var itemName = itemList[index];
        Debug.Log("use " + itemName);
        switch (itemName) {
            case "sword":
                FindObjectOfType<PlayerMeleeAttack>().Attack();
                
                break;
            case "stoneGenerator": 
                FindObjectOfType<PlayerRangeAttack>().Attack();
                break;
            case "apple":

                itemList.RemoveAt(index);
                player.GetComponent<PlayerHP>().AddHP(1);
                break;
            default:
                Debug.LogError("try to use " + itemName + " that does not have code for it");
                break;
        }


        //if(!itemDict.ContainsKey(itemName) || itemDict[itemName].amount < value)
        //{
        //    if (CheatManager.Instance.hasUnlimitResource)
        //    {
        //        return;
        //    }
        //    Debug.LogError("not enough item to consume");
        //    return;
        //}
        //itemDict[itemName].amount -= value;

        //if (itemValueDict[itemName] <= 0)
        //{
        //    itemValueDict.Remove(itemName);
        //}
        EventPool.Trigger("inventoryChanged");
    }


    //public int itemAmount(string itemName)
    //{
    //    return itemDict.ContainsKey(itemName) ? itemDict[itemName].amount : 0;
    //}
    //public bool hasItemAmount(string itemName,int amount)
    //{
    //    if (CheatManager.Instance.hasUnlimitResource)
    //    {
    //        return true;
    //    }
    //    return itemDict.ContainsKey(itemName) && itemDict[itemName].amount >= amount;
    //}
    //public bool hasItem(string itemName)
    //{
    //    return hasItemAmount(itemName, 1);
    //}
    // Start is called before the first frame update
    void Awake()
    {
        //string text = Resources.Load<TextAsset>("json/Inventory").text;
        //var allNPCs = JsonMapper.ToObject<AllItemInfo>(text);
        //foreach (ItemInfo info in allNPCs.resources)
        //{
        //    itemDict[info.name] = info;
        //    info.amount = info.startValue;
        //}


        EventPool.OptIn<int>(EventPool.bugFixed, OnBugFixed);
        EventPool.OptIn<int>(EventPool.bugBack, OnBugBack);
    }
    void OnBugBack(int id)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startInventory)
        {

            for (int i = 1; i <= 7; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha0 + i))
                {
                    consumeItem(i - 1);
                }
            }
        }
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    foreach(var key in itemDict.Keys)
        //    {
        //        //if (!itemDict[key].noItemCollected)
        //        {
        //            itemDict[key].amount += 1;
        //        }
        //    }
        //}
    }

    private void Start()
    {
        player = GameObject.FindObjectOfType<BugablePlayer>();
    }
}
