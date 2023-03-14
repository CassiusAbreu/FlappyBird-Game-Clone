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
    [SerializeField] private GameObject[] medals;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Button restartButton;
    public int _points;
    //create a property for points
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI pointsTextPanel;
    [SerializeField] private TextMeshProUGUI pointsTextRecord;
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
        pointsTextRecord.text = PlayerPrefs.GetInt("HighScore",0).ToString();
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
        CheckIfRecord();
        Time.timeScale = 0;
        canvas.SetActive(true);
        CheckMedal();
        gameOver = true;
    }

    private void CheckIfRecord()
    {
        if (_points >  PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", _points);
        }
        
        pointsTextRecord.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        pointsTextPanel.text = _points.ToString();
    }

    private void CheckMedal()
    {
        switch (_points)
        {
            case <=5:
                medals[0].SetActive(true);
                break;
            case <=10:
                medals[1].SetActive(true);
                break;
            case <=20:
                medals[2].SetActive(true);
                break;
            case >=40:
                medals[3].SetActive(true);
                break;
        }
    }
}
