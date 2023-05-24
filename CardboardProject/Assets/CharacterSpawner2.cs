using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner2 : MonoBehaviour
{
    public GameObject objectToSpawn;
    private float spawnDelay = 55.0f;

    private float timer = 0.0f;
    public int enemiesToGenerate = 1;
    public float spawnRange = 5f;

    void Update()
    {
        // Actualiza el temporizador
        timer += Time.deltaTime;

        // Si ha pasado el tiempo de espera, instancia el objeto y reinicia el temporizador
        if (timer >= spawnDelay)
        {
            Generate();
        }
        
        
    }
    public void Generate(){
        for (int i = 0; i <= enemiesToGenerate; i++){
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRange;
            randomPosition.y=transform.position.y;
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
            timer = 0.0f;
        }
        enemiesToGenerate++;

    }
}
