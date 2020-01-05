using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[System.Serializable]
public class GameData
{
    public int score;
    public int onTriggerIndex;
    public string onTriggerName;
    public int[] unlockedObstaclesByTriggerIndex;
    public float[] playerPosition;
    public float[] playerRotation;

    public GameData(GameSession gameSession) 
    {
        score = gameSession.GetScore();
        onTriggerName = gameSession.GetOnTriggerName();

        if (gameSession.GetUnlockedObstacles()!=null)
        {
            unlockedObstaclesByTriggerIndex = gameSession.GetUnlockedObstacles().ToArray();
            Debug.Log("In GameData: " + unlockedObstaclesByTriggerIndex.Length);
        }

        playerPosition = new float[3];

        Vector3 position = gameSession.GetPlayerTransform().position;
        playerPosition[0] = position.x;
        playerPosition[1] = position.y;
        playerPosition[2] = position.z;

        playerRotation = new float[4];

        Quaternion quaternion = gameSession.GetPlayerTransform().rotation;
        playerRotation[0] = quaternion.w;
        playerRotation[1] = quaternion.x;
        playerRotation[2] = quaternion.y;
        playerRotation[3] = quaternion.z;
    }

}
