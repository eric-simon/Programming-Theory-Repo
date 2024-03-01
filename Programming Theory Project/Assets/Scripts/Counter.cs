using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.Instance.IncreaseScore();
    }
}
