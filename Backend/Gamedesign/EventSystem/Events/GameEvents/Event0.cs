// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.EventSystem.Events.GameEvents.Event0
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign.EventSystem.DataStructures;
using Backend.Gamedesign.Utils;
using Backend.Gamedesign.Utils.UnitsOfWork;
using Backend.Managers;
using System;
using UnityEngine;

#nullable disable
namespace Backend.Gamedesign.EventSystem.Events.GameEvents;

[Event(0)]
public class Event0 : AbstractEvent
{
  private readonly EventInfo eventInfo = new EventInfo()
  {
    priority = 10,
    startDate = new DateTime(1985, 3, 11),
    endDate = new DateTime(1985, 4, 1),
    countryLimitation = new Countries?(Countries.USSR),
    eventType = EventType.Message
  };

  public override EventInfo EventInfo => this.eventInfo;

  public override bool CheckConditions(GameState gameState)
  {
    int num;
    if (!this.IfThisEventWasEverDone(gameState))
    {
      PoliticPosition? politicPosition1 = gameState.politicPositions[Characters.Chernenko];
      PoliticPosition politicPosition2 = PoliticPosition.President;
      num = !(politicPosition1.GetValueOrDefault() == politicPosition2 & politicPosition1.HasValue) ? 1 : 0;
    }
    else
      num = 0;
    return num != 0;
  }

  public override UnitOfWork[] StartEvent(GameState gameState, EventDrawInfo eventDrawInfo)
  {
    eventDrawInfo.eventTitle = LanguageManager.inst["events", "events0Title"];
    PoliticPosition? politicPosition1 = gameState.politicPositions[Characters.Gorbachev];
    PoliticPosition politicPosition2 = PoliticPosition.President;
    if (politicPosition1.GetValueOrDefault() == politicPosition2 & politicPosition1.HasValue)
    {
      eventDrawInfo.eventDesc = LanguageManager.inst["events", "events0Desc0"];
    }
    else
    {
      PoliticPosition? politicPosition3 = gameState.politicPositions[Characters.Romanov];
      PoliticPosition politicPosition4 = PoliticPosition.President;
      if (politicPosition3.GetValueOrDefault() == politicPosition4 & politicPosition3.HasValue)
      {
        eventDrawInfo.eventDesc = LanguageManager.inst["events", "events0Desc1"];
      }
      else
      {
        politicPosition3 = gameState.politicPositions[Characters.Grishin];
        PoliticPosition politicPosition5 = PoliticPosition.President;
        if (politicPosition3.GetValueOrDefault() == politicPosition5 & politicPosition3.HasValue)
        {
          eventDrawInfo.eventDesc = LanguageManager.inst["events", "events0Desc2"];
        }
        else
        {
          politicPosition3 = gameState.politicPositions[Characters.Shcherbytsky];
          PoliticPosition politicPosition6 = PoliticPosition.President;
          if (politicPosition3.GetValueOrDefault() == politicPosition6 & politicPosition3.HasValue)
          {
            eventDrawInfo.eventDesc = LanguageManager.inst["events", "events0Desc3"];
          }
          else
          {
            politicPosition3 = gameState.politicPositions[Characters.Gromyko];
            PoliticPosition politicPosition7 = PoliticPosition.President;
            if (politicPosition3.GetValueOrDefault() == politicPosition7 & politicPosition3.HasValue)
            {
              eventDrawInfo.eventDesc = LanguageManager.inst["events", "events0Desc4"];
            }
            else
            {
              politicPosition3 = gameState.politicPositions[Characters.CustomCharacter];
              PoliticPosition politicPosition8 = PoliticPosition.President;
              if (politicPosition3.GetValueOrDefault() == politicPosition8 & politicPosition3.HasValue)
              {
                string politicFullName = PoliticUtils.GetPoliticFullName(gameState, gameState.politicPositions[PoliticPosition.President].Value);
                eventDrawInfo.eventDesc = string.Format(LanguageManager.inst["events", "events0Desc5"], (object) politicFullName);
              }
            }
          }
        }
      }
    }
    this.MarkEventAsDone(gameState, 0);
    eventDrawInfo.image = 0;
    return new UnitOfWork[eventDrawInfo.optionsCount];
  }

  public override string FinishEvent(GameState gameState, int choice)
  {
    this.MarkEventAsDone(gameState, choice);
    Debug.Log((object) "finish");
    return "Кончили событие 0! Охуенный результат!";
  }
}
