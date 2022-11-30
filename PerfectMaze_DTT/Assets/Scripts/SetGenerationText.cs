using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetGenerationText : MonoBehaviour
{
    public static SetGenerationText instance;
    private TMP_Text text;

    private void Awake()
    {
        //singleton
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
        text = GetComponent<TMP_Text>();
    }

    public void SetText(string aText)
    {
        text.text = aText;
    }
}
