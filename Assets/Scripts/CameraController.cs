using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float start, end;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //location player
        var playerX = player.transform.position.x;

        //location camera
        var camX = transform.position.x;
        var camY = transform.position.y;
        var camZ = transform.position.z;

        if (playerX > start && playerX < end)
        {
            camX = playerX;
        }
        else
        {
            if (playerX < start)
            {
                camX = start;
            }
            if (playerX > end)
            {
                camX = end;
            }
        }
        //reset location camera
        transform.position = new Vector3(camX, camY, camZ);
    }
}
