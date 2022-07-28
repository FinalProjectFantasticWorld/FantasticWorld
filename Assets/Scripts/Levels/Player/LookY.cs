using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [Tooltip("speed Look Y")] [SerializeField] private float rotationSpeed = 1f;

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 rotation = transform.localEulerAngles;
        rotation.x -= mouseY * rotationSpeed;
        transform.localEulerAngles = rotation;
    }
}
