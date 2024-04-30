using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public float speed = 1f;
    bool hasScored = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -10)
        {
            float height = Random.Range(-1f, 1f);
            transform.position = new Vector2(11, height);
            hasScored = false;
            
        }




        //Test de score

        float planeX = GameObject.Find("Plane").transform.position.x;

        if (transform.position.x < planeX && !hasScored)
        {
            Debug.Log("+ 1 point");
            hasScored = true;
            FindAnyObjectByType<GameManager>().AddScore();
        }
    }

    void OnStartGame()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 0);
    }

    void OnGameOver()
    {
        enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
       
    }
}
