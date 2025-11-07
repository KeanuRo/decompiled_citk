// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.EventSystem.EventAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using System;

#nullable disable
namespace Backend.Gamedesign.EventSystem;

[AttributeUsage(AttributeTargets.Class)]
public class EventAttribute : Attribute
{
  public int Id;

  public EventAttribute(int Id) => this.Id = Id;
}
