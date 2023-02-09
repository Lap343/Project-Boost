using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float xRotationSpeed = 1;
    [SerializeField] float yRotationSpeed = 1;
    [SerializeField] float zRotationSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRotationSpeed, yRotationSpeed, zRotationSpeed);
    }
}
