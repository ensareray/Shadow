using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// This class only for the Hiding ability of shadow.
/// ShadowHide until a ceartain time or key press hides the shadow.
/// Works with "C"  key.   
///</summary>
public class ShadowHideController : MonoBehaviour
{
    [SerializeField] PlayerMovementController playerMovementController;
    public bool isShadowHideActive;
    [SerializeField]float hidingDuration;
    bool isHiding, endHiding;
    void Update()
    {
        if(!isShadowHideActive)
            return;

        if(Input.GetKeyDown(KeyCode.C))
        {
            if(isHiding)
            {
                EndHiding();
            }
            else
            {
                Hide();
            }
        }
    }

    private void EndHiding()
    {
        endHiding = true;
    }

    private void Hide()
    {
        //Animation Starts

        //Cant move starts
        playerMovementController.canMove = false;
        //Undetectable Starts


        isHiding = true;
        StartCoroutine( HideRoutine() );
    }
    IEnumerator HideRoutine()
    {
        float t = 0;
        while (t < hidingDuration)
        {
            if(endHiding == true)
                break;
            
            t += Time.deltaTime / Time.timeScale/hidingDuration;
            yield return null;
        }
        OnHidingEnd();
    }
    void OnHidingEnd()
    {
        //Animation Ends

        //Cant move Ends
        playerMovementController.canMove = true;
        //Undetectable Ends


        isHiding = false;
        endHiding = false;
    }
}
