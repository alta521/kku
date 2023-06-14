using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note : MonoBehaviour
{
    public bool canPressed;
    public KeyCode keyToPress;
    public GameObject hitEffect,goodEffect, perfectEffect, missEffect;

    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canPressed)
            {
                gameObject.SetActive(false);
                //musicManager.instance.NoteHit();

                if(Mathf.Abs(transform.position.y) > 0.25)
                {
                    Debug.Log("Hit");
                    musicManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if(Mathf.Abs(transform.position.y)>0.05f)
                {
                    Debug.Log("Good");
                    musicManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    Debug.Log("Perpect");
                    musicManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canPressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canPressed = false;
            musicManager.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }

    // Update is called o
    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.tag == "Activator")
    //    {
    //        CanPressed = false;
    //    }
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Activator")
    //    {
    //        CanPressed = true;
    //    }
    //}
}
