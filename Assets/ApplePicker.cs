using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public Canvas canv = null;
    Button btn; 
    // Start is called before the first frame update
    void Start()
    {
        btn = canv.GetComponentInChildren<Button>();
        btn.gameObject.SetActive(false);
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        if (basketList.Count==0)
        {
            SceneManager.LoadScene("SampleScene 3");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (btn.gameObject.activeSelf == false)
            {
                btn.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                btn.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            
        }
    }
}
