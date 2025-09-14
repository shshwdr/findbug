using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitToDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHP>())
        {
            SFXManager.Instance.PlaySFX("roarbite");
            collision.GetComponent<PlayerHP>().getDamage();
        }
        else if (collision. GetComponentInParent<PlayerHP>())
        {
            SFXManager.Instance.PlaySFX("roarbite");
            collision.GetComponentInParent<PlayerHP>().getDamage();
        }
    }
    
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (BugManager.Instance.fixedBugs[10] != BugStatus.BugFixed)
        {
            
            if (collision.GetComponent<PlayerHP>())
            {
                collision.GetComponent<PlayerHP>().getDamage();
            }

            if (collision.GetComponentInParent<PlayerHP>())
            {
                collision.GetComponentInParent<PlayerHP>().getDamage();
            }
        }
    }

}
