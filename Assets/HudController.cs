using System.Collections;
using System.Collections.Generic;
using Pool;
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

    public Button hintButton;

    private float hintTime = 60;

    private float hintTimer = 0;

    public TMP_Text hintTimeLabel;
    //public Image hintSpriteRender;

    int lastHintBugId = -1;
    bool ShouldShowHint;

    Color transparentColor;
    Color redColor;

    public HPsHandler hPsHandler;

    public GameObject hud;
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

        EventPool.OptIn<int>(EventPool.bugFixed, OnBugFixed);
        restartButton.onClick.AddListener(() =>
        {
            FindObjectOfType<BugablePlayer>().OnRestart();
            HideRestartButton();
            // GameManager.Instance.GetIntoPlayMode();
        });


        hintButton.onClick.AddListener(() =>
        {
            var hintText = "";
            
            SFXManager.Instance.PlayHint();
            if (hintTimer <= 0)
            {
                if ((int)GameManager.Instance.gameState >= (int)GameState.TalkedToGhost)
                {
                    
                    hintText = $"Select three bugs to get them back and kill the boss";
                }
                else
                {
                    if (lastHintBugId == -1)
                    {
                        for (int i = 0; i < BugManager.Instance.fixedBugs.Length; i++)
                        {
                            if (BugManager.Instance.fixedBugs[i] != BugStatus.BugFixed)
                            {
                                lastHintBugId = i;
                                break;
                            }
                        }
                    }

                    if (lastHintBugId != -1)
                    {
                        hintText = CSVLoader.Instance.bugs[lastHintBugId].Hint;
                    }
                }
            }
            else
            {
                hintText = $"Next hint in {hintTimer.ToString("0")} seconds";
            }

            FindObjectOfType<PopupMenu>().Show(hintText);
        });
    }

    void OnBugFixed(int bugId)
    {
        if (bugId == lastHintBugId)
        {
            lastHintBugId = -1;
            hintTimer = hintTime;
        }
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
        //hintTimeLabel.text = hintTimer > 0 ? $"Next hint in {hintTime.ToString("0")} seconds" : "";
        if (hintTimer > 0)
        {
            hintButton.GetComponentInChildren<TMP_Text>().text = $"HINT({ hintTimer.ToString("0")})";
        }
        else
        {
            hintButton.GetComponentInChildren<TMP_Text>().text = "HINT";
        }
        hintTimer -= Time.deltaTime;
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