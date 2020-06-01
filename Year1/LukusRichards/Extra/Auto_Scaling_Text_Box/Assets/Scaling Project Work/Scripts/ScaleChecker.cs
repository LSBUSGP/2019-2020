using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScaleChecker : MonoBehaviour
{
    private Text text;
    private TextMeshProUGUI textMP;

    private RectTransform rectTrans;

   // public Image backgroundImage;

   // public VerticalLayoutGroup vLG;
  //  public LayoutElement layoutElem;

    void Awake()
    {
        rectTrans = gameObject.GetComponent<RectTransform>();

      /*  backgroundImage = gameObject.GetComponent<Image>();

        vLG = gameObject.GetComponent<VerticalLayoutGroup>();

        layoutElem = gameObject.GetComponent<LayoutElement>(); */
    }

    IEnumerator Start()
    {
        float widthMin = 100f;
        float widthMax = 700f;
        float width = widthMin;
        float delta = 10f;

        while (true)
        {
            if (width > widthMax) delta = -delta;
            if (width < widthMin) delta = -delta;

            width += delta;

            rectTrans.sizeDelta = new Vector2(width, 160f);

            yield return null;
        }
    }
}
