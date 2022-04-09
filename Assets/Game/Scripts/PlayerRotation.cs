using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Transform rotator;

    private void Update()
    {
        Ray ray_mouse_pos = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray_mouse_pos, out hit))
        {
            //Vector3 dir = hit.point - rotator.position;
            //dir.Normalize();

            rotator.LookAt(hit.point);

            rotator.eulerAngles = new Vector3(0,rotator.eulerAngles.y,0);
        }

    }
}
