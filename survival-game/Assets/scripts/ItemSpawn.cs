using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour {
    [SerializeField] private GameObject gunPrefab;

    [SerializeField] private GameObject healingPrefab;
    [SerializeField] private GameObject increaseSpeedPrefab;

    void Start(){
        StartCoroutine(this.SpawnItem());
    }

    private IEnumerator SpawnItem(){
        System.Random random = new System.Random();

        float number = random.Next(4, 11);

        yield return new WaitForSeconds(number);

        float generatedPositionX = random.Next(-25, 15);
        float generatedPositionY = random.Next(-12, 15);

        float randomizedItem = Mathf.RoundToInt(random.Next(1, 11));   

        if(randomizedItem <= 6){
            Instantiate(gunPrefab, new Vector2(generatedPositionX, generatedPositionY), this.gunPrefab.transform.rotation);
        }

        if(randomizedItem >= 7 && randomizedItem <= 9){
            Instantiate(healingPrefab, new Vector2(generatedPositionX, generatedPositionY), this.healingPrefab.transform.rotation);
        }

        if(randomizedItem == 10){
            Instantiate(increaseSpeedPrefab, new Vector2(generatedPositionX, generatedPositionY), this.increaseSpeedPrefab.transform.rotation);
        }

        StartCoroutine(this.SpawnItem());
    }
}
