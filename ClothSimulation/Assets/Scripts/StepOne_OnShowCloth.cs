using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepOne_OnShowCloth : MonoBehaviour
{
    public GameObject Cloth;
    public float xSpeed = 250.0f;
    private float x = 0.0f;
 
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetComponent<StepCtrl>().RegistVoidDo(Steps.one, UpdataDo);       
    }

    public void UpdataDo() {
        if (Input.GetMouseButton(0))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            Quaternion rotation = Quaternion.Euler(0, x, 0);
            Cloth.transform.rotation = rotation;
        }
    }
}
