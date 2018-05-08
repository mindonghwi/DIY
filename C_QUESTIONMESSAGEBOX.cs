using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_QUESTIONMESSAGEBOX : MonoBehaviour {

    public void setQuestionBox()
    {
        gameObject.SetActive(true);
    }
    public void CloseQuestionBox()
    {
        gameObject.SetActive(false);
    }
}
