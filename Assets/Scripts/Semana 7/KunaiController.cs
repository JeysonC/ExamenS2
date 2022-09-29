using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    public float velocidadKunai = 50;

    public int danio=1;
    Rigidbody2D rb;
    float realVelocidad;

    public void SetRightDirection()
    {
        realVelocidad = velocidadKunai;
    }
    public void SetLeftDirection()
    {
        realVelocidad = -velocidadKunai;
    }
    public void SetDanio(int d){
        danio = d;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(realVelocidad, 0);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyZController>().Attacking(danio);
            // Destroy(other.gameObject);
        }
    }
}
