// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.EventSystem.DataStructures.EventInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using System;

#nullable disable
namespace Backend.Gamedesign.EventSystem.DataStructures;

[Serializable]
public class EventInfo
{
  public bool isCrisis = false;
  public byte priority;
  public DateTime startDate;
  public DateTime endDate;
  public Countries? countryLimitation = new Countries?();
  public EventType eventType;

  public override string ToString()
  {
    return $"Event; Priority: {this.priority}, IsCrisis:{this.isCrisis}, Country limitation: {this.countryLimitation}, Start: {this.startDate}, End: {this.endDate}, Type: {this.eventType}";
  }
}
