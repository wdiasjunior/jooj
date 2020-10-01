using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuscript : MonoBehaviour
{

    public Rigidbody rigidbody;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody rigid = Instantiate(rigidbody, transform.position - new Vector3(2 * (i % 2 == 0 ? -1 : 1), 0, 0), transform.rotation) as Rigidbody;
            i++;
            rigid.velocity = transform.TransformDirection(new Vector3(0, 0, 200));
            rigid.detectCollisions = true;
        }
    }
}
