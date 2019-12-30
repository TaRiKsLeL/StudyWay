using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameSession : MonoBehaviour
{

    [SerializeField] int score;
    [SerializeField] GameObject playerObject;
    [SerializeField] Vector3 basePlayerPosition;
    [SerializeField] List<GameObject> miniGameTriggers;
    private int onTriggerIndex;
    private List<int> unlockedObstaclesByTriggerIndex;

    private void Awake()
    {
        SetUpSingleton();

        if (SaveSystem.LoadGameSession() == null)
        {
            Instantiate(playerObject, basePlayerPosition, Quaternion.identity);
        }
        else
        {
            GameData data = SaveSystem.LoadGameSession();

            Vector3 playerPosition;
            playerPosition.x = data.playerPosition[0];
            playerPosition.y = data.playerPosition[1];
            playerPosition.z = data.playerPosition[2];
            Instantiate(playerObject, playerPosition, Quaternion.identity);
        }

        
        //InitTriggers();
    }

    

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }
    }

    public void SaveGameSession()
    {
        SaveSystem.SaveGameSession(this);
    }

    public void LoadGameSession()
    {
        GameData data = SaveSystem.LoadGameSession();

        score = data.score;

        if (data.unlockedObstaclesByTriggerIndex!=null)
        {
            unlockedObstaclesByTriggerIndex = data.unlockedObstaclesByTriggerIndex.ToList();
        }

        AddToScore(FindObjectOfType<MiniGameSession>().GetScore());

        print("In LoadGameSes : added score");

        if (miniGameTriggers[data.onTriggerIndex].GetComponent<PlatformBehaviourScript>().
            TryToUnlockObstacle(FindObjectOfType<MiniGameSession>().GetScore()))
        {
            print("In LoadGameSes : unlocked");

            unlockedObstaclesByTriggerIndex.Add(data.onTriggerIndex);
        }
    }

    //private void InitTriggers()
    //{
    //    triggers = new List<Transform>();


    //    foreach (Transform childTransform in miniGameTriggers.transform)
    //    {
    //        triggers.Add(childTransform);
    //    }
    //}

    //public List<Transform> GetTriggers()
    //{
    //    return triggers;
    //}

    public int GetOnTriggerIndex()
    {
        return onTriggerIndex;
    }

    public void SetOnTriggerIndex(int index)
    {
        onTriggerIndex = index;
    }

    public int GetTriggerIndex(GameObject gameObj)
    {
        int i = 0;
        foreach(GameObject t in miniGameTriggers)
        {
            if (t == gameObj)
            {
                return i;
            }
            i++;
        }
        return -1;
    }

    public List<int> GetUnlockedObstacles()
    {
        return unlockedObstaclesByTriggerIndex;
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreVal)
    {
        score += scoreVal;
    }

    public Vector3 GetPlayerPosition()
    {
        return GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
