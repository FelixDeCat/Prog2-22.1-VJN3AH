using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseWaypointer : MonoBehaviour
{
    public Waypoint[] myWaypoints;
    Waypoint current;

    [Range(1,10)]
    public float speedrotation = 3;

    float timer = 0;
    [SerializeField] float time_to_movement = 3f;
    bool anim;

    private void Start()
    {
        BeginAnimation();
    }

    public void BeginAnimation()
    {
        if (myWaypoints.Length <= 0) return;
        current = myWaypoints[0];
        anim = true;
        timer = 0;
    }
    public void EndAnimation()
    {
        anim = false;
        timer = 0;
    }

    void Lerp(float val)
    {
        transform.position = Vector3.Lerp(current.transform.position, current.next.transform.position, val);
        Vector3 dir = current.next.transform.position - current.transform.position;
        //transform.forward = dir;
        transform.forward = Vector3.Slerp(this.transform.forward, dir, Time.deltaTime * speedrotation);

    }

    private void Update()
    {
        if (anim)
        {
            if (timer < time_to_movement)
            {
                timer = timer + 1 * Time.deltaTime;
                //animacionnn
                Lerp(timer/time_to_movement);
            }
            else
            {
                timer = 0;
                current = current.next;
                if (current == null) anim = false;
            }
        }
    }
}
