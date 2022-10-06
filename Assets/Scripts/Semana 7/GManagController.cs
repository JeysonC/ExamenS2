using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManagController : MonoBehaviour
{
    public Text scoreText;
    public Text vidaText;

    private int score;
    private int vida;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        vida = 3;
        PrintScoreInScreen();
        PrintVidaInScreen();
    }

    public int Score(){
        return score;
    }
    public void GanarPuntos(int puntos){
        score += puntos;
        PrintScoreInScreen();
    }

    public int Vida(){
        return vida;
    }
    public void PerderVidas(int vidas){
        if(vida>0){
            vida -= vidas;
            PrintVidaInScreen();
        }
        
    }

    private void PrintScoreInScreen(){
        scoreText.text = "Puntaje: "+ score;
    }
    private void PrintVidaInScreen(){
        vidaText.text = "Vida: "+ vida;
    }
}
