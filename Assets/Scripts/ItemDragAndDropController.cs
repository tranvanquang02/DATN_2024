using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject DragItemIcon;

    RectTransform IconTransform;
    Image itemIconImage;

    private void Start()
    {
        itemSlot = new ItemSlot();
        IconTransform = DragItemIcon.GetComponent<RectTransform>();
        itemIconImage = DragItemIcon.GetComponent<Image>();
    }
    private void Update()
    {
        if (DragItemIcon.activeInHierarchy == true)
        {
            IconTransform.position = Input.mousePosition;

            if(Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                    Vector3 worldPosiion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPosiion.z = 0;
                    ItemSpawManager.Instance.SpawnItem( 
                        worldPosiion,
                        itemSlot.item,
                        itemSlot.count);
                    itemSlot.clear();
                    DragItemIcon.SetActive(false);
                }
            }
        }
    }
    internal void OnClick(ItemSlot itemSlot)
    {
        if(this.itemSlot.item == null)
        {
            this.itemSlot.copy(itemSlot);
            itemSlot.clear();
        }
        else
        {
            Item item = itemSlot.item;
            int count = itemSlot.count;

            itemSlot.copy(this.itemSlot);
            this.itemSlot.set(item, count);
        }
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if(itemSlot.item == null)
        {
            DragItemIcon.SetActive(false);
        }
        else
        {
            DragItemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.Icon;
        }
    }
}
