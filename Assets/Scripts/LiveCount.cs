using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveCount : MonoBehaviour
{
    public GameObject[] Lives;
    public int _remainingLives;

    public void LoseLife()
    {
        _remainingLives--;
        Lives[_remainingLives].SetActive(false);

        if (_remainingLives <= 0)
        {
            for (int i = 0; i < Lives.Length; i++)
            {
                Lives[i].SetActive(true);
            }
        }
    }

}
