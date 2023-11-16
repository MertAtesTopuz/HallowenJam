using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCol : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterHealth.instance.TakeDamage(1);
            Debug.Log(collision.name);
        }
    }
}
