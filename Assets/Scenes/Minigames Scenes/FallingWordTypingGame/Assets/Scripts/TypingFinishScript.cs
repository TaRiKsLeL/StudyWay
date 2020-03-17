using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TypingFinishScript : MonoBehaviour
{
    MiniGameSession gameSession;

    private int typingFinishScore;
    // Start is called before the first frame update
    [SerializeField]
    private Text typingFinishText;
    void Start()
    {
        gameSession = FindObjectOfType<MiniGameSession>(); 
        typingFinishScore = TypingWordManager.score;
        typingFinishText.text = "Кількіст зароблених тобою балів: "+typingFinishScore;
        gameSession.AddToScore(typingFinishScore);
    }

}
