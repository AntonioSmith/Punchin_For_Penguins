using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenguinDisplay : MonoBehaviour {

    public int penguins = 0;
    public Text penguinText;

    void Update()
    {
        penguinText.text = "Penguins : " + penguins;

        if (Input.GetKeyDown(KeyCode.Mouse0) && PauseMenu.isPaused == false)
        {
            penguins++;
        }
    }
}

