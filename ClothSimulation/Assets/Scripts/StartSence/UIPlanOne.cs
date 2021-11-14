using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIPlanOne : MonoBehaviour
{
    public GameObject TitileObj;
    public GameObject ConTextObj;
    public void ShowPlan(string titile,string context) {
        TitileObj.transform.GetChild(0).GetComponent<Text>().text = titile;
        ConTextObj.transform.GetChild(0).GetComponent<Text>().text = context;
        TitileObj.transform.DOLocalMoveX(-700, 2);
        ConTextObj.transform.DOLocalMoveX(220, 2);
    }

    public void ClosePlan() 
    {
        TitileObj.transform.DOLocalMoveX(-1700,2);
        ConTextObj.transform.DOLocalMoveX(1800, 2);
    }
}
