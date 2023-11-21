using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copscript : MonoBehaviour
{
   
    
   private BoxCollider col;
    public GameObject[] kalanhak;

    public AudioSource dusurdun;

    private void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    /* public void restart()// sahneyi yeniden yüklemek yerine oyunun bitme belirtilerini tek tek yok edip yeniden başlamasını sağladım.
      {
        for (int i = 0; i < kalanhak.Length; i++)
        {
          kalanhak[i].GetComponent<MeshRenderer>().enabled=true;
        }
        oyunsonupaneli.SetActive(false);
        GameManager.instance.canvaskontroletme();
        oyunbittikards=false;
        spawner.oyunbasladı=true;
        col.enabled=true;
        say=0;
        GameManager.skor=0;
        GameObject temp=GameObject.FindWithTag("domateslekesi");
        GameObject[] tempkutular=GameObject.FindGameObjectsWithTag("kutu");

        if (tempkutular!=null)// yandığında sahnede bulunan boya kutularını bulup yok ediyor
        {
          foreach (var item in tempkutular)
          {
            Destroy(item);
          }
        }


        if (temp != null)//domates lekesini oyun bitince yok ediyor
        {
             Destroy(temp);
        }
      }*/

    private void OnTriggerEnter(Collider collider) 
    {
       
       if (collider.CompareTag("kutu"))
       {
            dusurdun.Play();
            kalanhak[GameManager.say].GetComponent<ParticleSystem>().Play();
            kalanhak[GameManager.say].GetComponent<MeshRenderer>().enabled = false;
            GameManager.say++;
            
            
       }
    }
    
}
