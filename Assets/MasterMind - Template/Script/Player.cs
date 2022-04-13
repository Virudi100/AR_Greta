using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    int i = 0;
    //---------------------------//
    // variable pour apparition des lignes //
    [SerializeField] private int index = 0;
    public Lignes[] lines = new Lignes[12];
    int indexAssignChild = 0;

    //---------------------------//
    // variable pour raycast // 

    public Camera cam;

    //---------------------------//

    private bool isPlaying = false;
    
    private Lignes _accesToSphere;
    private Sphere sphere;

    public Color[] _tableauColor5 = new Color[] {Color.blue, Color.red, Color.magenta, Color.white,};

    //---------------------------//
    public LigneATrouver LigneATrouver;
    private GameObject SphereATrouver;
    [SerializeField] private GameObject[] playerLine;

    public delegate void TestColor();

    public static event TestColor jetest;

    [Header("UI Elements")] 
    [SerializeField] private GameObject victoryUI;
    [SerializeField] private GameObject defeatUI;
    [SerializeField] private Text textGudSpheres;
    
    //---------------------------//

    [SerializeField] private GameObject pionBlanc;
    [SerializeField] private GameObject pionNoir;

    [SerializeField] private bool[] isGudplacer = new bool[4];
    private void Awake()
    {
        jetest += Comparaison;
        isPlaying = true;
        victoryUI.SetActive(false);
        defeatUI.SetActive(false);
    }

    void Update()
    {
        //apparitionLines();
        infoRaycastChangeColor();
    }

    public void apparitionLines() //fait apparaitre les lines suivantes et verifié les bonnes couleurs
    {
        if (isPlaying == true)
        {
            lines[index].gameObject.GetComponent<Lignes>().enabled = false;
            index++;
            lines[index].gameObject.SetActive(true);
            
            Comparaison();
        }

    }

    private void infoRaycastChangeColor()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay((Input.mousePosition));

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<Sphere>() &&
                    hitInfo.collider.transform.parent.gameObject.GetComponent<Lignes>().enabled == true)
                {
                    Vector3 distanceToTarget = hitInfo.point - cam.transform.position;
                    Vector3 direction = distanceToTarget.normalized;
                    //Debug.Log(hitInfo.transform.name);
                    Debug.DrawRay(cam.transform.position, hitInfo.point, Color.cyan);

                    sphere = hitInfo.collider.gameObject.GetComponent<Sphere>();

                    hitInfo.collider.GetComponent<MeshRenderer>().material
                        .SetColor("_Color", _tableauColor5[sphere.index]);
                    sphere.index++;
                    if (sphere.index == 4)
                    {
                        sphere.index = 0;
                    }
                }
            }
        }


        //public Color GetSphereColor()
        {
            // return GetComponent<MeshRenderer>().material.GetColor("__color");
        }

        //public void SetSphereColor(Color newColor)
        {
            //GetComponent<MeshRenderer>().material.SetColor("__color",newColor);
        }
    }
    
    private void Comparaison()
    {
        int indexComparaison = 0;
        
        
        Debug.Log("je compare");

        foreach (GameObject sphereProposition in playerLine)
        {
            if (sphereProposition.GetComponent<Renderer>().material.color == LigneATrouver
                .sphereSoluceArray[indexComparaison].GetComponent<Renderer>().material.color)
            {
                i++;
                textGudSpheres.text = "You find " + i + " good color spheres and gud position";
                print("bonne couleurs =" + i);
                GameObject pion = Instantiate(pionNoir);
                pion.transform.position = sphereProposition.transform.position;
                isGudplacer[indexComparaison] = true;

                //au true, l'index de couleur est forcement le meme que les true donc il reste les false a calculer par rapport a leur meme index dans le tableau de solution
                //si la couleur de la spheresolution est egale a la couleur du tableau de proposition MAIS pas au meme index -> pion blanc
            }
            else
                isGudplacer[indexComparaison] = false;
            
            if (i >= 4)
            {
                Win();
            }
            else if (i < 4 && index == 11)
            {
                Defaite();
            }

            
            indexComparaison++;
        }
        i = 0;
        indexAssignChild++;

        for (int n = 0; n < playerLine.Length; n++)
        {
            playerLine[n] = lines[indexAssignChild].transform.GetChild(n).gameObject;
        }


        foreach (bool sphereControleRestant in isGudplacer)
        {
            //sphereControleRestant =
        }
        
        
        
        
        
    }
    

    private void Defaite()
    {
        defeatUI.SetActive(true);
        isPlaying = false;
    }

    private void Win()
    {
        print("Win !!");
        victoryUI.SetActive(true);
        isPlaying = false;
    }

    private void OnDisable()
    {
        jetest.Invoke();
    }


    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
    // code essai non fonctionnel 
    /*   Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint((mousePos));
        Debug.DrawRay(transform.position,mousePos-transform.position,Color.cyan);*/

}
