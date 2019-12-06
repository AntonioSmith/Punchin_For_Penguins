using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float time = 5;
    PlayerMovement playermovement;

    private void Start()
    {
        playermovement = GetComponent<PlayerMovement>();
        Time.timeScale = 1;
    }
    void Update()
    {
        //transform.Rotate(new Vector3(0, Time.deltaTime * 25, 0));
        // rotating on wrong axis
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        MovementUp();
        Destroy(gameObject);
    }
    public void MovementUp()
    {
        playermovement.walkSpeed = playermovement.walkSpeed + 3;
        time = 5;
        time -= Time.deltaTime;
        if (time <= 0)
        {
            playermovement.walkSpeed = 5;
        }
    }
}
