
using UnityEngine;

public enum Direction {
    Up, Down, Left, Right
}
public class Player : MonoBehaviour {

    public bool goWithObstacle;
    public bool Dead;
    public bool Moving;

    public Sprite frogSprite;
    public Sprite lilySprite;

    private Obstacle obstacle;
    public float MinX, MaxX, MinY, MaxY;

    public GameManage gameManage;
    private Animator anim;

    public Rigidbody2D rigid2D;

    public Vector3 TargetPosition;

    void Start() {
        anim = GetComponent<Animator>();

        rigid2D = GetComponent<Rigidbody2D>();
        TargetPosition = transform.position;


    }
    private void Update() {

        // Check for input
        if (Input.GetKeyDown(KeyCode.W)) {
            Move(Direction.Up);
        } else if (Input.GetKeyDown(KeyCode.S)) {
            Move(Direction.Down);
        } else if (Input.GetKeyDown(KeyCode.A)) {
            Move(Direction.Left);
        } else if (Input.GetKeyDown(KeyCode.D)) {
            Move(Direction.Right);
        }


    }
    private void LateUpdate() {
        
        Vector3 pos = transform.position;
        float boundPadding = 0.6f;
        if (pos.x > MaxX + boundPadding || pos.x < MinX - boundPadding)
            PlayerDead();
    }

    private void FixedUpdate() {
        // Move player
        if (!Dead) {
            transform.position = Vector2.MoveTowards(transform.position, TargetPosition, Time.fixedDeltaTime / 0.25f);
        }
        // Check if player is still moving
        if (transform.position == TargetPosition) {
            Moving = false;
        }
    }

    private void Move(Direction direction) {
        
        if (Moving || Dead){
            return;
        } 

        Vector3 currentRotation = transform.rotation.eulerAngles;

        Vector3 curPos = transform.position;
        TargetPosition = curPos;

        float step = 1f;

        switch (direction) {
            case Direction.Up:
                currentRotation.z = 0;
                TargetPosition.y = Mathf.Clamp(TargetPosition.y + step, MinY, MaxY);
                anim.Play("PlayerUp");
                break;
            case Direction.Down:
                currentRotation.z = 180;
                TargetPosition.y = Mathf.Clamp(TargetPosition.y - step, MinY, MaxY);
                anim.Play("PlayerUp");
                break;
            case Direction.Left:
                currentRotation.z = 90;
                TargetPosition.x = Mathf.Clamp(TargetPosition.x - step, MinX, MaxX);

                anim.Play("PlayerUp");
                break;
            case Direction.Right:
                currentRotation.z = -90;
                TargetPosition.x = Mathf.Clamp(TargetPosition.x + step, MinX, MaxX);
                anim.Play("PlayerUp");
                break;
        }
        transform.rotation = Quaternion.Euler(currentRotation);

        goWithObstacle = false;
        Moving = true;

    }
    public void ResetPosition() {
        // Reset position and target position
        Vector3 newPos = new Vector3(0.0f, MinY, 0.0f);
        transform.position = newPos;
        TargetPosition = newPos;

        // Reset animation
        anim.Play("PlayerUp");


        Dead = false;
    }
    public void PlayerDead() {

        gameManage.RealoadScore();
        Dead = true;
        Moving = false;
        goWithObstacle = false;
        GameObject.Find("EndPoint1").GetComponent<SpriteRenderer>().sprite = lilySprite;
        GameObject.Find("EndPoint2").GetComponent<SpriteRenderer>().sprite = lilySprite;
        GameObject.Find("EndPoint3").GetComponent<SpriteRenderer>().sprite = lilySprite;
        GameObject.Find("EndPoint4").GetComponent<SpriteRenderer>().sprite = lilySprite;
        GameObject.Find("EndPoint5").GetComponent<SpriteRenderer>().sprite = lilySprite;

        // Reset rotation
        transform.rotation = Quaternion.identity;

        ResetPosition();
       
    }

}
