using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BugBookCell : MonoBehaviour
{
    public TMP_Text text;

    public int id;
    public Button bugButton;
    public GameObject bugButtonSelected;

    public void Init(int id)
    {
        this.id = id;
        text.text =(int) BugManager.Instance.fixedBugs[id] >= (int)BugStatus.BugFixed? CSVLoader.Instance.bugs[id].Title:"???";

        if ((int)GameManager.Instance.gameState >= (int)GameState.TalkedToGhost)
        {
            bugButton.gameObject.SetActive(true);
        }
        else
        {
            bugButton.gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
