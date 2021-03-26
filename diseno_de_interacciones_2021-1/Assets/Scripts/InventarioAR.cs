using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioAR : MonoBehaviour
{
    static protected InventarioAR s_InventoryARInstance;
    static public InventarioAR InventarioARInstance{ get { return s_InventoryARInstance; } }
    public delegate void OnChange();
    public OnChange onChange;
    public int space = 10;
    public List<ItemAR> items = new List<ItemAR>();

    private void Awake() {
        s_InventoryARInstance = this;
    }

    public void Add(ItemAR newItem){
        if(items.Count < space){
            items.Add(newItem);
            if(onChange != null){
                onChange.Invoke();
            }
        } else{
            Debug.Log("No hay espacio disponible");
        }
    }

    public void Remove(ItemAR itemToRemove){
        if(items.Contains(itemToRemove)){
            items.Remove(itemToRemove);
            if(onChange != null){
                onChange.Invoke();
            }
        } else{
            Debug.Log("No esta el item");
        }
    }
}
