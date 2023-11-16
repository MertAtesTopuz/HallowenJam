using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shield : MonoBehaviour
{
    [SerializeField] GameObject shield;
    [SerializeField] GameObject blackFrameShild;

    [SerializeField] float shieldTime;

    [SerializeField] TextMeshProUGUI txt;

    bool tryre;

    float timer;
    [SerializeField] float timeSetter;
    [SerializeField] float oldTimeSetter;
    [SerializeField] float timeSetter2 = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && tryre == false)
        {
            StartCoroutine(ShieldTimer());
        }

        if (tryre ==true)
        {
            timer -= Time.deltaTime;
        }

        txt.text = timeSetter.ToString("0");

        if (timer <= 0)
        {
            timeSetter--;
            timer = timeSetter2;
        }
    }

    IEnumerator ShieldTimer()
    {
        shield.SetActive(true);
        yield return new WaitForSeconds(shieldTime);
        shield.SetActive(false);
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        blackFrameShild.SetActive(true);
        tryre = true;
        yield return new WaitForSeconds(timeSetter);
        blackFrameShild.SetActive(false);
        timeSetter = oldTimeSetter;
        tryre = false;
    }

}
