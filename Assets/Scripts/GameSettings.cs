using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public enum EGameMode
    {
        Easy,
        Medium,
        Hard,
        NotSet
    }

    public static GameSettings Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(this);
    }

    private EGameMode _gameMode;

    private void Start()
    {
        _gameMode = EGameMode.NotSet;
    }

    public void SetGameMode(EGameMode _mode)
    {
        _gameMode = _mode;
    }

    public void _SetGameMode(string _mode)
    {
        if (_mode == "Easy") 
            SetGameMode(EGameMode.Easy);
        else if (_mode == "Medium") 
            SetGameMode(EGameMode.Medium);
        else if (_mode == "Hard") 
            SetGameMode(EGameMode.Hard);
        else 
            SetGameMode(EGameMode.NotSet);
    }

    public string GetGameMode()
    {
        switch (_gameMode)
        {
            case EGameMode.Easy: return "Easy";
            case EGameMode.Medium: return "Medium";
            case EGameMode.Hard: return "Hard";
        }
        Debug.Log("Error");
        return " ";
    }
}
