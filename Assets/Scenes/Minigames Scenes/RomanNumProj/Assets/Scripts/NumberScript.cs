﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NumberScript : MonoBehaviour
{
    bool inCell;

    public NumberController.RomanNum value;

    Vector2 startPosition;
    Vector2 deltaMouse;

    Collider2D lastCollided;
    MiniGameSession gameSession;
    NumberController numberController;
    //RetrunBtn retrunBtn;


    // Start is called before the first frame update
    void Start()
    {

        gameSession = FindObjectOfType<MiniGameSession>();
        startPosition = transform.position;
    }


    private void OnMouseDown()
    {
        Debug.Log("mouse pressed");

        if (inCell)
        {
            transform.position = startPosition;
            inCell = false;
        }


        deltaMouse = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y);

    }

    private void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePos.x - deltaMouse.x, mousePos.y - deltaMouse.y);
    }

    private void OnMouseUp()
    {
        if (inCell)
        {
            transform.position = lastCollided.transform.position;

            BorderScript script = lastCollided.GetComponent<BorderScript>();

            numberController = GameObject.Find("NumberController").GetComponent<NumberController>();

            bool[] correctAnsw = numberController.correctAnswers;


            if (value == script.correctValue)
                correctAnsw[script.index] = true;
            else
                correctAnsw[script.index] = false;

            int numOfCorrect = 0;

            foreach(bool tmp in correctAnsw)
            {
                if (tmp)
                    numOfCorrect++;
            }

            if(numOfCorrect == correctAnsw.Length)
            {
                gameSession.AddToScore(10);

                numberController.removeAll();

                if (numberController.gameEnded)
                {
                   FindObjectOfType<BtnReturnScript>().ActivateBtn();
                }
                else
                {
                    numberController.AddNumbersSpr();
                }
                Debug.Log("you win");
            }


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lastCollided = collision;
        inCell = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inCell = false;
    }
}
