using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCUIDisplay : MonoBehaviour
{
    [SerializeField] Text capitalText;
    [SerializeField] Text amountLoseText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Text GetCapitalText()
    {
        return capitalText;
    }

    public void SetCapitalText(string text)
    {
        capitalText.text = text;
    }

    public Text GetAmountLose()
    {
        return amountLoseText;
    }

    public void SetAmoutLoseText(string text)
    {
        amountLoseText.text = text;
    }
}
