using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneController : MonoBehaviour
{
    // Controls phone of Player
    public DopamineScript dopamineScript;
    public BatteryScript batteryScript;
    public EnemyController enemyController;
    public MeshRenderer meshRenderer;
    public GameObject phoneBlindness;
    public GameObject deadPhone;
    public AchievementScript achievementScript;
    public PlayerController playerController;

    private bool isUsingPhone = false;
    private bool charging = false;


    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1 && batteryScript.IsDead() && isUsingPhone)
            PhoneDied();

        if (Input.GetKeyDown(KeyCode.Space))
            TogglePhoneUsage();
        else if (Input.GetKeyUp(KeyCode.Space))
            StopPhoneUsage();

        enemyController.SetChasingPlayer(isUsingPhone);
    }

    void TogglePhoneUsage()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1 && batteryScript.IsDead())
        {
            PhoneDied();
            return;
        }

        meshRenderer.enabled = true;
        phoneBlindness.SetActive(true);
        isUsingPhone = true;
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            if (charging)
                batteryScript.SetDrain(-1f);
            else
                batteryScript.SetDrain(batteryScript.defaultDrain);
        }
        playerController.SetSpeed(2.5f);
        if (enemyController.IsPlayerInRange())
            achievementScript.UnlockAchievement(2);
        StartCoroutine(WaitToGain());
    }

    void StopPhoneUsage()
    {
        dopamineScript.SetDrain(dopamineScript.defaultDrain);
        meshRenderer.enabled = false;
        isUsingPhone = false;
        phoneBlindness.SetActive(false);
        playerController.SetSpeed(5f);
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            deadPhone.SetActive(false);
            if (charging)
                batteryScript.SetDrain(batteryScript.defaultGain);
            else
                batteryScript.SetDrain(-1f);
        }
    }

    public void PhoneDied()
    {
        dopamineScript.SetDrain(dopamineScript.defaultDrain);
        phoneBlindness.SetActive(false);
        deadPhone.SetActive(true);
    }

    public void SetCharging(bool value)
    {
        charging = value;
        if (value)
            deadPhone.SetActive(false);

        if (isUsingPhone && value)
        {
            phoneBlindness.SetActive(true);
            batteryScript.SetDrain(-1f);
        }
        else if (!isUsingPhone && value)
            batteryScript.SetDrain(batteryScript.defaultGain);
        else if (isUsingPhone && !value)
        {
            phoneBlindness.SetActive(true);
            batteryScript.SetDrain(batteryScript.defaultDrain);
        }
        else if (!isUsingPhone && !value)
            batteryScript.SetDrain(-1f);

    }

    IEnumerator WaitToGain()
    {
        yield return new WaitForSeconds(2);
        if (isUsingPhone)
            dopamineScript.SetDrain(dopamineScript.defaultGain);
    }
}
