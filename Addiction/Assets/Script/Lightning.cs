using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject thisis;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (LightningManager.instance.animCheck == true)
        {
            StartCoroutine(LightningTimer());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterHealth.instance.TakeDamage(1);
        }
    }

    IEnumerator LightningTimer()
    {
        anim.SetTrigger("isLightning");
        LightningManager.instance.animCheck = false;
        yield return new WaitForSeconds(0.45f);
        LightningManager.instance.checkCounter++;
        thisis.SetActive(false);
    }

}
