using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFramework;
using UnityEngine.UI;

public class GUIMgrTest : MonoBehaviourSimplify
{
    [SerializeField]
    GameObject bullet;
    GUIMgr guiMgr = GUIMgr.instance;
    const string FIRE_PANEL_NAME = "fire panel";
    const string NEXTLEVEL_BTN_NAME = "next level";
    const string FIRE_BTN_NAME = "Fire btn";
    const string OPEN_POOL_BTN_NAME = "Openpool";
    const string OPEN_SAVE_BTN_NAME = "OpenMenu";
    const string MENU_NAME = "Menu";
    const string PANEL_NAME = "Panel";
    const string SAVE_BTN_NAME = "save btn";
    const string QUIT_BTN_NAME = "quit btn";
    const string SAVE_FILE_NAME = "Text";
    InputField inptField;
    SimpleObjectPool<GameObject> pool;
    bool menuIsActive = true;
    GameObject menuGo;
    private void Awake() {
        pool = new SimpleObjectPool<GameObject>(BulletFactoryMethod, BulletResetMethod, 5);

        OnStart(()=>{
            mOnStart();
        });
    }

    void mOnStart(){
        guiMgr.Set(new Vector2(3840, 2160), 1);
            
        menuGo = guiMgr.AddPanel(MENU_NAME, ELayer.Bottom);

        if (!guiMgr.OnClick(MENU_NAME, OPEN_SAVE_BTN_NAME, OnClickOpenSave)){
            // fail to add onClick
            Debug.LogErrorFormat("Fail to add OnClick for btn {0}", OPEN_SAVE_BTN_NAME);
        }

        if(!guiMgr.OnClick(MENU_NAME, OPEN_POOL_BTN_NAME, OnClickOpenPool)){

            Debug.LogErrorFormat("Fail to add OnClick for btn {0}", OPEN_POOL_BTN_NAME);
        }

        if(!guiMgr.OnClick(MENU_NAME, NEXTLEVEL_BTN_NAME, ()=>{
            LevelMgr.instance.LoadNext();
        })){

            Debug.LogErrorFormat("Fail to add OnClick for btn {0}", NEXTLEVEL_BTN_NAME);
        }

    }

    private void OnDestroy() {
        guiMgr.RemovePanel(MENU_NAME);
        guiMgr.RemovePanel(PANEL_NAME);
        guiMgr.RemovePanel(FIRE_PANEL_NAME);
    }

    private void OnClickOpenSave(){
        menuIsActive = false;
        menuGo.SetActive(menuIsActive);
        inptField = guiMgr.AddPanel(PANEL_NAME, ELayer.Top).transform.GetComponentInChildren<InputField>();


        inptField.text = SaveMgr.instance.LoadString(SAVE_FILE_NAME);

        // save action
        guiMgr.OnClick(PANEL_NAME, SAVE_BTN_NAME, ()=>{

            Debug.Log("into save");

            SaveMgr.instance.Save(inptField.text, SAVE_FILE_NAME); 

        });

        // quit/remove panel
        guiMgr.OnClick(PANEL_NAME, QUIT_BTN_NAME, ()=>{

            Debug.Log("into remove");
            menuIsActive = true;
            menuGo.SetActive(menuIsActive);
            guiMgr.RemovePanel(PANEL_NAME);


        });
                
    }

    private void OnClickOpenPool(){
        SetMenuGo(false);
        var go = guiMgr.AddPanel(FIRE_PANEL_NAME, ELayer.Top);

        guiMgr.OnClick(FIRE_PANEL_NAME, FIRE_BTN_NAME, ()=>{
            Fire();
        });

        guiMgr.OnClick(FIRE_PANEL_NAME, QUIT_BTN_NAME, ()=>{
            SetMenuGo(true);
            Debug.Log("into remove");
            guiMgr.RemovePanel(FIRE_PANEL_NAME);
        });

    }

    void SetMenuGo(bool active){
        menuIsActive = active;
        menuGo.SetActive(menuIsActive);
    }

    void Fire(){
        Debug.Log("Fire");
        var blt = pool.Allocate();
        blt.SetActive(true);
        Delay(3, ()=> pool.Recycle(blt));
    }

    GameObject BulletFactoryMethod(){
        var temp = Instantiate(bullet);
        temp.transform.position = Vector3.zero;
        temp.SetActive(false);
        return temp;
    }

    void BulletResetMethod(GameObject go){
        go.transform.position = Vector3.zero;
        go.SetActive(false);
    }

}
