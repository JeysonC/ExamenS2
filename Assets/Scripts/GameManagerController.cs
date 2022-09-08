using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    public Text balasText;
  
    private int bala;
    void Start()
    {
        bala = 5;
        PrintBulletInScreen();
    }

    // Update is called once per frame
    public int Bullet(){
        return bala;
    }
    public void PerderBalas(int balas){
        bala -= balas;
        PrintBulletInScreen();
    }
    private void PrintBulletInScreen(){
        balasText.text = "Balas: " + bala;
    }
}
