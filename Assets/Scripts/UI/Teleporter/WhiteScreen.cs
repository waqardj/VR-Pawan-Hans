using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteScreen : Singleton<WhiteScreen>
{





    public SpriteRenderer rend;

    public bool showOnStart;
    public float tweenTime = 1f;
    Color oldcol;

    private void Start()
    {
        
        
        rend = GetComponent<SpriteRenderer>();
        oldcol = rend.color;
        if (showOnStart)
        {
            
            FadeOut(1f);

        }
        else
        {
            Color tmp = oldcol;
            tmp.a = 0f;
            rend.color = tmp;
            
        }
            
    }

    

    public void FadeIn(float delay){
        StartCoroutine(PerformEffect(delay,"FADE_IN"));
    }

    public void FadeOut(float delay){
        StartCoroutine(PerformEffect(delay,"FADE_OUT"));
    }


    IEnumerator PerformEffect(float delay,string type){
        yield return new WaitForSeconds(delay);
        switch(type){
            case "FADE_IN":
               
                LeanTween.alpha(rend.gameObject,1,tweenTime);
                break;
            case "FADE_OUT":
               
                LeanTween.alpha(rend.gameObject,0,tweenTime);
                break;
        }
            
            
            
    }


}
