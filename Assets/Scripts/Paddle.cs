using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float xMin = 0f;
    [SerializeField] float xMax = 15f;

    // Cached components
    GameStatus myGameStatus;
    Ball myBall; // Your mind is dirty not mine...

    void Start()
    {
        myGameStatus = FindObjectOfType<GameStatus>();
        myBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), xMin, xMax);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (myGameStatus.IsAutoPlayEnabled())
        {
            return (myBall.transform.position.x);
        }
        else 
        {
            float mousePos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
            return (mousePos);
        }
    }
}
