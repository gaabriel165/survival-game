using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour{
    private Vector3 mousePosition;

    private void Awake() {
        Cursor.visible = false; 
    }
    
    void Update(){
        this.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(this.mousePosition.x, this.mousePosition.y, 0);
    }
}
