using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public static CharacterHealth instance;

    public Animator anim;
    public CharacterCoroller con;

    public Image[] hearts;
    public int health = 20;
    public int maxHealth = 20;
    private bool flashActive;
    [SerializeField] private float flashLenght = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer playerSprite;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
       // anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        HurtFlash();

        if (health <= 0)
        {
            anim.SetBool("isDeath", true);
            con.enabled = false;
            StartCoroutine(DeadAnim());
        }

    }

    public void TakeDamage(int amount)
    {
        hearts[health - 1].enabled = false;
        health -= amount;
        flashActive = true;
        flashCounter = flashLenght;
    }

    private void HurtFlash()
    {
        if (flashActive)
        {
            if (flashCounter > flashLenght * .99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLenght * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLenght * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    IEnumerator DeadAnim()
    {
        
        yield return new WaitForSeconds(0.45f);
        anim.SetBool("isDeath", false);
        gameObject.SetActive(false);
        UIManager.instance.enemyWCheck = true;
        Time.timeScale = 0.0f;
    }
}
