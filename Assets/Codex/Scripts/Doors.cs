using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour , Interactables
{

    public enum DoorState
    {
        Locked,
        Unlocked,
        Stuck
    }
    [SerializeField] DoorState doorState;
    private bool canInteract = false;
    public bool CanInteract()
    {
        return canInteract;
    }

    public void Interact()
    {
        Debug.Log("Interaction successfull");
    }
}
