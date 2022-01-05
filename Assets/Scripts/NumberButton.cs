using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NumberButton : Selectable, IPointerClickHandler, ISubmitHandler, IPointerUpHandler, IPointerExitHandler
{
    public int _value = 0;

    public void OnPointerClick(PointerEventData _eventData)
    {
        Events.UpdateSquareNumberMethod(_value);
    }

    public void OnSubmit(BaseEventData _eventData)
    {

    }
}
