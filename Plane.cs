using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] AudioClip soundJump;
    [SerializeField] AudioClip soundCrash;
    [SerializeField] AudioClip soundCollect;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector2(-2, 2);
        //transform.eulerAngles = new Vector3(0, 0, 90);
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 5, 0);
            GetComponent<AudioSource>().PlayOneShot(soundJump);
            
        }

        //Oriention du nez de l'avion
        float rotAngle = GetComponent<Rigidbody2D>().velocity.y * 2f;
        transform.eulerAngles = new Vector3(0, 0, rotAngle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D : " + collision.gameObject.name);

        FindObjectOfType<GameManager>().GameOver();
        GetComponent<AudioSource>().PlayOneShot(soundCrash);
        GetComponent<CircleCollider2D>().enabled = false;
    }

    void OnStartGame()
    {
        enabled = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    void OnGameOver()
    {
        enabled = false;
    }
}
