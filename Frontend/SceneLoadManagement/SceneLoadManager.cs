// Decompiled with JetBrains decompiler
// Type: Frontend.SceneLoadManagement.SceneLoadManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Interfaces;
using Backend.Managers;
using Frontend.InputManagement;
using Frontend.Tutorial;
using Frontend.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

#nullable disable
namespace Frontend.SceneLoadManagement;

public class SceneLoadManager : MonoBehaviour, IInitializable, ICallBackReceiver
{
  [SerializeField]
  private CitationController citationController;
  private readonly HashSet<int> timeNotAllowedScenes = new HashSet<int>()
  {
    0,
    1,
    3,
    4,
    5,
    7,
    8,
    9,
    10,
    11,
    12,
    13,
    14,
    15,
    16 /*0x10*/,
    17,
    18,
    19
  };
  public CanvasGroup canvasGroup;
  private SceneLoadManager.SceneLoadManagerState state = SceneLoadManager.SceneLoadManagerState.Nothing;
  private int previousScene = -1;
  public static SceneLoadManager inst;
  private float stepTime = 0.0f;
  private float timeToNextStep = 0.0f;
  private AsyncOperation loadingOperation = (AsyncOperation) null;
  private bool callBackArraived = false;
  private int newScene = 0;
  private bool displayAnimationThisTime = true;

  public int PreviousScene => this.previousScene;

  public int CurrentScene => this.newScene;

  public void LoadScene(
    int newScene,
    float transitionTime = 0.75f,
    bool shouldWaitCallBack = false,
    bool displayAnimation = true)
  {
    if (newScene == 1)
      this.citationController.Initialize();
    this.displayAnimationThisTime = displayAnimation;
    this.previousScene = SceneManager.GetActiveScene().buildIndex;
    this.newScene = newScene;
    this.stepTime = transitionTime / 3f;
    this.timeToNextStep = 0.0f;
    this.callBackArraived = !shouldWaitCallBack;
    this.state = SceneLoadManager.SceneLoadManagerState.Unloading;
    this.canvasGroup.alpha = 0.0f;
    this.gameObject.SetActive(true);
    InputManager.inst.AddProhibition(InputProhibitionType.SceneChanging);
    GlobalTimeManager.inst.AddProhibition(GlobalTimeManager.TimeFlowProhibition.SceneLoading);
  }

  IEnumerator IInitializable.Initialize()
  {
    Object.DontDestroyOnLoad((Object) this.gameObject);
    SceneLoadManager.inst = this;
    this.previousScene = -1;
    this.canvasGroup.alpha = 0.0f;
    SceneManager.activeSceneChanged += (UnityAction<Scene, Scene>) ((scene1, scene2) => this.ChangeActiveCamera());
    SceneManager.activeSceneChanged += (UnityAction<Scene, Scene>) ((scene1, scene2) => this.ResetTutorial());
    yield return (object) null;
  }

  private void ChangeActiveCamera()
  {
    this.GetComponent<Canvas>().worldCamera = Camera.main;
    this.GetComponent<Canvas>().renderMode = (RenderMode) 1;
  }

  private void ResetTutorial() => TutorialController.ClearContext();

  void ICallBackReceiver.CallBack(int arg)
  {
    if (arg != 1 || this.state == 0)
      return;
    this.callBackArraived = true;
  }

  private void Update()
  {
    if (this.state == SceneLoadManager.SceneLoadManagerState.Unloading)
    {
      if ((double) this.timeToNextStep <= (double) this.stepTime)
        this.timeToNextStep += Time.deltaTime;
      if ((double) this.timeToNextStep >= (double) this.stepTime || !this.displayAnimationThisTime)
      {
        if (this.displayAnimationThisTime)
          this.canvasGroup.alpha = 1f;
        this.state = SceneLoadManager.SceneLoadManagerState.WaitingForTheSceneToLoad;
        this.timeToNextStep = 0.0f;
        this.loadingOperation = SceneManager.LoadSceneAsync(this.newScene);
      }
      else if (this.displayAnimationThisTime)
        this.canvasGroup.alpha = Mathf.Clamp01(this.timeToNextStep / this.stepTime);
    }
    else if (this.state == SceneLoadManager.SceneLoadManagerState.WaitingForTheSceneToLoad)
    {
      if ((double) this.timeToNextStep <= (double) this.stepTime)
        this.timeToNextStep += Time.deltaTime;
      if ((double) this.timeToNextStep < (double) this.stepTime && this.displayAnimationThisTime || !this.loadingOperation.isDone || !this.callBackArraived)
        return;
      this.timeToNextStep = 0.0f;
      this.state = SceneLoadManager.SceneLoadManagerState.Loading;
    }
    else
    {
      if (this.state != SceneLoadManager.SceneLoadManagerState.Loading)
        return;
      if ((double) this.timeToNextStep <= (double) this.stepTime)
        this.timeToNextStep += Time.deltaTime;
      if ((double) this.timeToNextStep >= (double) this.stepTime || !this.displayAnimationThisTime)
      {
        this.state = SceneLoadManager.SceneLoadManagerState.Nothing;
        InputManager.inst.RemoveProhibition(InputProhibitionType.SceneChanging);
        GlobalTimeManager.inst.RemoveProhibition(GlobalTimeManager.TimeFlowProhibition.SceneLoading);
        if (this.timeNotAllowedScenes.Contains(this.newScene))
          GlobalTimeManager.inst.AddProhibition(GlobalTimeManager.TimeFlowProhibition.WrongScene);
        else
          GlobalTimeManager.inst.RemoveProhibition(GlobalTimeManager.TimeFlowProhibition.WrongScene);
        this.gameObject.SetActive(false);
      }
      else if (this.displayAnimationThisTime)
        this.canvasGroup.alpha = 1f - Mathf.Clamp01(this.timeToNextStep / this.stepTime);
    }
  }

  private enum SceneLoadManagerState
  {
    Nothing,
    Unloading,
    Loading,
    WaitingForTheSceneToLoad,
  }
}
