using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask collisionLayer;
    public LayerMask OtherCollisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool isPlayer, isEnemy;

    public GameObject hitFX;
    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }
    void DetectCollision()
    {

        Collider[] OtherHit = Physics.OverlapSphere(transform.position, radius, OtherCollisionLayer);
        if (OtherHit.Length > 0)
        {
            if (isPlayer)
            {
                //Vector3 hitFXPos = OtherHit[0].transform.position;
                //hitFXPos.y += 1.3f;
                
                if (OtherHit[0].transform.forward.x > 0)
                {
                    //hitFXPos.x += 0.3f;
                }
                else if (OtherHit[0].transform.forward.x < 0)
                {
                    //hitFXPos.x -= 0.3f;
                }
                OtherHit[0].transform.up = new Vector3(-600, -56, -20);
                //Instantiate(hitFX, hitFXPos, Quaternion.identity);
                if (gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG_TAG))
                {
                    //OtherHit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                }
                else
                {
                    //OtherHit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                }
            }
        }
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);
        if (hit.Length > 0)
        {
            if (isPlayer)
            {
                //Vector3 hitFXPos = hit[0].transform.position;
                //hitFXPos.y += 1.3f;

                if (hit[0].transform.forward.x > 0)
                {
                    //hitFXPos.x += 0.3f;
                }
                else if (hit[0].transform.forward.x < 0)
                {
                    //hitFXPos.x -= 0.3f;
                }
                //Instantiate(hitFX, hitFXPos, Quaternion.identity);
                if (gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG_TAG))
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                }
                else
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                }
            }
        }
    }
}
