using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            SFXManager.Instance.PlayClick();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
