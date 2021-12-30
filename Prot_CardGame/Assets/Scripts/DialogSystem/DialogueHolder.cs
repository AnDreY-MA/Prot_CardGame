using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogueHolder : MonoBehaviour
{
    [SerializeField] private Image _playerLeftCharacterImage;
    [SerializeField] private Image _rightCharacterImage;
    [SerializeField] private Transform _placeTextCard;

    [SerializeField] private DialogueTextCard[] _dialogueTextCards;

    private bool _dialogueFinished;
    public bool DialogueFinished => _dialogueFinished;

    public event Action OnDialogueChange;

    private void OnEnable()
    {
        _dialogueFinished = false;
        StartCoroutine(SwitchCardText());
    }

    private IEnumerator SwitchCardText()
    {
        if (_dialogueFinished != true)
        {
            foreach (DialogueTextCard textCard in _dialogueTextCards)
            {
                Instantiate(textCard, _placeTextCard);
                yield return new WaitForSeconds(2f);
            }
        }
        OnDialogueChange?.Invoke();
        _dialogueFinished = true;
    }

    public void SetDialogue(Sprite rightCharacter, DialogueTextCard[] dialogueText)
    {
        _dialogueTextCards = dialogueText;
        _rightCharacterImage.sprite = rightCharacter;
        gameObject.SetActive(true);
    }
    public void RemoveDialogue()
    {
        _dialogueTextCards = null;
        gameObject.SetActive(false);
    }
}
