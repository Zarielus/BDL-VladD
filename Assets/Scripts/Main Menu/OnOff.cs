using UnityEngine;
using UnityEngine.UI;

public class OnOff : MonoBehaviour
{
    public Image[] SwitchText;
    private Image _text;

    private void OnMouseDown()
    {
        if (_text == SwitchText[0])
            _text = SwitchText[1];
        else _text = SwitchText[0];
    }
}
