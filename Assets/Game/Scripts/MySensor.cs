using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySensor : MonoBehaviour
{
    Renderer myRender;
    [SerializeField] LayerMask mylayersToIgnore;
    [SerializeField] private string nameLayer;

    void Start()
    {
        myRender = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.layer == LayerMask.LayerToName(nameLayer))
        if(other.gameObject.tag == "ground") return;
        myRender.material.color = Color.red;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "ground") return;
        myRender.material.color = Color.green;
    }

    void OnTriggerStay(Collider other)
    {

    }
}
