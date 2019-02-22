using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var components = this.gameObject.GetComponentsInChildren<Text>();
        // テキストを文字の状態によって変更するようにします。
        components[0].text = "やり直し！";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButtonTest()
    {
    
        // Textコンポーネント郡を取得します。
        var components = this.gameObject.GetComponentsInChildren<Text>();
        components[0].text = "OK!!";
        Debug.Log("hello");

    }
}
