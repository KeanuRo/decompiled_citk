// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.TechnologiesSystem.TechnologyAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using System;

#nullable disable
namespace Backend.Gamedesign.TechnologiesSystem;

[AttributeUsage(AttributeTargets.Class)]
public class TechnologyAttribute : Attribute
{
  public ScienceTree scienceTree;

  public TechnologyAttribute(ScienceTree scienceTree) => this.scienceTree = scienceTree;
}
