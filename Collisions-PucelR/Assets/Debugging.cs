using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Debugging : MonoBehaviour //Missing monobehaviour!!!
{
    public TMP_Text output;
    public TMP_InputField input;

   public void Hello()
    {
        string userText = input.text;
        output.text = userText;
    }

}
