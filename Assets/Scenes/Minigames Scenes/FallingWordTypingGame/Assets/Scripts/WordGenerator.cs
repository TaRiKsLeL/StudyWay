using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = { "слово", "телефон", "картка","неймовірний","рибалка","готувати","сподіватися", "стіл", "скарб", "надійний", "готувати"
    ,"парк","намагатися","приходити","торт","успіх","автобус","грандіозний","бездоганний","трубка","клавіатура","ніч"};

   public static string GetRandomWord()
    {
        int randomInex = Random.Range(0, wordList.Length);

        string randomWord = wordList[randomInex];
        return randomWord;
    }
}
