using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class finishScript : MonoBehaviour
{
    private int finishScore;
    private int questionQuantity;
    [SerializeField]
    private Text finishText;
    // Start is called before the first frame 
    void Start()
    {
        finishScore = GameManager.score;
        questionQuantity = GameManager.countOfQuestion;
           finishText.text = "Твоя кількість правильних відповідей: " 
                + (finishScore) + " з " + questionQuantity + " питань.\n" +
                "Тепер можеш перейти \n до виконань інших завдань";        
        


    }
   
    // Update is called once per frame
    void Update()
    {

    }
}
