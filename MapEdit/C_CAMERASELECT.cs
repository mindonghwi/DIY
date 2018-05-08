using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CAMERASELECT : MonoBehaviour {

    public Camera firstPersonCamera;
    public Camera overheadCamera;

    void Start()
    {
        ShowFirstPersonView();
    }

    public void ShowOverheadView()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
        overheadCamera.backgroundColor = firstPersonCamera.backgroundColor;
    }

    public void ShowFirstPersonView()
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
        firstPersonCamera.backgroundColor = overheadCamera.backgroundColor;
    }
}
