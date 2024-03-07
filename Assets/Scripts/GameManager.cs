using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button _restartGameButton;
    private GameObject _player;
    private int _score = 0;
    private int _lives = 3;

    private void Start()
    {
        _player = GameObject.Find("Player").gameObject;
    }

    public void AddLives(int value)
    {
        _lives += value;
        if (_lives <= 0)
        {
            Debug.Log("Game Over");
            _lives = 0;
            Destroy(_player);
            _restartGameButton.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Lives = " + _lives);
        }
    }
    public void AddScore(int value)
    {
        _score += value;
        Debug.Log("Score = " + _score);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
}

