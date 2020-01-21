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
        }

        if (SaveSystem.LoadGameSession() == null)  //ставлю зайця на початкову позицію
        {
            Instantiate(playerObject, basePlayerPosition, Quaternion.identity);

        }
        else
        {
            this.LoadGameSession();
            SaveGameSession();
        }
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

        Destroy(FindObjectOfType<MiniGameSession>());
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

    public Transform GetPlayerTransform() // для збереження даних
    {
        return GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
