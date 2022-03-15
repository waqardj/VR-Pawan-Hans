using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIInteractor : MonoBehaviour
{
    
    [SerializeField]
    SoundManager soundManager;
    EventTrigger uiEvent;

   

    private void Start()
    {
        uiEvent = gameObject.AddComponent<EventTrigger>();
        if(uiEvent)
        {
            EventTrigger.Entry hover = new EventTrigger.Entry();
            hover.eventID = EventTriggerType.PointerEnter;
            hover.callback.AddListener((eventData) => { OnHoverUI(); });
            uiEvent.triggers.Add(hover);


            EventTrigger.Entry click = new EventTrigger.Entry();
            click.eventID = EventTriggerType.PointerDown;
            click.callback.AddListener((eventData) => { OnClickUI(); });
            uiEvent.triggers.Add(click);

        }
    }


    public void OnHoverUI()
    {
        if(soundManager)
        soundManager.PlaySound(SoundManager.AudioClipType.hoverAC);
    }

    public void OnClickUI()
    {
        if (soundManager)
        soundManager.PlaySound(SoundManager.AudioClipType.selectedAC);
    }

}
