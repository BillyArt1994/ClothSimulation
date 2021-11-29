using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public struct Qusetion {
    public Qusetion(int tmpid,string tmpContent,string tmpA,string tmpB,string tmpC,string tmpD,int tmpRight)
    {
        id = tmpid;
        Content = tmpContent;
        A = tmpA;
        B = tmpB;
        C = tmpC;
        D = tmpD;
        right = tmpRight;
    }
   
    public int id;
    public string Content;
    public string A;
    public string B;
    public string C;
    public string D;
    public int right;
}
public class QuestionPlanCtrl : MonoBehaviour
{
    public GameObject ctrl;
    public List<Toggle> AllToggle;
    public Text content;
    public Text A;
    public Text B;
    public Text C;
    public Text D;
    public GameObject tips;
    public GameObject CloseBtn;
    private int NowSelect;
    private int rightSelect;
    // Start is called before the first frame update

    void Start() {
        foreach (var item in AllToggle)
        {
            item.onValueChanged.AddListener(delegate (bool ison)
            {
                if (ison)
                {
                    NowSelect=item.transform.GetSiblingIndex();
                }
            });

        }
    }

    public void SetQusetion(Qusetion tmp) {
        content.text = tmp.Content;
        A.text = tmp.A;
        B.text = tmp.B;
        C.text = tmp.C;
        D.text = tmp.D;
        rightSelect = tmp.right;
    }


    public void OnShowPlan() {
        tips.gameObject.SetActive(false);
        CloseBtn.gameObject.SetActive(false);
        gameObject.transform.DOScale(1, 1);
        foreach (var item in AllToggle)
        {
            item.enabled = true;
        }
    }

    public void OnClosePlan() {
        
        gameObject.transform.DOScale(0, 1);
        //ctrl.GetComponent<StepCtrl>().TimeLinePlay();
    }

    public void OnCheckQuestion() {
        foreach (var item in AllToggle)
        {
            item.enabled = false;
        }
        tips.gameObject.SetActive(true);
        CloseBtn.gameObject.SetActive(true);
        if (NowSelect == rightSelect)
        {
            tips.GetComponent<Text>().text = "恭喜你回答正确";
        }
        else
        {
            tips.GetComponent<Text>().text = "很遗憾回答错误，正确选项为"+ ExcelColumnFromNumber(rightSelect);
        }
    }


    public  string ExcelColumnFromNumber(int column)
    {
        string columnString = "";
        decimal columnNumber = column;
        while (columnNumber > 0)
        {
            decimal currentLetterNumber = (columnNumber - 1) % 26;
            char currentLetter = (char)(currentLetterNumber + 65);
            columnString = currentLetter + columnString;
            columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
        }
        return columnString;
    }



}
