using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Baket : MonoBehaviour
{
    [Header("Set Dynamics")]
    public Text scoreGT;
    Vector3 mousePose2D;
    Vector3 mousePos3D;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePose2D = Input.mousePosition;
        mousePose2D.z = -Camera.main.transform.position.z;
        mousePos3D = Camera.main.ScreenToWorldPoint(mousePose2D);
        pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
