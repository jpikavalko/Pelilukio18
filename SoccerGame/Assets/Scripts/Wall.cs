using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jos koodi näyttää sekavalta, voit huoletta poistella kaikki kommentit.
//Ne eivät vaikuta itse suorituskykyyn tai mihinkään.
public class Wall : MonoBehaviour {

    //asetamme inspectorissa, kumman maali on kyseessä.
    public int playerGoal;

    //Tämä metodi kertoo, mitä tapahtuu, kun toinen objekti astuu tämän
    //peliobjektin colliderin rajojen sisälle.
    private void OnTriggerEnter(Collider other)
    {
        //Jos other ("muu") on tägätty nimellä "Ball", niin suorita seuraavat lauseet
        if(other.gameObject.tag == "Ball")
        {
            if (playerGoal == 1)
                ResetBall(2, other);
            if (playerGoal == 2)
                ResetBall(1, other);
        }
    }

    //Oma metodi nimeltä ResetBall, jolle syötämme parametriksi kokonaislukumuuttujan "goal"
    //ja Colliderin nimeltä "other".
    void ResetBall(int goal, Collider other)
    {
        //Logataan consoleen (Window -> Console) teksti. Huomaa plus-merkit ja katso, miten ne toimivat.
        Debug.Log("Pelaaja " + goal + " teki maalin");

        //resetoidaan pallon positio alkupisteeseen.
        other.gameObject.transform.position = new Vector3(0f, 0.5f, 0f);

        //Se ei kuitenkaan resetoi pallon momenttumia eli kaivamme toisen objektin (tässä tapauksessa pallo)
        //rigidbodyn ja asetamme sieltä löytyvän velocityn arvoon "nolla"
        other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        //Pelkkä liike-energian pysäyttäminen ei riitä, sillä mukana on myös kierimisliike. Asetetaan sekin nollaan.
        other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        //Vector3.zero tarkoittaa samaa kuin "new Vector3(0f, 0f, 0f)"

        //Pelaajat eivät resetoidu. Se on helppo tehdä, katsotaan se myöhemmin.
    }
}
