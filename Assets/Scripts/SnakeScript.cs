using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour {

    public float speed = 1.0f;
    public Vector3 moveBy = Vector3.one;

    public enum Mode {
        GoToA,
        GoToB,

    }

    Rigidbody2D myBody = null;

    Vector3 pointA;
    Vector3 pointB;
    public Mode currentMode = Mode.GoToB;

    void Start() {
        this.myBody = this.GetComponent<Rigidbody2D>();
        this.pointA = this.transform.position;

        moveBy.y = 0;
        moveBy.z = 0;
        this.pointB = pointA + moveBy;

    }
    void FixedUpdate() {
        setMode();

        run();
    }

    private void setMode() {
        
        Vector3 my_pos = this.transform.position;

         if (currentMode == Mode.GoToA) {
            if (isArrived(my_pos, pointA)) {
                currentMode = Mode.GoToB;
            }
        } else if (currentMode == Mode.GoToB) {
            if (isArrived(my_pos, pointB)) {
                currentMode = Mode.GoToA;
            }
        } else {
            currentMode = Mode.GoToB;
        }
    }

    private void run() {

        //[-1, 1]
        float value = this.getDirection();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Animator animator = GetComponent<Animator>();

        if (value < 0) {
            sr.flipX = false;

        } else if (value > 0) {
            sr.flipX = true;
        }
        if (Mathf.Abs(value) > 0) {
            Vector2 vel = myBody.velocity;
            vel.x = value * speed;
            myBody.velocity = vel;
        }


    }

    private float getDirection() {
        
        Vector3 my_pos = this.transform.position;

        if (currentMode == Mode.GoToA) {
            return -1;
        } else if (currentMode == Mode.GoToB) {
            return 1;
        }
        return 0;
    }

   
    private bool isArrived(Vector3 pos, Vector3 target) {
        pos.z = 0;
        target.z = 0;
        return Vector3.Distance(pos, target) < 0.2f;
    }

}
