using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private int quantities = 10;
    private int n = 0;

    private Vector3 center;
    private Vector3 size;

    void Start()
    {
        //Vai pegar os objetos com a tag Spawner
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawner");
    }

    void Update()
    {
        //Vai spawner a quantidade que for colocado em quantities
        if (n < quantities)
        {
            n++;
            SpawnObjectAtRandom();
        }
    }

    GameObject SelectRandomSpawner()
    {
        GameObject selectedSpawner;
        //Vai ser escolhido aleatoriamente o ponto de spawn
        selectedSpawner = spawnPoints[Random.Range(0, spawnPoints.Length)];
        return selectedSpawner;
    }

    void SpawnObjectAtRandom()
    {
        //Vai ser pego o centro e a escala do spwner escolhido aleatoriamente
        center = SelectRandomSpawner().transform.position;
        size = SelectRandomSpawner().transform.localScale;

        //Vai aleatorizar a posicao com base no centro e o tamanho do objeto spwner
        Vector3 randomPos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        //Esta instanciando o prefab de item na posicao aleatoria sem rotacao
        Instantiate(itemPrefab, randomPos, Quaternion.identity);
    }
}
