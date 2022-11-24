using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private PlayerController _playerHP;
    private PlayerLevel _playerXP;
    [SerializeField] private Image _healthBar, _xpBar;
    [SerializeField] private TextMeshProUGUI _hpText, _expText, _nextLevelText, _scoreText;

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
}
