using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BugBookCell : MonoBehaviour
{
    public TMP_Text text;

    public int id;

    public void Init(int id)
    {
        this.id = id;
        text.text = BugManager.Instance.fixedBugs[id] == BugStatus.BugFixed? CSVLoader.Instance.bugs[id].Title:"???";
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
