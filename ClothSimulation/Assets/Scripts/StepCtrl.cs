using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

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
public class StepCtrl : MonoBehaviour
{
    public GameObject StepCtrlTimeline;
    public GameObject ToolsContent;


    public Text ContextInfo;
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
    private bool HaveUpDate=false;
    private OnVoidDo TmpOnVoidDo;
    private OnStartDo TmpStartDo;
    // Start is called before the first frame update
    void Start()
    {
        string tmp = "error";
        ContextInfoDIc.TryGetValue(steps, out tmp);
        ContextInfo.text = tmp;
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



   


    //当暂停时判断
    public void TimeLinePause() {  
        StepCtrlTimeline.GetComponent<PlayableDirector>().Pause();
        HaveUpDate= OnVoidDoDic.TryGetValue(steps, out TmpOnVoidDo);//是否需要update操作
        if (OnStartDoDic.TryGetValue(steps,out TmpStartDo))//是否需要初始化
        {
            //ClearToolsContent();
            TmpStartDo();
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
            //ClearToolsContent();
            TmpStartDo();
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


}
