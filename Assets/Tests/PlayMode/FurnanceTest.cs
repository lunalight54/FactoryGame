using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class FurnanceTest
{

    FurnanceRecipeList returnFurnanceRecipes(string furnanceRecipesListName)
    {
         string[] guids = AssetDatabase.FindAssets($"t:{nameof(FurnanceRecipeList)} { furnanceRecipesListName }");
         
        if(guids.Length == 0)
            Assert.Fail($"No {nameof(FurnanceRecipeList)} found named {furnanceRecipesListName}");
        if(guids.Length > 1)
            Debug.LogWarning($"More than one {nameof(FurnanceRecipeList)} found named {furnanceRecipesListName}, taking first one");
        
        return (FurnanceRecipeList) AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guids[0]), typeof(FurnanceRecipeList));
    }

    Item findItemByName(string itemToFind)
    {
        string[] foundedItems = AssetDatabase.FindAssets($"t:{nameof(Item)} { itemToFind }");
        
        if(foundedItems.Length == 0)
            Assert.Fail($"No {nameof(Item)} found named {itemToFind}");
        if(foundedItems.Length > 1)
            Debug.LogWarning($"More than one {nameof(Item)} found named {itemToFind}, taking first one");

        return (Item) AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(foundedItems[0]), typeof(Item));
    }

    [UnityTest]
    public IEnumerator IronMeltTest()
    {
        var recipeList = returnFurnanceRecipes("Furnance Recipe List");
        
        var furnance = new GameObject().AddComponent<FurnanceInteractableController>();
        furnance.enabled = false;
        furnance.setRecipeLest(recipeList);
        yield return null;
        
        Assert.AreEqual(furnance.Production(findItemByName("UnsmeltedIron")),findItemByName("SmeltedIron"));
    }
    
    [UnityTest]
    public IEnumerator BronzeMeltTest()
    {
        
        var recipeList = returnFurnanceRecipes("Furnance Recipe List");
        
        var furnance = new GameObject().AddComponent<FurnanceInteractableController>();
        furnance.enabled = false;
        furnance.setRecipeLest(recipeList);
        yield return null;
        
        Assert.AreEqual(furnance.Production(findItemByName("UnsmeltedBronze")),findItemByName("SmeltedBronze"));
    }
}
