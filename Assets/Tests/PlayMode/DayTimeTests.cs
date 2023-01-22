using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;


public class DayTimeTests
{
    [SerializeField] public int some;
    /*
    [UnityTest]
    public IEnumerator CheckIfNight()
    {
        var dayTimeController = new GameObject().AddComponent<DayTimeController>();
        var so = new SerializedObject(dayTimeController);
        
        TextMeshProUGUI text = new GameObject().AddComponent<TextMeshProUGUI>();
        so.FindProperty("text").objectReferenceValue = text;
        so.ApplyModifiedProperties();
        
        yield return null;
        Assert.AreEqual(false ,dayTimeController.IsNight() );
    }
    */
}
