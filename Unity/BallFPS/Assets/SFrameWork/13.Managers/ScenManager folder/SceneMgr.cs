using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace SFramework
{
    public class SceneMgr : MonoBehaviourSimplify
    {
        public static SceneMgr Instance;
        private SceneMgr() { }
        public static SceneMgr GetInstance() { return Instance; }
        public int activeSceneBuildIndex;
        public int sceneIndexNeedToLoad = 0;
        public int addedSceneIndex = 0;
        public string addedSceneName = null;


        private void Update()
        {
            activeSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        }

        private void Awake()
        {
            Instance = this;

            AddEvent(EventType.LoadNextScene, LoadNextScene);
            AddEvent(EventType.LoadPreviousScene, LoadPreviousScene);
        }

        private void OnDestroy()
        {
            RemoveEvent(EventType.LoadNextScene, LoadNextScene);
            RemoveEvent(EventType.LoadPreviousScene, LoadPreviousScene);
        }

        public void LoadNextScene()
        {
            addedSceneName = null;
            addedSceneIndex = 0;
            sceneIndexNeedToLoad = activeSceneBuildIndex + 1;
            SceneManager.LoadScene("LoadingScene");
        }

        public void LoadNextSceneWithOtherScene(int addedScen)
        {
            addedSceneName = null;
            addedSceneIndex = addedScen;
            sceneIndexNeedToLoad = activeSceneBuildIndex + 1;
            SceneManager.LoadScene("LoadingScene");
        }

        public void LoadNextSceneWithOtherScene(string addedScen)
        {
            addedSceneIndex = 0;
            addedSceneName = addedScen;
            sceneIndexNeedToLoad = activeSceneBuildIndex + 1;
            SceneManager.LoadScene("LoadingScene");
        }

        public void LoadPreviousScene()
        {
            addedSceneName = null;
            addedSceneIndex = 0;
            sceneIndexNeedToLoad = activeSceneBuildIndex - 1;
            SceneManager.LoadScene("LoadingScene");
        }

        public void LoadScene(int sceneIndex)
        {
            addedSceneName = null;
            addedSceneIndex = 0;
            sceneIndexNeedToLoad = sceneIndex;
            SceneManager.LoadScene("LoadingScene");
        }

        public IEnumerator LoadSceneCoroutine(int buildIndex, Text text)
        {
            yield return null;

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(buildIndex);
            asyncOperation.allowSceneActivation = false;
            while (!asyncOperation.isDone)
            {
                //Output the current progress
                text.text = (asyncOperation.progress * 100) + "%";

                // Check if the load has finished
                if (asyncOperation.progress >= 0.9f)
                {
                    //if (Input.anyKeyDown)
                    //{
                    asyncOperation.allowSceneActivation = true;
                    //}

                }

                yield return null;
            }
        }

        public IEnumerator LoadSceneCoroutine(int buildIndex, Slider slider, Text text)
        {
            yield return null;

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(buildIndex);
            asyncOperation.allowSceneActivation = false;
            while (!asyncOperation.isDone)
            {
                //Output the current progress
                text.text = (asyncOperation.progress * 100) + "%";
                slider.value = asyncOperation.progress;
                // Check if the load has finished
                if (asyncOperation.progress >= 0.9f)
                {
                    //if (Input.anyKeyDown)
                    //{
                    asyncOperation.allowSceneActivation = true;
                    //}

                }

                yield return null;
            }
        }

        public IEnumerator LoadSceneCoroutine(int buildIndex, Slider slider)
        {
            yield return null;

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(buildIndex);
            asyncOperation.allowSceneActivation = false;
            while (!asyncOperation.isDone)
            {
                slider.value = asyncOperation.progress;
                // Check if the load has finished
                if (asyncOperation.progress >= 0.9f)
                {
                    //if (Input.anyKeyDown)
                    //{
                    asyncOperation.allowSceneActivation = true;
                    //}

                }

                yield return null;
            }
        }


        public IEnumerator LoadSceneCoroutine(int buildIndex)
        {
            yield return null;

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(buildIndex);

            asyncOperation.allowSceneActivation = false;

            while (!asyncOperation.isDone)
            {
                // Check if the load has finished
                if (asyncOperation.progress >= 0.9f)
                {
                    //if (Input.anyKeyDown)
                    //{
                    asyncOperation.allowSceneActivation = true;
                    //}

                }

                yield return null;
            }
        }

        public IEnumerator LoadSceneCoroutine(int buildIndex, Slider slider, Text text, int addedScen)
        {
            yield return null;

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(buildIndex);
            asyncOperation.allowSceneActivation = false;
            while (!asyncOperation.isDone)
            {
                //Output the current progress
                text.text = (asyncOperation.progress * 100) + "%";
                slider.value = asyncOperation.progress;
                // Check if the load has finished
                if (asyncOperation.progress >= 0.9f)
                {
                    AsyncOperation ao = SceneManager.LoadSceneAsync(addedScen);
                    ao.allowSceneActivation = false;
                    while (!ao.isDone)
                    {
                        if (ao.progress >= 0.9f)
                        {

                            ao.allowSceneActivation = true;

                        }
                        yield return null;
                    }
                    asyncOperation.allowSceneActivation = true;

                }

                yield return null;
            }

        }

        public IEnumerator LoadSceneCoroutine(int buildIndex, Slider slider, Text text, string addedScen)
        {
            yield return null;

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(buildIndex);
            asyncOperation.allowSceneActivation = false;

            AsyncOperation ao = SceneManager.LoadSceneAsync(addedScen, LoadSceneMode.Additive);
            ao.allowSceneActivation = false;

            while (!ao.isDone)
            {
                if (!asyncOperation.isDone)
                {
                    text.text = (asyncOperation.progress * 100) + "%";
                    slider.value = asyncOperation.progress;
                }
                
                // Check if the load has finished
                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                    if (ao.progress >= 0.9f)
                    {
                        
                        ao.allowSceneActivation = true;

                    }
                }

                yield return null;
            }
        }

        public void StartLoadingScene(IEnumerator loadSceneCoroutine)
        {
            StartCoroutine(loadSceneCoroutine);
        }
    }

}
