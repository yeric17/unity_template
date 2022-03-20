
using UnityEngine;
using Assets.Scripts.Commons;
using Assets.Scripts.Scenes;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private SceneGroup _mainMenuScenes = null;
    [SerializeField] private SceneGroup _gameplayScenes = null;
    [SerializeField] private SceneController _sceneController = null;

    public SceneGroup mainMenuScenes => _mainMenuScenes;
    public SceneGroup gameplayScenes => _gameplayScenes;
    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if(_sceneController == null)
        {
            _sceneController = GetComponentInChildren<SceneController>();
        }

        _sceneController.Load(_mainMenuScenes.sceneNames);
    }
}
