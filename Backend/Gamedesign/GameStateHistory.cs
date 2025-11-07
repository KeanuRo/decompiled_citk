// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.GameStateHistory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Backend.Gamedesign;

[Serializable]
public class GameStateHistory
{
  public Dictionary<string, Dictionary<DateTime, float>> valuesStatisticByDates = new Dictionary<string, Dictionary<DateTime, float>>();
  public Dictionary<string, float> lastValuesChange = new Dictionary<string, float>();
  public Dictionary<string, Dictionary<StatisticImpactSourceType, float>> lastValuesChangesSources = new Dictionary<string, Dictionary<StatisticImpactSourceType, float>>();
  public Dictionary<IncomeSource, int> lastIncome = new Dictionary<IncomeSource, int>();
  public Dictionary<Countries, Dictionary<StatisticImpactSourceType, float>> lastRelationsValuesChangesSources = new Dictionary<Countries, Dictionary<StatisticImpactSourceType, float>>();
  public Dictionary<Countries, Dictionary<StatisticImpactSourceType, float>> lastDiplomacyVectorValuesChangesSources = new Dictionary<Countries, Dictionary<StatisticImpactSourceType, float>>();
  public Dictionary<Countries, Dictionary<StatisticImpactSourceType, float>> lastLiberalizationVectorValuesChangesSources = new Dictionary<Countries, Dictionary<StatisticImpactSourceType, float>>();
}
