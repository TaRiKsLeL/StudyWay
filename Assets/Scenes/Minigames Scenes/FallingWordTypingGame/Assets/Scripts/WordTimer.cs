using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public TypingWordManager TypingWordManager;
    public float wordDelay = 2.5f;
    private float nextWordTime = 0f;

    private void Update()
    {
        if (Time.time >= nextWordTime)
        {
            TypingWordManager.AddWord();    
            nextWordTime = Time.time + wordDelay;
            wordDelay *= .99f;
        }
    }
}
