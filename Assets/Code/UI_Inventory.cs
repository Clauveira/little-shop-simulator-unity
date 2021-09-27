using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake() {
        FindItemReference();
    }

    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        RefreshInventoryIntems();
    }

    private void FindItemReference(){
        itemSlotContainer = transform.Find("itemSlotContainer");
        if (itemSlotTemplate == null) {
            itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        }
    }

    private void RefreshInventoryIntems(){
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 30f;
        
        if (itemSlotContainer == null || itemSlotTemplate == null) {
           FindItemReference();
        }

        foreach (Item item in inventory.GetItemList()) {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);

            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            
            image.sprite = item.GetSprite();
            image.color = item.color;


            x++;
            if (x > 3) {
                x = 0;
                y++;
            }
        }
    }
}
