using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BugBook : MonoBehaviour
{
    BugBookCell[] cells;
    public Button button;

    public Transform cellsParent;
    public GameObject menu;

    public List<int> selectedBugs = new List<int>();
    
    
    public Image image;
    public TMP_Text deatilTitle;
    public TMP_Text deatilDesc;
    public TMP_Text deatilHint;
    public TMP_Text deatilReason;

    public void Show()
    {
        menu.SetActive(true);
        for (int i = 0; i < CSVLoader.Instance.bugs.Count; i++)
        {
            cells[i].Init(i);
        }
        for (int i =  CSVLoader.Instance.bugs.Count; i < cells.Length; i++)
        {
            cells[i].gameObject.SetActive(false);
        }
        
    }
    public void Hide()
    {
        menu.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        cells = cellsParent.GetComponentsInChildren<BugBookCell>(true);
        button.onClick.AddListener(() =>
        {
            if (menu.activeSelf)
            {
                Hide();
            }
            else
            {
                Show();
            
            }
        });
        
        for (int i = 0; i < CSVLoader.Instance.bugs.Count; i++)
        {
            var tempi = i;
            cells[i].GetComponent<Button>().onClick.AddListener(() =>
            {
                UpdateDetailMenu(tempi);
            });
            
            cells[i].bugButton.onClick.AddListener(() =>
            {
                if (selectedBugs.Contains(tempi))
                {
                    BugManager.Instance.GetBugFixedAgain(i);
                    cells[i].bugButtonSelected .SetActive(false);
                    selectedBugs.Remove(tempi);
                }
                else
                {
                    if (selectedBugs.Count >= 3)
                    {
                        FindObjectOfType<PopupMenu>().Show("You can only use 3 bugs");
                    }
                    else
                    {
                        BugManager.Instance.GetBugBack(i);
                        cells[i].bugButtonSelected.SetActive(true);
                        selectedBugs.Add(tempi);
                    }
                }
            });
        }
        UpdateDetailMenu(0);
        Hide();
    }

    void UpdateDetailMenu(int i)
    {
        if (BugManager.Instance.fixedBugs[i] == BugStatus.BugFixed)
        {
            
            deatilTitle.text = CSVLoader.Instance.bugs[i].Title;
            deatilDesc.text = CSVLoader.Instance.bugs[i].Desc;
            deatilHint.text = "How to Repro: "+CSVLoader.Instance.bugs[i].Hint;
            deatilReason.text = "Root Reason: "+CSVLoader.Instance.bugs[i].Reason;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
