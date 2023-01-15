using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_controller : MonoBehaviour
{
   [SerializeField] private GameObject Itempanel;
   [SerializeField] private GameObject Craftpanel;
   [SerializeField] private GameObject Toolbar;

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.I))
      {
         Itempanel.SetActive(!Itempanel.activeInHierarchy);
         Craftpanel.SetActive(!Craftpanel.activeInHierarchy);
         Toolbar.SetActive(!Toolbar.activeInHierarchy);

      }
   }
}
