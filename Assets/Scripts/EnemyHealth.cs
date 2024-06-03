using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int health = 3;

    TowerBuilder towerBuilder;

    // Start is called before the first frame update
    void Start()
    {
        //Hitta första bästa towerbuilder i scenen.
        towerBuilder = FindObjectOfType<TowerBuilder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Var det ett skott jag nuddade?

        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            if (health == 0)
            {
                Destroy(gameObject);
                //Ge spelaren pengar!
                towerBuilder.money += 10;
            }

            Destroy(collision.gameObject);
        } 

    }

}
