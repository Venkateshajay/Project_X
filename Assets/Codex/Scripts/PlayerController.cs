using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;

    public void ImmobilizePlayer()
    {
        playerInput.enabled = false;
    }

    public void MobilizePlayer()
    {
        playerInput.enabled = true;
    }
}
