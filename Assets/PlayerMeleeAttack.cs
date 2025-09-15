using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public float cooldownTime = 0.2f;
    float currentCooldownTimer;
    Collider2D collider;
   // PlayerController playerController;
    
    public float attackRange = 1f; // 扇形的半径
    public float attackAngle = 90f; // 扇形的开口角度

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       // playerController = GetComponentInParent<PlayerController>();
        collider = GetComponent<Collider2D>();
        animator = GetComponent<PlayerHP>().animator;
    }

    // public void setactive(bool isActive)
    // {
    //     collider.enabled = isActive;
    // }
    // private void OnCollisionStay2D(Collision2D collision)
    // {
    //     if (collision.collider.GetComponent<EnemyController>() )
    //     {
    //         if (currentCooldownTimer < cooldownTime)
    //         {
    //             return;
    //         }
    //         currentCooldownTimer = 0;
    //         
    //         
    //         
    //         collision.collider.GetComponent<EnemyController>().getDamage();
    //
    //         playerController.attackAnim();
    //         AudioManager.Instance.playPlayerAttack();
    //         
    //     }
    //
    // }

    public void Attack()
    {
        
        SFXManager.Instance.PlaySFX("playerattacked");
        currentCooldownTimer = 0;

        //playerController.attackAnim();
        var movement = GetComponent<PlayerMove>().movement;
        var facing = GetComponent<PlayerMove>().facing;

        
        animator.SetBool("attack", true);
        animator.SetFloat("attackHorizontal", movement.x);

        animator.SetFloat("attackVertical", 0);
        
        
        AudioManager.Instance.playPlayerAttack();
        
        //check a fan shape in front of player and see if there is enemy in the fan shape
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);
        List<GameObject> enemiesInAttackRange = new List<GameObject>();

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Enemy")) // 检查标签是否为“Enemy”
            {
                Vector3 directionToTarget = (hitCollider.transform.position - transform.position).normalized;
                float angleToTarget = Vector3.Angle(facing, directionToTarget);

                if (angleToTarget < attackAngle / 2) // 检查是否在扇形区域内
                {
                    enemiesInAttackRange.Add(hitCollider.gameObject);
                }
            }
        }

        // 对扇形区域内的每个敌人执行攻击
        foreach (GameObject enemy in enemiesInAttackRange)
        {
            Debug.Log("Attacking enemy: " + enemy.name);
            enemy.GetComponent<EnemyController>().getDamage();
            // 在这里添加攻击逻辑，比如减少敌人的生命值等
        }
        
        
    }

    IEnumerator stopAttack()
    {
        yield return new WaitForSeconds(0.2f);
        
        animator.SetBool("attack", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
    // Update is called once per frame
    void Update()
    {

        currentCooldownTimer += Time.deltaTime;
        if (currentCooldownTimer >=  cooldownTime)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
              //  Attack();
            }
        }
    }
}
