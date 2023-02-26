using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Animator enemyAnimator;
    public GameObject enemyAnimatorGameObject;

    private GameObject nextPlayer;
    private GameObject player;
    private Rigidbody2D rb;

    [SerializeField] private GameObject lifebar;

    [SerializeField] private float speed = 1f;

    private Vector2 movement;

    private float health = 100;

    public void PlayAnimation(string animationName){
        enemyAnimator.Play(animationName);
    }
    
    private void Start() {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.player = GameObject.FindGameObjectWithTag("spritePlayer");
        this.nextPlayer = GameObject.FindGameObjectWithTag("nextPlayer");
    }

    void Update(){
        if (lifebar)
        {
            lifebar.transform.localScale = new Vector3(this.health / 100, 0.5364848f, 0);
        }

        Vector3 direction = player.transform.position - this.transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        rb.rotation = angle;

        direction.Normalize();
        movement = direction;


        if (this.health <= 0){
            this.rb.bodyType = RigidbodyType2D.Static;
            this.speed = 0;
            Destroy(lifebar);
            enemyAnimatorGameObject.GetComponent<PolygonCollider2D>().enabled = false;
            enemyAnimator.Play("zombie1death");

            StartCoroutine(this.destroyEnemy());
        }
    }

    private IEnumerator destroyEnemy()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    private void FixedUpdate() {
        if(this.health > 0)
        {
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collisionObject) {
        if(collisionObject.gameObject.tag == "nextPlayer"){
            enemyAnimator.Play("zombie1attack");
        }else{
            enemyAnimator.Play("zombie1walk");
        }
    }

    private void OnCollisionEnter2D(Collision2D collisionObject) {
        if(collisionObject.gameObject.tag == "bullet"){
            System.Random random = new System.Random();

            float damage = Mathf.RoundToInt(random.Next(30, 80));

            this.health -= damage;

            Destroy(collisionObject.gameObject);
        }
    }
}
