using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerScript : MonoBehaviour
{
    // Charges phone when nearby
    public BatteryScript batteryScript;
    public PhoneController phoneController;


    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && batteryScript.IsEnabled()) {
            phoneController.SetCharging(true);
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player") && batteryScript.IsEnabled()) {
            phoneController.SetCharging(false);
        }
    }
}
