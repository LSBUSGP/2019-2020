using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoSizer : MonoBehaviour
{
    public TextMeshProUGUI textBox;

    void Start()
    {
        SetSize();
    }

    void SetSize()
    {
        int textLength = textBox.text.Length;
        int width = textLength * 22;        

        textBox.rectTransform.sizeDelta = new Vector2(width, 50);
    }
}
