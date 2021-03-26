using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAR_UI : MonoBehaviour
{
    private InventarioAR _inventoryAR;
    // Start is called before the first frame update
    void Start()
    {
        _inventoryAR = InventarioAR.InventarioARInstance;
        _inventoryAR.onChange += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI(){
        Slot[] slots = GetComponentsInChildren<Slot>();
        for(int i=0; i<slots.Length; i++){
            if(i < _inventoryAR.items.Count){
                slots[i].SetItem(_inventoryAR.items[i]);
            }else{
                slots[i].Clear();
            }
        }
    }
}
