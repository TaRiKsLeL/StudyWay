using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;
    private Question currentQuestion;

    public static int score = 0;
    public static int countOfQuestion = 0;
    

    [SerializeField]
    private Text factText;

    [SerializeField]
    private Text infoScore;


    [SerializeField]
    private Text questionsCount;

    [SerializeField]
    private float timeBetweenQuestions = 1.0f;

    MiniGameSession gameSession;

    public AudioClip MusicClipTrue;
    public AudioClip MusicClipFalse;

    public AudioSource MusicSourceTrue;
    public AudioSource MusicSourceFalse;

    void Start ()
    {
        score = 0;
        countOfQuestion = 0;
        infoScore.text = "Бали: " + score + "/10";
        questionsCount.text = "Питання №: " + countOfQuestion + "/10";
        unansweredQuestions = null;

        if (unansweredQuestions == null || unansweredQuestions.Count==0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
            
        setCurrentQuestion();

        gameSession = FindObjectOfType<MiniGameSession>();

        MusicSourceTrue.clip = MusicClipTrue;
        MusicSourceFalse.clip = MusicClipFalse;

    }  
    void setCurrentQuestion()
    {
        int randomIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomIndex];

        factText.text = currentQuestion.fact;       
    }

    //IEnumerator TransitionToNextQuestion()
    //{
    //    unansweredQuestions.Remove(currentQuestion);

    //    yield return new WaitForSeconds(timeBetweenQuestions);

    //    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    public void selectTrue()
    {
        countOfQuestion++;
        if (currentQuestion.isTrue)
        {
            Debug.Log("CORRECT!!!");
            score++;
            MusicSourceTrue.Play();

        }
        else
        {
            Debug.Log("WRONG!!!");
            MusicSourceFalse.Play();
        }
        questionsCount.text = "Питання №: " + countOfQuestion + "/10";
        infoScore.text = "Бали:" + score + "/10";
        if (unansweredQuestions.Count != 0)
        {
            unansweredQuestions.Remove(currentQuestion);
            setCurrentQuestion();
        }
        else
        {
            finish();
        }
        // StartCoroutine(TransitionToNextQuestion());
    }

    public void selectFalse()
    {
        countOfQuestion++;

        if (!currentQuestion.isTrue)
        {
            Debug.Log("CORRECT!!!");
            score++;
            MusicSourceTrue.Play();
        }
        else
        {
            Debug.Log("WRONG!!!");
            MusicSourceFalse.Play();
        }

        questionsCount.text = "Питання №: " + countOfQuestion + "/10";
        infoScore.text = "Бали:" + score + "/10";
        if (unansweredQuestions.Count != 0)
        {
            unansweredQuestions.Remove(currentQuestion);
            setCurrentQuestion();
        }
        else
        {
            finish();
        }
        //StartCoroutine(TransitionToNextQuestion());
    }

    private void Update()
    {
       
        if (countOfQuestion == 10)
        {
            finish();
        }
    }
    void finish()
    {
        StopAllCoroutines();
        
       gameSession.AddToScore(score);
        SceneManager.LoadScene(4);
    }
}
