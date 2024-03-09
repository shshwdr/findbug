using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugableObject : MonoBehaviour
{
    public virtual bool DidTap()
    {
        Debug.Log("tap on " + gameObject.name);
        return false;
    }
}