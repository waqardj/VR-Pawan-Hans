using TMPro;
using UnityEngine;

public class Debugger : Singleton<Debugger>
{
    
    


    private TextMeshProUGUI _logs;

    private void Start()
    {
        _logs = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void AddLog(string content){
        _logs.text += "\n"+content;
    }

}
