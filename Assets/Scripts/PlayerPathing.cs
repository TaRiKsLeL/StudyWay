using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathing : MonoBehaviour
{
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float m_Speed = 1f;
    List<Transform> wayPoints;
    Rigidbody m_Rigidbody;
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        wayPoints = GetWaypoints();
        //transform.position = ;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Move();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Move();
        }


    }

    private void Move()
    {
        if (waypointIndex <= wayPoints.Count - 1)
        {

            var targetPosition = wayPoints[waypointIndex].transform.position;
            var movementThisFrame = m_Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if(Vector3.Distance(wayPoints[waypointIndex].transform.position,transform.position)<1)
             {
                    waypointIndex++;
                    print(waypointIndex);
             }

        }
    }


    List<Transform> GetWaypoints()
    {

        var waveWaypoints = new List<Transform>();

        foreach (Transform childTransform in pathPrefab.transform)
        {
           // childTransform.position = new Vector3(childTransform.position.x,gameObject.transform.position.y,childTransform.position.z);
            waveWaypoints.Add(childTransform);
        }

        return waveWaypoints;

    }
}


public static class IComparableExtension
{
    public static bool InRange<T>(this T value, T from, T to) where T : System.IComparable<T>
    {
        return value.CompareTo(from) >= 1 && value.CompareTo(to) <= -1;
    }
}