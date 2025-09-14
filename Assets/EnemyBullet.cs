using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public bool ignoreOtherCollider = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool isHitPlayer = false;
    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<PlayerHP>())
        {
            collision.collider.GetComponent<PlayerHP>().getDamage();
            isHitPlayer = true;
            if (BugManager.Instance.fixedBugs[10] == BugStatus.BugFixed)
            {
                Destroy(gameObject);
            }
            return;
        }
        else if (ignoreOtherCollider)
        {
            return;
        }
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // if (BugManager.Instance.fixedBugs[10])
        // {
        //     
        // }
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (BugManager.Instance.fixedBugs[10] != BugStatus.BugFixed)
        {
            if (collision.GetComponent<PlayerHP>())
            {
                if (BugManager.Instance.fixedBugs[10] == BugStatus.BugDefault)
                {
                    BugManager.Instance.fixedBugs[10] = BugStatus.BugTriggered;
                }
                collision.GetComponent<PlayerHP>().getDamage();
            }

            if (collision.GetComponentInParent<PlayerHP>())
            {
                if (BugManager.Instance.fixedBugs[10] == BugStatus.BugDefault)
                {
                    BugManager.Instance.fixedBugs[10] = BugStatus.BugTriggered;
                }
                collision.GetComponentInParent<PlayerHP>().getDamage();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHP>())
        {
            collision.GetComponent<PlayerHP>().getDamage();
            isHitPlayer = true;
            if (BugManager.Instance.fixedBugs[10] == BugStatus.BugFixed)
            {
                Destroy(gameObject);
            }
        }
        else if (collision. GetComponentInParent<PlayerHP>())
        {
            collision.GetComponentInParent<PlayerHP>().getDamage();
            isHitPlayer = true;
            if (BugManager.Instance.fixedBugs[10] == BugStatus.BugFixed)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            
            Destroy(gameObject);
        }
    }
}
