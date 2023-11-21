using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawner : MonoBehaviour
{
    public GameObject[] kutular;
    public GameObject spawnerobjesi;
    public GameObject domates;

    public static bool SpawnEt;
    private void Start()
    {
         SpawnEt = true;
         InvokeRepeating("spawnet", 1, .7f);

    }

   public void spawnet() //spawn etme komutunu invoke ederek updatete çalışmasını engelliyorum
    {
        if(SpawnEt)
        {
            Debug.Log("SPAWN EDİLİYOR");
         float xaraligi = Random.Range(-3.5f, 3.5f);
         int rastkutu = Random.Range(0, kutular.Length);
         int spawnolasılığı=Random.Range(0,100);
         if(spawnolasılığı>=0&&spawnolasılığı<=85){

             klonla(kutular[rastkutu], xaraligi);
         }
         else if(spawnolasılığı>=86&&spawnolasılığı<=100){
            klonla(domates,xaraligi);
         }
         
        }
    }


    void klonla(GameObject nesne,float x_kordinat)
    {
        GameObject yeniklon = Instantiate(nesne);

        yeniklon.transform.position = new Vector3(x_kordinat, spawnerobjesi.transform.position.y, spawnerobjesi.transform.position.z);
        Destroy(yeniklon, 4f);

    }
}
