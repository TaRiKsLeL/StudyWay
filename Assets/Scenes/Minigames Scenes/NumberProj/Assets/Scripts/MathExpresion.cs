using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MathExpresion : MonoBehaviour
{
    public enum Operaion
    {
        add = 0, subtract = 1
    }

    string scoreTxt = "РАХУНОК: ";

    bool gameOver = false;
    int score = 0;

    public int diapason;
    public float timeToSolve;
    float currentTimeToSolve;

    int firstArg;
    int secondArg;
    int result;
    int generatedResult;

    Operaion operation;
    Text timeTxt;
    MiniGameSession miniGameSession;

    void Start()
    {
        miniGameSession = GameObject.FindObjectOfType<MiniGameSession>();
        miniGameSession.resetScore();

        timeTxt = GameObject.Find("TimeTxt").GetComponent<Text>();
        createExpression();
    }

    void Update()
    {
        currentTimeToSolve -= Time.deltaTime;

        if (!gameOver)
        {
            timeTxt.text = ((int)currentTimeToSolve).ToString();
        }

        if (currentTimeToSolve <= 0)
        {
            gameOver = true;
            timeTxt.text = "0";
            timeTxt.GetComponent<Animator>().enabled = false;
            FindObjectOfType<BtnReturnScript>().ActivateBtn();

        }
    }

    void refreshTime()
    {
        currentTimeToSolve = timeToSolve;
    }

    public void createExpression()
    {
        if (gameOver)
        {
            return;
        }
        refreshTime();

        firstArg = Random.Range(0, diapason);
        secondArg = Random.Range(0, diapason);
        int rndOperation = Random.Range(0, 2);

        if((Operaion)rndOperation == Operaion.add)
        {
            result = firstArg + secondArg;
            operation = Operaion.add;
        }
        else
        {
            result = firstArg - secondArg;
            operation = Operaion.subtract;
        }

        if (Random.Range(0, 2) == 0)
        {
            generatedResult = Random.Range(0, 40);
        }
        else
        {
            generatedResult = result;
        }

        setTxt();
    }

    void setTxt()
    {
        GameObject.Find("FirstArgTxt").GetComponent<Text>().text = firstArg.ToString();
        GameObject.Find("SecArgTxt").GetComponent<Text>().text = secondArg.ToString();
        GameObject.Find("PossibleResultTxt").GetComponent<Text>().text = generatedResult.ToString();

        string operationStr = "";

        switch (operation)
        {
            case Operaion.add:
                operationStr = "+";
                break;
            case Operaion.subtract:
                operationStr = "-";
                break;
            default:
                break;

        }

        GameObject.Find("OperationTxt").GetComponent<Text>().text = operationStr;
    }

    void correctAnsw()
    {
        score++;
        miniGameSession.AddToScore(1);
        createExpression();
        GameObject.Find("ScoreTxt").GetComponent<Text>().text = score.ToString();

    }

    public void AnswerTrue()
    {
        if(generatedResult == result)
        {
            correctAnsw();
        }
        else
        {
            gameOver = true;
        }
    }
    public void AnswerFalse()
    {
        if (generatedResult != result)
        {
            correctAnsw();
        }
        else
        {
            gameOver = true;
        }
    }
}
