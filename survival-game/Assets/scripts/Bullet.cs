using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    void Start(){
        this.rb = GetComponent<Rigidbody2D>();
        this.rb.velocity = transform.up * speed;
    }

    void Update(){
        StartCoroutine(this.DestroyBullet());
    }

    IEnumerator DestroyBullet(){
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
