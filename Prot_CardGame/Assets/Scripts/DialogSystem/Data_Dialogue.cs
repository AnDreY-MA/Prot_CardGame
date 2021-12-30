using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Datas", fileName = "New String Dialogue")]
public class Data_Dialogue : ScriptableObject
{
    public string nameCharacter;
    [TextArea] public  string _inputText;
}
