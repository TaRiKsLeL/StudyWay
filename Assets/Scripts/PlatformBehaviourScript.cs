using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] int scoreToUnlock;
    [SerializeField] bool unlocked=false;


    public int GetScoreToUnlock()
    {
        return scoreToUnlock;
    }

    public bool TryToUnlockObstacle(int score)
    {
        if (score >= scoreToUnlock)
        {
            obstacle.SetActive(false);
            unlocked = true;
            return true;
        }
        return false;
    }
}
