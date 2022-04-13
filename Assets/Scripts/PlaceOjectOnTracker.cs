using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaceOjectOnTracker : MonoBehaviour
{
    public ARTrackedImageManager manager;
    public GameObject buttonTest;
    public GameObject[] tableauObjectSave;
    public GameObject[] tableauObjectInstancie;
    public int index = 0;
    


    private void Start()
    {
        buttonTest.SetActive(false);
    }

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
        if (args.added.Count >0)
        {
            //buttonTest.SetActive(true);*
            
        }
        if (args.updated.Count >0)
        {
           //buttonTest.SetActive(true);
           //buttonTest.transform.position = args.updated[0].transform.position; //0.0.0
           //tableauObjectInstancie[index].transform.position = args.updated[0].transform.position;
           //ChangeObject();

        }
        if (args.removed.Count >0)
        {
            //buttonTest.SetActive(false);
        }

        
    }


    public void ChangeObject()
    {
        switch (index)
        {
            case 0 :
                
                if (tableauObjectInstancie[index] != null) //si ce n'est pas la premiere fois
                {
                    Destroy(tableauObjectInstancie[index].gameObject); //detruit l'objet 0
                }
                tableauObjectInstancie[index+1] = Instantiate(tableauObjectSave[index]); //instancie mon objet 1
                
                index += 1;

                break;
            //////////////
            case 1:
                
                 Destroy(tableauObjectInstancie[index].gameObject); //detruit l'objet 1
                
                tableauObjectInstancie[index-1] = Instantiate(tableauObjectSave[index]); //instancie mon objet 0
                 index -= 1;
                break; 
            ///////////////
        }
    }
}
