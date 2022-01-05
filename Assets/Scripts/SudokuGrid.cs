using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuGrid : MonoBehaviour
{
    public int _rows = 0;
    public int _columns = 0;
    public float _squareOffset = 0.0f;
    public float _squareScale = 1.0f;
    public float _squareGap = 0.1f;
    public GameObject _gridSquare;
    public Vector2 _startPosition = new Vector2(0.0f, 0.0f);
    private int _selectedGridData = -1;

    private List<GameObject> _gridSquares = new List<GameObject>();
    
    void Start()
    {
        if (_gridSquare.GetComponent<GridSquare>() == null)
            Debug.LogError("Error");

        CreateGrid();
        SetGridNumber(GameSettings.Instance.GetGameMode());
    }
    private void CreateGrid()
    {
        SpawnGridSquares();
        SetSquarePosition();
    }

    private void SpawnGridSquares()
    {
        int _squareIndex = 0;
        for(int row = 0; row < _rows; row++)
            for(int column = 0; column < _columns; column++)
            {
                _gridSquares.Add(Instantiate(_gridSquare) as GameObject);
                _gridSquares[_gridSquares.Count - 1].GetComponent<GridSquare>().SetSquareIndex(_squareIndex);
                _gridSquares[_gridSquares.Count - 1].transform.SetParent(transform);
                _gridSquares[_gridSquares.Count - 1].transform.localScale = new Vector3(_squareScale, _squareScale, _squareScale);

                _squareIndex++;
            }
    }

    private void SetSquarePosition()
    {
        var _squareRectangle = _gridSquares[0].GetComponent<RectTransform>();
        Vector2 offset = new Vector2();
        Vector2 _squareGapNumber = new Vector2(0.0f, 0.0f);
        bool _rowMoved = false;

        offset.x = _squareRectangle.rect.width * _squareRectangle.transform.localScale.x + _squareOffset;
        offset.y = _squareRectangle.rect.height * _squareRectangle.transform.localScale.y + _squareOffset;

        int _columnNumber = 0;
        int _rowNumber = 0;

        foreach(GameObject _square in _gridSquares)
        {
            if(_columnNumber + 1 > _columns)
            {
                _rowNumber ++;
                _columnNumber = 0;
                _squareGapNumber.x = 0;
                _rowMoved = false;
            }
            var _posXOffset = offset.x * _columnNumber + (_squareGapNumber.x*_squareGap);
            var _posYOffset = offset.y * _rowNumber + (_squareGapNumber.y * _squareGap);

            if(_columnNumber > 0 && _columnNumber % 3 == 0)
            {
                _squareGapNumber.x++;
                _posXOffset += _squareGap;
            }
            if (_rowNumber > 0 && _rowNumber % 3 == 0 && _rowMoved == false)
            {
                _rowMoved = true;
                _squareGapNumber.y++;
                _posYOffset += _squareGap;
            }

            _square.GetComponent<RectTransform>().anchoredPosition = new Vector2(_startPosition.x + _posXOffset, _startPosition.y - _posYOffset);
            _columnNumber++;
        }
    }

    private void SetGridNumber(string _level)
    {
        _selectedGridData = Random.Range(0, SudokuData.Instance._sudokuGame[_level].Count);
        var _data = SudokuData.Instance._sudokuGame[_level][_selectedGridData];
        SetGridSquareData(_data);
    }
    private void SetGridSquareData(SudokuData.SudokuBoardData _data)
    {
        for(int i = 0; i < _gridSquares.Count; i++)
        {
            _gridSquares[i].GetComponent<GridSquare>().SetNumber(_data._unsolvedData[i]);
            _gridSquares[i].GetComponent<GridSquare>().SetCorrectNumber(_data._solvedData[i]);
            _gridSquares[i].GetComponent<GridSquare>().SetHasDefaultValue(_data._unsolvedData[i] != 0 && _data._unsolvedData[i] == _data._solvedData[i]);
        }
    }
}
