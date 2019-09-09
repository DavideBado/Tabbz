using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraManager : MonoBehaviour
{
    #region Cameras
    public Camera OnTheRoadCamera;
    public Camera InsideOrNearBuildCamera;
    public Camera POVCamera;
    #endregion

   //public Shader OutlineShader;

    #region Actions
    public Action Action_OnTheRoadCamera;
    public Action Action_InsideOrNearBuildCamera;
    public Action Action_POVCamera;
    #endregion

    private void OnEnable()
    {
        ActionsSub();
    }
    private void OnDisable()
    {
        ActionsUnsub();
    }

    private void ActionsSub()
    {
        Action_OnTheRoadCamera += SetOnTheRoadCamera;
        Action_InsideOrNearBuildCamera += SetInsideOrNearBuildCamera;
        Action_POVCamera += SetPOVCamera;
    }
    private void ActionsUnsub()
    {
        Action_OnTheRoadCamera -= SetOnTheRoadCamera;
        Action_InsideOrNearBuildCamera -= SetInsideOrNearBuildCamera;
        Action_POVCamera -= SetPOVCamera;
    }
    private void SetOnTheRoadCamera()
    {
        OnTheRoadCamera.gameObject.SetActive(true);
        InsideOrNearBuildCamera.gameObject.SetActive(false);
        POVCamera.gameObject.SetActive(false);
    }
    private void SetInsideOrNearBuildCamera()
    {
        OnTheRoadCamera.gameObject.SetActive(false);
        InsideOrNearBuildCamera.gameObject.SetActive(true);
        POVCamera.gameObject.SetActive(false);
       // InsideOrNearBuildCamera.RenderWithShader(OutlineShader, "RenderedByReplacementCamera");
    }
    private void SetPOVCamera()
    {
        OnTheRoadCamera.gameObject.SetActive(false);
        InsideOrNearBuildCamera.gameObject.SetActive(false);
        POVCamera.gameObject.SetActive(true);
    }
}