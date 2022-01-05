using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Events : MonoBehaviour
{
    //public delegate void UpdateSquareNumber(int _number);
    //public static event UpdateSquareNumber OnUpdateSquareNumber;
    public static event Action<int> OnUpdateSquareNumber;

    public static void UpdateSquareNumberMethod(int _number)
    {
        if (OnUpdateSquareNumber != null)
            OnUpdateSquareNumber(_number);
    }

    //public delegate void SquareSelected(int _squareIndex);
    //public static event SquareSelected OnSquareSelected;
    public static event Action<int> OnSquareSelected;
    public static void SquareSelectedMethod(int _squareIndex)
    {
        if (OnSquareSelected != null)
            OnSquareSelected(_squareIndex);
    }

    //public delegate void WrongNumber();
    //public static event WrongNumber OnWrongNumber;
    public static event Action OnWrongNumber;

    public static void OnWrongNumberMethod()
    {
        if (OnWrongNumber != null)
            OnWrongNumber();
    }
}
