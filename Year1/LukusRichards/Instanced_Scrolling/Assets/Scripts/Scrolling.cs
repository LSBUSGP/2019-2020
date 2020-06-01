using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float scrollY = 0.1f;
    float offSetY = 0.0f;
    Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offSetY += Time.deltaTime * scrollY;
        material.mainTextureOffset = new Vector2(0, offSetY);
    }

    private void OnDestroy()
    {
        Destroy(material);
    }
}
