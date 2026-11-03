using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 35.0f;
    private float lowerBound = -10.0f;
    private float rightBound = 26.0f;

    public bool isAnimal = true;

    // PlayerController 스크립트 참조
    private PlayerController player;

    void Start()
    {
        // 씬에서 PlayerController 컴포넌트를 찾아 player변수에 저장
        //FindAnyObjectByType -> 현재 씬에서 활성 중인 오브젝트 중 지정한 타입의 컴포넌트를 검색
        player = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < lowerBound || transform.position.x > rightBound)
        {
            if (isAnimal && player != null) //isAnimal에 체크표시(Inspector에서 설정 가능)가 되어있고 player 객체가 존재한다면 실행. 
            {
                player.LoseLife();  // player가 참조하는 PlayerController의 LoseLife() 메서드 호출
            }
            Destroy(gameObject);
        }
    }
}