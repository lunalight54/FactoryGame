using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Mob")]
public class MobData : ScriptableObject
{
    public string Name;
    public float speed = 1f;
    public int health = 10;
    public bool hostile;
    //public Sprite icon;
}
