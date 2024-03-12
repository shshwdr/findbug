using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneHP : MonoBehaviour
{

    public Image full;
    public Image half;
    private int value;

    public void setValue(int value)
    {
        half.gameObject.SetActive(false);
        full.gameObject.SetActive(false);
        if (value == 2)
        {
            full.gameObject.SetActive(true);
        }else if( value == 1)
        {
            half.gameObject.SetActive(true);
        }
    }
}
