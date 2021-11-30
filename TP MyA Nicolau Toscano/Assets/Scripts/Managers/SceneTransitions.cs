using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public UIManager UIManager;

    [SerializeField]
    private float _timeForTransition;

    private void Start()
    {
        EventManager.Subscribe("GameOver", YouLost);
        EventManager.Subscribe("GameWon", YouWon);
    }

    public void Level1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level3");
    }

    public void Resume()
    {
        UIManager.InactivePause();
        Time.timeScale = 1f;
    }

    public void YouWon(params object[] parameters)
    {
        SceneManager.LoadScene("YouWon");
    }

    public void YouLost(params object[] parameters)
    {
        StartCoroutine(WaitForLoadScene(2));
    }
    IEnumerator WaitForLoadScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("YouLost");
    }

    public void Play()
    {
        SceneManager.LoadScene("Levels");
    }

    public void Rules()
    {
        SceneManager.LoadScene("Rules");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
