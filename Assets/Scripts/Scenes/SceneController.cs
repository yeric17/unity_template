using Assets.Scripts.Commons;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.StateMachine;

namespace Assets.Scripts.Scenes
{
    public class SceneController : Singleton<SceneController>
    {
        private Dictionary<string, AsyncOperation> _asyncOperations = new Dictionary<string, AsyncOperation>();

        public int processCount
        {
            get {
                return _asyncOperations.Count;
            }
        }

        public bool isLoading => processCount > 0;

        public float loadProgress
        {
            get
            {
                if (_asyncOperations.Count < 1) return 1f;
                var count = _asyncOperations.Count;
                var totalProgress = _asyncOperations.Sum(operation => operation.Value.progress);
                return totalProgress / count;
            }
        }
        private IEnumerator LoadScene(string sceneName) {
            if (SceneManager.GetSceneByName(sceneName).isLoaded) yield break;

            //GameStateMachine.Instance.SetState(GameStateMachine.Instance.loadingSceneState);

            var loadSceneOpe = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            if (loadSceneOpe == null) {
                Debug.LogWarning($"The scene named: ({sceneName}) does not exist");
                yield break;
            }
            

            _asyncOperations.Add(sceneName,loadSceneOpe);

            while (!loadSceneOpe.isDone) {
                yield return null;
            }

            _asyncOperations.Remove(sceneName);

        }

        private IEnumerator UnloadScene(string sceneName)
        {
            if (!SceneManager.GetSceneByName(sceneName).isLoaded) yield break;
            var unloadSceneOpe = SceneManager.UnloadSceneAsync(sceneName);
            if (unloadSceneOpe == null)
            {
                Debug.LogError($"The scene named : ({sceneName}) does not exist");
                yield break;
            }
            _asyncOperations.Add(sceneName, unloadSceneOpe);
            while (!unloadSceneOpe.isDone)
            {
                yield return null;
            }
            _asyncOperations.Remove(sceneName);
        }
        public void Load(string sceneName)
        {
            StartCoroutine(LoadScene(sceneName));
        }

        public void Load(string[] sceneNames)
        {
            for (var sceneIdx = 0; sceneIdx < sceneNames.Length; sceneIdx++)
            {
                Load(sceneNames[sceneIdx]);
            }
        }

        public void Load(string loadSceneName, string unloadSceneName)
        {
            Load(loadSceneName);
            Unload(unloadSceneName);
        }

        public void Load(string[] loadSceneNames, string[] unloadSceneNames)
        {
            Load(loadSceneNames);
            Unload(unloadSceneNames);
        }


        public void Load(string loadSceneName, string[] unloadSceneNames)
        {
            Load(loadSceneName);
            Unload(unloadSceneNames);
        }

        public void Load(string[] loadSceneNames, string unloadSceneName)
        {
            Load(loadSceneNames);
            Unload(unloadSceneName);
        }

        public void Unload(string sceneName)
        {
            StartCoroutine(UnloadScene(sceneName));
        }
        public void Unload(string[] sceneNames)
        {
            for (var sceneIdx = 0; sceneIdx < sceneNames.Length; sceneIdx++)
            {
                StartCoroutine(UnloadScene(sceneNames[sceneIdx]));
            }
        }

        public bool CallbackIsNotLoading() {
            return !isLoading;
        }
    }
}
