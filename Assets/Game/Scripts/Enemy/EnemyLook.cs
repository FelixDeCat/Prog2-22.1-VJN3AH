using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour
{
    Character myCharacter;

    [SerializeField] float speed;

    [SerializeField] float distance_to_brake = 1f;

    private void Start()
    {
        myCharacter = GameManager.Char;
        
    }

    bool oneshot;

    private void Update()
    {
        Vector3 dir = myCharacter.Position - this.transform.position;
        //transform.forward = dir;

        transform.forward = Vector3.Slerp(this.transform.forward, dir, Time.deltaTime * 2f);

        if (Vector3.Distance(transform.position, myCharacter.Position) > distance_to_brake)
        {
            oneshot = false;
            transform.position = transform.position + dir.normalized * speed * Time.deltaTime;
        }
        else
        {
            if (!oneshot)
            {
                oneshot = true;
                //empieza el timer
                //animacion
                //bla bla bla
            }
        }
    }
}
