using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Camera mainCam;

    [SerializeField] GameObject projectile;
    [SerializeField] bool countBool = true;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        var camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (InputHandler.instance.bulletArea == true && countBool == true)
            {
                 Vector3 vec = camPos;
                vec.z++;
                Instantiate(projectile, vec, Quaternion.identity);
                InputHandler.instance.bulletArea = false;
                StartCoroutine(ShootDelay());
            }
            
        }
    }

    IEnumerator ShootDelay()
    {
        countBool = false;
        yield return new WaitForSeconds(1f);
        countBool = true;
    }
}
