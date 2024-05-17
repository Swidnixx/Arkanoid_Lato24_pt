using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paletka : MonoBehaviour
{
    public float speed = 5;
    public float maxPos = 7;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        x *= speed * Time.deltaTime;
        transform.position += new Vector3(x, 0, 0);

        if(Mathf.Abs(transform.position.x) > maxPos)
        {
            Vector3 correctPos = transform.position;
            correctPos.x = Mathf.Clamp(transform.position.x, -maxPos, maxPos);
            transform.position = correctPos;
        }
    }
}
