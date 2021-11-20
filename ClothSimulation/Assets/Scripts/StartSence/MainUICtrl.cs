using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public delegate void UIClose();
public delegate void OnTipsShow();
public delegate void OnTipsClose();
public enum UIStaet { 
    cxjd,
    kcjs,
    kssj
}
public class MainUICtrl : MonoBehaviour
{
    public GameObject TopUI;
    public GameObject PlanOne;
    public GameObject PlanTwo;
    public GameObject PlanThree;
    public GameObject TipsObj;

    private UIStaet uIStaet = UIStaet.cxjd;
    public UIClose nowClosed;
    public void ShowTop() {
        TopUI.transform.DOLocalMoveY(485,1);
        PlanOne.transform.GetComponent<UIPlanOne>().ShowPlan("江南大学传习馆");
    }


    public void ShowTips(OnTipsShow onTipsShow, OnTipsClose onTipsClose) {
        TipsObj.transform.Find("CloseBtn").GetComponent<Button>().onClick.AddListener(()=>{ onTipsClose(); CloseTips(); });
        TipsObj.transform.DOScale(1, 0.5f);
        onTipsShow();
    }

    public void CloseTips() {
        TipsObj.transform.DOScale(0, 0.5f);
    }


    public void OnCxjdBtnDown() {
        if (CheckChange(UIStaet.cxjd))
        {
            PlanOne.transform.GetComponent<UIPlanOne>().ShowPlan("江南大学传习馆");
        }
    }


    public void OnKcjsBtnDown()
    {
        if (CheckChange(UIStaet.kcjs))
        {
            PlanTwo.transform.GetComponent<UIPlanTwoKCJS>().ShowPlan();
        }
    }

    public void OnKssjBtnDown()
    {
        if (CheckChange(UIStaet.kssj))
        {
            PlanThree.transform.GetComponent<UIPlanThreeKSSJ>().ShowPlan();
        }
    }

    public void OnGyzxBtnDown()
    {

    }


    public void RegistClose(UIClose tmp) {
        nowClosed = tmp;
    }

    private bool CheckChange(UIStaet ChangeTo) {
        if (ChangeTo == uIStaet)
        {
            return false;
        }
        else
        {
            nowClosed();
            uIStaet = ChangeTo;
            return true;
        }
        
    }
}
