using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    public Image image;
    public TMP_Text indexLabel;
    public TMP_Text usageLabel;
    public Button button;
    int index;
    Dictionary<string, string> nameToUsage = new Dictionary<string, string>()
    {
        {"apple","Space to Eat" },
        {"sword","Space To Equip" }
    };
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(delegate { onClick(); });
    }

    void onClick()
    {
        if (GameManager.Instance.isInFindBugMode)
        {
            if (BugManager.Instance.fixedBugs[6] == BugStatus.BugDefault && index>=Inventory.Instance.maxCount)
            {
                string dialogname = "tooManyInventory";
                DialogueManager.StartConversation(dialogname, null, null);
                BugManager.Instance.fixBug(6);
                return;
            }
            if (BugManager.Instance.fixedBugs[5] == BugStatus.BugDefault && name == "sword")
            {
                int swordCount = 0;
                foreach (var item in Inventory.Instance.itemList)
                {
                    if(item == "sword")
                    {
                        swordCount++;
                    }
                }
                if(swordCount > 1)
                {
                    string dialogname = "chestMultiTime";
                    DialogueManager.StartConversation(dialogname, null, null);
                    BugManager.Instance.fixBug(5);
                    return;
                }
            }
            
            DialogueManager.StartConversation("inventory", null, null);
        }
    }

    public void init(int ind,string na)
    {
        name = na;
        index = ind;
        indexLabel.text = (index+1).ToString();
        image.sprite = Resources.Load<Sprite>("item/"+name);
        if (!nameToUsage.ContainsKey(name))
        {
            Debug.LogError("no name to usage for " + name);
        }
        usageLabel.text = nameToUsage[name];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("mouse down");
    }
}
