// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.ScenarioSettings.Utils.ScenarioSettingsManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign.ScenarioSettings.Scenarios;
using Backend.Interfaces;
using Backend.OtherUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Backend.Gamedesign.ScenarioSettings.Utils;

public class ScenarioSettingsManager : MonoBehaviour, IInitializable
{
  public static ScenarioSettingsManager inst;
  [SerializeField]
  private Dictionary<ScenarioType, AbstractScenario> scenarios = new Dictionary<ScenarioType, AbstractScenario>();

  IEnumerator IInitializable.Initialize()
  {
    ScenarioSettingsManager.inst = this;
    this.OrganizeScenarios();
    yield return (object) null;
  }

  public void OrganizeScenarios()
  {
    foreach (Type typesByAttribute in ReflectionUtils.GetTypesByAttributes(typeof (ScenarioAttribute)))
    {
      AbstractScenario instance = Activator.CreateInstance(typesByAttribute) as AbstractScenario;
      this.scenarios.Add(instance.scenarioType, instance);
    }
  }

  public AbstractScenario GetScenarioSettings(ScenarioType scenarioType)
  {
    return this.scenarios[scenarioType];
  }
}
