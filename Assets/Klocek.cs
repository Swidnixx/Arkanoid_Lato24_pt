using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klocek : MonoBehaviour
{
    public int lives = 1;

    private void Start()
    {
        SetKlocek(lives);
    }

    public void SetKlocek(int life)
    {
        lives = life;
        SetColor();
    }

    void SetColor()
    {
        Color[] colors = { Color.white, Color.yellow, Color.green };
        Color color = colors[lives - 1];
        GetComponent<MeshRenderer>().material.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ball"))
        {
            lives--;
            if (lives > 0)
            {
                SetColor();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
