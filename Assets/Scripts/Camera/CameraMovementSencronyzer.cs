using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementSencronyzer : MonoBehaviour
{
    [SerializeField]PlayerMovementController playerMovementController;
    void Start()
    {
        OnCameraAngleChange();
    }
    public void OnCameraAngleChange()
    {
        DetectCameraNormal();
    }
    void DetectCameraNormal()
    {
        float y = Mathf.Abs(transform.rotation.eulerAngles.y);
        Debug.Log(y);
        if( y >= 315 && y < 45 )
        {
            playerMovementController.cameraNormal = 0;
        }
        else if(y >= 45 && y < 135)
        {
            playerMovementController.cameraNormal = 3;
        }
        else if(y >= 135 && y < 225)
        {
            playerMovementController.cameraNormal = 2;
        }
        else if(y >= 225 && y < 315)
        {
            playerMovementController.cameraNormal = 1;
        }
        playerMovementController.SyncWithCameraNormal();
    }
}
