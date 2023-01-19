using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerInteractable : Interactable
{
    [SerializeField] GameObject workingMiner;
    [SerializeField] GameObject NotWorkingMiner;
    [SerializeField] private bool isWorking;

    public override void Interact(Character character)
    {
        if (isWorking == false)
        {
            isWorking = true;
            NotWorkingMiner.SetActive(false);
            workingMiner.SetActive(true);

        }
        else
        {
            isWorking = false;
            NotWorkingMiner.SetActive(true);
            workingMiner.SetActive(false);
        }
    }

    public bool IsWorking()
    {
        return isWorking;
    }


}

