using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using DG.Tweening;

public enum Steps {
     zero,
     one,
     two,
     three,
     four,
     five,
     six,

}


public delegate void OnVoidDo();
public delegate void OnStartDo();
public delegate void OnSelectTool();
public delegate void OnPauseDo();
public class StepCtrl : MonoBehaviour
{
    public GameObject StepCtrlTimeline;
    public GameObject ToolsContent;


    public Text ContextInfo;
    public Text helpText;
    public Text TipsText;
    private Steps steps = Steps.zero;
    private Dictionary<Steps, string> ContextInfoDIc = new Dictionary<Steps, string> {
        { Steps.zero,"引言"},
        { Steps.one,"成品展示"},
        { Steps.two,"面料上浆"},
        { Steps.three,"面料，里料裁剪"},
        { Steps.four,"绲边布上浆，扣折绲边条"},
        { Steps.five,"里料拼缝。"},
    };

    private Dictionary<Steps, OnVoidDo> OnVoidDoDic = new Dictionary<Steps, OnVoidDo>{ };
    private Dictionary<Steps, OnStartDo> OnStartDoDic = new Dictionary<Steps, OnStartDo> { };
    private Dictionary<Steps, OnPauseDo> OnPauseDoDic = new Dictionary<Steps, OnPauseDo> { };
    private bool HaveUpDate=false;
    private OnVoidDo TmpOnVoidDo;
    private OnStartDo TmpStartDo;
    private OnPauseDo TmpPauseDo;
    // Start is called before the first frame update
    void Start()
    {
        string tmp = "error";
        ContextInfoDIc.TryGetValue(steps, out tmp);
        ContextInfo.text = tmp;
        SetHelpText("点击下一步继续学习。");
    }

    // Update is called once per frame
    void Update()
    {

        if (HaveUpDate)
        {
            TmpOnVoidDo();
        }
    }

    public void RegistVoidDo(Steps tmpStep,OnVoidDo tmpVoidDo) {
        OnVoidDoDic.Add(tmpStep, tmpVoidDo);
    }

    public void RegistStartDo(Steps tmpStep, OnStartDo tmpStartDo) {
        OnStartDoDic.Add(tmpStep, tmpStartDo);
    }


    public void RegistPauseDo(Steps tmpStep, OnPauseDo tmpOnPauseDo) {
        OnPauseDoDic.Add(tmpStep, tmpOnPauseDo);
    }


    public void SetTipsText(string tipstext) {
        TipsText.text = tipstext;
     
    }

    public void SetHelpText(string helptext) {
        helpText.text = helptext;
    }
   


    //当暂停时判断
    public void TimeLinePause() {  
        StepCtrlTimeline.GetComponent<PlayableDirector>().Pause();
        HaveUpDate= OnVoidDoDic.TryGetValue(steps, out TmpOnVoidDo);//是否需要update操作
        if (OnPauseDoDic.TryGetValue(steps, out TmpPauseDo))//是否需要初始化
        {
            //ClearToolsContent();
            TmpPauseDo();
        }
    }


    public void TimeLineStepChangePause() {
        steps++;
        string tmp = "error";
        ContextInfoDIc.TryGetValue(steps, out tmp);
        ContextInfo.text = tmp;
        StepCtrlTimeline.GetComponent<PlayableDirector>().Pause();
        HaveUpDate = OnVoidDoDic.TryGetValue(steps, out TmpOnVoidDo);//是否需要update操作
        if (OnStartDoDic.TryGetValue(steps, out TmpStartDo))//是否需要初始化
        {
            Debug.Log(steps);
            TmpStartDo();
        }
        if (OnPauseDoDic.TryGetValue(steps, out TmpPauseDo))//是否需要初始化
        {
            //ClearToolsContent();
            TmpPauseDo();
        }

    }

    public void TimeLineStepChangePlay()
    {
        StepCtrlTimeline.GetComponent<PlayableDirector>().Play();
        steps++;
        string tmp = "error";
        ContextInfoDIc.TryGetValue(steps, out tmp);
        ContextInfo.text = tmp;
    }


    public void TimeLinePlay() {
        StepCtrlTimeline.GetComponent<PlayableDirector>().Play();
    }

    public void ShowTips() {
        ToolsContent.transform.DOLocalMoveX(725.34f, 1);
    }

    public void CloseTips() {
        ToolsContent.transform.DOLocalMoveX(1500, 1);
    }
}
