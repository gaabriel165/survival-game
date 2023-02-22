using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPrefab : MonoBehaviour
{
    private Player player;

    private void Start(){
        this.player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collisionObject) {
         if(collisionObject.gameObject.tag == "spritePlayer"){
            Destroy(gameObject);
            this.player.Healing();
        }
    }
}
