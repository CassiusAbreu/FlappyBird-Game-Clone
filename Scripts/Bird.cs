using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D _rb;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Button restartButton;
    public int _points;
    //create a property for points
    public int Points => _points;
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private AudioSource _audioSource;
    private GameManager _gameManager;
    private readonly Vector3 _initialPosition = new Vector3(-0.629f, 0.851f, 0);

    public static bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if(_rb == null)
            Debug.LogError("Rigidbody2D is null");
        
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(_gameManager == null)
            Debug.LogError("GameManager is null");
        
        restartButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        Time.timeScale = 1;
        canvas.SetActive(false);
        transform.position = _initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
        {
            _audioSource.PlayOneShot(_audioClips[0]);
            _rb.velocity = Vector2.up * speed;
        }
    }
    
    private void FixedUpdate()
    {
        pointsText.text = _points.ToString();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _audioSource.PlayOneShot(_audioClips[2]);
        GameOver();
    }
    
    public void AddPoints()
    {
        _audioSource.PlayOneShot(_audioClips[1]);
        _points++;
        if(_points % 4 == 0)
            _gameManager.StartCoroutine(_gameManager.ChangeBackground());
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        canvas.SetActive(true);
        gameOver = true;
    }
}
