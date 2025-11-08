// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.EventCompletionState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1AEE2D60-F9AC-4BB1-9F59-FC7C8812BBA8
// Assembly location: C:\Users\Киану\RiderProjects\SampleCitK2Mod\lib\Assembly-CSharp.dll

using Newtonsoft.Json;
using System;

#nullable disable
namespace Backend.Gamedesign;

[Serializable]
public class EventCompletionState
{
  [JsonProperty]
  public int choice;
  [JsonProperty]
  public DateTime expirationDate;

  public EventCompletionState(int choice, DateTime expirationDate)
  {
    this.choice = choice;
    this.expirationDate = expirationDate;
  }
}
