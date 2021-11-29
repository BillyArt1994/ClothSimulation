using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StepTwo_OnMianLiaoShangJiang : MonoBehaviour
{
    private enum State {
        mianliaoshangjiang,
        zhiyang,
        mianliaocaijian,
    }

    public GameObject shuazi;
    public GameObject jiandao;
    public GameObject huafeng;
    public GameObject zhiyang;
    private bool IsPlay = true;
    private struct StateInfo{
        public StateInfo(string tmphlep,string tmptips) {
            help = tmphlep;
            tips = tmptips;
        }
        public  string help;
        public  string tips;
    }
    private State selfState = State.mianliaoshangjiang;
    private Dictionary<State, StateInfo> AllInfo = new Dictionary<State, StateInfo>
    {
        {  State.mianliaoshangjiang,new StateInfo("点击上浆剂对面料进行上浆。","上浆要点") },
        {  State.zhiyang,new StateInfo("点击划粉按照纸样进行画样。","(一)面料纵向对折:确定前后衣片中线、左右肩线。\n(二)画出前后的领深线和领宽线。" +
            "(三)画出挂肩长、上腰（胸宽）、下腰位置。" +
            "(四)在前领口下约0.7cm—1cm处定大襟口起点A点，大襟定B点7.5cm左右。" +
            "(五)确定腋下纽扣位置C点：挂肩长+2.5cm，延长至布料光边止口D点。" +
            "(六)划顺大襟曲线（A-B-C）。" +
            "(七)领圈内画出领宽线平行的线段EF，E点在前中线上，F点距离领宽止口0.7cm左右，并剪开EF 线段（上下两层）。" +
            "(八)沿着DCBAE的方向剪开。" +
            "(九)将EF的下层面料（右片）剪口，以缉合省道方式缝合0.5cm-0.8cm左右（归拢），上层面料（左片）剪口拔开约1cm 左右。" +
            "该步骤目的取得大襟定处与小襟对应部位的重叠量，以盖住小襟缝线。" +
            "(十)分别偏移前后中线，使得大襟线与小襟线之间的重叠量增加，偏移量根据大小襟之间的重叠量确定。" +
            "该步骤目的是取得大小襟之间的重叠量，以盖住小肩与小襟的缝合线。" +
            "(十一)修正挂肩、上腰、下腰位置、确定挂肩长、上腰宽、下腰宽、臀围宽、下摆宽、开衩长，划顺袖缝线、衣身侧缝线。" +
            "(十二)修正领圈弧线，按设定尺寸挖剪领圈。" +
            "(十三)裁剪、领子、绲条布。" +
            "(十四)注意点：如领子领口、领圈、大襟、开衩处为绲边工艺处理，则领圈、大襟开襟止口、开衩处为净样。（附图）" +
            "(十五)里料裁剪（附图）") },
         {  State.mianliaocaijian,new StateInfo("点击剪刀对面料进行裁剪。","按照画的线条进行裁剪") },


    };

    void Start()
    {
        gameObject.transform.GetComponent<StepCtrl>().RegistVoidDo(Steps.two, UpdataDo);
        gameObject.transform.GetComponent<StepCtrl>().RegistStartDo(Steps.two, StartDo);
        gameObject.transform.GetComponent<StepCtrl>().RegistPauseDo(Steps.two, PauseDo);

    }


    private void ChangeTipsAndHelp() {
        StateInfo tmpinfo;
        if (AllInfo.TryGetValue(selfState, out tmpinfo))
        {
            gameObject.transform.GetComponent<StepCtrl>().SetHelpText (tmpinfo.help) ;
            gameObject.transform.GetComponent<StepCtrl>().SetTipsText(tmpinfo.tips);
        }
       
    }


    private void PauseDo() {
        IsPlay = true;
        ChangeTipsAndHelp();
        switch (selfState)
        {
            case State.mianliaoshangjiang:
                shuazi.GetComponent<MeshRenderer>().material.SetFloat("_Offset", 0.01f);

                break;
            case State.zhiyang:
                gameObject.transform.GetComponent<StepCtrl>().QusetionPlan.transform.GetComponent<QuestionPlanCtrl>().SetQusetion(new Qusetion(0,
                    "测试题",
                    "A",
                    "B",
                    "C",
                    "D",
                    1));
                gameObject.transform.GetComponent<StepCtrl>().QusetionPlan.transform.GetComponent<QuestionPlanCtrl>().OnShowPlan();
                gameObject.transform.GetComponent<StepCtrl>().TimeLinePause();
                huafeng.GetComponent<MeshRenderer>().material.SetFloat("_Offset", 0.01f);
                break;
            case State.mianliaocaijian:
                jiandao.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_Offset", 0.001f);
                break;
            default:
                break;
        }
    }

    public void UpdataDo()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, int.MaxValue))
                {
                    if (IsPlay)
                    {

                        Debug.Log(hit.collider.transform.name);
                        switch (selfState)
                        {
                            case State.mianliaoshangjiang:
                                if (hit.collider.transform.name == "刷子")
                                {

                                shuazi.GetComponent<MeshRenderer>().material.SetFloat("_Offset", 0);
                                gameObject.transform.GetComponent<StepCtrl>().TimeLinePlay();
                                    selfState++;
                                IsPlay = false;
                                }
                                break;
                            case State.zhiyang:
                                if (hit.collider.transform.name == "huafen")
                                {
                                huafeng.GetComponent<MeshRenderer>().material.SetFloat("_Offset", 0);
                                gameObject.transform.GetComponent<StepCtrl>().TimeLinePlay();
                                       selfState++;
                                zhiyang.transform.DOScale(0.002687774f, 1);
                                IsPlay = false;
                            }
                            break;
                            case State.mianliaocaijian:
                                if (hit.collider.transform.name == "Scissors")
                                {

                                jiandao.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_Offset", 0);
                                gameObject.transform.GetComponent<StepCtrl>().TimeLinePlay();
                                    selfState++;
                                IsPlay = false;
                            }
                            break;
                            default:
                                break;
                        }

                    }

            }
       
        }
        
    }

   
    private void StartDo() {
        ChangeTipsAndHelp();
        gameObject.transform.GetComponent<StepCtrl>().ShowTips();
    }


}
