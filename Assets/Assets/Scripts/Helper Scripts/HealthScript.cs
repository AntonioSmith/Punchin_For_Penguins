using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;
    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private bool hasDied;

    public bool isPlayer;
    // Start is called before the first frame update
    private void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();
    }
    public void ApplyDamage(float damage, bool knockDown)
    {
        if (hasDied)
            return;
        health -= damage;
        if (health <= 0)
        {
            animationScript.Death();
            hasDied = true;

            if (isPlayer)
            {

            }
            return;
        }
        if (!isPlayer)
        {
            if (knockDown)
            {
                if (Random.Range(0, 2) > 0)
                {
                    animationScript.KnockDown();
                }
            }
            else
            {
                if (Random.Range(0,3) > 1)
                {
                    animationScript.Hit(); 
                }
            }
        }
    }
}
