using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour , Interactables
{
    PlayerController player;
    [SerializeField] private int keyId;
    private MeshCollider[] boxColliders = new MeshCollider[5];
    Animator[] animators;
    AudioSource audioSource;
    public enum DoorState
    {
        Locked,
        Unlocked,
        Stuck
    }
    [SerializeField] DoorState doorState;
    private bool canInteract = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        boxColliders = gameObject.GetComponentsInChildren<MeshCollider>();
        animators = gameObject.GetComponentsInChildren<Animator>();
    }
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
        /*for (int i = 0; i < boxColliders.Length; i++)
        {
            boxColliders[i].enabled = false;
        }*/
        for(int i = 0; i < animators.Length; i++)
        {
            bool value = animators[i].GetBool("OpenOrClose");
            animators[i].SetBool("OpenOrClose", !value);
        }
        doorState = DoorState.Unlocked;
        Debug.Log("Door Opened");
        audioSource.Play();
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
