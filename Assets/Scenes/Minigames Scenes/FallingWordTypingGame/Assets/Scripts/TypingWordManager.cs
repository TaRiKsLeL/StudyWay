using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypingWordManager : MonoBehaviour
{
    public List<Word> words;

    public WordSpawner wordSpawner;

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    public static int score ;
    private float timer = 60f;
    public bool hasActiveWord;
    private Word activeWord;
    [SerializeField]
    public Text scoreInfo;
    [SerializeField]
    public Text timeInfo;
    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
        words.Add(word);
    }

    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach(Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }
        if(hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
            score++;
            scoreInfo.text = "Бали: " + score;
            MusicSource.Play();
        }

    }
    public Word GetActiveWord()
    {
        return activeWord;
    }
    public List<Word> GetListOfWord()
    {
        return words;   
    }

    public Word GetWordByText(string text)
    {
        foreach(Word word in words)
        {
            if (word.word.Equals(text))
            {
                print("Getting " + word.word);
                return word;
            }
        }

        return null;
    }

    private void Start()
    {
        score = 0;
        StartCoroutine("TimeRemain");
    }

    IEnumerator TimeRemain()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timer--;
            timeInfo.text = "Час: " + timer;
            if (timer == 0)
            {
                TypingGameFinsh();
            }
        }
    }
   public void TypingGameFinsh()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("TypingGameFinsh");
    }
}
