using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootcolide : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ignore;
    public Collider collision;
    public GameObject explosion;


    void Start()
    {
		
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
            Instantiate(explosion, collision.collider.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(collision.collider);
            Destroy(gameObject);


        } else
        {
            Physics.IgnoreCollision(collision.collider, this.collision);
        }
    }
}
