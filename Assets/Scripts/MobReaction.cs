using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MobReaction : ToolHit
{
    [SerializeField] MobData mobInfo;
    [SerializeField] private float spread = 0.7f;
    [SerializeField] private Item item;
    [SerializeField] private int itemCountInOneDrop = 1;
    int ToolDamage;
    int currentHealth;
    private void Start()
    {
        currentHealth = mobInfo.health;
    }
    public override void Hit()
    {
        GameManager.instance.messageController.hideBackground();
        GameManager.instance.messageController.Show("hit!",1,Color.red);
        
        currentHealth -= ToolDamage;
        
        if (currentHealth <= 0)
        {
            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            ItemSpawnManager.instance.SpawnItem(position, item, itemCountInOneDrop);
            Destroy(gameObject);
        }
        
    }
    public override void GetDamage(int damage)
    {
        this.ToolDamage = damage;
    }
}
