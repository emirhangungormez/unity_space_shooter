using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public Vector3 randomPosizyon;
    public GameObject Asteroid1;
    public GameObject Asteroid2;
    public float baslangicBekleme;
    public float olusturmaBekleme;
    public float donguBekleme;

    bool oyunBittiKontrol = false;
    bool yenidenBaslaKontrol = false;

    public Text text;
    public Text gameOverText;
    public Text R;

    int score;

    void Start() 
    {
        score = 0;
        text.text = "Score: " + score; 
        
        StartCoroutine(olustur());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && yenidenBaslaKontrol)
        {
            SceneManager.LoadScene("0");
        }
    }

    IEnumerator olustur()
    {
        yield return new WaitForSeconds(baslangicBekleme);

        while(true)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randomPosizyon.x, randomPosizyon.x), 0, randomPosizyon.z);

                if (Random.Range(1, 3) == 1)
                {
                    Instantiate(Asteroid1, vec, Quaternion.identity);
                    yield return new WaitForSeconds(olusturmaBekleme); //1 saniye bekle
                }

                if (Random.Range(1, 3) == 2)
                {
                    Instantiate(Asteroid2, vec, Quaternion.identity);
                    yield return new WaitForSeconds(olusturmaBekleme); //1 saniye bekle
                }
            }

            if (oyunBittiKontrol)
            {
                R.text = "Yeniden baþlamak için R'ye basýn.";
                yenidenBaslaKontrol = true;
                break;
            }

            yield return new WaitForSeconds(donguBekleme);
        }
    }

    public void ScoreArtir(int gelenScore)
    {
        score += gelenScore;
        text.text = "Score: " + score;
    }

    public void OyunBitti()
    {
        gameOverText.text = "Oyun bitti :(";
        oyunBittiKontrol = true;
    }
}
