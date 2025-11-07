// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.ScenarioSettings.Scenarios.AbstractScenario
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using System;
using System.Reflection;

#nullable disable
namespace Backend.Gamedesign.ScenarioSettings.Scenarios;

public abstract class AbstractScenario
{
  public ScenarioType scenarioType
  {
    get
    {
      return ((ScenarioAttribute) Attribute.GetCustomAttribute((MemberInfo) this.GetType(), typeof (ScenarioAttribute))).scenarioType;
    }
  }

  public abstract void SetUpScenario(
    GameState gameState,
    GameScenario gameScenario,
    GameRules gameRules);
}
