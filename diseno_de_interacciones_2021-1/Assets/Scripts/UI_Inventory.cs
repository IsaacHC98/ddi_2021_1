using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class UI_Inventory : MonoBehaviour
{
   private Inventory inventory;
   private Transform itemSlotContainer;
   private Transform itemSlotTemplate;
   
   private void Awake() {
       itemSlotContainer = transform.Find("ItemSlotContainer");
       itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
   }

   public void SetInventory(Inventory inventory){
       this.inventory = inventory;

       inventory.onItemListChanged += Inventory_OnItemChanged;
       RefreshInventoryItems();
   }

   private void Inventory_OnItemChanged(object sender, System.EventArgs e){
       RefreshInventoryItems();
   }
       

   public void RefreshInventoryItems(){
       foreach(Transform child in itemSlotContainer){
           if(child == itemSlotTemplate) continue;
           Destroy(child.gameObject);
       }
       int x = 0;
       int y = 0;
       float itemSlotCellSize = 80;
       foreach(Item item in inventory.GetItemList()){
           RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
           itemSlotRectTransform.gameObject.SetActive(true);
           
           itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
               inventory.UseItem(item);
           };

           itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize * -1);
           Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
           image.sprite = item.GetSprite();

            TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            if(item.amount > 1){
                uiText.SetText(item.amount.ToString());
            } else{
                uiText.SetText("");
            }

           x++;
           if(x > 4){
               x = 0;
               y++;
           }
       }
   }
}
