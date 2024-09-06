using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    [SerializeField] private float maxBattery;
    [SerializeField] private float batteryUsageRate;
    [SerializeField] Battery battery;
        private float currentBattery;

    void Start()
    {
        currentBattery = maxBattery;
        battery.UpdateSlider(currentBattery, maxBattery);
    }

    void Update()
    {
        // Self note: (If input manager is used, do GetButton instead and is the better option)
        if (Input.GetKey(KeyCode.R))
        {
            if(currentBattery > 0)
            {
                StartRecording();
                Debug.Log("Current Battery: " + currentBattery);
            }

        }
    }

    void StartRecording()
    {
        currentBattery -= batteryUsageRate;
        battery.UpdateSlider(currentBattery, maxBattery);
    }
}
