using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;


public class imageRecog : MonoBehaviour
{
    public GameObject chris;
    private ARTrackedImageManager imageManager;
    public Text tracked;
    private Camera user;

    private void Awake()
    {
        imageManager = FindObjectOfType<ARTrackedImageManager>();
        user = FindObjectOfType<Camera>();
        Debug.Log("hello wurld");
    }

    private void Start()
    {
        Debug.Log(imageManager.referenceLibrary.count);
    }
    void Update()
    {
       
    }
    public void OnEnable()
    {
        imageManager.trackedImagesChanged += onImageDetect;
    }

    public void OnDisable()
    {
        imageManager.trackedImagesChanged -= onImageDetect;
    }

    public void onImageDetect(ARTrackedImagesChangedEventArgs events)
    {
       // tracked.text = "tracked!" + "/n";
        Debug.Log("oh shit!");

        foreach (var trackedImage in events.added)
        {
            tracked.text += "Added: " + trackedImage.referenceImage.name + "\n";

            if (trackedImage.referenceImage.name == "QR1")
                user.transform.position = new Vector3(user.transform.position.x, user.transform.position.y, -8);
        }

        foreach (var trackedImage in events.removed)
        {
            tracked.text = "Removed: " + trackedImage.referenceImage.name + "\n";
        }
    }



}
