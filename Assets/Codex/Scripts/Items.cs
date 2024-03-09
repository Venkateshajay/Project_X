using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour , Interactables
{
    [SerializeField] ItemsData itemData;
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
        if(itemState == ItemState.Pickable)
        {
            Pick();
        }
        else
        {
            See();
        }
        Debug.Log("Interaction successfull");
    }

    private void Pick()
    {

    }

    private void See()
    {

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
