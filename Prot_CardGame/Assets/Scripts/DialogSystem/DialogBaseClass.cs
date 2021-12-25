using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogBaseClass : MonoBehaviour
{
    public bool finished { get; protected set; }

    protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont,
                                    float delay, float delayBetweenLines)
    {
        textHolder.color = textColor;
        textHolder.font = textFont;

        for (int i = 0; i < input.Length; i++)
        {
            textHolder.text += input[i];
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        finished = true;
    }
}
