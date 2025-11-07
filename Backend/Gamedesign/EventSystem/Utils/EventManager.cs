// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.EventSystem.Utils.EventManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign.EventSystem.DataStructures;
using Backend.Gamedesign.EventSystem.Events;
using Backend.Gamedesign.Utils.UnitsOfWork;
using Backend.Interfaces;
using Backend.OtherUtils;
using Frontend.SceneLoadManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Backend.Gamedesign.EventSystem.Utils;

public class EventManager : MonoBehaviour, IInitializable
{
  public static EventManager inst;
  private Dictionary<int, AbstractEvent> events = new Dictionary<int, AbstractEvent>();
  private Dictionary<int, AbstractEvent> crisisEvents = new Dictionary<int, AbstractEvent>();

  IEnumerator IInitializable.Initialize()
  {
    EventManager.inst = this;
    this.OrganizeEvents();
    yield return (object) null;
  }

  public void ProccessEventImmediately(
    GameState gameState,
    int Id,
    bool openEventsWindowImmediately,
    bool shouldNotCheckConditionsAfterItsAdded = true)
  {
    gameState.currentEventsIds.Push((Id, shouldNotCheckConditionsAfterItsAdded));
    if (!openEventsWindowImmediately)
      return;
    this.OpenEventWindow();
  }

  public void OpenEventWindow() => SceneLoadManager.inst.LoadScene(11, displayAnimation: false);

  private void OrganizeEvents()
  {
    foreach (Type typesByAttribute in ReflectionUtils.GetTypesByAttributes(typeof (EventAttribute)))
    {
      AbstractEvent instance = Activator.CreateInstance(typesByAttribute) as AbstractEvent;
      if (instance.EventInfo.isCrisis)
        this.crisisEvents.Add(instance.Id, instance);
      else
        this.events.Add(instance.Id, instance);
    }
  }

  public int? GetNewCrisisEvent(GameState gameState)
  {
    int? newCrisisEvent = new int?();
    foreach (KeyValuePair<int, AbstractEvent> crisisEvent in this.crisisEvents)
    {
      AbstractEvent abstractEvent = crisisEvent.Value;
      EventInfo eventInfo = abstractEvent.EventInfo;
      if (eventInfo.countryLimitation.HasValue)
      {
        Countries? countryLimitation = eventInfo.countryLimitation;
        Countries playerCountry = gameState.playerCountry;
        if (!(countryLimitation.GetValueOrDefault() == playerCountry & countryLimitation.HasValue))
          goto label_6;
      }
      int num;
      if (!abstractEvent.CanBeAddedOnlyManually)
      {
        num = abstractEvent.CheckConditions(gameState) ? 1 : 0;
        goto label_7;
      }
label_6:
      num = 0;
label_7:
      if (num != 0)
      {
        newCrisisEvent = new int?(crisisEvent.Key);
        break;
      }
    }
    return newCrisisEvent;
  }

  public int? GetNewEvent(GameState gameState)
  {
    byte num1 = 0;
    int? newEvent = new int?();
    foreach (KeyValuePair<int, AbstractEvent> keyValuePair in this.events)
    {
      if (num1 != byte.MaxValue)
      {
        AbstractEvent abstractEvent = keyValuePair.Value;
        EventInfo eventInfo = abstractEvent.EventInfo;
        int num2;
        if ((int) eventInfo.priority >= (int) num1 && eventInfo.startDate <= gameState.date && eventInfo.endDate >= gameState.date)
        {
          if (eventInfo.countryLimitation.HasValue)
          {
            Countries? countryLimitation = eventInfo.countryLimitation;
            Countries playerCountry = gameState.playerCountry;
            if (!(countryLimitation.GetValueOrDefault() == playerCountry & countryLimitation.HasValue))
              goto label_8;
          }
          if (!abstractEvent.CanBeAddedOnlyManually)
          {
            num2 = abstractEvent.CheckConditions(gameState) ? 1 : 0;
            goto label_9;
          }
        }
label_8:
        num2 = 0;
label_9:
        if (num2 != 0)
        {
          num1 = eventInfo.priority;
          newEvent = new int?(keyValuePair.Key);
        }
      }
      else
        break;
    }
    return newEvent;
  }

  public (EventType, UnitOfWork[]) StartEvent(
    int Id,
    GameState gameState,
    EventDrawInfo eventDrawInfo)
  {
    AbstractEvent abstractEvent = this.crisisEvents.ContainsKey(Id) ? this.crisisEvents[Id] : this.events[Id];
    UnitOfWork[] unitOfWorkArray = abstractEvent.StartEvent(gameState, eventDrawInfo);
    return (abstractEvent.EventInfo.eventType, unitOfWorkArray);
  }

  public string FinishEvent(int Id, GameState gameState, int choice)
  {
    return (this.crisisEvents.ContainsKey(Id) ? this.crisisEvents[Id] : this.events[Id]).FinishEvent(gameState, choice);
  }

  public bool CheckEventConditions(int Id, GameState gameState)
  {
    return (this.crisisEvents.ContainsKey(Id) ? this.crisisEvents[Id] : this.events[Id]).CheckConditions(gameState);
  }
}
