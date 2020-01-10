using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] public Transform playerObject;

    [SerializeField] public float distanceFromObject;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 lookOnObject = playerObject.position - transform.position;

        transform.forward = lookOnObject.normalized;

        Vector3 playerLastPosition;
        playerLastPosition = playerObject.position - lookOnObject.normalized * distanceFromObject;

        playerLastPosition.y = playerObject.position.y + distanceFromObject / 2;

        transform.position = playerLastPosition;
        */
    }
}