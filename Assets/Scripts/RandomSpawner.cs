using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] myObjects;
    public float checkRadius;
    private float objectCount;

    // Start is called before the first frame update
    void Start()
    {
        objectCount = SceneManager.GetActiveScene().buildIndex;
          
        for(int i = 0; i < objectCount; i++)
        {
            int randomIndex = Random.Range(0,myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-2, 9), 0.8f, Random.Range(-2, 3));

            if(!Physics.CheckSphere(randomSpawnPosition, checkRadius))
            {
                Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);

            }
            else
            {
                i -= 1;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}