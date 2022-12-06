using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private float _exp;
    [SerializeField] private float _expPerLevel;
    [SerializeField] private int _level;
    private float _expToNextLevel;
    private float _totalExpEarned;

    //Public EXP variables with a get for private variables for the EXPBar
    public float EXP { get { return _exp; } }
    public float EXPToNextLevel { get { return _expToNextLevel; } }
    public float Score { get { return _totalExpEarned; } }

    private void Awake()
    {
        _expToNextLevel = _expPerLevel;
        _level = 1;
    }

    public void GainExperience(float expGain)
    {
        _exp = _exp + expGain;
        _totalExpEarned = _totalExpEarned + expGain;
        if(_exp >= _expToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        _level++;
        _exp = _exp - _expToNextLevel;
        _expToNextLevel = _expToNextLevel * 2;
    }
}
