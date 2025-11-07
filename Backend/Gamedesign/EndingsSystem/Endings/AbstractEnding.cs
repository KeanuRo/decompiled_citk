// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.EndingsSystem.Endings.AbstractEnding
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Frontend.Ending;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace Backend.Gamedesign.EndingsSystem.Endings;

public abstract class AbstractEnding
{
  public int EndingNumber
  {
    get
    {
      return ((EndingAttribute) Attribute.GetCustomAttribute((MemberInfo) this.GetType(), typeof (EndingAttribute))).endingNumber;
    }
  }

  public abstract bool TestConditions(GameState gameState);

  public abstract List<EndingDrawInfo> GetEndingDrawInfos(GameState gameState);
}
