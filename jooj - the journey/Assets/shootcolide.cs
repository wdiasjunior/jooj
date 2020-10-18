using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootcolide : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ignore;
    public Collider collision;
    public GameObject explosion;
    public GameObject parent;
    public bool ignoreEnemies = false;


    void Start()
    {
        if (ignoreEnemies)
        {
            Physics.IgnoreLayerCollision(10, 9);
        } else
        {
            Physics.IgnoreLayerCollision(0, 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.tag.Contains("IgnoreShoot"))
        {
            ScoreScript.scoreValue += 1;
            Destroy(collision.gameObject);
        }

        Instantiate(explosion, collision.collider.transform.position, Quaternion.identity);
        Destroy(collision.collider);
        Destroy(gameObject);
    }
}
