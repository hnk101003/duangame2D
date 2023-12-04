using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public int cointValue = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.instance.PlaySound(AudioManager.instance.coin, 1f);

            GameController.instance.AddScore(cointValue);

            Destroy(gameObject);

        }
    }
}
