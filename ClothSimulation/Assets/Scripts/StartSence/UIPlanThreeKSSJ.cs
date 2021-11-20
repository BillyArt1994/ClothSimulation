using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIPlanThreeKSSJ : MonoBehaviour
{

    private struct DingZhi {
        public DingZhi(string tmpName,string tmpImgPath) {
            ImgPath = tmpImgPath;
            Name = tmpName;
        }
      public string ImgPath;
      public string Name;
    }
    public GameObject Ctrl;
    public GameObject KSSJContent;
    public GameObject ShowImg;
    public GameObject ViewContent;

    public GameObject ThreeDCtrl;
    public GameObject Qipao;

    private Dictionary<string, DingZhi> KuanshiDingZhi = new Dictionary<string, DingZhi> {
        {"kuanshiA",new DingZhi("A型","kuanshi/A") },
        {"kuanshiH",new DingZhi("H型","kuanshi/H") },
        {"kuanshiX",new DingZhi("X型","kuanshi/X") },
    };

    private Dictionary<string, DingZhi> LingZiDingZhi = new Dictionary<string, DingZhi> {
        {"zhong",new DingZhi("中领","lingzi/zhong") },
        {"di",new DingZhi("低领","lingzi/di") },
        {"gao",new DingZhi("高领","lingzi/gao") },
    };


    private Dictionary<string, DingZhi> NiuKouDingZhi = new Dictionary<string, DingZhi> {
        {"yi",new DingZhi("一字扣","niukou/yi") },
        {"pan",new DingZhi("盘香扣","niukou/pan") },
        {"juhua",new DingZhi("菊花扣","niukou/juhua") },
    };


    private Dictionary<string, DingZhi> XiuZiDingZhi = new Dictionary<string, DingZhi> {
        {"wu",new DingZhi("一字扣","xiuzi/wu") },
        {"duan",new DingZhi("盘香扣","xiuzi/duan") },
        {"zhong",new DingZhi("菊花扣","xiuzi/zhong") },
        {"chang",new DingZhi("菊花扣","xiuzi/chang") },
    };
    public void ShowPlan()
    {

        Ctrl.transform.GetComponent<MainUICtrl>().RegistClose(ClosePlan);
        ShowImg.transform.DOLocalMoveX(-610, 2);
        KSSJContent.transform.DOLocalMoveX(0, 2);
        ThreeDCtrl.transform.GetComponent<ShowObjsCtrl>().ShowTmpObj("QiPaoDingZhi");
        OnKuanshiBtnDown();
    }

    private void ClosePlan()
    {
        ShowImg.transform.DOLocalMoveX(-1700, 2);
        KSSJContent.transform.DOLocalMoveX(2800, 2);
    }

    public void OnShowClothesBtnDown() {
       
    }


    public void OnKuanshiBtnDown() {
        ClearAllChild();
        foreach (KeyValuePair<string, DingZhi> kvp in KuanshiDingZhi)
        {
            AddToViewContent(kvp.Value);
        }

    }

    public void OnLinziBtnDown() {
        ClearAllChild();
        foreach (KeyValuePair<string, DingZhi> kvp in LingZiDingZhi)
        {
            AddToViewContent(kvp.Value);
        }
    }

    public void OnNiukouBtnDown() {
        ClearAllChild();
        foreach (KeyValuePair<string, DingZhi> kvp in NiuKouDingZhi)
        {
            AddToViewContent(kvp.Value);
        }
    }


    public void OnXiuziBtnDown() {
        ClearAllChild();
        foreach (KeyValuePair<string, DingZhi> kvp in XiuZiDingZhi)
        {
            AddToViewContent(kvp.Value);
        }
    }

    private void ClearAllChild() {
        for (int i = 0; i < ViewContent.transform.childCount; i++)
        {
            GameObject.Destroy(ViewContent.transform.GetChild(i).gameObject);
        }
    }


    private void AddToViewContent(DingZhi tmpdingzhi) 
    {
        Object tmpobj = Resources.Load("DingZhi", typeof(GameObject));
        GameObject newTool = Instantiate(tmpobj) as GameObject;


        
        Object tmpSpriteobj = Resources.Load("kuanshi/" + tmpdingzhi.ImgPath, typeof(Sprite));
        Sprite tmpSprite = Instantiate(tmpSpriteobj) as Sprite;


        newTool.transform.Find("NameText").GetComponent<Text>().text = tmpdingzhi.Name;
        newTool.transform.Find("ShowImg").GetComponent<Image>().sprite = tmpSprite;
        newTool.transform.Find("Btn").GetComponent<Button>().onClick.AddListener(() => { Debug.Log(tmpdingzhi.Name); });
        newTool.transform.SetParent(ViewContent.transform);


    }
}
