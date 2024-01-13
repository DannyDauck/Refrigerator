using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRefrigerator : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private GameObject refrigeratorDoor;
    [SerializeField]
    private GameObject refrigerator;
    private float doorAngel = 70f;
    [SerializeField]
    [Header("Rotation Speed")]
    private float rotationSpeed = 45f;
    private AudioSource audio;
    private bool triggered = false;
    [Header("Sound")]
    [SerializeField]
    private AudioClip openSound;
    [SerializeField]
    private AudioClip closeSound;
    private float rotation = 0f;
    [Header("Trigger Settings")]
    [SerializeField]
    private bool autoCloseOnTriggerExit = true;




    void Start()
    {
        audio = refrigerator.gameObject.GetComponent<AudioSource>();
        
    }


    void Update()
    {

        // The hardcoded 90 degrees are needed because this asset is imported from blender


        if (triggered && Input.GetKeyDown(KeyCode.Space))
        {
            openRefrigdgerator();
        }
        if (refrigeratorDoor.transform.rotation.eulerAngles.y != rotation + 90)
        {
            if (rotation == 70)
            {
                if (refrigeratorDoor.transform.rotation.eulerAngles.y > 90f + doorAngel)
                {
               
                    Quaternion targetRotation = Quaternion.Euler(-90f, 0f, 90f + doorAngel);
                    refrigeratorDoor.transform.rotation = targetRotation;
                }
                else
                {
                    
                    refrigeratorDoor.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                }
            }
            else if (rotation == 0)
            {
                if (refrigeratorDoor.transform.rotation.eulerAngles.y < 90)
                {
                    
                    Quaternion targetRotation = Quaternion.Euler(-90f, 0f, 90f);
                    refrigeratorDoor.transform.rotation = targetRotation;
                }
                else
                {
                   
                    refrigeratorDoor.transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
                }
            }

        } 
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("MainCamera"))
        {
            button.SetActive(true);
            triggered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("MainCamera"))
        {
            button.SetActive(false);
            triggered = false;
            if (refrigeratorDoor.transform.rotation.eulerAngles.y != 90f && autoCloseOnTriggerExit)
            {
                openRefrigdgerator();
            }
        }
    }
    public void openRefrigdgerator()
    {
        if (refrigeratorDoor.transform.rotation.eulerAngles.y == 90f)
        {
            rotation = doorAngel;

            audio.PlayOneShot(openSound);

        }
        else
        {
            rotation = 0f;

            audio.PlayOneShot(closeSound);


        }
    }

}


