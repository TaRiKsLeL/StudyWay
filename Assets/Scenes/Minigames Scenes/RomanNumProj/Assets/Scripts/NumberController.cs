﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberController : MonoBehaviour
{
    public bool gameEnded = false;

    public float numShiftX;
    public float numStartX;
    public float numY;

    public float answerShiftX;
    public float answerStartX;
    public float answerY;

    public float gameDuration;


    public List<RomanNum> correctRomanNum;
    public List<GameObject> numObj;
    public List<GameObject> createdNums;
    public List<GameObject> createdBorders;
   
    MiniGameSession gameSession;

    public bool[] correctAnswers;
    private int number;

    public enum RomanNum
    {
        I, IV, V, IX, X, Cell
    }

    void Start()
    {
        gameSession = FindObjectOfType<MiniGameSession>();
        gameSession.resetScore();

        Debug.Log("on start");
        AddNumbersSpr();
    }

    void Update()
    {
        Debug.Log(gameDuration);
        gameDuration -= Time.deltaTime;

        if (gameDuration <= 0.0f)
        {
            Debug.Log("ha ha time over");
            timerEnded();
        }

    }
    void timerEnded()
    {
        gameEnded = true;
    }

    public void AddNumbersSpr()
    {
        float currentNumX = numStartX;
        float currentAnswerX = answerStartX;

        GenerateNumber();

        int loopIter = 0;

        foreach (RomanNum generatedNum in correctRomanNum)
        {
            int extraNumberChance = Random.Range(0, 2);

            if(extraNumberChance == 1)
            {
                createdNums.Add(GameObject.Instantiate(numObj[Random.Range(0, numObj.Count-1)], new Vector2(currentNumX += numShiftX, numY), new Quaternion()));
            }

            //create roman number
            createdNums.Add(GameObject.Instantiate(numObj[(int)generatedNum], new Vector2(currentNumX += numShiftX, numY), new Quaternion()));
            //create cell for number
            BorderScript border = GameObject.Instantiate(numObj[(int)RomanNum.Cell], new Vector2(currentAnswerX += answerShiftX, answerY), new Quaternion())
                .GetComponent<BorderScript>();
            border.correctValue = generatedNum;
            border.index = loopIter;

            createdBorders.Add(border.gameObject);
            
            loopIter++;
        }
    }

    public void removeAll()
    {
        foreach(GameObject gameObjectTmp in createdNums)
        {
            Destroy(gameObjectTmp);
        }
        
        foreach(GameObject gameObjectTmp in createdBorders)
        {
            Destroy(gameObjectTmp);
        }
    }

    public void GenerateNumber()
    {
        number = Random.Range(1, 40);

        correctRomanNum = new List<RomanNum>();

        Debug.Log(number);
        GameObject.FindGameObjectWithTag("NumToEnter").GetComponent<Text>().text = number.ToString();


        while (number != 0)
        {
            if (number >= 10)
            {
                correctRomanNum.Add(RomanNum.X);
                number -= 10;
            }
            else if (number >= 5)
            {
                if (number < 9)
                {
                    correctRomanNum.Add(RomanNum.V);
                    number -= 5;
                }
                else
                {
                    correctRomanNum.Add(RomanNum.IX);
                    number = 0;
                }
            }

            else if (number >= 1)
            {
                if (number < 4)
                {
                    correctRomanNum.Add(RomanNum.I);
                    number -= 1;
                }
                else
                {
                    correctRomanNum.Add(RomanNum.IV);
                    number = 0;
                }
            }
        }

        correctAnswers = new bool[correctRomanNum.Count];

        Debug.Log(number);

        foreach (RomanNum num in correctRomanNum)
        {
            Debug.Log(num);
        }
    }
}
