using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchManager : MonoBehaviour
{

    public Texture2D cursorTexture;
    public Texture2D cursorTextureHit;

    enum CursorStateEnum { playMode, findBugNormal, findBugHit };
    CursorStateEnum cursorState;
    
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (!CSDialogManager.Instance.isInDialogue)
            {
                // Your raycast handling
                Vector3 mousePosition = Input.mousePosition;
                //CSUtil.LOG("mouse click " + mousePosition);
                mousePosition = new Vector3(mousePosition.x, mousePosition.y, 10);
                RaycastHit2D[] vHits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero);
                bool hasHitted = false;
                foreach (RaycastHit2D vhit in vHits)
                {
                    if (GameManager.Instance.isInFindBugMode)
                    {

                        BugableObject script = vhit.transform.gameObject.GetComponent<BugableObject>();
                        //TouchAction script = vhit.transform.gameObject.GetComponent<TouchAction>();
                        //FogOfWarItem fowItem = vhit.transform.gameObject.GetComponent<FogOfWarItem>();
                        if (script != null)
                        {
                            if (script.DidTap())
                            {
                                hasHitted = true;
                                SFXManager.Instance.PlayBugSuccess();
                                break;
                            }
                        }
                        
                    }
                }

                if (!hasHitted)
                {
                    
                    SFXManager.Instance.PlayBugFailed();
                }
                //improve this later, don't call manager in update

                //{
                //    ChangeCursorState(CursorStateEnum.findBugHit);
                //    hasHitted = true;
                //}
            }

        }
        if (!GameManager.Instance.isInFindBugMode)
        {
            ChangeCursorState(CursorStateEnum.playMode);
        }
        else// if (!hasHitted)
        {
            ChangeCursorState(CursorStateEnum.findBugNormal);
        }

    }

    void ChangeCursorState(CursorStateEnum newState)
    {
        if (cursorState != newState)
        {
            switch (newState)
            {
                case CursorStateEnum.findBugNormal:
                    Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
                    break;
                case CursorStateEnum.findBugHit:
                    Cursor.SetCursor(cursorTextureHit, Vector2.zero, CursorMode.Auto);
                    break;
                case CursorStateEnum.playMode:
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    break;
            }
            cursorState = newState;
        }
    }
}
