using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorInteractable : Interactable
{
    [SerializeField] GameObject workingGenerator;
    [SerializeField] bool isWorking;

    public override void Interact(Character character)
    {
        if (isWorking == false)
        {
            isWorking = true;
        }
    }
}
