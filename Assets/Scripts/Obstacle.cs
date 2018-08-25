
using UnityEngine;
using UnityEngine.SceneManagement;
public class Obstacle : MonoBehaviour {
    private Player player;
    private float onPlatformMove;
    private bool lilySet;

    private Animator anim;

    public static Transform PlayerLastTrigger;
    private GameManage game;
    private float time_to_wait = 0.5f;


    private bool lily1 ;
    private bool lily2 ;
    private bool lily3 ;
    private bool lily4 ;
    private bool lily5 ;
	void Start () {
        
        player = GameObject.Find("Player").GetComponent<Player>();
        time_to_wait = 0.5f;
        lily1 = false;
        lily2 = false;
        lily3 = false;
        lily4 = false;
        lily5 = false;
	}
	
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            
            PlayerLastTrigger = transform;

            if (gameObject.CompareTag("crocodile")) {
                player.PlayerDead();
            } else if (gameObject.CompareTag("log")) {
                MoveOnPlatform();
                anim = GetComponent<Animator>();
            }else if(gameObject.CompareTag("turtle")) {
                MoveOnPlatform(); 

            }else if (gameObject.CompareTag("snake")) {
                player.PlayerDead();

            }else if (gameObject.CompareTag("car")) {
                player.PlayerDead();
            
            }else if (gameObject.CompareTag("finish")) {
                player.ResetPosition();
                lily1 = true;
                GameObject.Find("EndPoint1").GetComponent<SpriteRenderer>().sprite = player.frogSprite;
                FinishGame();
            }else if (gameObject.CompareTag("finish1")) {
                player.ResetPosition();
                lily2 = true;
                GameObject.Find("EndPoint2").GetComponent<SpriteRenderer>().sprite = player.frogSprite;
                FinishGame();
            }else if (gameObject.CompareTag("finish2")) {
                player.ResetPosition();
                lily3 = true;
                GameObject.Find("EndPoint3").GetComponent<SpriteRenderer>().sprite = player.frogSprite;
                FinishGame();
            }else if (gameObject.CompareTag("finish3")) {
                player.ResetPosition();
                lily4 = true;
                GameObject.Find("EndPoint4").GetComponent<SpriteRenderer>().sprite = player.frogSprite;
                FinishGame();
            }else if (gameObject.CompareTag("finish4")) {
                player.ResetPosition();
                lily5 = true;
                GameObject.Find("EndPoint5").GetComponent<SpriteRenderer>().sprite = player.frogSprite;
                FinishGame();
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            if (gameObject.CompareTag("log")) {
                
                if (!player.Moving) {
                    Vector3 newPos = transform.position;
                    newPos.x += -onPlatformMove;
                    player.transform.position = newPos;
                } else {
                    
                    MoveOnPlatform();

                }
            }else if (gameObject.CompareTag("turtle")) {

                if (!player.Moving) {
                    Vector3 newPos = transform.position;
                    newPos.x += -onPlatformMove;
                    player.transform.position = newPos;
                } else {

                    MoveOnPlatform();
                    time_to_wait -= Time.deltaTime;
                    if (time_to_wait <= 0) {
                        anim.Play("TurtleUnderWater");
                        player.PlayerDead();
                    } else {
                        return;
                    }
                }
            }else if (gameObject.CompareTag("water")) {
                Death();
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            if (gameObject.CompareTag("log")) {
                player.goWithObstacle = false;
            }else if (gameObject.CompareTag("turtle")) {
                player.goWithObstacle = false;
            }
        }
    }
    private void Death() {
        
        if (player.Moving || player.goWithObstacle){
            return;
        } 
        lily1 = false;
        lily2 = false;
        lily3 = false;
        lily4 = false;
        lily5 = false;

        player.PlayerDead();
    }
    public void FinishGame() {
        if (lily1 && lily2 && lily3 && lily4 && lily5) {
            SceneManager.LoadScene("MenuScene");

        }
    }
    // Stick player to object
    private void MoveOnPlatform() {
        
        Vector3 playerPos = player.transform.position;
        Vector3 pos = transform.position;
        onPlatformMove = pos.x - playerPos.x;

        player.goWithObstacle = true;
    }
}
