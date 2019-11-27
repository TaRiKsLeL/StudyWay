
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Player Path Config")]
public class PathConfig : ScriptableObject
{
    [SerializeField] GameObject pathPrefab;

    public List<Transform> GetWaypoints()
    {

        var waveWaypoints = new List<Transform>();

        foreach (Transform childTransform in pathPrefab.transform)
        {
            waveWaypoints.Add(childTransform);
        }

        return waveWaypoints;

    }
}
