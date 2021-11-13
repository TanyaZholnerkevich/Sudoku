using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuGrid : MonoBehaviour
{
    public int _rows = 0;
    public int _columns = 0;
    public float _squareOffset = 0.0f;
    public float _squareScale = 1.0f;
    public GameObject _gridSquare;
    public Vector2 _startPosition = new Vector2(0.0f, 0.0f);
    private List<GameObject> _gridSquares = new List<GameObject>();
    
    void Start()
    {
        if (_gridSquare.GetComponent<GridSquare>() == null)
            Debug.LogError("Error");
    }

    void Update()
    {
        
    }
    private void CreateGrid()
    {
        SpawnGridSquares();
        SetSquarePosition();
    }

    private void SpawnGridSquares()
    {
        for(int row = 0; row < _rows; row++)
            for(int column = 0; column < _columns; column++)
            {
                _gridSquares.Add(Instantiate(_gridSquare) as GameObject);
                _gridSquares[_gridSquares.Count - 1].transform.parent = this.transform;
                _gridSquares[_gridSquares.Count - 1].transform.localScale = new Vector3(_squareScale, _squareScale, _squareScale);
            }
    }

    private void SetSquarePosition()
    {
        var _squareRectangle = _gridSquares[0].GetComponent<RectTransform>();
        Vector2 offset = new Vector2();
        offset.x = _squareRectangle.rect.width * _squareRectangle.transform.localScale.x + _squareOffset;
        offset.y = _squareRectangle.rect.height * _squareRectangle.transform.localScale.y + _squareOffset;

        int _columnNumber = 0;
        int _rowNumber = 0;
        foreach(GameObject _square in _gridSquares)
        {
            if(_columnNumber + 1 > _columns)
            {
                _rowNumber +;
                _columnNumber = 0;
            }
            var _posxOffset = offset.x * _columnNumber;
            var _posyOffset = offset.y * _rowNumber;
            _square.GetComponent<RectTransform>().anchoredPosition = new Vector2(_startPosition.x + _posxOffset, _startPosition.y - _posyOffset);
        }
    }


}
