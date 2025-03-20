using UnityEngine;

public class FirstMessageTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject firstMessagePanel;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            CursorController.EnableCursor();
            firstMessagePanel.SetActive(true);
            Destroy(this);
        }
    }
}