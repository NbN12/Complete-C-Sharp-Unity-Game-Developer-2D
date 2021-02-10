using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;
    [SerializeField] private float screenWidthInUnits = 16f;

    // cache reference
    GameSession gameSession;
    Ball ball;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if(gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
}
