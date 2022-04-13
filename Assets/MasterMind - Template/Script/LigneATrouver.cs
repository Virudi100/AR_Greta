using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LigneATrouver : MonoBehaviour
{
 //---------------------------------------------------------//
 // variable pour tableau de couleur //
 private Color _bleu = Color.blue;
 private Color _rouge = Color.red;
 private Color _violet = Color.magenta;
 private Color _blanc = Color.white;

 private Color[] _tableauColor = new Color[4];
 [HideInInspector] public Color[] _tableauSolution = new Color[4];
 private int indexSolution = 0;

 public GameObject[] sphereSoluceArray;
 //---------------------------------------------------------//
 
 private void Start()
 {
  ColorRandomStartGame();
 }



 public void ColorRandomStartGame()
 {
  _tableauColor = new[] {_bleu, _rouge, _violet, _blanc};
  
  foreach (GameObject sphere in sphereSoluceArray)
  {
    sphere.GetComponent<Renderer>().material.color = _tableauColor[Random.Range(0,_tableauColor.Length)];
    _tableauSolution[indexSolution] = sphere.GetComponent<Renderer>().material.color;
    
    indexSolution++;
  }

  indexSolution = 0;

  /*sphereArray[0].GetComponent<Renderer>().material.color = _tableauColor[Random.Range(0,_tableauColor.Length)];  //et non pas Random.Range(0,3), car si un jour je change de nombre de couleur, je risque de perdre du temps a changer
  sphereArray[1].GetComponent<Renderer>().material.color = _tableauColor[Random.Range(0,_tableauColor.Length)];
  sphereArray[2].GetComponent<Renderer>().material.color = _tableauColor[Random.Range(0,_tableauColor.Length)];
  sphereArray[3].GetComponent<Renderer>().material.color = _tableauColor[Random.Range(0,_tableauColor.Length)];
  //sphere[0].GetComponent<Renderer>().material.color = _blanc;*/




 }
 
}
