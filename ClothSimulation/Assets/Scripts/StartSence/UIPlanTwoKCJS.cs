using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIPlanTwoKCJS : MonoBehaviour
{
    public GameObject Ctrl;
    public GameObject TitileObj;
    public GameObject ConTextObj;

    public GameObject GJJSTitileObj;
    public GameObject GJJSConTextObj;


    public GameObject GYJSTitileObj;
    public GameObject GYJSConTextObj;
    public string ContextString;
    // Start is called before the first frame update
    public void ShowPlan()
    {
        Ctrl.transform.GetComponent<MainUICtrl>().nowClosed();
        Ctrl.transform.GetComponent<MainUICtrl>().RegistClose(ClosePlan);
        ConTextObj.transform.GetChild(0).GetComponent<Text>().text = ContextString;
        TitileObj.transform.DOLocalMoveX(-680, 2);
        ConTextObj.transform.DOLocalMoveX(0, 2);

    }

    private void ClosePlan()
    {
        TitileObj.transform.DOLocalMoveX(-1700, 2);
        ConTextObj.transform.DOLocalMoveX(2800, 2);
    }


    public void ShowGJJSPlan() {
        Ctrl.transform.GetComponent<MainUICtrl>().nowClosed();
        Ctrl.transform.GetComponent<MainUICtrl>().RegistClose(CloseGJJSPlan);
        GJJSTitileObj.transform.DOLocalMoveX(-680, 2);
        GJJSConTextObj.transform.DOLocalMoveX(0, 2);

    }


    private void CloseGJJSPlan() {
        GJJSTitileObj.transform.DOLocalMoveX(-1700, 2);
        GJJSConTextObj.transform.DOLocalMoveX(2800, 2);
    }


    public void ShowGYJSPlan() {
        Ctrl.transform.GetComponent<MainUICtrl>().nowClosed();
        Ctrl.transform.GetComponent<MainUICtrl>().RegistClose(CloseGYJSPlan);
        GYJSTitileObj.transform.DOLocalMoveX(-680, 2);
        GYJSConTextObj.transform.DOLocalMoveX(0, 2);
    }


    private void CloseGYJSPlan() {
        GYJSTitileObj.transform.DOLocalMoveX(-1700, 2);
        GYJSConTextObj.transform.DOLocalMoveX(2800, 2);
    }
}
