using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
   public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadEasyLevel(string name)
    {
        GameSettings.Instance.SetGameMode(GameSettings.EGameMode.Easy);
        SceneManager.LoadScene(name);
    }

    public void LoadMediumLevel(string name)
    {
        GameSettings.Instance.SetGameMode(GameSettings.EGameMode.Medium);
        SceneManager.LoadScene(name);
    }

    public void LoadHardLevel(string name)
    {
        GameSettings.Instance.SetGameMode(GameSettings.EGameMode.Hard);
        SceneManager.LoadScene(name);
    }

    public void ActivateObject(GameObject _object)
    {
        _object.SetActive(true);
    }

    public void DeactivateObject(GameObject _object)
    {
        _object.SetActive(false);
    }
}
