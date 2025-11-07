// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.GameScenario
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable
namespace Backend.Gamedesign;

[Serializable]
public class GameScenario
{
  [JsonProperty]
  public int baseIncomeValue = 3000;
  public Dictionary<Wars, WarInfo> warsStartInfo = new Dictionary<Wars, WarInfo>();
  public GameScenario.PortraitsInfo portraitsInfo;
  public Dictionary<Characters, List<PoliticTraitChangeDescription>> politicTraitsChangeDescription = new Dictionary<Characters, List<PoliticTraitChangeDescription>>();
  public DateTime startDate = DateTime.MinValue;

  public class PortraitsInfo
  {
    public string atlasName = "";
    public int firstIndex = 0;
    public int count = 0;
  }
}
