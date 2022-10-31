using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollect : MonoBehaviour
{
    private int _coins;

    private void Start()
    {
        _coins = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            coin.Collected();

            StartCoroutine(Collect(coin));
        }
    }

    private IEnumerator Collect(Coin coin)
    {
        while(coin.CanDestroy == false)
        {
            yield return null;
        }

        Destroy(coin.gameObject);
    }
}
