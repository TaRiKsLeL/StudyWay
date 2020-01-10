﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] GameObject pathPrefab;
    [SerializeField] float m_Speed = 1f;
    //List<Transform> wayPoints;
    Rigidbody m_Rigidbody;
    Animator anim;

    int waypointIndex = 0;


    bool onMove=false;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();


        //wayPoints = GetWaypoints();

    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    //Move(true);
        //    transform.position = new Vector3(0, 0, transform.position.z + m_Speed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    //Move(false);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Rotate(Vector3.up * 7*m_Speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Rotate(Vector3.down *7 *m_Speed * Time.deltaTime);
        //}


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * 7 * m_Speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * 7 * m_Speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward* m_Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * m_Speed * Time.deltaTime;
        }

        if (Input.anyKeyDown)
        {
           // onMove = true;
            Move_Ani();
        }
        else
        {
            //onMove = false;
            Idle_Ani();
        }

    }

    //private void Move(bool forward)
    //{
    //    if (waypointIndex <= wayPoints.Count - 1 || waypointIndex >= 0)
    //    {
            
    //            var targetPosition = wayPoints[waypointIndex].transform.position;
    //            var movementThisFrame = m_Speed * Time.deltaTime;

    //        if (forward)
    //        {
    //                transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

    //                if (Vector3.Distance(wayPoints[waypointIndex].transform.position, transform.position) < 1)
    //                {
    //                    waypointIndex++;
    //                    print(waypointIndex);
    //                }
    //            }
    //        else
    //        {
    //            targetPosition = wayPoints[waypointIndex-1].transform.position;
    //            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

    //            if (Vector3.Distance(wayPoints[waypointIndex-1].transform.position, transform.position) < 1)
    //            {
    //                waypointIndex--;
    //                print(waypointIndex);
    //            }

    //        }
            

    //    }
    //}

    public void Idle_Ani()
    {
        if (!anim.GetBool("Idle"))
        {
            print("Set Idle");
            anim.SetTrigger("Idle");
        }
    }

    public void Move_Ani()
    {
        if (!anim.GetBool("Move"))
        {
            print("Set Move");
            anim.SetTrigger("Move");
        }
    }

    public void Damage_Ani()
    {
        anim.SetTrigger("Damage");
    }

    public void Death_Ani()
    {
        anim.SetTrigger("Death");
    }


//    List<Transform> GetWaypoints()
//    {

//        var waveWaypoints = new List<Transform>();

//        foreach (Transform childTransform in pathPrefab.transform)
//        {
//            waveWaypoints.Add(childTransform);
//        }

//        return waveWaypoints;

//    }

}


//public static class IComparableExtension
//{
//    public static bool InRange<T>(this T value, T from, T to) where T : System.IComparable<T>
//    {
//        return value.CompareTo(from) >= 1 && value.CompareTo(to) <= -1;
//    }
//}