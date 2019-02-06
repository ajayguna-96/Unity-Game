using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (transform.position.y < -1)
        {
            die();
        }

    }
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Scene2");
        }
    }
    public static void die()
    {
        SceneManager.LoadScene("Scene1");
    }
}