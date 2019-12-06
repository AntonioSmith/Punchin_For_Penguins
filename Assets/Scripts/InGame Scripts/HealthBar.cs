using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthBar;
    public float health = .5f;

    private void Start()
    {
        healthBar = GameObject.Find("healthBar").GetComponent<Image>();
    }

    void update()
    {
        healthBar.fillAmount = health / 100f;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    health - (1 / 100f);
        //    if (health <= 0)
        //    {
        //        health = 0;
        //    }
        //}
    }
}
