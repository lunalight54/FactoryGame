using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float pickUpDistance = 1.5f;
    [SerializeField] private float ttl = 10f;

    private void Awake()
    {
        playerTransform = GameManager.instance.player.transform;
    }

    private void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl < 0)
        {
            Destroy(gameObject);
        }

        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance > pickUpDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position,
            playerTransform.position,
            speed * Time.deltaTime);
        
        if (distance < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
