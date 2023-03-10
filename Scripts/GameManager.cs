using System;
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
    [SerializeField] private SpriteRenderer[] backgrounds;
    private const float fadeTime = 3f;
    private Bird _bird;

    void Start()
    {
        _bird = GameObject.Find("Bird").GetComponent<Bird>();
        if (_bird == null)
            Debug.LogError("Bird is null");

        backgrounds[1].color = new Color(backgrounds[0].color.r, backgrounds[0].color.g, backgrounds[0].color.b, 0);

        /*if(background != null)
            background.sprite = backgrounds[0];*/

        pauseButton.onClick.AddListener((() => GamePaused()));
        resumeButton.onClick.AddListener((() => GameResumed()));
    }

    private void GameResumed()
    {
        pause.SetActive(true);
        resume.SetActive(false);
        Time.timeScale = 1;
    }

    private void GamePaused()
    {
        Time.timeScale = 0;
        pause.SetActive(false);
        resume.SetActive(true);
    }

    //i will refactor this later
    public IEnumerator ChangeBackground()
    {
        if (Math.Abs(backgrounds[0].color.a - 1) < 0.01f)
        {
            float time = Time.deltaTime;
            float percentage =  time/fadeTime;
            
            while (backgrounds[0].color.a > 0)
            {
                backgrounds[1].color = new Color(1, 1, 1, backgrounds[1].color.a + 1 * percentage);
                backgrounds[0].color = new Color(1, 1, 1, backgrounds[0].color.a - 1 * percentage);
                yield return new WaitForSeconds(fadeTime * percentage);
            }
            backgrounds[0].color = Color.clear;
        }
        else if (backgrounds[0].color.a == 0)
        {
            float time = Time.deltaTime;
            float percentage =  time/fadeTime;
            while (backgrounds[0].color.a < 1)
            {
                backgrounds[1].color = new Color(1, 1, 1, backgrounds[1].color.a - 1 * percentage);
                backgrounds[0].color = new Color(1, 1, 1, backgrounds[0].color.a + 1 * percentage);
                yield return new WaitForSeconds(fadeTime * percentage);
            }
            backgrounds[1].color = Color.clear;
        }



    }

   
}