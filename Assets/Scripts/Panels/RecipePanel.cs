using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipePanel : ItemPanel
{
    [SerializeField] RecipeList recipeList;
    [SerializeField] Crafting crafting;

    public override void Show() 
    {
        int i = 0;
        for (; i < recipeList.recipes.Count && i < buttons.Count; i++)
        {
            buttons[i].Set(recipeList.recipes[i].output, false);
        }
        for (;i < buttons.Count; i++)
        {
            buttons[i].Clean();
        }
    }

    public override void OnClick(int id)
    {
        if (id >= recipeList.recipes.Count) { return; }
        crafting.Craft(recipeList.recipes[id]);
    }
}
