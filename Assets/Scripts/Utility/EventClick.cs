using UnityEngine;
using UnityEngine.EventSystems;

public abstract class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.LogWarning("On pointer down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.LogWarning("On pointer up");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.LogWarning("On pointer click");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.LogWarning("On pointer exit");
    }
}
