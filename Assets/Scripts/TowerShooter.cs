using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooter : MonoBehaviour
{
    List<GameObject> enemiesInRange = new List<GameObject>();
    public GameObject bulletPrefab;
    float cooldown;

    public GameObject gunPart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if( enemiesInRange.Count > 0)
        {
            Vector2 aimDirection = enemiesInRange[0].transform.position - transform.position;

            //Det finns en fiende i närheten!
            if (cooldown < 0)
            {
                //Skjut!
                
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

                bulletRigidbody.velocity = aimDirection.normalized * 10f;

                cooldown = 1f;
            }

            //Rotera tornet genom att räkna ut vinkeln
            float angle = Vector2.SignedAngle(Vector2.up, aimDirection);

            gunPart.transform.rotation = Quaternion.Euler(0,0,angle);

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Var det en fiende?
        if(collision.gameObject.tag == "Enemy")
        {
            print("Det var en fiende som kom i närheten!");
            enemiesInRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            print("Det var en fiende som lämnade vår range!");
            enemiesInRange.Remove(collision.gameObject);
        }
    }
}
