using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private AudioSource zombieSound; 

    private void Start() {
        StartCoroutine(this.SpawnEnemy());

        this.zombieSound = this.GetComponent<AudioSource>();
    }

    private IEnumerator SpawnEnemy(){
        System.Random random = new System.Random();

        float number = random.Next(2, 8);

        yield return new WaitForSeconds(3);

        if(number < 4){
            zombieSound.Play();
        }

        float generatedPositionX = random.Next(-25, 15);
        float generatedPositionY = random.Next(-12, 14);

        Instantiate(enemyPrefab, new Vector2(generatedPositionX, generatedPositionY), this.enemyPrefab.transform.rotation);

        StartCoroutine(this.SpawnEnemy());
    }
}
