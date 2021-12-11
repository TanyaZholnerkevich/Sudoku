using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GridSquare : Selectable, IPointerClickHandler, ISubmitHandler, IPointerUpHandler, IPointerExitHandler
{
    public GameObject _numberText;
    public int _number;

    private bool _selected = false;
    private int _squareIndex = -1;
   
    public bool IsSelected() { return _selected; }
    public void SetSquareIndex(int _index)
    {
        _squareIndex = _index;
    }

    protected override void Start()
    {
        _selected = false;
    }

    void Update()
    {
        
    }

    public void DisplayText()
    {
        if (_number == 0)
            _numberText.GetComponent<Text>().text = "";
        else
            _numberText.GetComponent<Text>().text = _number.ToString();
    }

    public void SetNumber(int _inputNumber)
    {
        _number = _inputNumber;

        DisplayText();
    }

    public void OnPointerClick(PointerEventData _eventData)
    {
        _selected = true;
        Events.SquareSelectedMethod(_squareIndex);
    }

    public void OnSubmit(BaseEventData _eventData)
    {

    }

    private void OnEnable()
    {
        Events.OnUpdateSquareNumber += OnSetNumber;
        Events.OnSquareSelected += OnSquareSelected;
    }

    private void OnDisable()
    {
        Events.OnUpdateSquareNumber -= OnSetNumber;
        Events.OnSquareSelected -= OnSquareSelected;
    }

    public void OnSetNumber(int _inputNumber)
    {
        if (_selected)
        {
            SetNumber(_inputNumber);
        }
    }

    public void OnSquareSelected(int _inputSquareIndex)
    {
        if(_squareIndex != _inputSquareIndex)
        {
            _selected = false;
        }
    }
}
