using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // You can change the key
        {
            UIManager.Instance.TogglePauseMenuUI();
        }
    }
}
