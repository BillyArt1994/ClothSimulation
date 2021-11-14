using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public delegate void UIClose();
public enum UIStaet { 
    cxjd,
    kcjs,
    kssj
}
public class MainUICtrl : MonoBehaviour
{
    public GameObject TopUI;
    public GameObject StartUI;

    private UIStaet uIStaet = UIStaet.cxjd;
    public void ShowTop() {
        TopUI.transform.DOLocalMoveY(485,1);
        StartUI.transform.GetComponent<UIPlanOne>().ShowPlan("江南大学传习馆", "江南大学传习馆");
    }



    public void OnCxjdBtnDown() { 
        
    }


    public void OnKcjsBtnDown()
    {

    }

    public void OnKssjBtnDown()
    {

    }

    public void OnGyzxBtnDown()
    {

    }


    private bool CheckChange(UIStaet ChangeTo) {
        if (ChangeTo == uIStaet)
        {
            return false;
        }
        else
        {

            uIStaet = ChangeTo;
            return true;
        }
        
    }
}
