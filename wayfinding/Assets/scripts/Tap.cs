using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;
using System.IO;
using System;

public class Tap : MonoBehaviour
{
    public GameObject objToPlace;
    public GameObject indicator;
    public Camera mainCam;
    public ARRaycastManager rcManager;

    private ARSessionOrigin arOrigin;
    private ARRaycastManager arRaycast;
    private Pose placementPose;
    private bool placementPoseIsValid = false;


    // Start is called before the first frame update
    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        updatePlacementIndicator();
        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //placePbject();
        }
    }

    private void placePbject()
    {
        Instantiate(objToPlace, placementPose.position, placementPose.rotation);
    }

    private void updatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            indicator.SetActive(true);
            indicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
            indicator.SetActive(false);
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = mainCam.ViewportToScreenPoint(new Vector3(.5f, .5f));
        var hits = new List<ARRaycastHit>();

        rcManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;

        if(placementPoseIsValid)
        {
            placementPose = hits[0].pose;
        }
    }
}
