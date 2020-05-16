using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button btnStart; 
    public Button btnExit;
    public Animator transition;

    void Start()
    {
        btnStart.onClick.AddListener(StartGame);
        btnExit.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        StartCoroutine(LoadLevel(1));
    }


    IEnumerator LoadLevel(int level)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(level);

    }

}
