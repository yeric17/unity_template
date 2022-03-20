using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Scenes;
using Assets.Scripts.StateMachine;
public class MainMenu : MonoBehaviour
{

    public void PlayButton()
    {
        SceneController.Instance.Load(GameManager.Instance.gameplayScenes.sceneNames, GameManager.Instance.mainMenuScenes.sceneNames);
    }

    public void ExitButton()
    {
        //Todo: refactor when save game feature will be implementing
        Application.Quit();
    }
}
