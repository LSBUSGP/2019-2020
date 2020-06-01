using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingMaterialScript : MonoBehaviour
{
    public enum vertDirection {
        stationary,
        up,
        down
    };

    public enum horDirection {
        stationary,
        left,
        right
    };

    public vertDirection verticalScrollDirection;
    public float verticalScrollSpeed;

    public horDirection horizontalScrollDirection;
    public float horizontalScrollSpeed;

    Material thisMat;

    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        thisMat = GetComponent<Renderer>().material;

        float x, y;

        switch(verticalScrollDirection)
        {
        case vertDirection.stationary:
            y = 0;
            break;
        case vertDirection.up:
            y = 1;
            break;
        case vertDirection.down:
            y = -1;
            break;
        default:
            print("error");
            y = 0;
            break;
        }

        switch(horizontalScrollDirection)
        {
        case horDirection.stationary:
            x = 0;
            break;
        case horDirection.right:
            x = 1;
            break;
        case horDirection.left:
            x = -1;
            break;
        default:
            print("error");
            x = 0;
            break;
        }

        offset = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        if(offset.x >= 0)
        {
            offset.x += Time.deltaTime * horizontalScrollSpeed;
        }
        else if(offset.x <= 0)
        {
            offset.x -= Time.deltaTime * horizontalScrollSpeed;
        }

        if(offset.y >= 0)
        {
            offset.y += Time.deltaTime * verticalScrollSpeed;
        }
        else if(offset.y <= 0)
        {
            offset.y -= Time.deltaTime * verticalScrollSpeed;
        }

        thisMat.SetTextureOffset("_MainTex", offset);

        GetComponent<Renderer>().material = thisMat;
    }
}
