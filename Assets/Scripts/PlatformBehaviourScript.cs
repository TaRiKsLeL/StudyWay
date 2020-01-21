using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlatformBehaviourScript : MonoBehaviour
{
    [SerializeField] public int index;
    [SerializeField] public GameObject obstacle;
    [SerializeField] int scoreToUnlock;
    [SerializeField] bool unlocked=false;

    private void Start()
    {
        print("In PlatformBehaviourScript - Start()");
        
        if (SaveSystem.LoadGameSession() != null)
        {
            GameData data = SaveSystem.LoadGameSession();

            if (data.unlockedObstaclesByTriggerIndex != null)
            {
                if (data.unlockedObstaclesByTriggerIndex.ToList().Contains(index)){ //перевіряю чи мій індекс є в списку розблочених
                    print("My index " + index + " is in List");
                    obstacle.SetActive(false);
                }
            }
        }
    }

    public int GetScoreToUnlock()
    {
        return scoreToUnlock;
    }

    public bool TryToUnlockObstacle(int score)
    {
        print("Score To Unlock:" + scoreToUnlock + "   Score: " + score);

        if (score >= scoreToUnlock)
        {
            unlocked = true;
            return true;
        }
        return false;
    }
}
