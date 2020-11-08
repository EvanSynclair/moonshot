using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Rotate(0f, 1f, 0f, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Rotate(0f, -1f, 0f, Space.World);
        }
    }
}
