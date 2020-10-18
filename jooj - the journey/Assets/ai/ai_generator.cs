using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_generator : MonoBehaviour
{

    public GameObject prefab;
    private float lastGenerated = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastGenerated > 5)
        {
            if (Random.Range(0, 1000) > 500)
            {
                Vector3 position = this.transform.position + new Vector3(Random.Range(1000, 2500), Random.Range(1000, 2500), Random.Range(1000, 2500));
                GameObject enemy = Instantiate(prefab, position, Quaternion.identity);
                enemy.GetComponent<ai>().player = this.transform;
            }
            lastGenerated = Time.time;
        }
    }
}
