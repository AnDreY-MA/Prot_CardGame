using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueTextCard : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] [TextArea] private string _inputText;
    [SerializeField] private Font _fontText;
    [SerializeField] private Text _nameBlock;
    [SerializeField] private Text _textBlock;

    private bool _isFinished;
    public bool IsFinished => _isFinished;

    private void OnEnable()
    {
        _isFinished = false;
        _nameBlock.text = _name;
        _textBlock.text = _inputText;
    }

    public DialogueTextCard(string name, string inputText)
    {
        _name = name;
        _inputText = inputText;
    }
}
