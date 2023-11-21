using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class kutuscript : MonoBehaviour,Iclickable
{
    
    public Rigidbody rb;
    public Collider col;
    public float guc;
    public GameObject leke;
    public static int  katmanarttirma;
    private SpriteRenderer sr;
    ParticleSystem party;
    MeshRenderer mesh;
    
    public AudioSource patlatmasource;
    
    private void Start()
    {
        
        int random_eksen=Random.Range(8,60);
        int random_eksen2=Random.Range(15,100);
        transform.Rotate(0,random_eksen,random_eksen2);
        mesh = GetComponent<MeshRenderer>();
        party = GetComponent<ParticleSystem>();
        rb.AddForce(Vector3.up * guc);
        //InvokeRepeating("komboazalt",0,1);   // kombo olayını iyice düşün. 
        //Aşağıda komboazaltmak için bir fonksiyon oluştur.Burada da her 10 saniyede bir azaltma işlemi uyguluyor
    }


    public void tıkladın()
    {
        patlatmasource.Play();
        GameManager.kutuvurmasayisi+=1;
        sr = leke.GetComponent<SpriteRenderer>();
        party.Play();
        mesh.enabled = false;
        col.enabled = false;
        sr.sortingOrder = katmanarttirma;
        katmanarttirma++;
        Instantiate(leke, new Vector3(transform.position.x, transform.position.y,0),Quaternion.identity);
        Destroy(gameObject, 0.3f);
        GameManager.instance.BoyaSayısı -= 1;
        PlayerPrefs.SetInt("boya", GameManager.instance.BoyaSayısı);

    }
    

    public void click()
    {
       tıkladın();
     
    }
   
}
