using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidControl : MonoBehaviour
{
    static AudioSource audio;

    Rigidbody fizik;
    public float hiz;

    GameObject oyunKontrol;
    GameControl kontrol;

    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = transform.forward * -hiz;

        audio = GetComponent<AudioSource>();

        oyunKontrol = GameObject.FindGameObjectWithTag("GameControl");
        //Hiyerarþide yer alan bir nesneye ulaþýr.

        kontrol = oyunKontrol.GetComponent<GameControl>();
        //Nesnede yer alan bir koda ulaþýr.
    }

    public GameObject patlama;
    public GameObject oyuncuPatlama;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Edge")
        {
            audio.Play();
            Debug.Log("Bravo, iyi atýþ!");
            Destroy(col.gameObject);
            Destroy(gameObject);

            Instantiate(patlama, transform.position, transform.rotation);
            //(obje, pozisyon,rotasyon)

            kontrol.ScoreArtir(10);

        }

        if (col.tag == "Player")
        {
            audio.Play();

            Instantiate(oyuncuPatlama, col.transform.position, col.transform.rotation);

            kontrol.ScoreArtir(-50);
            kontrol.OyunBitti();          
        }
    }
}
