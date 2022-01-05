using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public List<GameObject> _errorImages;
    public GameObject _gameOver;

    int _lives = 0;
    int _errorNumber = 0;
    
    void Start()
    {
        _lives = _errorImages.Count;
        _errorNumber = 0;
    }

    private void WrongNumber()
    {
        if(_errorNumber < _errorImages.Count)
        {
            _errorImages[_errorNumber].SetActive(true);
            _errorNumber++;
            _lives--;
        }
        CheckForGameOver();
    }

    private void CheckForGameOver()
    {
        if(_lives <= 0)
        {
            _gameOver.SetActive(true);
        }
    }

    private void OnEnable()
    {
        Events.OnWrongNumber += WrongNumber;
    }

    private void OnDisable()
    {
        Events.OnWrongNumber -= WrongNumber;
    }
}
