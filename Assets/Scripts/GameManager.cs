using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int point;
    BallManager ballManager;
    public GameObject pointText;

    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        point = GroundManager.Point;
        pointText.GetComponent<Text>().text = point.ToString();
        if (BallManager.gameState=="gameOver") 
        {
            Debug.Log(point.ToString());
            BallManager.gameState = "end";
            button.SetActive(true);
        }
    }
}
