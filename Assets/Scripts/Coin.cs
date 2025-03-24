using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Я триггернулся");
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            ball.AddPoint();
            gameObject.SetActive(false);
        }
    }

    
}