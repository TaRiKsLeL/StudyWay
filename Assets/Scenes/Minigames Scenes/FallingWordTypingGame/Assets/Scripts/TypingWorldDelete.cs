using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingWorldDelete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Deleting" + collision.gameObject.GetComponent<Text>().text);
        FindObjectOfType<TypingWordManager>().hasActiveWord = false;        
        FindObjectOfType<TypingWordManager>().GetListOfWord().Remove(FindObjectOfType<TypingWordManager>().GetActiveWord());
        FindObjectOfType<TypingWordManager>().GetListOfWord().Remove(FindObjectOfType<TypingWordManager>().
            GetWordByText(collision.gameObject.GetComponent<Text>().text));
        Destroy(collision.gameObject);
    }
}
