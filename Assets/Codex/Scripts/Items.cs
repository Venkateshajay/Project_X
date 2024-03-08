using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour , Interactables
{
    public enum ItemState
    {
        Pickable,
        NonPickable
    }
    [SerializeField] ItemState itemState;
    private bool canInteract = true;

    public bool CanInteract()
    {
        return canInteract;
    }

    public void Interact()
    {
        Debug.Log("Interaction successfull");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && canInteract)
        {
            other.GetComponent<PlayerController>().item = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.GetComponent<PlayerController>().item == this)
            {
                other.GetComponent<PlayerController>().item = null;
            }
            
        }
    }
}
