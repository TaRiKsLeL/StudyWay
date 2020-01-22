using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public TypingWordManager typingWordManager;

    void Update()
    {
        foreach(char letter in Input.inputString)
        {
            typingWordManager.TypeLetter(letter);
        }
    }
}
