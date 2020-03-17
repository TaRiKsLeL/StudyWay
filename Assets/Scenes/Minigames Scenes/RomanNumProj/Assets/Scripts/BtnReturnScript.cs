using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnReturnScript : MonoBehaviour
{
    public void ActivateBtn()
    {
        GetComponent<Button>().interactable = true;
    }
}
