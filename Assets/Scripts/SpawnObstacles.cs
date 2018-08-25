using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {
    
    public Transform log;
    public Transform log1;
    public Transform croco;
    public Transform turtle;
    public Transform car1;
    public Transform car2;
    public Transform car3;
    public Transform car4;
    public Transform car5;
    public Transform black;
    public Transform Vydralog;

    public GameObject parentObject;
    public Animator anim;

    float x = -9f;
    float y = -3.5f;
    float time_to_wait = 0f;
    void Start() {
        Instantiate(black, new Vector3(10, 0, 0), Quaternion.identity);
        Instantiate(black, new Vector3(-10, 0, 0), Quaternion.identity);
    }
    private void Update() {
        

        time_to_wait -= Time.deltaTime;
        if (time_to_wait <= 0) {
            //SPAWN logs and crocos
            var goVydraLog = Instantiate(Vydralog, new Vector3(x, y, 0), Quaternion.identity);
            goVydraLog.transform.parent = parentObject.transform;
            /*
            var goLog = Instantiate(log, new Vector3(x, y, 0), Quaternion.identity);
            goLog.transform.parent = parentObject.transform;
            var goCroco = Instantiate(croco, new Vector3(x - 4f, y, 0), Quaternion.identity);
            goCroco.transform.parent = parentObject.transform;
*/
            var goLog1 = Instantiate(log1, new Vector3(x-1f, y+6f, 0), Quaternion.identity);
            goLog1.transform.parent = parentObject.transform;
            var goCroco1 = Instantiate(croco, new Vector3(x - 5f, y + 6f, 0), Quaternion.identity);
            goCroco1.transform.parent = parentObject.transform;

            var goLog2 = Instantiate(log, new Vector3(x - 2f, y + 8f, 0), Quaternion.identity);
            goLog2.transform.parent = parentObject.transform;
            var goCroco2 = Instantiate(croco, new Vector3(x - 4.5f, y + 8f, 0), Quaternion.identity);
            goCroco2.transform.parent = parentObject.transform;


            //SPAWN turtles
            var goTurtle = Instantiate(turtle, new Vector3(x + 20f, y+7f, 0), Quaternion.identity);
            goTurtle.transform.parent = parentObject.transform;
            var goTurtle1 = Instantiate(turtle, new Vector3(x + 21f, y + 7f, 0), Quaternion.identity);
            goTurtle1.transform.parent = parentObject.transform;
            var goTurtle2 = Instantiate(turtle, new Vector3(x + 22f, y + 7f, 0), Quaternion.identity);
            goTurtle2.transform.parent = parentObject.transform;

            //SPAWN CARS

            var goCar2 = Instantiate(car2, new Vector3(x + 20f, y + 1f, 0), Quaternion.identity);//from right to left
            goCar2.transform.parent = parentObject.transform;


            var goCar1 = Instantiate(car1, new Vector3(x - 2f, y  + 2f, 0), Quaternion.identity);
            goCar1.transform.parent = parentObject.transform;
            var goCar11 = Instantiate(car1, new Vector3(x - 4f, y + 2f, 0), Quaternion.identity);
            goCar11.transform.parent = parentObject.transform;




            var goCar3 =Instantiate(car3, new Vector3(x - 5f, y + 4f, 0), Quaternion.identity);
            goCar3.transform.parent = parentObject.transform;

            var goCar31 = Instantiate(car3, new Vector3(x -6f, y + 4f, 0), Quaternion.identity);
            goCar31.transform.parent = parentObject.transform;

            var goCar4 =Instantiate(car4, new Vector3(x + 20f, y + 5f, 0), Quaternion.identity);//from right to left
            goCar4.transform.parent = parentObject.transform;

            var goCar5 = Instantiate(car5, new Vector3(x + 20f, y -1f, 0), Quaternion.identity);//from right to left
            goCar5.transform.parent = parentObject.transform;

            var goCar51 = Instantiate(car5, new Vector3(x + 22f, y - 1f, 0), Quaternion.identity);//from right to left
            goCar51.transform.parent = parentObject.transform;

            time_to_wait = 2.5f;
        }
    }



}
