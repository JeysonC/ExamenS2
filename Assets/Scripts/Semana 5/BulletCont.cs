using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCont : MonoBehaviour
{
    public float velocidadBullet = 50;
    private GameManag gamemanager;

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
        gamemanager = FindObjectOfType<GameManag>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(realVelocity, 0);
    }

    void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.tag == "Zombie"){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            gamemanager.GanarPuntos(10);
            
        }
    }
}
