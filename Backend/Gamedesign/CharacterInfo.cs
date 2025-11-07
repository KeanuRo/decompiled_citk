// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.CharacterInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Backend.Gamedesign;

[Serializable]
public class CharacterInfo
{
  [JsonProperty]
  public CustomCharacterInfo customCharacterInfo = (CustomCharacterInfo) null;
  [JsonProperty]
  private float power = 0.0f;
  [JsonProperty]
  private float stress = 0.0f;
  public DateTime surveillanceUntil = DateTime.MinValue;
  public int monthsOfIllness = 0;
  public bool underSurveillance = false;
  public bool underSuppress = false;
  public bool underSupport = false;
  public Countries homeLand;
  public PoliticPosition? desiredPosition = new PoliticPosition?();
  public DateTime birthDay = DateTime.MinValue;
  public CharacterInfo.PoliticStatus status = CharacterInfo.PoliticStatus.NotPresented;
  public Dictionary<CharacterInfo.PoliticCharacteristic, int> charLevel = new Dictionary<CharacterInfo.PoliticCharacteristic, int>()
  {
    [CharacterInfo.PoliticCharacteristic.Diplomacy] = 0,
    [CharacterInfo.PoliticCharacteristic.Intrigue] = 0,
    [CharacterInfo.PoliticCharacteristic.Thrift] = 0
  };
  public Dictionary<CharacterInfo.PoliticCharacteristic, float> charExp = new Dictionary<CharacterInfo.PoliticCharacteristic, float>()
  {
    [CharacterInfo.PoliticCharacteristic.Diplomacy] = 0.0f,
    [CharacterInfo.PoliticCharacteristic.Intrigue] = 0.0f,
    [CharacterInfo.PoliticCharacteristic.Thrift] = 0.0f
  };
  public HashSet<Traits> traits = new HashSet<Traits>();
  public HashSet<Characters> knownTraitors = new HashSet<Characters>();
  [JsonProperty]
  private float relationsToPlayer = 0.0f;
  [JsonProperty]
  public bool Randomized = false;

  [JsonIgnore]
  public float Power
  {
    get => this.power;
    set => this.power = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float Stress
  {
    get => this.stress;
    set => this.stress = Mathf.Clamp(value, 0.0f, 100f);
  }

  public int Age(DateTime now)
  {
    int num = now.Year - this.birthDay.Year;
    if (this.birthDay.Date > now.AddYears(-num))
      --num;
    return num;
  }

  public float AgePlus(DateTime now)
  {
    return (float) (now.Year - this.birthDay.Year) - (float) ((double) Mathf.Abs(this.birthDay.Date.Month - now.Month) / 1.2000000476837158 / 10.0);
  }

  [JsonIgnore]
  public float RelationsToPlayer
  {
    get => this.relationsToPlayer;
    set => this.relationsToPlayer = Mathf.Clamp(value, 0.0f, 100f);
  }

  public enum PoliticStatus
  {
    NotPresented,
    Alive,
    Dead,
    Immigrant,
  }

  public enum PoliticCharacteristic
  {
    Diplomacy,
    Intrigue,
    Thrift,
  }
}
