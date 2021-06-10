using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Raphael Frei - 2021

public class PlayerBehaviour : MonoBehaviour{

    //Moving Speed (in tests, Speed = 10000)
    public float speed;

    //Vectors for input position
    private Vector2 initialPosition, finalPosition;

    private Rigidbody2D rb;

    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update(){

        //When clicking or touching the screen
        if(Input.GetMouseButtonDown(0)) {
            StartDragging();

        }

        //When release the screen
        if(Input.GetMouseButtonUp(0)) {
            StopDragging();

        }
    }

    //Get input position when clicked
    void StartDragging() {
        initialPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    //Get final position when release clicking
    void StopDragging() {
        finalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Add throw force to the object based on the diference between holding and releasing position
        //The -1 is for a reverse swipe
        rb.AddForce(Vector2.one * speed * -1 * Time.deltaTime * (finalPosition - initialPosition), ForceMode2D.Force);

        initialPosition = new Vector2(0, 0);
    }
}
