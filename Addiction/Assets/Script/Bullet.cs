using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject target;
    public float speed;
    [SerializeField] float destroyTime;
    Rigidbody2D bulletRB;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterHealth.instance.TakeDamage(1);
            Destroy(this.gameObject);
        }
        else if(other.tag != "Manager")
        {
            Destroy(this.gameObject);
        }
    }

}
