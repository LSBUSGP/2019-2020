using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{

    public float scrollingXDirection = 0.5f;
    public float scrollingYDirection = 0.5f;
    public float Speed;
    float offSetX;
    float offSetY;


// Start is called before the first frame update
void Start()
    {
        Speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        if (scrollingXDirection >= 1f)
        {
            scrollingXDirection = 1f;
        }
        if (scrollingYDirection >= 1f)
        {
            scrollingYDirection = 1f;
        }

        if (scrollingXDirection <= -1f)
        {
            scrollingXDirection = -1f;
        }
        if (scrollingYDirection <= -1f)
        {
            scrollingYDirection = -1f;
        }

        offSetX += Time.deltaTime * scrollingXDirection;
        offSetY += Time.deltaTime * scrollingYDirection;

        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offSetX, offSetY) * Speed;

    }
}
