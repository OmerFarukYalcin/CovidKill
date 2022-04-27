using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    GameObject gameControl;
    void Start()
    {
        gameControl = GameObject.Find("_Scripts");

        rb = GetComponent<Rigidbody2D>();

        direction=Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        rb.AddForce(direction.normalized * 15,ForceMode2D.Impulse);

        Destroy(gameObject,4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.name.Equals("Player") && !collision.name.Equals("Wals") && !collision.name.Contains("Vacchine"))
        {
            if (collision.name.Contains("Enemy"))
            {
                gameControl.GetComponent<GameControl>().RandomEnemySpanner();
                gameControl.GetComponent<GameControl>().score += 10;
                gameControl.GetComponent<GameControl>().pointText.text = "Point= " + gameControl.GetComponent<GameControl>().score;
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
    }
}
