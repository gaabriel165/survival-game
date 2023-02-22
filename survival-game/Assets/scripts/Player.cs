using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour{

    
    [SerializeField] private GameObject imgTiro;

    [SerializeField] private AudioSource gunSound;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] public Transform shootingPoint;

    private GameObject spritePlayer;

    private PlayerAnimationController playerAnimation;

    [SerializeField] private TMP_Text textFieldBulletsQuantity;

    [SerializeField] private Image LifeBar;

    public int speed = 10;

    public float health = 100;
    public int bullets = 35;

    IEnumerator ShowTiro()
    {
        this.imgTiro.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        this.imgTiro.SetActive(false);
    }

    private void Awake() {
        this.spritePlayer = GameObject.FindGameObjectWithTag("spritePlayer");
        this.playerAnimation = GameObject.FindObjectOfType<PlayerAnimationController>();
    }

    void Update(){
        LifeBar.fillAmount = this.health / 100;

        this.textFieldBulletsQuantity.text = this.bullets.ToString();

        this.transform.Translate(0, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0);
        this.transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);

        if(Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d")){
            this.playerAnimation.PlayAnimation("playerwalk");
        }else {
            this.playerAnimation.PlayAnimation("playeridle");
        }

        if (Input.GetMouseButtonDown(0) && bullets >= 1){
            StartCoroutine(this.ShowTiro());
            Instantiate(bulletPrefab, shootingPoint.position, this.spritePlayer.transform.rotation);
            this.gunSound.Play();

            this.bullets -= 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collisionObject) {
        System.Random random = new System.Random();

        float damage = random.Next(7, 15);

        if(collisionObject.gameObject.tag == "enemy"){
            this.health -= Mathf.RoundToInt(damage);
        }
    }

    public void AddBullets(){
        this.bullets += 15;
    }

    public void Healing(){
        if(this.health >= 85){
            this.health = 100;
            return;
        }

        this.health += 15;   
    }

    public void IncreaseSpeed(){
        this.speed += 3;

        StartCoroutine(this.DecreaseSpeed());
    }

    private IEnumerator DecreaseSpeed(){
        yield return new WaitForSeconds(6);
        this.speed -= 3;
    }
}
