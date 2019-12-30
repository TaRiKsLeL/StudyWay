using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int score;
    public int onTriggerIndex;
    public int[] unlockedObstaclesByTriggerIndex;
    public float[] playerPosition;

    public GameData(GameSession gameSession) 
    {
        score = gameSession.GetScore();

        onTriggerIndex = gameSession.GetOnTriggerIndex();

        if (gameSession.GetUnlockedObstacles()!=null)
        {
            unlockedObstaclesByTriggerIndex = gameSession.GetUnlockedObstacles().ToArray();
        }

        playerPosition = new float[3];
        playerPosition[0] = gameSession.GetPlayerPosition().x;
        playerPosition[1] = gameSession.GetPlayerPosition().y;
        playerPosition[2] = gameSession.GetPlayerPosition().z;
    }

}
