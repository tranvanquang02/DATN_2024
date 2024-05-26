using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image Icon;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image HightLight;

    int MyIndex;
    public void SetIndex(int index)
    {
        MyIndex = index;
    }
    public void Set(ItemSlot slot)
    {
       Icon.sprite = slot.item.Icon;
       Icon.gameObject.SetActive(true);
       if(slot.item.Stackable)
       {
            text.gameObject.SetActive(true);
            text.text = slot.count.ToString();
       }
        else
        {
            text.gameObject.SetActive(false);
        }
    }
    public void clean()
    {
        Icon.sprite = null;
        Icon.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemPanel itemPanel = transform.parent.GetComponent<ItemPanel>();
        itemPanel.OnClick(MyIndex);
    }
    public void Hightight(bool a)
    {
        HightLight.gameObject.SetActive(a);
    }
}
