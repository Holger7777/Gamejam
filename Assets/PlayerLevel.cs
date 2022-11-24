using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    private float _exp;

    public void GetExp(float _expGain)
    {
        _exp = _exp + _expGain;
    }
}
