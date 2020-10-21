using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cuscript : MonoBehaviour
{
    public Image BlackFade;
    public Text TextAccomplished;
    public Text TextEnd;

    public Rigidbody rigidbody;

    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("EarthScene"))
        {
            BlackFade.canvasRenderer.SetAlpha(0.0f);
            TextAccomplished.canvasRenderer.SetAlpha(0.0f);
            TextEnd.canvasRenderer.SetAlpha(0.0f);
            StartCoroutine(WaitToLoad(13));
        }
    }


    IEnumerator WaitToLoad(float seconds)
    {
        BlackFade.CrossFadeAlpha(1, 7, true);
        TextAccomplished.CrossFadeAlpha(1, 7, true);
        TextAccomplished.canvasRenderer.SetAlpha(0.0f);
        
        yield return new WaitForSeconds(seconds);
        TextAccomplished.canvasRenderer.SetAlpha(0.0f);
        TextEnd.CrossFadeAlpha(1, 5, true);

        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("MainMenu");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody rigid = Instantiate(rigidbody, transform.position - new Vector3(2 * (i % 2 == 0 ? -1 : 1), 0, 0), transform.rotation) as Rigidbody;
            rigid.gameObject.layer = 9;
            i++;
            rigid.velocity = transform.TransformDirection(new Vector3(0, 0, 1500));
            rigid.detectCollisions = true;
        }
    }


}
