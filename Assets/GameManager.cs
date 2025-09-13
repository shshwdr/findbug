using System;
using Pool;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;
public enum GameState {Default,BattlePortalOn,BossPortalOn}
public class GameManager : Singleton<GameManager>
{
    public BugablePlayer player;
    public bool isInFindBugMode;
    public GameState gameState;

    public GameObject battlePortal;
    void Start()
    {
        
        player = GameObject.FindObjectOfType<BugablePlayer>();
        EventPool.OptIn<int>(EventPool.bugFixed, OnBugFixed);
    }

    private void Awake()
    {
        CSVLoader.Instance.Init();
    }

    void OnBugFixed(int id)
    {
        GetIntoPlayMode();
        
        
        
        
        
        //if fixed enough bug, start dialogue to next portal
        if (BugManager.Instance.fixedBugCount() > 5 && gameState == GameState.Default)
        {
            gameState = GameState.BattlePortalOn;
            DialogueManager.StartConversation("BattlePortal", null, null);
            battlePortal.gameObject.SetActive(true);
        }
    }
    public void GetIntoFindBugMode()
    {
        isInFindBugMode = true;
        HudController.Instance.UpdateUI();
    }

    public void GetIntoPlayMode()
    {
        isInFindBugMode = false;
        HudController.Instance.UpdateUI();
    }
}
