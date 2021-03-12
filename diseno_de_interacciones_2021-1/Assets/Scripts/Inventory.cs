using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory{

    public event EventHandler onItemListChanged;
    private List<Item> itemList;
    private Action<Item> useItemAction;

    public Inventory(Action<Item> useItemAction){
        this.useItemAction = useItemAction;
        itemList = new List<Item>();
        
        AddItem(new Item{itemType = Item.ItemType.RiffleAmmo, amount = 1});
        AddItem(new Item{itemType = Item.ItemType.ShotgunAmmo, amount = 1});
        AddItem(new Item{itemType = Item.ItemType.Armor, amount = 1});
    }

    public void AddItem(Item item){
        if(item.IsStackable()){
            bool itemAlreadyInInventory = false;
            foreach(Item inventoryItem in itemList){
                if(inventoryItem.itemType == item.itemType){
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if(!itemAlreadyInInventory){
                itemList.Add(item);
            }
        } else{
            itemList.Add(item);
        }
        onItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item){
        if(item.IsStackable()){
            Item itemInInvetory = null;
            foreach(Item inventoryItem in itemList){
                if(inventoryItem.itemType == item.itemType){
                    inventoryItem.amount -= item.amount;
                    itemInInvetory = inventoryItem;
                }
            }
            if(itemInInvetory != null && itemInInvetory.amount <= 0){
                itemList.Remove(itemInInvetory);
            }
        } else{
            itemList.Remove(item);
        }
        onItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(Item item){
        useItemAction(item);
    }

    public List<Item> GetItemList(){
        return itemList;
    }

}
