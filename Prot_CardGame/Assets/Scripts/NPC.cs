using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class NPC : MonoBehaviour
{
    [SerializeField] private Sprite _image;
    [SerializeField] private DialogueHolder _dialogueHolder;
    [SerializeField] private DialogueTextCard[] _listDialogue;

    private SpriteRenderer _spriteRenderer;

    private void OnEnable() => _dialogueHolder.OnDialogueChange += RemoveDialogue;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _image;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            player.SetDialogue();
            _dialogueHolder.SetDialogue(_image, _listDialogue);
        }
    }

    private void RemoveDialogue() => _dialogueHolder.RemoveDialogue();
}
