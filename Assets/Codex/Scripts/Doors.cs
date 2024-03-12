using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour , Interactables
{
    PlayerController player;
    private int keyId;
    public enum DoorState
    {
        Locked,
        Unlocked,
        Stuck
    }
    [SerializeField] DoorState doorState;
    private bool canInteract = true;
    public bool CanInteract()
    {
        return canInteract;
    }

    public void Interact()
    {
        if (CanInteract())
        {
            Debug.Log("Interaction successfull");
            if (doorState == DoorState.Locked)
            {
                CheckForKey();
            } 
            else if (doorState == DoorState.Unlocked)
            {
                OpenDoor();
            }
            else if(doorState == DoorState.Stuck)
            {
                Debug.Log("Stuck");
            }
        }        
    }

    private void CheckForKey()
    {
         if (player.CheckForKeys(keyId))
        {
            OpenDoor();
        }
        else
        {
            Debug.Log("Doesn't have the key");
        }
    }

    private void OpenDoor()
    {
        Debug.Log("Door Opened");
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player" && canInteract)
        {
            player = other.GetComponent<PlayerController>();
            player.door = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (player.door == this)
            {
                player.door = null;
                player = null;
            }

        }
    }
}
