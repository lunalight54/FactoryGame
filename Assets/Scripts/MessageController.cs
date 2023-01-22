using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class MessageController : MonoBehaviour
{
    [SerializeField] private GameObject MessagePanel;
    private TextMeshProUGUI MessagePanelText;
    private Image backGround;
    private float? time;
    private float messageDuration;
    
    public void Awake()
    {
        backGround = MessagePanel.GetComponent<Image>();
        MessagePanel.SetActive(false);
        Debug.Log("message controller started");
        MessagePanelText = GetComponent<TextMeshProUGUI>();
        MessagePanelText.text = "start message";
    }

    public void Show(String textToShow, float messageDuration, Color color)
    {
        MessagePanelText.text = textToShow;
        MessagePanelText.color = color;
        this.messageDuration = messageDuration;
        MessagePanel.SetActive(true);
        time = 0;
    }

    public void hideBackground()
    {
       if(time == null)
        backGround.enabled = false;
    }

    public void Update()
    {
        if (time != null)
        {
            time += Time.deltaTime;
            if (time > messageDuration)
            {
                Hide();
            }
        }
    }

    public void Hide()
    {
        MessagePanel.SetActive(false);
        time = null;
        MessagePanelText.text = "not configured text";
        MessagePanelText.color = Color.black;
        backGround.enabled = true;
    }
}
