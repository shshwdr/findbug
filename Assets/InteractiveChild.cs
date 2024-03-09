using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveChild : MonoBehaviour
{
    public GameObject interactiveUI;
    public bool isTriggered;
    PlayerMove player;

    // Start is called before the first frame update
    void Start()
    {
        interactiveUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(isTriggered && Input.GetKeyDown(KeyCode.Space))
        {
            isTriggered = false;
            GetComponentInParent<InteractiveBase>().Interact(player);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMove>())
        {
            interactiveUI.SetActive(true);
            isTriggered = true;
            player = collision.GetComponent<PlayerMove>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMove>())
        {
            interactiveUI.SetActive(false);
            isTriggered = false;
        }
    }
}
