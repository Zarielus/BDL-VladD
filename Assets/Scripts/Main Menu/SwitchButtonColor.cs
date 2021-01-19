
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwitchButtonColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image _image;
    private Color _startColor;

    //-------------------------------------------------------------
    void Start()
    {
        _image = GetComponent<Image>();
        _startColor = _image.color;
    }

    void Update()
    {
        
    }
    //-------------------------------------------------------------

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        _image.color = new Color(0.6132076f, 0.08966714f, 0.08966714f, 1f);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        _image.color = _startColor;
    }

}
