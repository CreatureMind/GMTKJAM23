using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    StartScreen,
    CutScene,
    InGame,
    EndGame
}

public class GameCameraManagerManager : MonoBehaviour
{
    
    public Canvas startGameCanvas;
    public Canvas endGameCanvas;

    public Camera Camera;
    public Camera HeroCamera;
    public Camera BossCamera;

    public GameObject Hero;
    public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        startGameCanvas.enabled = false;
        endGameCanvas.enabled = false;
        SetState(GameState.StartScreen);

        Camera.enabled = true;
        HeroCamera.enabled = false;
        BossCamera.enabled = false;
    }

    void SetState(GameState gameState)
    {
        if (gameState == GameState.StartScreen)
        {
            startGameCanvas.enabled = true;
            endGameCanvas.enabled = false;

            Camera.enabled = true;
            HeroCamera.enabled = false;
            BossCamera.enabled = false;

        }

        if (gameState == GameState.CutScene)
        {
            startGameCanvas.enabled = false;
            endGameCanvas.enabled = false;

            Camera.enabled = false;
            HeroCamera.enabled = true;
            BossCamera.enabled = false;
        }

        if (gameState == GameState.InGame)
        {
            startGameCanvas.enabled = false;
            endGameCanvas.enabled = false;

            Camera.enabled = false;
            HeroCamera.enabled = false;
            BossCamera.enabled = true;
        }

        if (gameState == GameState.EndGame)
        {
            Camera.enabled = true;
            HeroCamera.enabled = false;
            BossCamera.enabled = false;

            startGameCanvas.enabled = false;
            endGameCanvas.enabled = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetState(GameState.StartScreen);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetState(GameState.CutScene);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetState(GameState.InGame);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetState(GameState.EndGame);
        }
    }


}
