using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int Points { get; private set; } = 0;
    private readonly string COINS_MESSAGE = $"Количество собранных монет : ";
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();
        if (coin != null)
        {
            AddPoint();
            DestroyCoin(coin);
        }
    }

    private void DestroyCoin( Coin coin)
    {
        coin.gameObject.SetActive(false);
    }

    private void AddPoint()
    {
        Points += 1;
        Debug.Log(COINS_MESSAGE + $"{Points}");
    }
}