using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;


public class DayTimeTests
{

    [UnityTest]
    public IEnumerator CheckIfNight()
    {
        var gameObject = new GameObject();
        var dayTimeController = gameObject.AddComponent<DayTimeController>();
        dayTimeController.enabled = false;
        dayTimeController.Start();
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(false, dayTimeController.IsNight());
    }
    
}
