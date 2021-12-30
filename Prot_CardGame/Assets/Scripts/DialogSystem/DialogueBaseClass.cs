using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBaseClass : MonoBehaviour
{
    public bool finished { get; protected set; }
    protected IEnumerator WriteText(string name, string inputText, TextMesh textHolder, Font textFont)
    {
        textHolder.font = textFont;

        for (int i = 0; i < inputText.Length; i++)
        {
            textHolder.text += inputText[i];
        }

        yield return null;
    }
}
