using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;

    private Inventory inventory;
    public GameObject inventoryUI;
    // Start is called before the first frame update

    private void Start() {
        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);
        inventoryUI.SetActive(false);
    }

    private void UseItem(Item item){
        switch(item.itemType){
            case Item.ItemType.Armor:
                Debug.Log("Armadura aumento un 25%");
                inventory.RemoveItem(new Item{itemType = Item.ItemType.Armor, amount = 1});
                break;
            case Item.ItemType.Medkit:
                Debug.Log("Salud aumento un 50%");
                inventory.RemoveItem(new Item{itemType = Item.ItemType.Medkit, amount = 1});
                break;
        }
    }
    
    private void OnTriggerEnter(Collider other) {
        ItemWorld itemWorld = other.GetComponent<ItemWorld>();
        if(itemWorld != null){
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
}
