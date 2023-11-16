using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Animator anim;

    [SerializeField] GameObject blackFrameLightning;
    [SerializeField] GameObject blackFrameMeteor;
    [SerializeField] TextMeshProUGUI txt;

    [SerializeField] TextMeshProUGUI mainTimerTxt;
    float mainTimer = 50;
    float mainTimeSetter;

    float timer;
    [SerializeField] float timeSetter;
    [SerializeField] float oldTimeSetter;
    [SerializeField] float timeSetter2 = 1;

    public bool enemyWCheck;
    public bool heroWCheck;

    public GameObject enemyWPnl;
    public GameObject heroWPnl;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        oldTimeSetter = timeSetter;
    }

    private void Update()
    {
        mainTimer -= Time.deltaTime;
        mainTimeSetter = mainTimer;

        if (LightningManager.instance.lightningCheck == true)
        {
            timer -= Time.deltaTime;
            StartCoroutine(Cooldown());
        }
        txt.text = timeSetter.ToString("0");
        mainTimerTxt.text = mainTimeSetter.ToString("00");

        if (mainTimeSetter <=0)
        {
            heroWCheck = true;
        }

        if (timer <= 0)
        {
            timeSetter--;
            timer = timeSetter2;
        }

        EnemyWin();
        HeroWin();
    }

    IEnumerator Cooldown()
    {        
        blackFrameLightning.SetActive(true);
        yield return new WaitForSeconds(timeSetter);
        blackFrameLightning.SetActive(false);
        LightningManager.instance.lightningCheck = false;
        timeSetter = oldTimeSetter;
    }

    private void EnemyWin()
    {
        if (enemyWCheck == true)
        {
            enemyWPnl.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void HeroWin()
    {
        if (heroWCheck == true)
        {
            heroWPnl.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void MenuBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }


}
