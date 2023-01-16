using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnanceInteractable : Interactable
{
    [SerializeField] GameObject workingFurnance;
    [SerializeField] GameObject NotWorkingFurnance;
    [SerializeField] bool isWorking;

    public override void Interact(Character character)
    {
        if (isWorking == false)
        {
            isWorking = true;
            NotWorkingFurnance.SetActive(false);
            workingFurnance.SetActive(true);

        }
        else
        {
            isWorking = false;
            NotWorkingFurnance.SetActive(true);
            workingFurnance.SetActive(false);
        }
    }
}
