using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour
{
    public Character myCharacter;

    public void ANIM_EVENT(string param)
    {
        if (param == "shoot")
        {
            myCharacter.ANIMEVENT_Shoot();
        }
    }
}
