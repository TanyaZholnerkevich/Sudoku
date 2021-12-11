using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public delegate void UpdateSquareNumber(int _number);
    public static event UpdateSquareNumber OnUpdateSquareNumber;

    public static void UpdateSquareNumberMethod(int _number)
    {
        if (OnUpdateSquareNumber != null)
            OnUpdateSquareNumber(_number);
    }

    public delegate void SquareSelected(int _squareIndex);
    public static event SquareSelected OnSquareSelected;

    public static void SquareSelectedMethod(int _squareIndex)
    {
        if (OnSquareSelected != null)
            OnSquareSelected(_squareIndex);
    }
}
