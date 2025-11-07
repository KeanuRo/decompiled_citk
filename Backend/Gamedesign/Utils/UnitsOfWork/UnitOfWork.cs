// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.Utils.UnitsOfWork.UnitOfWork
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Backend.Gamedesign.Utils.UnitsOfWork;

public class UnitOfWork
{
  private readonly Backend.Gamedesign.Utils.TextFormatter.TextFormatter textFormatter = Backend.Gamedesign.Utils.TextFormatter.TextFormatter.StartCreation();
  private readonly List<Action<GameState, GameRules, GameScenario>> actions = new List<Action<GameState, GameRules, GameScenario>>();

  public static UnitOfWork StartCreation() => new UnitOfWork();

  public void Execute(GameState gameState, GameRules gameRules, GameScenario gameScenario)
  {
    foreach (Action<GameState, GameRules, GameScenario> action in this.actions)
      action(gameState, gameRules, gameScenario);
  }

  public UnitOfWork AddAction(
    Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter> stringRepresentationSettings,
    Action<GameState, GameRules, GameScenario> gameStateAction)
  {
    stringRepresentationSettings(this.textFormatter);
    this.actions.Add(gameStateAction);
    return this;
  }

  public string FinalizeInColor() => this.textFormatter.FinalizeInColor();

  public string Finalize() => this.textFormatter.Finalize();
}
