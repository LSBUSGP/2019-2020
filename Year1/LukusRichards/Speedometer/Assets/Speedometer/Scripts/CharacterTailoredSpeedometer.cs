using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterTailoredSpeedometer : MonoBehaviour
{
    private const float maxSpeedAngle = -20;
    private const float zeroSpeedAngle = 210;

    private Transform needleTransform;
    private Transform speedLabelTemplateTransform;

    public Rigidbody2D objectToMeasure;

    public bool disallowBackwards = true;

    private float speedMax;
    private float speed;

    // Start is called before the first frame update
    private void Awake()
    {
        needleTransform = transform.Find("needle");
        speedLabelTemplateTransform = transform.Find("SpeedLabelTemplate");
        speedLabelTemplateTransform.gameObject.SetActive(false);

        speed = 0;
        speedMax = 200f;

        CreateSpeedLabels();
    }

    private void Update()
    {
        HandlePlayerInput();

        // speed += 30f * Time.deltaTime;
        // if (speed > speedMax) speed = speedMax;

        //needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
    }

    private void HandlePlayerInput()
    {
        if(disallowBackwards || Vector3.Dot(objectToMeasure.velocity, objectToMeasure.transform.forward) > 0.0f)
        {
            needleTransform.rotation = Quaternion.Euler(0.0f, 0.0f, -objectToMeasure.velocity.magnitude);
        }

        speed = Mathf.Clamp(speed, 0f, speedMax);
    }

    private void CreateSpeedLabels()
    {
        int labelAmount = 10;
        float totalAngelSize = zeroSpeedAngle - maxSpeedAngle;

        for (int i = 0; i <= labelAmount; i++)
        {
            Transform speedLabelTransform = Instantiate(speedLabelTemplateTransform, transform);
            float labelSpeedNormalisation = (float)i / labelAmount;
            float speedLabelAngel = zeroSpeedAngle - labelSpeedNormalisation * totalAngelSize;
            speedLabelTransform.eulerAngles = new Vector3(0, 0, speedLabelAngel);
            speedLabelTransform.Find("Speed Text").GetComponent<Text>().text = Mathf.RoundToInt(labelSpeedNormalisation * speedMax).ToString();
            speedLabelTransform.Find("Speed Text").eulerAngles = Vector3.zero;
            speedLabelTransform.gameObject.SetActive(true);
        }

        needleTransform.SetAsLastSibling();
    }
}
