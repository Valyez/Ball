using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private CoinCollector _collector;

    private void Awake()
    {
        _collector = gameObject.GetComponent<CoinCollector>();
    }

    public int getCoinsCount()
    {
        return _collector.Points;
    }
}