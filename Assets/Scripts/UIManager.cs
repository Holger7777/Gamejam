using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private PlayerController _playerHP;
    private PlayerLevel _playerXP;
    [SerializeField] private Image _healthBar, _xpBar;
    [SerializeField] private TextMeshProUGUI _hpText, _expText, _nextLevelText, _scoreText, _finalScoreText;
    [SerializeField] private GameObject _health, _xp, _score;
    [SerializeField] private CanvasGroup _blackScreen, _gameOverScreen;

    private void Start()
    {
        _playerHP = FindObjectOfType<PlayerController>();
        _playerXP = FindObjectOfType<PlayerLevel>();
    }

    private void Update()
    {
        _healthBar.fillAmount = Mathf.Clamp(_playerHP.HP / _playerHP.MaxHealth, 0, 1);
        _xpBar.fillAmount = Mathf.Clamp(_playerXP.EXP / _playerXP.EXPToNextLevel, 0, 1);
        _hpText.SetText(_playerHP.HP.ToString());
        _expText.SetText(_playerXP.EXP.ToString());
        _nextLevelText.SetText(_playerXP.EXPToNextLevel.ToString());
        _scoreText.SetText(_playerXP.Score.ToString());
    }

    public void GameOver()
    {
        _health.SetActive(false);
        _xp.SetActive(false);
        _score.SetActive(false);
        _finalScoreText.SetText(_playerXP.Score.ToString());
        Debug.Log("woop?");
        StartCoroutine(BlackScreen());
        StartCoroutine(GameOverScreen());

    }

    private IEnumerator BlackScreen()
    {
        Debug.Log("woop");
        yield return new WaitForSeconds(2);
        _blackScreen.alpha = 1;
    }

    private IEnumerator GameOverScreen()
    {
        yield return new WaitForSeconds(2);
        _gameOverScreen.alpha = 1;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
