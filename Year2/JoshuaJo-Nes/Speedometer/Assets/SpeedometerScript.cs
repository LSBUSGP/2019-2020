using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedometerScript : MonoBehaviour
{
    public GameObject objectToMeasure;
    public float objectSpeed;
    public float objectSpeedMPH;
    public float speedMax;

    public Transform needleTranform;
    private const float MAX_SPEED_ANGLE = -20;
    private const float ZERO_SPEED_ANGLE = 230;
    public Text speedText;

    private void Start()
    {
        speedMax = objectToMeasure.GetComponent<CubeMovementController>().maxSpeed;
    }

    void Update()
    {
        objectSpeed = objectToMeasure.GetComponent<Rigidbody>().velocity.z;
        objectSpeedMPH = (((objectToMeasure.GetComponent<Rigidbody>().velocity.z / 1000) * 60) * 60) * 0.621371f;

        needleTranform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
        speedText.text = Mathf.Round(objectSpeedMPH).ToString() + " MPH";
    }

    private float GetSpeedRotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalized = objectSpeedMPH / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }
}
