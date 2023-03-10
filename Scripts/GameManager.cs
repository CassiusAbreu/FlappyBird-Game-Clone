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
    private Bird _bird;
    [SerializeField] private Sprite[] backgrounds;
    [SerializeField] private SpriteRenderer background;
    void Start()
    {
        _bird = GameObject.Find("Bird").GetComponent<Bird>();
        if(_bird == null)
            Debug.LogError("Bird is null");
        
        if(background != null)
            background.sprite = backgrounds[0];
        
        pauseButton.onClick.AddListener( (() => GamePaused()));
        resumeButton.onClick.AddListener((() => GameResumed()));
    }
    private void GameResumed()
    {
        pause.SetActive(true);
        resume.SetActive(false);
    }
    private void GamePaused()
    {
        Time.timeScale = 0;
        pause.SetActive(false);
        resume.SetActive(true);
    }

    public void ChangeBackground()
    {
        if(background.sprite == backgrounds[0])
            background.sprite = backgrounds[1];
        else
            background.sprite = backgrounds[0];
    }
}
