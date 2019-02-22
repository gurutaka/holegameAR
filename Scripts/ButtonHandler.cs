using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
    }

    public void OnClick()
    {
        GameObject GameDirector = GameObject.Find("Game");
        var HolePlacer = GameDirector.GetComponent<HolePlacer>();

        var components = this.gameObject.GetComponentsInChildren<Text>();
        if (HolePlacer.isStarted)
        {
            HolePlacer.isStarted = false;
            components[0].text = "スタート！";
            HolePlacer.Reset();
        }
        else
        {
            HolePlacer.isStarted = true;
            components[0].text = "やり直し！";
        }


    }
}