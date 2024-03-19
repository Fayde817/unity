using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
     public int maxVie = 100;
     public int vieactuelle;

     public SystemHealth barredevie;
     private void Start()
     {
          vieactuelle = maxVie;
          barredevie.VieMax(maxVie);
     }

     private void Update()
     {
          if (Input.GetKeyDown(KeyCode.Space))
          {
               TakeDamage(20);
          }
     }

     void TakeDamage(int dmg)
     {
          vieactuelle -= dmg;
          barredevie.UpdateVie(vieactuelle);
     }
}
