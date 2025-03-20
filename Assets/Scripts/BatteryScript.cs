using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryScript : MonoBehaviour
{
    // Battery draining script  
    [SerializeField]
    private Slider batterySlider;
    [SerializeField]
    private PhoneController phoneController;

    private bool enabled;
    private bool drain;
    private bool isDead;
    private float battery;

    public float defaultDrain = 2f;
    public float defaultGain = -5f;
    private float currentDrain;

    void Start()
    {
        currentDrain = 0;
        enabled = false;
        drain = false;
        battery = 50;
    }

    void Update()
    {
        isDead = battery == 0;
        
        if (enabled && drain)
        {
            float drainThisFrame = currentDrain * Time.deltaTime;
            battery = Mathf.Clamp(battery - drainThisFrame, 0, 100);
        }
        SetBatteryUI(battery);
    }

    public void Enable()
    {
        enabled = true;
        drain = true;
        isDead = false;
    }

    public void SetBatteryUI(float amount)
    {
        batterySlider.value = amount;
    }

    public void SetDrain(float amount) {
        currentDrain = amount;
    }

    public bool IsDead() {
        return isDead;
    }

    public bool IsEnabled() {
        return enabled;
    }

}
