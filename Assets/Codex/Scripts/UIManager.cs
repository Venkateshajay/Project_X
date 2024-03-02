using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas InventoryCanvas; 
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryCanvasSwitch(!InventoryCanvas.gameObject.activeSelf);
        }
    }

    private void InventoryCanvasSwitch(bool value)
    {
        InventoryCanvas.gameObject.SetActive(value);
    }
}
