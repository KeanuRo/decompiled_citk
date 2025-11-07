// Decompiled with JetBrains decompiler
// Type: Frontend.MapWindow.MapWindowController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign.Utils;
using Backend.Managers;
using Frontend.Map;
using Frontend.UI;
using Frontend.UpPanel;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

#nullable disable
namespace Frontend.MapWindow;

public class MapWindowController : MonoBehaviour
{
  public List<WarEntity> wars;
  [SerializeField]
  private static int currentSpeed = 0;
  [SerializeField]
  private static int lastSpeed = 0;
  [SerializeField]
  private UpPanelController upPanelController;
  [SerializeField]
  private CountryInfoPanelController countryInfoPanelController;
  [SerializeField]
  private MapController mapController;
  private float timeToNextTick = 0.0f;
  [SerializeField]
  [Range(0.01f, 2f)]
  private float tickTime = 2f;
  [SerializeField]
  private ButtonsGroup speedButtons;

  public static void ResetGameSpeed()
  {
    MapWindowController.lastSpeed = MapWindowController.currentSpeed = 0;
  }

  public void SetPause(InputAction.CallbackContext context)
  {
    if (!((InputAction.CallbackContext) ref context).performed || !this.CanRunTimeInMapScene)
      return;
    if (MapWindowController.currentSpeed == 0)
      this.ChangeSpeedFromHotkeys(MapWindowController.lastSpeed);
    else
      this.ChangeSpeedFromHotkeys(0);
  }

  public void ChangeSpeed(int newSpeed)
  {
    if (newSpeed == 0)
      MapWindowController.lastSpeed = MapWindowController.currentSpeed;
    MapWindowController.currentSpeed = newSpeed;
  }

  public void ChangeSpeedFromHotkeys(int newSpeed) => this.speedButtons.Selected = newSpeed;

  public void SpeedUp(InputAction.CallbackContext context)
  {
    if (!((InputAction.CallbackContext) ref context).performed)
      return;
    this.ChangeSpeedFromHotkeys(Mathf.Clamp(MapWindowController.currentSpeed + 1, 0, 3));
  }

  public void SpeedDown(InputAction.CallbackContext context)
  {
    if (!((InputAction.CallbackContext) ref context).performed)
      return;
    this.ChangeSpeedFromHotkeys(Mathf.Clamp(MapWindowController.currentSpeed - 1, 0, 3));
  }

  private void Start()
  {
    this.Repaint(true);
    if (MapWindowController.currentSpeed == 0)
      return;
    this.ChangeSpeedFromHotkeys(MapWindowController.currentSpeed);
  }

  private bool CanRunTimeInMapScene
  {
    get
    {
      return GameStateManager.inst.GameState.currentEventsIds.Count == 0 && GlobalTimeManager.inst.CanRunTime();
    }
  }

  private void Update()
  {
    if (!this.CanRunTimeInMapScene)
      return;
    this.timeToNextTick += Time.deltaTime * (float) MapWindowController.currentSpeed;
    if ((double) this.timeToNextTick >= (double) this.tickTime)
    {
      this.timeToNextTick = 0.0f;
      this.TimeTick();
    }
  }

  private void TimeTick()
  {
    this.Repaint(TickUtils.ProcessTick(GameStateManager.inst.GameState, GameStateManager.inst.GameScenario, GameStateManager.inst.GameRules));
  }

  private void RepaintWars()
  {
    foreach (WarEntity war in this.wars)
      war.Repaint();
  }

  public void Repaint(bool needToRepaintEverything)
  {
    this.RepaintWars();
    this.upPanelController.Repaint();
    if (needToRepaintEverything)
    {
      this.mapController.Repaint();
      this.countryInfoPanelController.Repaint();
    }
    SteamStatusUtils.SetDynamicSteamStatus(GameStateManager.inst.GameState);
  }
}
