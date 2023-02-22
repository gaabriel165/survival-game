using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGun : MonoBehaviour
{
    private Player player;

    private void Start(){
        this.player = GameObject.FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collisionObject) {
         if(collisionObject.gameObject.tag == "spritePlayer"){
            Destroy(gameObject);
            this.player.AddBullets();
        }
    }
}
