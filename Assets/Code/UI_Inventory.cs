
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    public bool is_players = false;
    public int rows = 4;

    private void Awake() {
        FindItemReference();
    }

    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryIntems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e){
        RefreshInventoryIntems();
    }

    private void FindItemReference(){
        itemSlotContainer = transform.Find("itemSlotContainer");
        if (itemSlotTemplate == null) {
            itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        }
    }

    private void RefreshInventoryIntems(){
        if (itemSlotContainer == null || itemSlotTemplate == null) {
           FindItemReference();
        }
        foreach(Transform child in itemSlotContainer){
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        int cont = 0;
        float itemSlotCellSize = 30f;
        

        foreach (Item item in inventory.GetItemList()) {
            
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);
            itemSlotTemplate.GetComponent<itemSlotContainer>().setID(cont);
            cont++;

            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            
            image.sprite = item.GetSprite();
            image.color = item.color;

            x++;
            if (x > rows-1) {
                x = 0;
                y++;
            }
        }
    }

    public void AddBuyingItem(StoreSlot slot){
        if (!inventory.getIsFull()){
            inventory.AddItem(slot.getItem());
            ///// OnItemListChanged?.Invoke(this, EventArgs.Empty);
            slot.saleAccepted();
        }
    }


}
