using UnityEngine;
using System.Collections;

public class TargetDetection1 : MonoBehaviour
{
    private Transform tr;
    private float rotY;
    private bool targetHit;

    // Use this for initialization
    void Start()
    {
        // reference components
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // draws the forward facing direction
        // you do NOT need this to raycast, just for debug purposes
        DrawForward();

        // handles object rotation on the y axis
        rotY-=0.5f;
        if (rotY < 0.0f) rotY = 360.0f;
        tr.eulerAngles = new Vector3(0.0f, rotY, 0.0f);

        // raycasting
        RaycastHit hit;
        Ray ray = new Ray(tr.position, tr.forward);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name == "Cube" && !targetHit)
            {

                hit.collider.gameObject.SetActive(false);
                targetHit = true;
                PlayerMovement.die();
            }
        }
        else if (targetHit)
        {
           // Debug.Log("Nothing was detected.");
            targetHit = false;
        }
    }

    void DrawForward()
    {
        Vector3 forward = tr.TransformDirection(Vector3.forward)*15f;
        Debug.DrawRay(tr.position, forward, Color.red);
    }
}