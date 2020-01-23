using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StudyWayFinish : MonoBehaviour
{
    GameSession gameSession;
    [SerializeField]
    public Text studyWayFisinshScoreText;

    public int studyWayFinishScore;
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        studyWayFinishScore = gameSession.GetScore();  
        studyWayFisinshScoreText.text = " Вітаєм, тобі вдалось пройти гру!!!\n Твоя загальна кількість балів: "+studyWayFinishScore;
    }


    private void OnTriggerEnter(Collider collision)
    {
        
        SceneManager.LoadScene("StudyWayFinishScene");
    }

}
