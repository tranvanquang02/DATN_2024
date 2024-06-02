using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject toolbarPanel;
    [SerializeField] GameObject topPanel;
    [SerializeField] GameObject adddtionalPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryPanel.activeInHierarchy == false)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
    }
    public void Open()
    {
        inventoryPanel.SetActive(true);
        toolbarPanel.SetActive(false);
        topPanel.SetActive(true);

    }
    public void Close()
    {
        inventoryPanel.SetActive(false);
        toolbarPanel.SetActive(true);
        topPanel.SetActive(false);
        adddtionalPanel.SetActive(false);
    }
}
