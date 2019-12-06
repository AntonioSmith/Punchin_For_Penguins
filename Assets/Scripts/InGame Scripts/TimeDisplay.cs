using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{

    public float time = 300; // Used a float so I could use deltaTime
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = time + "sec.";
        time -= Time.deltaTime; // Reduces time every second instead of every frame
        timeText.text = ((int)time).ToString(); // Converts the time to an int so it can be displayed as a whole number in UI
        if (time <= 0) // Stops timer at 0 seconds
            {
                time = 0;
            }       
    }
}
