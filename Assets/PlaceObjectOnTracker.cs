using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaceObjectOnTracker : MonoBehaviour
{
    public ARTrackedImageManager manager;
    public GameObject cubePrefab;
    private GameObject newGo;

    private void OnEnable()
    {
        manager.trackedImagesChanged += OnTrackedImageChange;
    }

    private void OnDisable()
    {
        manager.trackedImagesChanged -= OnTrackedImageChange;
    }

    private void OnTrackedImageChange(ARTrackedImagesChangedEventArgs args)
    {

        for (int i = 0; i < args.added.Count; i++)
        {
            newGo = Instantiate(cubePrefab, args.added[i].transform);
        }

        for (int i = 0; i < args.updated.Count; i++)
        {
            newGo.transform.position = args.updated[i].transform.position;
        }

        for (int i = 0; i < args.removed.Count; i++)
        {
            if(newGo != null)
            {
                Destroy(newGo);
            }
        }
    }
}
