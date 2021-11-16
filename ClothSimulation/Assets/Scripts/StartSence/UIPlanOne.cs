using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIPlanOne : MonoBehaviour
{
    public GameObject Ctrl;
    public GameObject TitileObj;
    public GameObject ConTextObj;

    public GameObject YxmjfsTitileObj;
    public GameObject YxmjfsConTextObj;
    public GameObject GourpContent;
    public string ContextString;

    public void Start()
    {
        LoadShowCloth();
    }
    public void ShowPlan(string titile) {

        Ctrl.transform.GetComponent<MainUICtrl>().RegistClose(ClosePlan);
        TitileObj.transform.GetChild(0).GetComponent<Text>().text = titile;
        ConTextObj.transform.GetChild(0).GetComponent<Text>().text = ContextString;
        TitileObj.transform.DOLocalMoveX(-680, 2);
        ConTextObj.transform.DOLocalMoveX(0, 2);



        
    }

    private void ClosePlan() 
    {
        TitileObj.transform.DOLocalMoveX(-1700,2);
        ConTextObj.transform.DOLocalMoveX(2800, 2);
    }

    public void OnNextBtnDown() {
        Ctrl.transform.GetComponent<MainUICtrl>().nowClosed();
        Ctrl.transform.GetComponent<MainUICtrl>().RegistClose(CloseYxmjfsPlan);
        ShowYxmjfsPlan();
    }

    public void OnBackBtnDown() {
        Ctrl.transform.GetComponent<MainUICtrl>().nowClosed();
        Ctrl.transform.GetComponent<MainUICtrl>().RegistClose(ClosePlan);
        ShowPlan("江南大学传习馆");

    }

    private void ShowYxmjfsPlan()
    {
        YxmjfsTitileObj.transform.DOLocalMoveX(-680, 2);
        YxmjfsConTextObj.transform.DOLocalMoveX(0, 2);

    }

    private void CloseYxmjfsPlan() {
        YxmjfsTitileObj.transform.DOLocalMoveX(-1700, 2);
        YxmjfsConTextObj.transform.DOLocalMoveX(2800, 2);
    }

    private void LoadShowCloth() {
        Object tmpobj = Resources.Load("ShowClothObj", typeof(GameObject));
        GameObject newShowClothObj = Instantiate(tmpobj) as GameObject;
        newShowClothObj.transform.SetParent(GourpContent.transform);
        newShowClothObj.transform.Find("NameText").GetComponent<Text>().text = "深蓝短袖夹旗袍";
        newShowClothObj.transform.GetComponent<Button>().onClick.AddListener(Ctrl.transform.GetComponent<MainUICtrl>().ShowTips);

    }

    

}
