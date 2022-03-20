using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Scenes
{
    [CreateAssetMenu(fileName = "NewSceneGroup", menuName = "SceneGroup/NewSceneGroup")]
    public class SceneGroup : ScriptableObject
    {
        [SerializeField] private string[] _sceneNames = null;

        public string[] sceneNames => _sceneNames;

        public bool isLoaded => _sceneNames.All(name => SceneManager.GetSceneByName(name).isLoaded);
    }
}
