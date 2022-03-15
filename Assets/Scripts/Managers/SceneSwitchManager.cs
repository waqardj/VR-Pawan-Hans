using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchManager : Singleton<SceneSwitchManager>
{
   
    private void Start()
    {
        
    }
    public void SwitchScene(int index)
    {
        StartCoroutine(WaitAndLoad(index));
    }
    IEnumerator WaitAndLoad(int index)
    {

        WhiteScreen.instance.FadeIn(0f);
        
        //CameraFade.instance.FadeIn();
        yield return new WaitForSeconds(2f);
        AsyncOperation op = SceneManager.LoadSceneAsync(index);
        while (!op.isDone)
        {
            yield return null;
        }
        //print("2");
        //WhiteScreen.instance.FadeOut(0f);

        //CameraFade.instance.FadeOut();

    }
}
