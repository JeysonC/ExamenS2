using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    public float velocidadBullet = 50;
    private GameManagerController gamemanager;

    Rigidbody2D rb;
    float realVelocity;

    public void SetRightDirection(){
        realVelocity = velocidadBullet;
    }
    public void SetLeftDirection(){
        realVelocity = -velocidadBullet;
    }

    void Start()
    {
        gamemanager = FindObjectOfType<GameManagerController>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(realVelocity, 0);
    }

    void OnCollisionEnter2D(Collision2D other){
        Destroy(this.gameObject);
        if(other.gameObject.tag == "Zombie"){
            Destroy(other.gameObject);

            gamemanager.PerderBalas(1);
            gamemanager.SaveGame();
        }
    }
}
