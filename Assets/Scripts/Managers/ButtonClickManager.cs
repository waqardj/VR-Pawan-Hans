using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonClickManager : MonoBehaviour
{
    EventTrigger trigger;
    
    [SerializeField]
    Color hoverColorImage, selectColorImage, normalColorImage;
  
    [SerializeField]
    Color hoverColorText, selectColorText, normalColorText;
    Image img;
    TextMeshProUGUI text;
    Button btn;
    private void Start()
    {
        btn = GetComponent<Button>();
        img = GetComponent<Image>();
        if (img)
            img.color = normalColorImage;
        text = GetComponentInChildren<TextMeshProUGUI>();
        if(text)
        {
            text.color = normalColorText;
        }
        trigger = gameObject.AddComponent<EventTrigger>();
        if (trigger)
        {
            EventTrigger.Entry hover = new EventTrigger.Entry();
            hover.eventID = EventTriggerType.PointerEnter;
            hover.callback.AddListener((eventData) => { OnHoverUI(); });
            trigger.triggers.Add(hover);


            EventTrigger.Entry pressDown = new EventTrigger.Entry();
            pressDown.eventID = EventTriggerType.PointerDown;
            pressDown.callback.AddListener((eventData) => { OnPressUI(); });
            trigger.triggers.Add(pressDown);

            EventTrigger.Entry pressUp = new EventTrigger.Entry();
            pressUp.eventID = EventTriggerType.PointerExit;
            pressUp.callback.AddListener((eventData) => { OnPressUpUI(); });
            trigger.triggers.Add(pressUp);

        }
    }

    public void OnHoverUI()
    {
        if(btn&&btn.interactable==false)
        {
            return;
        }
        if(img)
        {
            img.color = hoverColorImage;
        }
        if(text)
        {
            text.color = hoverColorText;
        }
    }

    public void OnPressUI()
    {
        if (btn && btn.interactable == false)
        {
            return;
        }
        if (img)
        {
            img.color = selectColorImage;
        }
        if (text)
        {
            text.color = selectColorText;
        }
    }

    public void OnPressUpUI()
    {
        if (btn && btn.interactable == false)
        {
            return;
        }
        if (img)
        {
            img.color = normalColorImage;
        }
        if (text)
        {
            text.color = normalColorText;
        }
    }
}
