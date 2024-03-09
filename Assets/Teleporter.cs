using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : InteractiveBase
{
    public string targetRoomName;
    public Transform teleportTransform;
    public KeyCode cheatKeyCode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CheatManager.Instance.isCheating)
        {
            if(Input.GetKey(KeyCode.T) )
                if(Input.GetKeyDown(cheatKeyCode))
            {
                var player = GameObject.Find("player").GetComponent<PlayerMove>();
                player.GetComponent<BugablePlayer>().teleport(this);
            }
        }
    }
    public override void Interact(PlayerMove player)
    {
        player.GetComponent<BugablePlayer>().teleport(this);
        
    }
}
