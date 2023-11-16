using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;

    private Camera mainCam;
    public GameObject saw;
    public GameObject firePit;
    public GameObject lightning;

    public bool bulletArea;

    private void Awake()
    {
        mainCam = Camera.main;
        instance = this;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }

        var rayHit = Physics2D.GetRayIntersection(mainCam.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider)
        {
            return;
        }

        GameObject lastHit = rayHit.collider.gameObject;

        if (lastHit.CompareTag("Manager"))
        {
            bulletArea = true;
        }
    }
}


/*
GameObject lastHit = rayHit.collider.gameObject;

if (ObjectManger.instance.isSawSelected == true)
{
    Instantiate(saw, lastHit.transform.position, Quaternion.identity);
}

if (ObjectManger.instance.isLightningSelected == true)
{
    Instantiate(lightning, lastHit.transform.position, Quaternion.identity);
}

if (ObjectManger.instance.isFirePitSelected == true)
{
    Instantiate(firePit, lastHit.transform.position, Quaternion.identity);
}
*/