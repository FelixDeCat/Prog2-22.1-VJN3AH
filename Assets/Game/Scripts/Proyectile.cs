using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    [SerializeField] float speed;
    bool anim;

    public void Move(Vector3 position, Vector3 direction)
    {
        this.transform.position = position;
        this.transform.forward = direction;
        anim = true;
    }

    private void Update()
    {
        if (!anim) return;

        this.transform.position += this.transform.forward * speed * Time.deltaTime;
    }
}
