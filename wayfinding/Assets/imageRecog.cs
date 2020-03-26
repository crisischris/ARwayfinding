using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class imageRecog : MonoBehaviour
{
    public GameObject chris;
    private ARTrackedImageManager imageManager;

    private void Awake()
    {
        imageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void OnEnable()
    {
        imageManager.trackedImagesChanged += onImageDetect;
    }

    public void OnDisable()
    {
        imageManager.trackedImagesChanged -= onImageDetect;
    }

    public void onImageDetect(ARTrackedImagesChangedEventArgs args)
    {
        foreach(var trackedImage in args.added)
        {
            if (trackedImage.name == "pos1")
                chris.SetActive(true);
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
