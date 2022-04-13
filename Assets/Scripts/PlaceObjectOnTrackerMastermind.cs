using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaceObjectOnTrackerMastermind : MonoBehaviour
{
    public ARTrackedImageManager manager;

    public GameObject masterMind;


    private void OnEnable()
    {
        manager.trackedImagesChanged += OnTrackedImageChange;
    }
    
    private void OnDisable()
    {
        manager.trackedImagesChanged -= OnTrackedImageChange;
    }

    private void Awake()
    {
        masterMind.SetActive(false);
    }

    private void OnTrackedImageChange(ARTrackedImagesChangedEventArgs args)
    {
        if (args.added.Count >0)
        {
          masterMind.SetActive(true);
            
        }
        if (args.updated.Count >0)
        {
            
        }
        if (args.removed.Count >0)
        {
           masterMind.SetActive(false);
        }

        
    }


    public void ChangeObject()
    {
        
    }
}
