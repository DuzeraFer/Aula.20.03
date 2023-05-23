using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnObjects;
    [SerializeField] public List<GameObject> spawnedObjects;
    [SerializeField] public GameObject arCamera;

    int rounds;

    public void StartSpawn()
    {
        StartCoroutine(SpawnObjects());

        rounds = 1;
    }

    IEnumerator SpawnObjects()
    {
        GameObject ballon;

        Vector3 pos = arCamera.transform.position + arCamera.transform.forward * Random.Range(4, 8);
        pos.y -= 4;
        yield return new WaitForSeconds(3);

        ballon = Instantiate(spawnObjects[0], pos, Quaternion.identity);

        spawnedObjects.Add(ballon);

        ballon = Instantiate(spawnObjects[1], pos, Quaternion.identity);
        ballon.transform.Translate(Camera.main.transform.right * -2);

        spawnedObjects.Add(ballon);

        ballon = Instantiate(spawnObjects[2], pos, Quaternion.identity);
        ballon.transform.Translate(Camera.main.transform.right * 2);

        spawnedObjects.Add(ballon);

        if (rounds > 3)
        {
            GameObject extraSpawn = null;

            int randomSpawn = Random.Range(0, 100);

                if (randomSpawn <= 49) extraSpawn = Instantiate(spawnObjects[3], pos, Quaternion.identity);
                else if (randomSpawn >= 50 && randomSpawn < 90) extraSpawn = Instantiate(spawnObjects[4], pos, Quaternion.identity);
                else if (randomSpawn >= 90) extraSpawn = Instantiate(spawnObjects[5], pos, Quaternion.identity);

            spawnedObjects.Add(extraSpawn);

            int randomSpawnPos = Random.Range(0, 3);

            if (randomSpawnPos == 1) extraSpawn.transform.Translate(Camera.main.transform.right * 1.5f);
            else if (randomSpawnPos == 2) extraSpawn.transform.Translate(Camera.main.transform.right * -1.5f);
        }
     
        if (_GameManager.startGame)
            StartCoroutine(SpawnObjects());

        rounds++;
    }
}
