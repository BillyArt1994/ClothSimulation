using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepThree_OnMianLiaoShangJiang : MonoBehaviour
{
    private bool IsSelect = false;
    [System.Obsolete]
    void Start()
    {
        gameObject.transform.GetComponent<StepCtrl>().RegistVoidDo(Steps.three, UpdataDo);
        gameObject.transform.GetComponent<StepCtrl>().RegistStartDo(Steps.three, StartDo);

    }

    public void UpdataDo()
    {
        Debug.Log(4);
        if (Input.GetMouseButtonDown(0))
        {
            if (IsSelect)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, int.MaxValue))
                {
                    if (hit.collider.transform.name== "布料")
                    {
                        gameObject.transform.GetComponent<StepCtrl>().TimeLinePlay();
                    }
                }
            }
            else
            {
                Debug.Log("请选择浆糊");
            }
        }
        
    }

    [System.Obsolete]
    private void StartDo() {
        gameObject.transform.GetComponent<StepCtrl>().RegistToolsBtn("浆糊", SelectJiangHu);
    }


    private void SelectJiangHu() {
        IsSelect = true;
    }
}
