using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour { 

    public static int health = 100;
    public Text healthText;

    void Update()
    {
    healthText.text = "Health : " + health.ToString();

        if(Input.GetKeyDown(KeyCode.Space))
    {
        health--;
            if (health <= 0)
            {
                health = 0;
            }
    }
    }
}

