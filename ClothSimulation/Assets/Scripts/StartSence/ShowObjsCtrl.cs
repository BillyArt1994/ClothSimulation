using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjsCtrl : MonoBehaviour
{
    public GameObject Showobjs;
    public float xSpeed = 250.0f;
    private float x = 0.0f;
    private bool IsShow = false;



    public void ShowTmpObj(string Name) {
        Showobjs.transform.rotation = new Quaternion(0,0,0,0);
        for (int i = 0; i < Showobjs.transform.childCount; i++)
        {
            Showobjs.transform.GetChild(i).gameObject.SetActive(false);
        }
        Showobjs.transform.Find(Name).gameObject.SetActive(true);
        IsShow = true;
    }


    public void Close() 
    {
        IsShow = false;
    }


    public void Update()
    {
        if (IsShow)
        {
            if (Input.GetMouseButton(0))
            {
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                Quaternion rotation = Quaternion.Euler(0, x, 0);
                Showobjs.transform.rotation = rotation;
            }
        }
       
    }
}
