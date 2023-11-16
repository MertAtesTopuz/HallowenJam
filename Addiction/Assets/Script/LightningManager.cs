using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningManager : MonoBehaviour
{
    public static LightningManager instance;

    [SerializeField] GameObject lightning;
    public bool lightningCheck;
    public float checkCounter;
    public bool animCheck;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        var camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        lightning.transform.position = new Vector3(camPos.x, camPos.y, lightning.transform.position.z);

        if (lightningCheck == false)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                 checkCounter++; 
            }

            if (checkCounter == 1)
            {
                lightning.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    animCheck = true;
                    lightningCheck = true;
                }
            }

            else if (checkCounter == 2)
            {
                lightning.SetActive(false);
                checkCounter = 0;
            }
        }
    }
}
