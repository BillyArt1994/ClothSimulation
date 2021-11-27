using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTwo_OnMianLiaoShangJiang : MonoBehaviour
{
    private enum State { 
        mianliaoshangjiang,
        mianliaocaijian,
    }
    private bool IsSelect = false;
    private State selfState = State.mianliaoshangjiang;
    [System.Obsolete]
    void Start()
    {
        gameObject.transform.GetComponent<StepCtrl>().RegistVoidDo(Steps.two, UpdataDo);
        gameObject.transform.GetComponent<StepCtrl>().RegistStartDo(Steps.two, StartDo);

    }

    public void UpdataDo()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, int.MaxValue))
                {
                    Debug.Log(hit.collider.transform.name);
                    switch (selfState)
                    {
                        case State.mianliaoshangjiang:
                        if (hit.collider.transform.name == "刷子")
                        {
                            gameObject.transform.GetComponent<StepCtrl>().TimeLinePlay();
                        }
                        break;
                        case State.mianliaocaijian:
                            break;
                        default:
                            break;
                    }
                   
                    
                }
       
        }
        
    }

    [System.Obsolete]
    private void StartDo() {
       
    }


    private void SelectJiangHu() {
        IsSelect = true;
    }
}
