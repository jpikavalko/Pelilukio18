using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Movement script on ennemminkin "Class" eli "luokka". Kakoispiste ja toinen luokka perässä tarkoittaa
//että perimme MonoBehaviour -luokasta jotakin. Jos sitä ei olisi, emme voisi käyttää suoraan
//Start() ja Update() -funktioita.
public class Movement : MonoBehaviour
{
    //Rigidbody tyypin muuttuja (tässä tapauksessa komponentti) nimeltä "rb"
    Rigidbody rb;

    //public = julkinen = näkyy inspectorissa
    //luodaan float tyyppinen muuttuja, jonka nimi on speed ja joka alustetaan arvoon 5
    public float speed = 5f;

    //int tyypin muuttuja nimeltä playerNumber.
    public int playerNumber;

    //Start-metodia kutsutaan pelin käynnistyessä sen ensimmäisellä framella.
    //Frame per second on ihanteellisesti 60 tai enemmän.
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Näppäin inputit tapahtuvat aina Update-metodin (= funktion) sisällä.
    void Update()
    {
        //Jos pelaajan arvo = 1, niin suoritamme kaarisulkujen sisällä olevan pätkän koodia.
        //Jos näin ei ole, siirrymme scopen yli seuraavana kohtaan.
        if (playerNumber == 1)
        {
            //GetAxis "Vertical" ja "Horizontal" löytyvät Unitysta ->
            //Edit -> Project Settings -> Input (aukeaa Inspectoriin)
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");

            //Kutsutaan itse luomaamme metodia MovePlayer(), jolle annetaan parametreiksi
            //inputista saamamme float v ja float h.
            MovePlayer(h, v);
        }
        if (playerNumber == 2)
        {
            float v = Input.GetAxis("Vertical2");
            float h = Input.GetAxis("Horizontal2");
            MovePlayer(h, v);
        }
    }

    //Metodi joka ottaa parametreikseen (sulkujen sisällä) kaksi arvoa "float h" ja "float v"
    void MovePlayer(float h, float v)
    {
        //tämä ei ole lainkaan pakollinen vaihe vaan...
        float newSpeed = speed * Time.deltaTime;

        //...voimme kirjoittaa seuraavan myös:
        //transform.Translate(h * speed * Time.deltaTime, 0f, v * speed * Time.deltaTime);
        transform.Translate(h * newSpeed, 0f, v * newSpeed);
    }

}