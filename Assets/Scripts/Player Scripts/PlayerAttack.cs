using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2,
}

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterAnimation playerAnim;
    private bool activateTimerToReset;
    private float defaultComboTimer = 0.4f;
    private float currentComboTimer;
    private ComboState currentComboState;
    void Awake()
    {
        playerAnim = GetComponentInChildren<CharacterAnimation>();
    }
    void Start()
    {
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.NONE;
    }
    // Update is called once per frame
    void Update()
    {
        ComboAttacks();
        ResetComboState();
    }
    void ComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentComboState== ComboState.PUNCH_3 || currentComboState == ComboState.KICK_1 || currentComboState == ComboState.KICK_2)
            {
                return;
            }
            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;
            if (currentComboState == ComboState.PUNCH_1)
            {
                playerAnim.Punch1();
                FindObjectOfType<audioManager>().Play("windWiff");
            }
            if (currentComboState == ComboState.PUNCH_2)
            {
                playerAnim.Punch2();
                FindObjectOfType<audioManager>().Play("windWiff1");
            }
            if (currentComboState == ComboState.PUNCH_3)
            {
                playerAnim.Punch3();
                FindObjectOfType<audioManager>().Play("windWiff2");
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            //if combo is punch 3 or kick 2, stop cpmbo
            if (currentComboState== ComboState.KICK_2 || currentComboState == ComboState.PUNCH_3)
            {
                return;
            }
            //if no combo yet or punch 1 or 2, become kick
            if (currentComboState == ComboState.NONE || currentComboState == ComboState.PUNCH_1 || currentComboState == ComboState.PUNCH_2)
            {
                currentComboState = ComboState.KICK_1;
            }
            else if (currentComboState == ComboState.KICK_1)
            {
                //if kick 1, become kick 2
                currentComboState++;
            }
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;
            //play animations
            if (currentComboState == ComboState.KICK_1)
            {
                playerAnim.Kick1();
                FindObjectOfType<audioManager>().Play("windWiff1");
            }
            if (currentComboState == ComboState.KICK_2)
            {
                playerAnim.Kick2();
                FindObjectOfType<audioManager>().Play("windWiff2");
            }
        } // combo attacks
    }
    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            currentComboTimer -= Time.deltaTime;
            if (currentComboTimer <= 0f)
            {
                currentComboState = ComboState.NONE;
                activateTimerToReset = false;
                currentComboTimer = defaultComboTimer;
            }
        }
    } // reset combo state
} //class
