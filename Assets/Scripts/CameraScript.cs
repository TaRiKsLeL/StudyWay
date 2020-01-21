using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Range(0f,40f)]
    [SerializeField] public float rotationSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            transform.RotateAround(transform.parent.position,Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            transform.RotateAround(transform.parent.position, Vector3.down, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            transform.RotateAround(transform.parent.position, Vector3.back, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            transform.RotateAround(transform.parent.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}