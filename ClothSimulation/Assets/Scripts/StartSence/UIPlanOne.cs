using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIPlanOne : MonoBehaviour
{
    private struct Clothse {
        public Clothse(string tmpname, string tmpinfo) {
            name = tmpname;
            info = tmpinfo;
        }
        public string name;
        public string info;
    }

    public GameObject Ctrl;
    public GameObject TitileObj;
    public GameObject ConTextObj;

    public GameObject YxmjfsTitileObj;
    public GameObject YxmjfsConTextObj;
    public GameObject GourpContent;
    public string ContextString;

    public GameObject ClothShowTmp;
    public GameObject ShowClothCtrl;


    private Dictionary<string, Clothse> allClothse = new Dictionary<string, Clothse> {
        {"ShenLanDuanXIu",new Clothse("深蓝提花短袖旗袍","深蓝提花短袖旗袍") },

    };

    public void Start()
    {
        foreach (KeyValuePair<string, Clothse> kvp in allClothse)
        {
            LoadShowCloth(kvp.Key, kvp.Value);
        }
       
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

    private void LoadShowCloth(string clothesName,Clothse TmpClothes) {

        Object tmpobj = Resources.Load("ShowClothObj", typeof(GameObject));
        GameObject newShowClothObj = Instantiate(tmpobj) as GameObject;

        Object tmpSpriteobj = Resources.Load("clothes/" + clothesName, typeof(Sprite));
        Sprite tmpSprite = Instantiate(tmpSpriteobj) as Sprite;
        newShowClothObj.transform.Find("CoverImg").GetComponent<Image>().sprite = tmpSprite;
        newShowClothObj.transform.SetParent(GourpContent.transform);
        newShowClothObj.transform.Find("NameText").GetComponent<Text>().text = TmpClothes.name;
      
        newShowClothObj.transform.GetComponent<Button>().onClick.AddListener(()=> { Ctrl.transform.GetComponent<MainUICtrl>().ShowTips(()=> 
        {
            OnOpenTmpCloth(clothesName, TmpClothes);
        },
        ()=>{
            OnCloseTmpCloth();
        }); });

    }

    private void OnOpenTmpCloth(string clothesName, Clothse TmpClothes) {
        ShowClothCtrl.transform.GetComponent<ShowObjsCtrl>().ShowTmpObj(clothesName);
        ClothShowTmp.transform.SetParent(Ctrl.transform.GetComponent<MainUICtrl>().TipsObj.transform.Find("Content01"));
        ClothShowTmp.transform.DOScale(1,0.5f);
        ClothShowTmp.transform.Find("NameText").GetComponent<Text>().text = TmpClothes.name;
        ClothShowTmp.transform.Find("ContentText").GetComponent<Text>().text = TmpClothes.info;
    }


    private void OnCloseTmpCloth() {
        ClothShowTmp.transform.SetParent(transform);
        ClothShowTmp.transform.DOScale(0, 0.5f);
        ShowClothCtrl.transform.GetComponent<ShowObjsCtrl>().Close();
    }

    

}
