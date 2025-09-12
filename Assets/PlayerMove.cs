using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : HPCharacterController
{

    public Vector2 movement;
    public float moveSpeed = 5f;
    // Start is called before the first frame update

    
    override protected void Update()
    {
        if (isDead)
        {
            //stopAttackAnim();
            return;
        }
            if (CSDialogManager.Instance.isInDialogue)
        {
            movement = new Vector2(0, 0);
            return;
        }
        //if (GameManager.instance.isCheatOn && Input.GetKeyDown(KeyCode.M))
        //{
        //    GameOver();
        //    return;
        //}
        //if (GameManager.instance.isPaused)
        //{
        //    moveSpeed = 0;
        //    movement = Vector2.zero;
        //    return;
        //}


        movement.x = Input.GetAxisRaw("Horizontal");

        //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
        movement.y = Input.GetAxisRaw("Vertical");
        float speed = movement.sqrMagnitude;
        movement = Vector2.ClampMagnitude(movement, 1);
        if (movement.magnitude > 0.1f)
        {
            if (CSDialogManager.Instance.isInBuggyDialogue)
            {
                BugManager.Instance.triggerBug(4);
            }
        }
        //animator.SetFloat("speed", movement.sqrMagnitude);


        //base.Update();
        //DialogueManager.StartConversation("firstMerge", null, null);

    }

    protected override void Awake()
    {
        base.Awake();
        spriteObject = GetComponentInChildren<SpriteRenderer>().gameObject;
    }

    private void LateUpdate()
    {
        if (isDead)
        {
            return;
        }
        if (CSDialogManager.Instance.isInDialogue)
        {
            return;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        testFlip(movement);
        // rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
}
