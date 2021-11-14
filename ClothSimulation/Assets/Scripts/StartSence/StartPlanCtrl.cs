using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartPlanCtrl : MonoBehaviour
{
    public GameObject ctrl;

    public GameObject yunOne;
    public GameObject yunTwo;
    public GameObject StartUI;
    public GameObject BgUI;
    public GameObject BGMark;
    public Color tmpColor;
    public Button StartBtn;
    public float time=10;

    private Tweener one;
    private Tweener two;
    // Start is called before the first frame update
    void Start()
    {
        one=yunOne.transform.DOLocalMoveX(-700, time).SetLoops(-1, LoopType.Yoyo);
        two=yunTwo.transform.DOLocalMoveX(700, time).SetLoops(-1, LoopType.Yoyo);
        StartBtn.transform.GetComponent<Image>().DOFade(0.5f,2).SetLoops(-1, LoopType.Yoyo);
    }

    public void OnStart() {
        one.Pause();
        two.Pause();
        yunOne.transform.DOLocalMoveX(-1700, 2);
        yunTwo.transform.DOLocalMoveX(1700, 2);
        StartUI.transform.DOLocalMoveX(-1700, 2);
        StartBtn.transform.DOLocalMoveX(1700, 2);
        BGMark.GetComponent<Image>().DOColor(tmpColor, 2);
        BgUI.transform.DOScale(1.1f,2);
        ctrl.transform.GetComponent<MainUICtrl>().ShowTop();
    }
}
