using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
        //    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5);
            print("kek");
        }
        
    }
}
