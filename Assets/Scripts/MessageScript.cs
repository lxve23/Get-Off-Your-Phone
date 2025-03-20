using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MessageScript : MonoBehaviour
{
    // UI Panel controller script
    GameObject phone;
    GameObject blockedDoor;
    DopamineScript dopamineMeter;
    public PhoneController phoneController;
    public BatteryScript batteryScript;
    public GameObject howToPlay;
    public GameObject playerPhone;

    void Start()
    {
        phone = GameObject.Find("Phone");
        blockedDoor = GameObject.Find("BlockDoorWall");
        dopamineMeter = GameObject.Find("Dopamine Meter").GetComponent<DopamineScript>();
    }

    public void CloseFirstMessage(GameObject obj) {
        CloseMessage(obj);
        StartCoroutine(TipSelfDestruct());
        Destroy(phone);
        Destroy(blockedDoor);
        dopamineMeter.Enable();
        if (SceneManager.GetActiveScene().buildIndex != 1)
            batteryScript.Enable();
        playerPhone.SetActive(true);
    }

    public void CloseMessage(GameObject obj) {
        obj.SetActive(false);
        CursorController.DisableCursor();
    }

    public IEnumerator TipSelfDestruct()
    {
        howToPlay.SetActive(true);
        yield return new WaitForSeconds(10);
        Destroy(howToPlay);

    }
}
