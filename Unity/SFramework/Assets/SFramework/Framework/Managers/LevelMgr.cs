using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace SFramework{
public class LevelMgr : SingletonBase<LevelMgr>
{
    LevelMgrGo mgrGo = LevelMgrGo.instance;
    public void LoadNext(bool sync = false){
        if (sync){

        }
        else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void LoadPrevious(bool sync = false){
        if (sync){

        }
        else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
}