using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.100f;
    public Vector3 offSet;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offSet;
    }
}
