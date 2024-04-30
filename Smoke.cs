using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public float alpha = 1f;
    [SerializeField] GameObject plane;
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1f * Time.deltaTime, 0, 0));
        alpha -= 1f * Time.deltaTime;

        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);

        if (alpha < 0)
        {
            Reset();
        }
    }

    private void Reset()
    {
        alpha = 1f;
        transform.position = plane.transform.position + new Vector3(-0.5f, 0, 0);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
