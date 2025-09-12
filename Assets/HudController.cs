using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudController : Singleton<HudController>
{

    //public TextMeshProUGUI pointsText;
    //public Button pauseButton;
    public Button foundBugButton;
    public TextMeshProUGUI foundBugButtonText;
    public Button restartButton;

    //public Image hintSpriteRender;

    bool ShouldShowHint;

    Color transparentColor;
    Color redColor;

    public HPsHandler hPsHandler;

    // Use this for initialization
    void Start()
    {
        hPsHandler = GetComponentInChildren<HPsHandler>();
        //pauseButton.onClick.AddListener(OnClickPauseButton);
        foundBugButton.onClick.AddListener(OnClickFoundBugButton);
        //redColor = hintSpriteRender.color;
        transparentColor = new Color(redColor.r, redColor.g, redColor.b, 0);
        UpdateUI();
        HideRestartButton();
restartButton.onClick.AddListener(() =>
{
    FindObjectOfType<BugablePlayer>().OnRestart();
    // GameManager.Instance.GetIntoPlayMode();
});
    }

    public void ShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }
    public void HideRestartButton()
    {
        restartButton.gameObject.SetActive(false);
    }


    void OnClickFoundBugButton()
    {
        if (CSDialogManager.Instance.isInDialogue)
        {
            return;
        }
        //AchievementManager.Instance.FinishAchievement("firstTimeTapFoundItButton");
        if (GameManager.Instance.isInFindBugMode)
        {
            GameManager.Instance.GetIntoPlayMode();
        }
        else
        {
            GameManager.Instance.GetIntoFindBugMode();
        }
    }

    public void UpdateUI()
    {
        if (GameManager.Instance.isInFindBugMode)
        {
            foundBugButtonText.text = "Back To Play";

        }
        else
        {
            foundBugButtonText.text = "FOUND IT!";
        }
    }

    public void SetHP(int amount)
    {
        hPsHandler.SetHP(amount);
    }

    // Update is called once per frame
    void Update()
    {
        //pointsText.text = CurrencyManager.Instance.AmountOfCurrency("points").ToString();

        //if (!GameModeManager.Instance.isInFindBugMode && BugableObjectManager.Instance.HasBugTriggered)
        //{
        //    hintSpriteRender.color = Color.Lerp(transparentColor, redColor, Mathf.PingPong(Time.time, 0.5f));
        //}
        //else
        //{
        //    hintSpriteRender.color = transparentColor;
        //}

    }

}
