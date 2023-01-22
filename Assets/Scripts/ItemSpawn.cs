using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TimeAgent))]
public class ItemSpawn : MonoBehaviour
{
    [SerializeField] Item ToSpawn;
    [SerializeField] int count;
    [SerializeField] float spread = 2f;
    [SerializeField] float probability = 0.5f;
    private MinerInteractable miner;
    private void Start()
    {
        TimeAgent timeAgent = GetComponent<TimeAgent>();
        timeAgent.onTimeTick += Spawn;
        miner = GetComponent<MinerInteractable>();
    }
    void Spawn()
    {
        if (miner.IsWorking() && UnityEngine.Random.value < probability)
        {
            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;

            ItemSpawnManager.instance.SpawnItem(position, ToSpawn, count);
        }
    }
}