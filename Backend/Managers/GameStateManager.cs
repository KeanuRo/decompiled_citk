// Decompiled with JetBrains decompiler
// Type: Backend.Managers.GameStateManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign;
using Backend.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Backend.Managers;

public class GameStateManager : MonoBehaviour, IInitializable
{
  private GameState gameState;
  private GameRules gameRules;
  private GameScenario gameScenario;
  public static GameStateManager inst;
  private readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings()
  {
    TypeNameHandling = (TypeNameHandling) 4,
    Converters = (IList<JsonConverter>) new List<JsonConverter>()
    {
      (JsonConverter) new StringEnumConverter()
    }
  };

  public GameState GameState => this.gameState;

  public GameRules GameRules => this.gameRules;

  public GameScenario GameScenario => this.gameScenario;

  private void LoadGameRules()
  {
    TextAsset assetToUnload = Resources.Load("GameRules\\default") as TextAsset;
    this.gameRules = JsonConvert.DeserializeObject<GameRules>(assetToUnload.text, this.jsonSettings);
    Resources.UnloadAsset((Object) assetToUnload);
  }

  private void LoadGameScenario(ScenarioType type)
  {
    TextAsset assetToUnload = Resources.Load("GameScenario\\" + type.ToString()) as TextAsset;
    this.gameScenario = JsonConvert.DeserializeObject<GameScenario>(assetToUnload.text, this.jsonSettings);
    Resources.UnloadAsset((Object) assetToUnload);
    PortraitsManager.inst.LoadPortraits(this.gameScenario.portraitsInfo);
  }

  public void LoadStartGameState(ScenarioType type)
  {
    TextAsset assetToUnload = Resources.Load("GameState\\" + type.ToString()) as TextAsset;
    this.gameState = JsonConvert.DeserializeObject<GameState>(assetToUnload.text, this.jsonSettings);
    Resources.UnloadAsset((Object) assetToUnload);
    this.LoadGameScenario(type);
  }

  public void SetGameState(GameState gameState)
  {
    this.gameState = gameState;
    this.LoadGameScenario(gameState.scenarioType);
  }

  IEnumerator IInitializable.Initialize()
  {
    GameStateManager.inst = this;
    Object.DontDestroyOnLoad((Object) this.gameObject);
    this.LoadGameRules();
    yield return (object) null;
  }
}
