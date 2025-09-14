using System;
using Pool;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PixelCrushers.DialogueSystem;
using UnityEngine;
public enum GameState {Default,BattlePortalOn,BossPortalOn,BossFailed, TalkedToGhost}
public class GameManager : Singleton<GameManager>
{
    public BugablePlayer player;
    public bool isInFindBugMode;
    public GameState gameState;

    public GameObject battlePortal;
    public GameObject bossPortal;
    public GameObject voidPortal;
    public GameObject ghostHelp;

    public void startDialogue(string dialogueName)
    {
        
    }
    
    void Start()
    {
        
        player = GameObject.FindObjectOfType<BugablePlayer>();
        EventPool.OptIn<int>(EventPool.bugFixed, OnBugFixed);
        EventPool.OptIn<int>(EventPool.bugBack, OnBugBack);
    }
    void OnBugBack(int id)
    {
        
    }

    private void Awake()
    {
        CSVLoader.Instance.Init();
    }

    void OnBugFixed(int id)
    {
        GetIntoPlayMode();
        
        
        
        
        
        //if fixed enough bug, start dialogue to next portal
        if (canUnlockBattle() && gameState == GameState.Default)
        {
            gameState = GameState.BattlePortalOn;
            CSDialogManager.Instance.StartConversation("BattlePortal", null, null);
            battlePortal.gameObject.SetActive(true);
        }
        
        
        if (canUnlockFinal() && gameState == GameState.BattlePortalOn)
        {
            gameState = GameState.BossPortalOn;
            CSDialogManager.Instance.StartConversation("BossPortal", null, null);
            bossPortal.gameObject.SetActive(true);
        }
    }

    bool canUnlockBattle()
    {
        var hasNotFixed = CSVLoader.Instance.bugs.Where(x => x.unlockLevel == 1)
            .Any(x => BugManager.Instance.fixedBugs[x.Id] != BugStatus.BugFixed);
        return !hasNotFixed;
    }

    bool canUnlockFinal()
    {
        var hasNotFixed = CSVLoader.Instance.bugs.Where(x => x.unlockLevel == 2)
            .Any(x => BugManager.Instance.fixedBugs[x.Id] != BugStatus.BugFixed);
        return !hasNotFixed;
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
