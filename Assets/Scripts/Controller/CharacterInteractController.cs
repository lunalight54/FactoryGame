using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterInteractController : MonoBehaviour
{
    private CharacterController characterController;
    private Rigidbody2D rgbd2d;
    [SerializeField] private float offsetDistance = 1f;
    [SerializeField] private float sizeOfInteractableArea = 1.2f;
    private Character character;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        characterController = GetComponent<CharacterController>();
        character = GetComponent<Character>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Interacte();
        }
    }

    void Interacte()
    {
        Vector2 position = rgbd2d.position + characterController.lastMotionVector * offsetDistance;
        Collider2D[] collider = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (var c in collider)
        {
            var hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(character);
                break;
            }
        }
    }
}
