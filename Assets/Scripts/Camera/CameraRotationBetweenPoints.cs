using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationBetweenPoints : MonoBehaviour
{
    [SerializeField]Transform[] cameraPoints;
    [SerializeField] Transform cameraPointObject;
    int activeTabIndex = 0, arrayLength;
    bool isLerping;
    [SerializeField]float lerpDuration;
    [SerializeField] CameraMovementSencronyzer cameraMovementSencronyzer;
    void Start()
    {
        int i = 0;
        arrayLength = cameraPointObject.childCount;
        cameraPoints = new Transform[arrayLength];
        foreach (Transform child in cameraPointObject)
        {
            cameraPoints[i] = child;
            i++;
        }
        activeTabIndex = 0;

        StartCoroutine(LerpCamera());
    }

    void Update()
    {
        if(isLerping == false)
        {
            if( Input.GetKeyDown(KeyCode.Tab) )
            {
                GoNext();
            }
            else if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                if( Input.GetKeyDown(KeyCode.Tab) )
                {
                    GoPrevious();
                }
            }
        }
    }
    void GoNext()
    {
        activeTabIndex++;
        if(activeTabIndex > arrayLength-1)
        {
            activeTabIndex = 0;
        }
        StartCoroutine(LerpCamera());
    }
    void GoPrevious()
    {
        activeTabIndex--;
        if(activeTabIndex < 0)
        {
            activeTabIndex = arrayLength-1;
        }
        StartCoroutine(LerpCamera());
    }
    IEnumerator LerpCamera()
    {
        float t = 0.0f;
        isLerping = true;
        while(t < lerpDuration)
        {
            t += Time.deltaTime / (Time.timeScale / lerpDuration);
            transform.position = Vector3.Lerp(transform.position, cameraPoints[activeTabIndex].position, t);
            transform.rotation = Quaternion.Lerp(transform.rotation,cameraPoints[activeTabIndex].rotation,t);
            yield return null;
        }
        isLerping = false;
        cameraMovementSencronyzer.OnCameraAngleChange();
    }
}
