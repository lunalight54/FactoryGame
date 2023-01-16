using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObjectsReferenceManager : MonoBehaviour
{
    public PlaceableObjectsManager placeableObjectsManager;

    public void Place(Item item, Vector3Int pos) 
    {
        if (placeableObjectsManager == null) 
        {
            Debug.LogWarning("No placeableObjectsManager reference detected");
            return;
        }
        Debug.Log("Placing new object"+item.Name);
        placeableObjectsManager.Place(item, pos);
    }
}