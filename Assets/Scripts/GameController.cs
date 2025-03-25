using UnityEngine;

public class GameController : MonoBehaviour
{
    private const string LOSE_STRING = "Вы проиграли!";
    private const string WIN_STRING = "Вы выиграли!";
    private const string TIME_STRING = "Текущее время: ";

    [SerializeField] float _maxTime;
    [SerializeField] int _scoreToWin;
    [SerializeField] private Ball _ball;

    private float _timer;
    private int _score;
    private bool _isRunning;

    private void Awake()
    {
        _isRunning = true;
    }

    private void Update()
    {
        if (_isRunning)
        {
            _timer += Time.deltaTime;
            Debug.Log(TIME_STRING + _timer);
        }

        if (_timer > _maxTime)
        {
            Lose();
        }

        _score = _ball.getCoinsCount();

        if (_score == _scoreToWin)
        {
            Win();
        }
    }

    private void Lose()
    {
        Debug.Log(LOSE_STRING);
        GameOver();
    }

    private void Win()
    {
        Debug.Log(WIN_STRING);
        GameOver();
    }

    private void GameOver()
    {
        _ball.gameObject.SetActive(false);
        _isRunning = false;
    }
}