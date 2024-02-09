using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{

    public static Score instance;

    [SerializeField] private TextMeshProUGUI _currentScoreTxt;
    [SerializeField] private TextMeshProUGUI _highScoreTxt;

    private int _score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _currentScoreTxt.text = _score.ToString();

        _highScoreTxt.text =PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if(_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            _highScoreTxt.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        _currentScoreTxt.text = _score.ToString();
        UpdateHighScore();
    }


}
