using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/FurnanceRecipeList")]
public class FurnanceRecipeList : ScriptableObject
{
    public List<FurnanceReceipt> recipes;

}
