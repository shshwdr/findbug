using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HPsHandler : MonoBehaviour
{
    public List<OneHP> hps;
    public Button button;
    void Start()
    {
        foreach (var hp in hps)
        {
            hp.setValue(2);
        }

        if (button)
        {
            button.onClick.AddListener(delegate { onClick(); });
        }
    }

    void onClick()
    {
        if (GameManager.Instance.isInFindBugMode)
        {
            if (BugManager.Instance.fixedBugs[8] == BugStatus.BugDefault && GameManager.Instance.player.GetComponent<PlayerHP>().currentHP>6)
            {
                string dialogname = "tooMuchHP";
                DialogueManager.StartConversation(dialogname, null, null);
                BugManager.Instance.fixBug(8);
                return;
            }
            if (BugManager.Instance.fixedBugs[9] == BugStatus.BugDefault && GameManager.Instance.player.GetComponent<PlayerHP>().currentHP<0)
            {
                
                string dialogname = "killedButStillAlive";
                BugManager.Instance.fixBug(9);
                DialogueManager.StartConversation(dialogname, null, null);
                
                return;
            }
            
            DialogueManager.StartConversation("playerHpBar", null, null);
            
        }
    }
    public void SetHP(int value)
    {
        int index = 0;
        foreach (var hp in hps)
        {
            hp.setValue(0);
        }

        if (BugManager.Instance.fixedBugs[8] == BugStatus.BugFixed)
        {
            for (int i = 3; i < hps.Count; i++)
            {
                hps[i].gameObject.SetActive(false);
            }
        }
        while (value > 0)
        {
            int tempValue = math.min(value, 2);
            value -= tempValue;

            if (index < hps.Count)
            {
                hps[index].setValue(tempValue);
            }
            else
            {
                var newHP = Instantiate(hps[0], hps[0].transform.parent);
                hps.Add(newHP);
                newHP.setValue(tempValue);
            }
            
            index++;
        }
    }
}
