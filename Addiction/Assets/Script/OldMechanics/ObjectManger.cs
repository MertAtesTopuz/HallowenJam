using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManger : MonoBehaviour
{
    public static ObjectManger instance;

    public bool isSawSelected;
    public bool isLightningSelected;
    public bool isFirePitSelected;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isSawSelected = true;
            isFirePitSelected = false;
            isLightningSelected = false;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            isLightningSelected = true;
            isSawSelected = false;
            isFirePitSelected = false;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            isFirePitSelected = true;
            isSawSelected = false;
            isLightningSelected = false;
        }
    }
}
