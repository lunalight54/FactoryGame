using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_controller : MonoBehaviour
{
   [SerializeField] private GameObject panel;

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.I))
      {
         panel.SetActive(!panel.activeInHierarchy);
      }
   }
}
