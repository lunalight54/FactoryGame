using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject craftingPanel;
    //[SerializeField] GameObject toolbarPanel;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            if (panel.activeInHierarchy == false)
            {
                Open();
            }
            else {
                Close();
            }
        }
        
    }

    public void Open() 
    {
        panel.SetActive(true);
        GameManager.instance.toolbarPanel.gameObject.SetActive(false);
        if(GameManager.instance.chestPanel.gameObject.activeInHierarchy == false)
            craftingPanel.SetActive(true);
        //GameManager.instance.pa
        //statusPanel.SetActive(true);
        //toolbarPanel.SetActive(false);
    }

    public void Close() 
    {
        panel.SetActive(false);
        GameManager.instance.toolbarPanel.gameObject.SetActive(true);
        craftingPanel.SetActive(false);
        GameManager.instance.furnancePanel.gameObject.SetActive(false);
        GameManager.instance.chestPanel.gameObject.SetActive(false);

        //statusPanel.SetActive(false);
        //toolbarPanel.SetActive(true);
    }
}