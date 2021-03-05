using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploCar : Interactable
{
    private MeshRenderer mr; 
    private GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        go = GameObject.Find("Car");
        mr.enabled = false;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Interact()
    {
        mr.enabled = true;
        Destroy(go,3f);
        Destroy(mr,3f);
    }
}
