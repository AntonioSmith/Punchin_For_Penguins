﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject laser;
    private Rigidbody myLaser;

    private CharacterAnimation enemyAnim;
    private Rigidbody myBody;
    public float speed = 5f;
    private Transform playerTarget;
    public float attackDistance = 1f;
    private float chasePlayerAfterAttack = 1f;
    private float CurrentAttackTime;
    private float defaultAttackTime = 2f;
    private bool followPlayer, attackPlayer;
    // Start is called before the first frame update

    private void Awake()
    {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();
        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }
    void Start()
    {
        followPlayer = true;
        CurrentAttackTime = defaultAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        myBody.position = new Vector3(myBody.position.x, myBody.position.y, 0.04f);
        BulletUpdate();
        Attack();
    }
    void FixedUpdate()
    {
        FollowTarget();
    }
    void FollowTarget()
    {
        //if not follow player
        if (!followPlayer)
        {
            return;
        }
        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance)
        {
            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * speed;
            if (myBody.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
        }
        else if (Vector3.Distance(transform.position,playerTarget.position) <= attackDistance)
        {
            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    }
    void Attack()
    {
        //if shouldn't attack player, stop
        if (!attackPlayer)
        {
            return;
        }
        CurrentAttackTime += Time.deltaTime;

        if (CurrentAttackTime > defaultAttackTime)
        {
            GameObject makeLaser = Instantiate(laser) as GameObject;
            makeLaser.transform.position = transform.position * 2;
            myLaser = makeLaser.GetComponent<Rigidbody>();
            myLaser.velocity = new Vector3(20f, 0f, 2f);
            print(myLaser.velocity);
            enemyAnim.EnemyAttack(Random.Range(0, 3));
            CurrentAttackTime = 0f;


        }
        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttack)
        {
            attackPlayer = false;
            followPlayer = true;
        }

    }
    void BulletUpdate()
    {
    }
}
