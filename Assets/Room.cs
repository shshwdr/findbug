using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject destroyObj;

    public GameObject instantiateObj;

    public void GetIntoRoom()
    {
        if (destroyObj)
        {
            
            Destroy(destroyObj);
            var ob =Instantiate(instantiateObj,transform);
            destroyObj = ob;
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
