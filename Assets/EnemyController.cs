using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : HPCharacterController
{
    //NavMeshAgent agent;

    public string roomName;

    public GameObject mergedToMonster;
    

    public float invincibleSpeedScale = 0.3f;
    public float originSpeed= 0.3f;
    SpriteRenderer m_Renderer;
    protected EnemyController mergingOther;
    public Animator deathAnimator;

    float offMergeDistance = 0;

    //Rigidbody2D rb;
    // Start is called before the first frame update
    protected  void Start()
    {

        //rb = GetComponent<Rigidbody2D>();
        //agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = false;
        //agent.updateUpAxis = false;
        

       // EnemyManager.instance.enemiesDictionary[enemyType].Add(this);
        //base.Start();

        animator = transform.Find("test").GetComponentInChildren<Animator>();
        spriteObject = animator.transform.parent.gameObject;
        //EnemyManager.instance.updateEnemies();
        //originSpeed = agent.speed;
        m_Renderer = animator. GetComponent<SpriteRenderer>();
        offMergeDistance = GetComponent<CircleCollider2D>().radius * 2f;

       
    }


    float getDistanceToTarget(Transform target)
    {
        //todo use navmesh distance instead of position distance
        return ((Vector2)transform.position - (Vector2)target.position).magnitude;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isDead || GameManager.Instance.player.isDead)
        {
            //agent.isStopped = true;
            return;
        }
        base.Update();
        if (isStuned)
        {
            //agent.isStopped = true;
            //agent.velocity = Vector3.zero;
            //return;
        }


        //move
        else
        {
            //find the cloest target, either player or enemy with same type and merge level
            float shortestDistance = 10000f;
            Transform shortestTarget = transform;
            bool foundTarget = false;
            if (m_Renderer.isVisible)
            {
               // agent.speed = originSpeed;
            }
            else
            {
                //agent.speed = originSpeed * invincibleSpeedScale;

                shortestTarget = transform;
                shortestDistance = float.MaxValue;
            }
            
            {
                //agent.isStopped = true;
            }
        }
        animator.SetFloat("speed", 1);

        if (roomName == GameManager.Instance.player.GetComponent<BugablePlayer>().roomName)
        {
            //var target = GameManager.Instance.player.transform.position;
           // transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * originSpeed);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (isBoss() && collision.GetComponent<PlayerController>())
        //{
        //    collision.GetComponent<PlayerController>().getDamage();
        //}
    }
    protected override void Die()
    {
        base.Die();
        animator.SetTrigger("die");
        //deathAnimator.enabled = true;
        Destroy(gameObject, 0.3f);
    }

}
