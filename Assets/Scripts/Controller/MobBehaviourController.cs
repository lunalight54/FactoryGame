using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MobBehaviourController : MonoBehaviour
{
    [SerializeField] MobData mobInfo;
    private DayTimeController time;
    [SerializeField] private float attackDistance = 1.5f;
    private Transform playerTransform;
    Rigidbody2D rigidbody2d;// unnecessary maybe?
    float speed = 1f;
    Animator animator;
    private bool isHostile;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = mobInfo.speed;
        isHostile = mobInfo.hostile;
        time = GameManager.instance.dayTimeController;
        playerTransform = GameManager.instance.player.transform;
    }

    private void Update()
    {
        if (time.IsNight() && isHostile)
        {
            Hunt();
        }
        else
        {
            animator.SetBool("moving", false);
            rigidbody2d.velocity = new Vector2(0.0f, 0.0f);
        }
    }
    private void Hunt()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance > attackDistance)
        {
            animator.SetBool("moving", true);
            Move();
            return;
        }
        animator.SetBool("moving", false);
        Attack();
    }
    private void Attack()
    {
        Debug.LogWarning("Zombie attacks!");
    }
    private void Move()
    {
        /*transform.LookAt(playerTransform);
        transform.position += transform.forward * speed * Time.deltaTime;*/
        Vector2 direction = transform.position - playerTransform.position;
        rigidbody2d.velocity = -direction * speed;

        if (playerTransform.position.x < transform.position.x )//look left
        {
            animator.SetFloat("Horizontal", -1f);
        }
        else{//look right
            animator.SetFloat("Horizontal", 1f);
        }
    }
}
