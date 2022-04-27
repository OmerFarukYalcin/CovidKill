using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject Player,Bullet,Cure,Enemy,bonusHp;
    public Text pointText,totalPointText,totalPointStext;
    public Image fixTimerImage;
    public GameObject SuccesPanel,MainMenu;
    float timer=2;
    float bulletTimer = 3;
    float fixtimer;
    float fixtimerValue;
    public int score;
    void Start()
    {
        GetComponent<AudioSource>().Play();
        fixtimer = Random.Range(8, 15);
        fixtimerValue = fixtimer;
        Time.timeScale = 1;

        for (int i = 0; i < Random.Range(10,25); i++)
        {
            RandomEnemySpanner();
        }
    }
    void Update()
    {
        if (timer < Time.time)
        {
            RandomBonusSpanner();
            timer = Time.time + 2;
        }
        if (bulletTimer < Time.time)
        {
            RandomBulletSpanner();
            bulletTimer = Time.time + 3;
        }

        FixVirus();
        GameExit();
    }

    public void RandomEnemySpanner()
    {
        Instantiate(Enemy,Random.insideUnitCircle *50,Quaternion.identity);
        Enemy.gameObject.tag = "Test";
    }

    void RandomBonusSpanner()
    {
        Instantiate(bonusHp, Random.insideUnitCircle * 7, Quaternion.identity);
        bonusHp.gameObject.tag = "Test";
    }

    void RandomBulletSpanner()
    {
        Instantiate(Bullet, Random.insideUnitCircle * 7, Quaternion.identity);
        Bullet.gameObject.tag = "Test";
    }

    void FixVirus ()
    {
        fixtimer -= Time.deltaTime;
        fixTimerImage.GetComponent<Image>().fillAmount = fixtimer / fixtimerValue;
        if (fixtimer <= 0 )
        {
            Instantiate(Cure, new Vector2(-6.89f, -3.43f), Quaternion.identity);
            Cure.gameObject.tag = "Test";
            enabled = false;
        }
    }

    public void CurePandemic()
    {
        Time.timeScale = 0;
        SuccesPanel.SetActive(true);
        totalPointStext.text = "Total Point = " + score;
    }
    void GameExit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    public void ButtonX()
    {
        MainMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }
}
