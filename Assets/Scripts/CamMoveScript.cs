using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveScript : MonoBehaviour
{
    [SerializeField]
    private float movingSpeed = 3.0f;
    [SerializeField]
    private float turningSpeed = 45.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * -movingSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * -turningSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * turningSpeed * Time.deltaTime);
        }
    }
}
