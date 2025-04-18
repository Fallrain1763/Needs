using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseManager : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isPaused = false;
    public Canvas pauseCanvas;
    void Start()
    {
        ResumeGame();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }else{
                PauseGame();
            }
        }
    }

    void togglePause(){
        isPaused = !isPaused;
    }

    public void ResumeGame(){
            Time.timeScale = 1;
            pauseCanvas.gameObject.SetActive(false);
            togglePause();
    }

    void PauseGame(){
        Time.timeScale = 0;
        pauseCanvas.gameObject.SetActive(true);
        togglePause();
    }

    public void GoToMenu(){
        SceneManager.LoadScene("TitleScreen");
    }
}
