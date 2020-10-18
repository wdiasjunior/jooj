using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai : MonoBehaviour
{

    public Transform player;
    public Rigidbody shotRigid;
    private Rigidbody rd;
    private int i = 0;
    private float lastShootTime = 0;
    private float offset;


    private float minDistance;
    private float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();

        minDistance = Random.Range(250, 500);
        maxDistance = Random.Range(minDistance, minDistance + 2000);
        this.offset = Random.Range(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.transform.position, player.position);
        dist = Mathf.Max(minDistance, dist);
        dist = Mathf.Min(maxDistance, dist);
        this.transform.LookAt(this.player);

        float velocity = Remap(dist, minDistance, maxDistance, 0, 5000);

        rd.velocity = this.transform.forward * velocity;

        float diff = Time.time - (lastShootTime + offset);

        if (diff >= 2 && dist <= minDistance * 4)
        {
            Rigidbody rigid = Instantiate(shotRigid, transform.position - new Vector3(2 * (i % 2 == 0 ? -1 : 1), 0, 0), transform.rotation) as Rigidbody;
            rigid.gameObject.GetComponent<shootcolide>().parent = this.gameObject;
            rigid.gameObject.GetComponent<shootcolide>().ignoreEnemies = true;
            rigid.gameObject.layer = 10;
            this.lastShootTime = Time.time;
            i++;
            rigid.transform.LookAt(player);
            rigid.velocity = transform.forward * 1000;
            rigid.detectCollisions = true;
        }
    }

    private float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
