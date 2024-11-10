using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public enum UIList
    { 
        PANEL_START,    //PANEL : 게임 내에서 ESC를 눌렀을 때 UI가 닫히지 않는 경우

        LoadingUI,
        //GameHUD_UI, //캔버스를 프리팹화 했을 때 파일 이름과 동일해야 함
        Canvas_A,
        Canvas_B,




        PANEL_END,
        POPUP_START,   //POPUP : 게임 내에서 ESC를 눌렀을 때 UI가 닫히는 경우



        POPUP_END,
    }
}
