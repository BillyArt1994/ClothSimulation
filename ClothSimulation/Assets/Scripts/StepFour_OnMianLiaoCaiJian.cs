using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepFour_OnMianLiaoCaiJian : MonoBehaviour
{
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
       

    }


}
