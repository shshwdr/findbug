using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPCharacterController : MonoBehaviour
{
    public int maxHP = 6;

    public int currentHP = 6;
    public Animator animator;
    //HPBarHandler hpBar;
    protected HPsHandler hpBar;
    public  bool isDead;
    public  bool isStuned;

    public AudioClip[] beHitClips;

    public Rigidbody2D rb;

    public float stunTime = 0.3f;
    float currentStunTimer = 0;

    public bool hasInvinsibleTime;
    public float invinsibleTime = 0.3f;
    float currentInvinsibleTimer;
    public GameObject spriteObject;
    
    public bool isInvincible = false;
    // Start is called before the first frame update
    virtual protected void Awake()
    {

        hpBar = GetComponentInChildren<HPsHandler>();
        rb = GetComponent<Rigidbody2D>();
        if (hpBar)
        {
            hpBar.SetHP(currentHP);
        }
    }
    // Update is called once per frame
    virtual protected void Update()
    {
        if (isStuned)
        {
            currentStunTimer += Time.deltaTime;
            if (currentStunTimer >= stunTime)
            {
                isStuned = false;
            }
        }
        currentInvinsibleTimer += Time.deltaTime;
    }

    public virtual void updateHP()
    {

        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        hpBar.SetHP(currentHP);
    }
    virtual protected void playHurtSound()
    {

    }
    public virtual void getDamage(int damage = 1)
    {
        if (isDead)
        {
            return;
        }

        if (isInvincible)
        {
            return;
        }
        if(hasInvinsibleTime && currentInvinsibleTimer < invinsibleTime)
        {
            return;
        }
        currentInvinsibleTimer = 0;
        currentHP -= damage;
        playHurtSound();
        updateHP();
        if (currentHP == 0)
        {
            Die();
        }
        else
        {
            isStuned = true;
            currentStunTimer = 0;
            animator.SetTrigger("hit");
        }

    }

    protected virtual void Die()
    {
        isDead = true;
    }


    bool facingRight = true;
    void flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = spriteObject.transform.localScale;
        scaler.x = -scaler.x;
        // spriteObject.transform.position = new Vector3(spriteObject.transform.position.x + 1, spriteObject.transform.position.y, -1);
        spriteObject.transform.localScale = scaler;
        //spriteObject.GetComponent<SpriteRenderer>().flipX = !facingRight;
    }
    public void testFlip(Vector3 movement)
    {
        if (facingRight == false && movement.x > 0f)
        {
            flip();
        }
        if (facingRight == true && movement.x < 0f)
        {
            flip();
        }
    }
}
