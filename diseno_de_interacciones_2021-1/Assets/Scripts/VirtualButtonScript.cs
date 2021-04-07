using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonScript : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject augmentable;
    private VirtualButtonBehaviour virtualButton;
    public Animator animator;

    private void Awake() {
        virtualButton = GetComponent<VirtualButtonBehaviour>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(virtualButton != null){
            virtualButton.RegisterEventHandler(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        animator.SetTrigger("attack");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
    }
}
