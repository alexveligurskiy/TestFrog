
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManage : MonoBehaviour {
    private Obstacle obstacle;
    public Text scoreText;
    public float Timer = 0;
    public float minuteCount = 0;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        ShowScore();
	}

    public void ShowScore(){
        Timer += Time.deltaTime;
        scoreText.text = "Time:" + minuteCount + "m:" + (int)Timer + "s";
        if (Timer >= 60) {
            minuteCount++;
            Timer = 0;
        }

    }
    public void RealoadScore(){
        Timer = 0;
        minuteCount = 0;
    }

}
