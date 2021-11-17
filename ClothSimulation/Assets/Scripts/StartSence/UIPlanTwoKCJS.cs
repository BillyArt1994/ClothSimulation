using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIPlanTwoKCJS : MonoBehaviour
{
    private struct Tool {
        public Tool(string tmpName,string tmpInfo) {
            Name = tmpName;
            Info = tmpInfo;
        } 
        public string Name;
        public string Info;
    }

    public GameObject Ctrl;
    public GameObject TitileObj;
    public GameObject ConTextObj;

    public GameObject GJJSTitileObj;
    public GameObject GJJSConTextObj;
    public GameObject GJJSContent;


    public GameObject GYJSTitileObj;
    public GameObject GYJSConTextObj;

    public string ContextString;



    private Dictionary<string, Tool> AllTools = new Dictionary<string, Tool>() {
        {"huafen",new Tool("划粉","用于在面料上绘制旗袍裁片，方面裁剪。") },
        {"jiandao",new Tool("服装专用剪刀","用于面料裁剪") },
        {"zhichi",new Tool("直尺","辅助旗袍裁片绘制") },
        {"ruanchi",new Tool("软尺","用于量体裁衣") },
        {"zhengzhu",new Tool("珠针","用于衣片固定") },
        {"neizi",new Tool("镊子","辅助旗袍细节制作") },
        {"zhuizi",new Tool("锥子","用于旗袍部分细节打孔") },
        {"yundou",new Tool("熨斗","用于面料及旗袍熨烫") },
        {"fengrenji",new Tool("缝纫机","用于缝制旗袍") },
        {"soufengzheng",new Tool("手缝针","用于手工缝纫旗袍细节") },
        {"fengrenxian",new Tool("缝纫线","用于旗袍机缝及手缝") },
        {"shangjiangji",new Tool("上浆剂","用于旗袍领部、盘扣等需要上浆硬挺的面料部分") },
        {"tangdeng",new Tool("烫凳","熨烫时使用，根据熨烫的部位选择对应的尺寸和形状的烫凳。") },
        {"dingzheng",new Tool("顶针","做手缝的时候使用") },
        {"wanzuiqianzi",new Tool("弯嘴钳子","盘扣的时候用到的比较多") },
        {"shajian",new Tool("纱剪","用来剪一些手缝线") },
        {"tongsi",new Tool("铜丝","做硬盘花扣造型支撑用") },
        {"lingcheng",new Tool("领衬","领子里衬，用来保持旗袍领子立挺的造型.可-以用树脂硬衬，也可以用布衬/纸衬") }
    };



    private void Start()
    {
        foreach (KeyValuePair<string, Tool> kvp in AllTools)
        {
            LoadTools(kvp.Key, kvp.Value);
        }
    }

    private void LoadTools(string toolName,Tool tmpTool) {
        Object tmpobj = Resources.Load("Tools/tool", typeof(GameObject));
        GameObject newTool = Instantiate(tmpobj) as GameObject;

       

        Object tmpSpriteobj = Resources.Load("Tools/" + toolName, typeof(Sprite));
        Sprite tmpSprite = Instantiate(tmpSpriteobj) as Sprite;


        newTool.transform.Find("toolName").GetComponent<Text>().text = tmpTool.Name;
        newTool.transform.Find("Toolimg").GetComponent<Image>().sprite = tmpSprite;
        newTool.transform.Find("kuang").GetComponent<Button>().onClick.AddListener(()=> { Debug.Log(toolName); });
        newTool.transform.SetParent(GJJSContent.transform);
    }


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
