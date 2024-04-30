using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] float vibrationRange = 0.5f;
    float alpha = 1f;
    Vector3 cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        alpha -= Time.deltaTime * 2f;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);

        

        Camera.main.transform.position = new Vector3(
            Random.Range(-vibrationRange, vibrationRange),
            Random.Range(-vibrationRange, vibrationRange),
            Camera.main.transform.position.z
            );
        if(alpha < 0f)
        {
            Camera.main.transform.position = cameraPos;
            enabled = false;
        }
    }
}
