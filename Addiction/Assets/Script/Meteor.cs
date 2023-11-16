using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private SpriteRenderer renderer;
    public Color newColor;
    public GameObject meteorCollider;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Manager")
        {
            renderer.material.color = newColor;
            StartCoroutine(ExplodeDelay());
        }
    }

    IEnumerator ExplodeDelay()
    {
        meteorCollider.SetActive(true);
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject);
    }
}
