using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public Vector2 moveInput;

    public int lives = 5;               //플레이어 목숨
    private bool isGameOver = false;    // 게임 오버 여부

    public float speed = 10.0f;
    public float xRange = 20.0f;
    public float zRangeMin = -2.0f;
    public float zRangeMax = 17.0f;

    public GameObject projectilePrefabs;
    public InputAction fireAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < zRangeMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeMin);
        }
        if (transform.position.z > zRangeMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeMax);
        }

        moveInput = moveAction.ReadValue<Vector2>();

        transform.Translate(Vector3.right * Time.deltaTime * speed * moveInput.x);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);

        if (fireAction.triggered)
        {
            Instantiate(projectilePrefabs, transform.position, projectilePrefabs.transform.rotation);
        }
    }

    public void LoseLife()  //다른 클래스에서도 호출 가능.
    {
        if (isGameOver) //false시 진행, ture일시 return으로 인해 함수 종료
        {
            return; //isGameOver가 true라면 함수 종료.
        }

        lives--;

        Debug.Log("Lives: " + lives);

        if (lives <= 0) //게임오버 여부 확인
        {
            isGameOver = true;
            Debug.Log("Game Over!");
        }
    }
}