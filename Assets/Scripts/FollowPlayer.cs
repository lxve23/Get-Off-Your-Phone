using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Camera follows Player
    [SerializeField] Transform player;
    [SerializeField] float mouseSpeed = 3;
    [SerializeField] float orbitDamping = 10;

    Vector3 localRotate;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;

        localRotate.x += Input.GetAxis("Mouse X") * mouseSpeed;
        localRotate.y -= Input.GetAxis("Mouse Y") * mouseSpeed;

        localRotate.y = Mathf.Clamp(localRotate.y, -5f, 30f);

        Quaternion qt = Quaternion.Euler(localRotate.y, localRotate.x, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, qt, Time.deltaTime * orbitDamping);
    }
}
