using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    public GameObject GameWonPanel;
    public GameObject GamePausedPanel;
    public GameObject Timer;


    public static bool gamePaused;

    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        gamePaused = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if(currentScene.buildIndex != 0)
        {
            CheckIfGameWon();
            CheckIfGamePaused();
        }
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    public void QuitLevel()
    {
        SceneManager.LoadScene(0);
        gamePaused = false;        
    }

    public void ContinueGame()
    {
        gamePaused = false;
        Time.timeScale = 1;
        GamePausedPanel.SetActive(false);
    }

    void CheckIfGameWon()
    {
        if(WinGameScript.gameWon)
        {
            GameWonPanel.SetActive(true);
        }
    }

    void CheckIfGamePaused()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !gamePaused)
        {
            Time.timeScale = 0;
            GamePausedPanel.SetActive(true);
            gamePaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused)
        {
            Time.timeScale = 1;
            GamePausedPanel.SetActive(false);
            gamePaused = false;
        }
        
        
    }
}
