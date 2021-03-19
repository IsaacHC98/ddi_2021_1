using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject hud;
    public GameObject inventory;
    public GameObject controls;
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("Pause")){
            if(isPaused){
                ResumeGame();
            } else{
                PauseGame();
            }
        }
    }

    public void PauseGame(){
        pauseMenu.SetActive(true);
        hud.SetActive(false);
        inventory.SetActive(false);
        controls.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        hud.SetActive(true);
        controls.SetActive(true);
        controls.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame(){
        Application.Quit();
    }
}
