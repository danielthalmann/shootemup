using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Info : MonoBehaviour
{
    private TMP_Text m_TextComponent;

    // Start is called before the first frame update
    void Start()
    {
        m_TextComponent = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        string text = Screen.width + " x " + Screen.height;
        Vector2 v = CameraUtils.GetScreenToWorld();
        text += " " + v.x + " x " + v.y;
        m_TextComponent.text = text;
        
    }
}
