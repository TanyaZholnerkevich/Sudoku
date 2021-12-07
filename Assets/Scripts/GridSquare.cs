using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSquare : Selectable
{
    public GameObject _numberText;
    public int _number; 

    
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
}
