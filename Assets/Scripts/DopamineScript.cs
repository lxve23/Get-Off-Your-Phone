using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DopamineScript : MonoBehaviour
{
    // Dopamine draining script
    [SerializeField]
    private Slider dopamineSlider;
    [SerializeField]
    private LevelController levelController;
    [SerializeField]
    private EnemyController enemyController;

    private bool enabled;
    private bool drain;
    private float dopamine;

    public float defaultDrain = 2f;
    public float defaultLowerDrain = 2f;
    public float defaultGain = -5f;
    private float currentDrain;

    void Start()
    {
        currentDrain = defaultDrain;
        enabled = false;
        drain = false;
        dopamine = 50;
    }

    void Update()
    {
        if (enabled && drain)
        {
            float drainThisFrame = currentDrain * Time.deltaTime;
            dopamine = Mathf.Clamp(dopamine - drainThisFrame, 0, 100);
        }
        SetDopamineUI(dopamine);

        if (dopamine > 90)
            levelController.AllowNextLevel();
        if (dopamine <= 0)
            enemyController.OnPlayerReached();

    }

    public void Enable()
    {
        enabled = true;
        drain = true;
    }

    public void SetDopamineUI(float amount)
    {
        dopamineSlider.value = amount;
    }

    public void SetDrain(float amount) {
        currentDrain = amount;
    }

}
