using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawnManager : MonoBehaviour
{
    public static MobSpawnManager instance;
    private void Awake()
    {
        Debug.LogWarning("MobSpawnManager is created");
        instance = this;
    }

    [SerializeField] GameObject pickUpMobPrefab;

    public void SpawnMob(Vector3 position)
    {
        GameObject o = Instantiate(pickUpMobPrefab, position, Quaternion.identity);
        o.GetComponent<MobBehaviourController>();
    }
}
