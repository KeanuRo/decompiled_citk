// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.DoctrinesSystem.DoctrineAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using System;

#nullable disable
namespace Backend.Gamedesign.DoctrinesSystem;

[AttributeUsage(AttributeTargets.Class)]
public class DoctrineAttribute : Attribute
{
  public DoctrineType doctrineType;

  public DoctrineAttribute(DoctrineType doctrineType) => this.doctrineType = doctrineType;
}
