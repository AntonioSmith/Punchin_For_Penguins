using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform Player;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (rb.position.x >= 9)
        {
            rb.position = new Vector2(9, 2.6f);
        }
        if (Player.position.y >= 2)
        {
            rb.position = new Vector2(Player.position.x, Player.position.y + .6f);
        }
        else
        {
            rb.position = new Vector2(Player.position.x, 2.6f);
        }
    }
}
