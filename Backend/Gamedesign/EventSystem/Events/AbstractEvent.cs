// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.EventSystem.Events.AbstractEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign.EventSystem.DataStructures;
using Backend.Gamedesign.Utils.UnitsOfWork;
using System;
using System.Reflection;

#nullable disable
namespace Backend.Gamedesign.EventSystem.Events;

public abstract class AbstractEvent
{
  public virtual bool CanBeAddedOnlyManually => false;

  public int Id
  {
    get
    {
      return ((EventAttribute) Attribute.GetCustomAttribute((MemberInfo) this.GetType(), typeof (EventAttribute))).Id;
    }
  }

  public abstract Backend.Gamedesign.EventSystem.DataStructures.EventInfo EventInfo { get; }

  public abstract bool CheckConditions(GameState gameState);

  public abstract UnitOfWork[] StartEvent(GameState gameState, EventDrawInfo eventDrawInfo);

  public abstract string FinishEvent(GameState gameState, int choice);

  protected bool IfThisEventWasEverDone(GameState gameState)
  {
    return gameState.eventsDone.ContainsKey(this.Id);
  }

  protected void MarkEventAsDone(GameState gameState, int choice)
  {
    gameState.eventsDone.Add(this.Id, new EventCompletionState(choice, DateTime.MaxValue));
  }

  protected void MarkEventAsDone(GameState gameState, int choice, DateTime expirationDate)
  {
    gameState.eventsDone.Add(this.Id, new EventCompletionState(choice, expirationDate));
  }
}
