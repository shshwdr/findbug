using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugBook : MonoBehaviour
{
    BugBookCell[] cells;
    public Button button;

    public Transform cellsParent;
    public GameObject menu;

    public void Show()
    {
        menu.SetActive(true);
        for (int i = 0; i < BugManager.Instance.bugsDesc.Count; i++)
        {
            cells[i].Init(i);
        }
        for (int i = BugManager.Instance.bugsDesc.Count; i < cells.Length; i++)
        {
            cells[i].gameObject.SetActive(false);
        }
        
    }
    public void Hide()
    {
        menu.SetActive(false);
    }
    // Start is called before the first frame update
    void Awake()
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
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
