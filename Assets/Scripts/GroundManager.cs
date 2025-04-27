using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject groundPrefab;
    public float range=10.0f;
    public float yRange = 14.0f;
    public static int Point { get; set; } = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            Debug.Log("touched");
            GameObject Ground = Instantiate(groundPrefab, new Vector3(Random.Range(-range, range), transform.position.y + yRange, 0.0f), Quaternion.identity);
            Destroy(this.gameObject);
            ++Point;
        }
    }
}
