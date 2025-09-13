using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyaerBullet : MonoBehaviour
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
        if (collision.collider.GetComponent<EnemyController>())
        {
            collision.collider.GetComponent<EnemyController>().getDamage();
            isHitPlayer = true;
            if (BugManager.Instance.fixedBugs[10] == BugStatus.BugFixed)
            {
                Destroy(gameObject);
            }
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
            if (collision.GetComponent<EnemyController>())
            {
                if (BugManager.Instance.fixedBugs[10] == BugStatus.BugDefault)
                {
                    BugManager.Instance.fixedBugs[10] = BugStatus.BugTriggered;
                }
                collision.GetComponent<EnemyController>().getDamage();
            }

            if (collision.GetComponentInParent<EnemyController>())
            {
                if (BugManager.Instance.fixedBugs[10] == BugStatus.BugDefault)
                {
                    BugManager.Instance.fixedBugs[10] = BugStatus.BugTriggered;
                }
                collision.GetComponentInParent<EnemyController>().getDamage();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyController>())
        {
            collision.GetComponent<EnemyController>().getDamage();
            isHitPlayer = true;
            if (BugManager.Instance.fixedBugs[10] == BugStatus.BugFixed)
            {
                Destroy(gameObject);
            }
        }
        else if (collision. GetComponentInParent<EnemyController>())
        {
            collision.GetComponentInParent<EnemyController>().getDamage();
            isHitPlayer = true;
            if (BugManager.Instance.fixedBugs[10] == BugStatus.BugFixed)
            {
                Destroy(gameObject);
            }
        }
    }
}
