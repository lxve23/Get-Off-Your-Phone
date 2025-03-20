using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 Angles;
    public Transform player;
    public float sensitivityX;
    public float sensitivityY;
    void Update()
    {
        float rotationY = Input.GetAxis("Mouse Y") * sensitivityX;
        player.Rotate(0, Input.GetAxis("Mouse X") * sensitivityY, 0);
        if (rotationY > 0)
        {
            Angles = new Vector3(Mathf.MoveTowards(Angles.x, -90, rotationY), 0);
        }
        else
        {
            Angles = new Vector3(Mathf.MoveTowards(Angles.x, 90, -rotationY), 0);
            transform.localEulerAngles = Angles;
        }
    }

}
