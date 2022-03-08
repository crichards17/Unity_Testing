using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGame : MonoBehaviour
{
    float roundStartDelayTime = 3;
    bool roundStarted;
    float roundStartTime;
    int waitTime;

    // Start is called before the first frame update
    void Start()
    {
        print("Press the spacebar at the right time.");
        roundStarted = true;
        Invoke("SetNewRandomTime", roundStartDelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && roundStarted)
        {
            InputReceived();
        }
    }

    void SetNewRandomTime()
    {
        waitTime = Random.Range(5, 21);
        roundStartTime = Time.time;

        print($"{waitTime} seconds.");
    }

    void InputReceived()
    {
        print(GetOutputMessage());

        Invoke("SetNewRandomTime", roundStartDelayTime);
    }

    string GetOutputMessage()
    {
        float playerWaitTime = Time.time - roundStartTime;
        float delta = Mathf.Abs(waitTime - playerWaitTime);
        string success;
        if (delta < 0.15)
        {
            success = "Great job!";
        }
        else if (delta < 0.75)
        {
            success = "Good work!";
        }
        else if (delta < 1.25)
        {
            success = "Good enough.";
        }
        else if (delta < 1.75)
        {
            success = "Not great...";
        }
        else
        {
            success = "You can do better.";
        }
        return $"You were waited for {playerWaitTime} seconds, and you were {delta} seconds off. {success}";
    }
}
