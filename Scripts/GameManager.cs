using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pause;
    [SerializeField] private Button resumeButton;
    [SerializeField] private GameObject resume;
    // Start is called before the first frame update
    void Start()
    {
        pauseButton.onClick.AddListener( (() => GamePaused()));
        resumeButton.onClick.AddListener((() => GameResumed()));
    }
    private void GameResumed()
    {
        Time.timeScale = 1;
        pause.SetActive(true);
        resume.SetActive(false);
    }
    private void GamePaused()
    {
        Time.timeScale = 0;
        pause.SetActive(false);
        resume.SetActive(true);
    }
    
    
}
