using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject gameControl;
    GameObject LevelLoadControl;
    public GameObject bullet,failPanel;
    public Text playerHptext,totalBulletText;
    private int playerHp;
    private int TotalBullet = 50;
    public string LevelName;
    float x,y;
    void Start()
    {
        playerHp = 100;
        LevelLoadControl = GameObject.Find("LevelLoader");
        gameControl = GameObject.Find("_Scripts");
        rb =GetComponent<Rigidbody2D>();
        playerHptext.text = "Player Hp= " + playerHp;
        
    }

    
    void Update()
    {
        PlayerMovement();
        Fire();
        DestorAll();
    }

    void PlayerMovement()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        rb.AddForce(new Vector2(x*10f, y*10f));
    }

    void PlayerDead()
    {
        Debug.Log("Player is Dead!");
        Time.timeScale = 0;
        failPanel.SetActive(true);
        gameControl.GetComponent<GameControl>().totalPointText.text = "Total Point = " + gameControl.GetComponent<GameControl>().score;
    }

    void DestorAll()
    {
        if (failPanel.activeInHierarchy || gameControl.GetComponent<GameControl>().SuccesPanel.activeInHierarchy)
        {
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Test");
            foreach (GameObject Test in temp)
            GameObject.Destroy(Test);
        }
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0) && TotalBullet>0 && !gameControl.GetComponent<GameControl>().MainMenu.activeInHierarchy && !failPanel.activeInHierarchy && !gameControl.GetComponent<GameControl>().SuccesPanel.activeInHierarchy)
        {
            Instantiate(bullet,transform.position,Quaternion.identity);
            TotalBullet -= 1;
            totalBulletText.text = "Total Bullet= " + TotalBullet;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Enemy"))
        {
            playerHp -= 10;
            playerHptext.text = "Player Hp= " + playerHp;
            if (playerHp <= 0)
            {
                PlayerDead();
                playerHptext.text = "Player Hp= 0";
            }
        }
        else if (collision.name.Contains("BonusHp"))
        {
            if (playerHp < 100)
            {
                playerHp += 10;
                playerHptext.text = "Player Hp= " + playerHp;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.name.Contains("bulletspawn"))
        {
                TotalBullet += 1;
                totalBulletText.text = "Total Bullet= " + TotalBullet;
            Destroy(collision.gameObject);
        }

        else if (collision.name.Contains("Vacchine"))
        {
            //if (SceneManager.GetActiveScene().buildIndex < 3)
            //{
            //    LevelLoadControl.GetComponent<LevelLoader>().LoadNextLevel();
            //}
            //else
            //{
            //    gameControl.GetComponent<GameControl>().CurePandemic();
            //}
            PlayerPrefs.SetInt(LevelName, 1);
            gameControl.GetComponent<GameControl>().CurePandemic();
        }
    }
}
