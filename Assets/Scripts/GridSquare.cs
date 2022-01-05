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
    public int _correctNumber = 0;

    private bool _selected = false;
    private int _squareIndex = -1;
    private bool _hasDefaultValue = false;

    public void SetHasDefaultValue(bool _hasDefault)
    {
        _hasDefaultValue = _hasDefault;
    }

    public bool GetHasDefaultValue()
    {
        return _hasDefaultValue;
    }

   
    public bool IsSelected() 
    { 
        return _selected; 
    }

    public void SetSquareIndex(int _index)
    {
        _squareIndex = _index;
    }

    public void SetCorrectNumber(int _inputNumber)
    {
        _correctNumber = _inputNumber;
    }

    private void Start()
    {
        _selected = false;
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
        if (_selected && _hasDefaultValue == false)
        {
            SetNumber(_inputNumber);
            if (_inputNumber != _correctNumber)
            {
                var _colors = this.colors;
                _colors.normalColor = Color.red;
                this.colors = _colors;

                Events.OnWrongNumberMethod();
            }
            else
            {
                _hasDefaultValue = true;
                var _colors = this.colors;
                _colors.normalColor = Color.white;
                this.colors = _colors;
            }
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
