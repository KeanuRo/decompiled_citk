// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.EndingsSystem.EndingAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using System;

#nullable disable
namespace Backend.Gamedesign.EndingsSystem;

[AttributeUsage(AttributeTargets.Class)]
public class EndingAttribute : Attribute
{
  public int endingNumber;

  public EndingAttribute(int endingNumber) => this.endingNumber = endingNumber;
}
