using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject hiddenDoor;

    void OnTriggerEnter2D(Collider2D collider)  // Code that runs when the player first enters the trigger
    {
        if(collider.CompareTag("Player"))
        {
            hiddenDoor.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collider)   //  Runs when the player exits the trigger
    {
        if(collider.CompareTag("Player"))
        {
            hiddenDoor.SetActive(true);
        }
    }
}
