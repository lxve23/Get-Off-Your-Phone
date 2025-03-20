using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelScript : MonoBehaviour
{
    public int level;

    void OnTriggerEnter(Collider other) {
            SceneManager.LoadScene(level);
        
    }
}
