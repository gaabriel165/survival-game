using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    [SerializeField] GameObject gameoverImg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            this.gameoverImg.gameObject.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && Time.timeScale == 0)
        {
            Application.LoadLevel(0);
            Time.timeScale = 1;
            this.gameoverImg.gameObject.SetActive(false);
        }


    }
}
