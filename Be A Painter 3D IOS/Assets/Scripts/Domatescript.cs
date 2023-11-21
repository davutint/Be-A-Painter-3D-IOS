using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domatescript : MonoBehaviour
{
    ParticleSystem party;
    MeshRenderer mesh;
    
    public Rigidbody rb;
    public float guc;
    public Collider col;
    public GameObject leke;

    public AudioSource vurmasesi;
    
    void Start()
    
    {
        int random_eksen=Random.Range(8,60);
        int random_eksen2=Random.Range(15,100);
        transform.Rotate(0,random_eksen,random_eksen2);
        mesh = GetComponent<MeshRenderer>();
        party = GetComponent<ParticleSystem>();
        rb.AddForce(Vector3.up* guc);
        
    }

    

    

   public void domatevurdun()
    {

        vurmasesi.Play();
        Instantiate(leke, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        party.Play();
        mesh.enabled = false;
        col.enabled = false;
        GameManager.OyunBitti = true;
        Destroy(gameObject, 0.3f);
        

    }
}
