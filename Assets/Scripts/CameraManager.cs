using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float delta = 0.0f; //ÉJÉÅÉâÇ∆playerÇÃç¿ïWÇÃç∑
    public float bottomLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float x = transform.position.x;
            float y = player.transform.position.y + delta;
            float z = transform.position.z;
            bottomLimit = transform.position.y;
            if (y < bottomLimit)
            {
                y = bottomLimit;
            }
            Vector3 v3 = new Vector3(x, y, z);
            transform.position = v3;
        }
    }
}
