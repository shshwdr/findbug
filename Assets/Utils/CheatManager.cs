using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : Singleton<CheatManager>
{
    public bool hasUnlimitResource;
    public bool isCheating = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            hasUnlimitResource = !hasUnlimitResource;
        }

        for(int i = 0; i <= 9; i++)
        {
            if (Input.GetKey(KeyCode.C) && Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                BugManager.Instance.finishFixBug(i);
            }
        }
    }
}
