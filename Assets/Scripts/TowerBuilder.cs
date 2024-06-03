using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public GameObject towerPrefab;

    public int money = 50;
    int towerCost = 30;

    public TextMeshProUGUI moneyUI;

    public LayerMask buildingLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 towerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            towerPosition.x = Mathf.Round(towerPosition.x);
            towerPosition.y = Mathf.Round(towerPosition.y);

            if (Physics2D.OverlapCircle(towerPosition, 0.4f, buildingLayer) == false)
            {
                //Har jag r�d?
                if (money >= towerCost)
                {
                    Instantiate(towerPrefab, towerPosition, Quaternion.identity);
                    money -= towerCost;
                }
                
            }

            
        }

        moneyUI.text = "$" + money.ToString();
        
    }
}
