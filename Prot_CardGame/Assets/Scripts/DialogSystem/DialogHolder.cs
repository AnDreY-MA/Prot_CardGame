using System.Collections;
using UnityEngine;

public class DialogHolder : MonoBehaviour
{
    private IEnumerator dialogueSeq;
    private bool dialogueFinished;

    private void OnEnable()
    {
        dialogueSeq = DialogueSequnce();
        StartCoroutine(dialogueSeq);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Deactivate();
            gameObject.SetActive(false);
            StopCoroutine(dialogueSeq);
        }
    }

    private IEnumerator DialogueSequnce()
    {
        if (!dialogueFinished)
        {
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogLine>().finished);
            }
        }
        else
        {
            int index = transform.childCount - 1;
            Deactivate();
            transform.GetChild(index).gameObject.SetActive(true);
            yield return new WaitUntil(() => transform.GetChild(index).GetComponent<DialogLine>().finished);
        }

        dialogueFinished = true;

        gameObject.SetActive(false);
    }

    private void Deactivate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
