using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            DestroyImmediate(this.gameObject);
    }

    [SerializeField] Character myChar;
    public static Character Char
    {
        get
        {
            return instance.myChar;
        }
    }

}
