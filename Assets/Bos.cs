using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject invincible;
    public void SetInvincible()
    {
        invincible .SetActive(true);
        GetComponent<EnemyController>().isInvincible = true;
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
