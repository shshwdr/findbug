using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : InteractiveBase
{
    public string talkDialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact(PlayerMove player)
    {
        base.Interact(player);

        DialogueManager.StartConversation(talkDialogue, null, null);
    }
}
