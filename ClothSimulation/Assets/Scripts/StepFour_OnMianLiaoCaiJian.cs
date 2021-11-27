using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepFour_OnMianLiaoCaiJian : MonoBehaviour
{
    private bool IsSelect = false;
    [System.Obsolete]
    void Start()
    {
        gameObject.transform.GetComponent<StepCtrl>().RegistVoidDo(Steps.four, UpdataDo);
        gameObject.transform.GetComponent<StepCtrl>().RegistStartDo(Steps.four, StartDo);
    }

    [System.Obsolete]
    private void StartDo()
    {
       
    }


    public void UpdataDo()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsSelect)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, int.MaxValue))
                {
                    if (hit.collider.transform.name == "布料")
                    {
                        gameObject.transform.GetComponent<StepCtrl>().TimeLinePlay();
                    }
                }
            }
            else
            {
                Debug.Log("请选择剪刀");
            }
        }

    }

    private void SelectJianDao() {
        IsSelect = true;
    }
  
}
