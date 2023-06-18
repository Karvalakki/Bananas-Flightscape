using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public bool paused = false;

    public GameObject pauseMenu;
    public GameObject mainMenu;

    public void TogglePause()
    {
        if (paused == true)
        {
            paused = false;
        }
        else if (paused == false)
        {
            paused = true;
        }
    }

    public void ToMenu()
    {
        TogglePause();
        SceneManager.LoadScene(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
        //Esc button for toggling pause on or off
    {
        if(Input.GetButtonDown("Cancel"))
        {
            TogglePause();
        }

        //Pauses the game and opens the menu
        if(paused == true)
        {
           pauseMenu.SetActive(true);
            mainMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        else if(paused == false)
        {
           pauseMenu.SetActive(false);
            mainMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
