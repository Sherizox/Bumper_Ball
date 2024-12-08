using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemySphere;
    public  float SpawnRange = 30f;
    public  float SpawnRange1 = 6f;
    public  int numberOfSpheres = 5;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfSpheres; i++)
        {
            Instantiate(enemySphere, GenerateSphere(), enemySphere.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private  Vector3 GenerateSphere()
    {

        float posX = Random.Range(-SpawnRange1, SpawnRange);
        float posz = Random.Range(-SpawnRange1, SpawnRange);

        Vector3 pos = new Vector3(posX, 0, posz);
         return pos;

       
    }


}
