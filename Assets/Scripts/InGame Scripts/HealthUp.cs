using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUp : MonoBehaviour
{
    
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * 25));
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
        GainHealth();
        Destroy(gameObject);
    }
    public void GainHealth()
    {
        HealthDisplay.health += 50;
        if (HealthDisplay.health >= 100)
        {
            HealthDisplay.health = 100;
        }
    }
}
