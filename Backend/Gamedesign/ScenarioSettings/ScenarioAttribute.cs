// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.ScenarioSettings.ScenarioAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using System;

#nullable disable
namespace Backend.Gamedesign.ScenarioSettings;

[AttributeUsage(AttributeTargets.Class)]
public class ScenarioAttribute : Attribute
{
  public ScenarioType scenarioType;

  public ScenarioAttribute(ScenarioType scenarioType) => this.scenarioType = scenarioType;
}
