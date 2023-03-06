using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D _rb;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Button restartButton;
    

    public static bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
        restartButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        _rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
        canvas.SetActive(false);
        this.transform.position = new Vector3(-0.629f, 0.851f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = Vector2.up * speed;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        canvas.SetActive(true);
        gameOver = true;
    }
}
