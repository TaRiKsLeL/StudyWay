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
    [SerializeField] Quaternion basePlayerQuaternion;

    string onTriggerName;
    private List<int> unlockedObstaclesByTriggerIndex;

    public void Awake()
    {
        SetUpSingleton();

        if (unlockedObstaclesByTriggerIndex == null)
        {
            unlockedObstaclesByTriggerIndex = new List<int>();
            print("I'm nulling List");
        }
        //else
        //{
        //    unlockedObstaclesByTriggerIndex = SaveSystem.LoadGameSession().unlockedObstaclesByTriggerIndex.ToList();
        //    print("I'm pulling saved List");
        //}

        print("Game Session: In Awake");

        if (SaveSystem.LoadGameSession() == null)
        {
            Instantiate(playerObject, basePlayerPosition, Quaternion.identity);

            print("Game Session: In Awake -  New Game set up");

        }
        else
        {
            print("Game Session: In Awake  -  Loading data");
            this.LoadGameSession();
            SaveGameSession();

        }
    }

    public void Update()
    {
        //print("unlockedObstaclesByTriggerIndex" + unlockedObstaclesByTriggerIndex.Count());
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

    public void LoadSavedIndexes()
    {
        if (SaveSystem.LoadGameSession() != null)
        {
            unlockedObstaclesByTriggerIndex = SaveSystem.LoadGameSession().unlockedObstaclesByTriggerIndex.ToList();
        }
    }

    public void LoadGameSession()
    {
        GameData data = SaveSystem.LoadGameSession();
        InstantiatePlayer(data);

        score = data.score;
        AddToScore(FindObjectOfType<MiniGameSession>().GetScore());
        print("Game Session: In LoadGameSession : added score");

        if (data.unlockedObstaclesByTriggerIndex != null)
        {
            unlockedObstaclesByTriggerIndex = data.unlockedObstaclesByTriggerIndex.ToList();
            print(unlockedObstaclesByTriggerIndex.Count());
        }

        print(data.onTriggerName);

        if (GameObject.Find(data.onTriggerName).GetComponent<PlatformBehaviourScript>() != null) 
        {
            if (GameObject.Find(data.onTriggerName).
            GetComponent<PlatformBehaviourScript>().
            TryToUnlockObstacle(FindObjectOfType<MiniGameSession>().GetScore()))
            {
                print("Game Session: In LoadGameSession : unlocked");

                unlockedObstaclesByTriggerIndex.Add(
                    GameObject.Find(data.onTriggerName).
                    GetComponent<PlatformBehaviourScript>().index);

                print("Added index: " + GameObject.Find(data.onTriggerName).GetComponent<PlatformBehaviourScript>().index);
                print(unlockedObstaclesByTriggerIndex.Count());
            }
        }
    }

    private void InstantiatePlayer(GameData data)
    {
        Vector3 playerPosition;
        playerPosition.x = data.playerPosition[0];
        playerPosition.y = data.playerPosition[1];
        playerPosition.z = data.playerPosition[2];

        Quaternion playerRotation;
        playerRotation.w = data.playerRotation[0];
        playerRotation.x = data.playerRotation[1];
        playerRotation.y = data.playerRotation[2];
        playerRotation.z = data.playerRotation[3];

        Instantiate(playerObject, playerPosition, playerRotation);
    }

    public string GetOnTriggerName()
    {
        return onTriggerName;
    }

    public void SetOnTriggerName(string name)
    {
        onTriggerName = name;
    }


    //public int GetTriggerIndex(GameObject gameObj)
    //{
    //    int i = 0;
    //    foreach(GameObject t in miniGameTriggers)
    //    {
    //        if (t == gameObj)
    //        {
    //            return i;
    //        }
    //        i++;
    //    }
    //    return -1;
    //}

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

    public Transform GetPlayerTransform()
    {
        return GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
