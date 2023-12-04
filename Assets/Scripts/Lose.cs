using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public float loseHeight = -100;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < loseHeight)
        {
            AudioManager.instance.PlaySound(AudioManager.instance.death, 1f);
            gameObject.SetActive(false);

            GameController.instance.GameOver();

            Time.timeScale = 0;
        }
    }
}
