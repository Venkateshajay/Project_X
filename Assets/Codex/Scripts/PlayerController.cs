using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    public Items item;
    public void ImmobilizePlayer()
    {
        playerInput.enabled = false;
    }

    public void MobilizePlayer()
    {
        playerInput.enabled = true;
    }

    public void OnInteract()
    {
        Debug.Log("E");
        if(item != null)
        {
            item.Interact();
        }
    }
}
