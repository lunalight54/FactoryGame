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
    public Item item;
    public int count = 1;
    private void Awake()
    {
        playerTransform = GameManager.instance.player.transform;
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;
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
            //*TODO* Should be added into specified controller rather than being checked here.
            if (GameManager.instance.itemContainer != null)
            {
                GameManager.instance.itemContainer.Add(item, count);
            }
            else
            {
                Debug.LogWarning("No inventory container attached to the game manager");
            }
            Destroy(gameObject);
        }
    }
}
