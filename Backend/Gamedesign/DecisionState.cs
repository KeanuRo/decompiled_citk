// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.DecisionState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using System;

#nullable disable
namespace Backend.Gamedesign;

[Serializable]
public class DecisionState
{
  public int level = 0;
  public DateTime? cooldown = new DateTime?();
}
