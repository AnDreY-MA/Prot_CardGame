using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class DialogLine : DialogBaseClass
{
    [SerializeField] [TextArea] private string _inputText;
    [SerializeField] private Color _textColor;
    [SerializeField] private Font _textFont;
    [SerializeField] private float _delay;
    [SerializeField] private float _delayBetweenLines;

    private Text _textHolder;
    private IEnumerator _lineAppear;

    private void OnEnable()
    {
        ResetLine();
        _lineAppear = WriteText(_inputText, _textHolder, _textColor, _textFont, _delay, _delayBetweenLines);
        StartCoroutine(_lineAppear);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_textHolder.text != _inputText)
            {
                StopCoroutine(_lineAppear);
                _textHolder.text = _inputText;
            }
            else
                finished = true;
        }
    }

    private void ResetLine()
    {
        _textHolder = GetComponent<Text>();
        _textHolder.text = "";
        finished = false;
    }
}
