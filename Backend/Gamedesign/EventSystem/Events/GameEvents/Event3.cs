// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.EventSystem.Events.GameEvents.Event3
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign.EventSystem.DataStructures;
using Backend.Gamedesign.EventSystem.Utils;
using Backend.Gamedesign.Utils;
using Backend.Gamedesign.Utils.ConditionsFormatter;
using Backend.Gamedesign.Utils.UnitsOfWork;
using Backend.Managers;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Backend.Gamedesign.EventSystem.Events.GameEvents;

[Event(3)]
public class Event3 : AbstractEvent
{
  private readonly EventInfo eventInfo = new EventInfo()
  {
    priority = 10,
    startDate = new DateTime(1985, 4, 10),
    endDate = new DateTime(1985, 4, 20),
    countryLimitation = new Countries?(Countries.USSR),
    eventType = EventType.Default
  };

  public override EventInfo EventInfo => this.eventInfo;

  public override bool CheckConditions(GameState gameState)
  {
    return !this.IfThisEventWasEverDone(gameState) && gameState.partyStates.Any<KeyValuePair<Factions, MultiPartyClass>>((Func<KeyValuePair<Factions, MultiPartyClass>, bool>) (t => t.Value.nameType == 3));
  }

  public override UnitOfWork[] StartEvent(GameState gameState, EventDrawInfo eventDrawInfo)
  {
    eventDrawInfo.eventTitle = LanguageManager.inst["events", "events3Title"];
    PoliticPosition? politicPosition1 = gameState.politicPositions[Characters.CustomCharacter];
    PoliticPosition politicPosition2 = PoliticPosition.President;
    if (politicPosition1.GetValueOrDefault() == politicPosition2 & politicPosition1.HasValue)
    {
      string politicFullName = PoliticUtils.GetPoliticFullName(gameState, gameState.politicPositions[PoliticPosition.President].Value);
      eventDrawInfo.eventDesc = string.Format(LanguageManager.inst["events", "events0Desc1"], (object) politicFullName);
    }
    else
    {
      EventDrawInfo eventDrawInfo1 = eventDrawInfo;
      LanguageManager inst = LanguageManager.inst;
      PoliticPosition? politicPosition3 = gameState.politicPositions[Characters.Chernenko];
      PoliticPosition politicPosition4 = PoliticPosition.President;
      string str1 = $"events3Desc{(politicPosition3.GetValueOrDefault() == politicPosition4 & politicPosition3.HasValue ? 0 : 2)}";
      string str2 = inst["events", str1];
      eventDrawInfo1.eventDesc = str2;
    }
    eventDrawInfo.image = 3;
    eventDrawInfo.optionsCount = 6;
    eventDrawInfo.optionsEnabled = new bool[eventDrawInfo.optionsCount];
    eventDrawInfo.optionsNames = new string[eventDrawInfo.optionsCount];
    eventDrawInfo.optionsNamesAlt = new string[eventDrawInfo.optionsCount];
    eventDrawInfo.optionsConditions = new string[eventDrawInfo.optionsCount];
    Backend.Gamedesign.Utils.ConditionsFormatter.ConditionsFormatter conditionsFormatter = Backend.Gamedesign.Utils.ConditionsFormatter.ConditionsFormatter.StartCreation(Backend.Gamedesign.Utils.ConditionsFormatter.ConditionsFormatter.MainConditionOperator.AND);
    conditionsFormatter.AddPoliticalPowerCondition(gameState, 50, Backend.Gamedesign.Utils.ConditionsFormatter.ConditionsFormatter.СomparisonOperator.GreaterOE);
    UnitOfWork[] unitOfWorkArray = new UnitOfWork[eventDrawInfo.optionsCount];
    for (int index = 0; index < eventDrawInfo.optionsCount; ++index)
    {
      unitOfWorkArray[index] = UnitOfWork.StartCreation();
      switch (index)
      {
        case 0:
          unitOfWorkArray[index].AddFactionLoyalNum(gameState, Factions.Conservative, 3f).AddTwoFactionLoyalNum(gameState, 5f, Factions.SocialPatriot, Factions.NeoStalinist).AddFactionLoyalNum(gameState, Factions.Reformist, -8f);
          if (gameState.characters[Characters.Zimyanin].status == CharacterInfo.PoliticStatus.Alive)
            unitOfWorkArray[index].AddPoliticPower(10, Characters.Zimyanin).AddPoliticLoyalty(10, Characters.Zimyanin);
          if (gameState.characters[Characters.Kosolapov].status == CharacterInfo.PoliticStatus.Alive)
            unitOfWorkArray[index].AddPoliticPower(10, Characters.Kosolapov).AddPoliticLoyalty(10, Characters.Kosolapov);
          if (gameState.characters[Characters.Sokolov].status == CharacterInfo.PoliticStatus.Alive)
            unitOfWorkArray[index].AddPoliticPower(10, Characters.Sokolov).AddPoliticLoyalty(10, Characters.Sokolov);
          unitOfWorkArray[index].AddTwoFactionLoyalNum(gameState, -6f, Factions.LiberalDemocracy, Factions.NationalLiberal).AddFactionLoyalNum(gameState, Factions.Moderate, -5f).AddPoliticalPower(-50f).AddPowerOfPoliticByTwoFaction(gameState, -3, Factions.Moderate, Factions.Reformist).AddTwoFactionPowerNum(gameState, 15, Factions.NeoStalinist, Factions.SocialPatriot);
          break;
        case 1:
          unitOfWorkArray[index].AddFactionLoyalNum(gameState, Factions.Conservative, 10f).AddTwoFactionLoyalNum(gameState, 5f, Factions.SocialPatriot, Factions.NeoStalinist).AddFactionLoyalNum(gameState, Factions.Reformist, 8f);
          if (gameState.characters[Characters.Ponomarev].status == CharacterInfo.PoliticStatus.Alive)
            unitOfWorkArray[index].AddPoliticPower(5, Characters.Ponomarev).AddPoliticLoyalty(2, Characters.Ponomarev);
          if (gameState.characters[Characters.Demichev].status == CharacterInfo.PoliticStatus.Alive)
            unitOfWorkArray[index].AddPoliticPower(5, Characters.Demichev).AddPoliticLoyalty(2, Characters.Demichev);
          if (gameState.characters[Characters.Kuznetsov].status == CharacterInfo.PoliticStatus.Alive)
            unitOfWorkArray[index].AddPoliticPower(5, Characters.Kuznetsov).AddPoliticLoyalty(2, Characters.Kuznetsov);
          unitOfWorkArray[index].AddThreeFactionLoyalNum(gameState, -5f, Factions.Moderate, Factions.LiberalDemocracy, Factions.NationalLiberal).AddFactionLoyalNum(gameState, Factions.Reformist, -10f).AddPoliticalPower(-50f).AddFactionPowerNum(gameState, Factions.Conservative, 30).AddPowerOfPoliticByFaction(gameState, Factions.Conservative, 5).AddPowerOfPoliticByFaction(gameState, Factions.Moderate, -3).AddPowerOfPoliticByFaction(gameState, Factions.Reformist, -5);
          break;
        case 2:
          unitOfWorkArray[index].AddThreeFactionLoyalNum(gameState, 5f, Factions.Conservative, Factions.Moderate, Factions.Reformist);
          if (gameState.characters[Characters.Smyrtioukov].status == CharacterInfo.PoliticStatus.Alive)
            unitOfWorkArray[index].AddPoliticPower(5, Characters.Smyrtioukov).AddPoliticLoyalty(2, Characters.Smyrtioukov);
          if (gameState.characters[Characters.Dumachev].status == CharacterInfo.PoliticStatus.Alive)
            unitOfWorkArray[index].AddPoliticPower(5, Characters.Dumachev).AddPoliticLoyalty(2, Characters.Dumachev);
          if (gameState.characters[Characters.Mesiats].status == CharacterInfo.PoliticStatus.Alive)
            unitOfWorkArray[index].AddPoliticPower(5, Characters.Mesiats).AddPoliticLoyalty(2, Characters.Mesiats);
          unitOfWorkArray[index].AddFourFactionLoyalNum(gameState, -5f, Factions.SocialPatriot, Factions.NeoStalinist, Factions.LiberalDemocracy, Factions.NationalLiberal).AddPoliticalPower(-50f).AddFactionPowerNum(gameState, Factions.Moderate, 10).AddPowerOfPoliticByFaction(gameState, Factions.Moderate, 5).AddPowerOfPoliticByTwoFaction(gameState, -5, Factions.Conservative, Factions.Reformist);
          break;
        case 3:
          unitOfWorkArray[index].AddFactionLoyalNum(gameState, Factions.Moderate, 5f);
          if (gameState.characters[Characters.Ligachyov].status == CharacterInfo.PoliticStatus.Alive)
            unitOfWorkArray[index].AddPoliticPower(5, Characters.Ligachyov).AddPoliticLoyalty(2, Characters.Ligachyov);
          if (gameState.characters[Characters.Ryzhkov].status == CharacterInfo.PoliticStatus.Alive)
            unitOfWorkArray[index].AddPoliticPower(5, Characters.Ryzhkov).AddPoliticLoyalty(2, Characters.Ryzhkov);
          if (gameState.characters[Characters.Chebrikov].status == CharacterInfo.PoliticStatus.Alive)
            unitOfWorkArray[index].AddPoliticPower(5, Characters.Chebrikov).AddPoliticLoyalty(2, Characters.Chebrikov);
          unitOfWorkArray[index].AddFactionLoyalNum(gameState, Factions.Reformist, 10f).AddFiveFactionLoyalNum(gameState, -5f, Factions.SocialPatriot, Factions.NeoStalinist, Factions.Conservative, Factions.LiberalDemocracy, Factions.NationalLiberal).AddPoliticalPower(-50f).AddPowerOfPoliticByTwoFaction(gameState, 5, Factions.Moderate, Factions.Reformist).AddPowerOfPoliticByFaction(gameState, Factions.Conservative, -5).AddTwoFactionPowerNum(gameState, 10, Factions.Moderate, Factions.Reformist);
          break;
        case 4:
          if (gameState.characters[Characters.Shevardnadze].status == CharacterInfo.PoliticStatus.Alive)
            unitOfWorkArray[index].AddPoliticPower(5, Characters.Shevardnadze).AddPoliticLoyalty(5, Characters.Shevardnadze);
          if (gameState.characters[Characters.Dolgikh].status == CharacterInfo.PoliticStatus.Alive)
            unitOfWorkArray[index].AddPoliticPower(5, Characters.Dolgikh).AddPoliticLoyalty(5, Characters.Dolgikh);
          if (gameState.characters[Characters.Zaykov].status == CharacterInfo.PoliticStatus.Alive)
            unitOfWorkArray[index].AddPoliticPower(5, Characters.Zaykov).AddPoliticLoyalty(5, Characters.Zaykov);
          unitOfWorkArray[index].AddTwoFactionLoyalNum(gameState, 5f, Factions.Reformist, Factions.LiberalDemocracy).AddFourFactionLoyalNum(gameState, -5f, Factions.SocialPatriot, Factions.NeoStalinist, Factions.Moderate, Factions.NationalLiberal).AddTwoFactionLoyalNum(gameState, 15f, Factions.Reformist, Factions.LiberalDemocracy).AddFactionLoyalNum(gameState, Factions.Conservative, -7f).AddPoliticalPower(-50f).AddPowerOfPoliticByTwoFaction(gameState, 5, Factions.Reformist, Factions.LiberalDemocracy).AddPowerOfPoliticByTwoFaction(gameState, -5, Factions.Conservative, Factions.Moderate);
          break;
        case 5:
          unitOfWorkArray[index].AddPoliticPower(10, gameState.politicPositions[PoliticPosition.ChairmanOfTheKGB].Value).AddPoliticPower(10, gameState.politicPositions[PoliticPosition.MinisterOfDefense].Value).AddPowerOfPoliticByFaction(gameState, Factions.Conservative, 15).AddPowerOfPoliticByFaction(gameState, Factions.Moderate, 15);
          break;
      }
    }
    for (int index = 0; index < eventDrawInfo.optionsCount; ++index)
    {
      if (index != 5 && conditionsFormatter.Finalize().Item1)
        eventDrawInfo.optionsEnabled[index] = true;
      if (index != 5)
        eventDrawInfo.optionsConditions[index] = conditionsFormatter.Finalize().Item2;
      ref string local = ref eventDrawInfo.optionsNamesAlt[index];
      local = $"{local}<color=blue>{LanguageManager.inst["events", "AnswerResult"]}</color>\n{unitOfWorkArray[index].FinalizeInColor()}";
      eventDrawInfo.optionsNames[index] = LanguageManager.inst["events", $"events3Answer{index}"];
    }
    eventDrawInfo.optionsEnabled[5] = true;
    return unitOfWorkArray;
  }

  public override string FinishEvent(GameState gameState, int choice)
  {
    string str1 = "";
    string str2 = "";
    string str3 = "";
    Characters? politicPosition1;
    switch (choice)
    {
      case 0:
        if (gameState.characters[Characters.Zimyanin].status == CharacterInfo.PoliticStatus.Alive)
          str1 = PoliticUtils.GetPoliticFullName(gameState, Characters.Zimyanin);
        if (gameState.characters[Characters.Kosolapov].status == CharacterInfo.PoliticStatus.Alive)
          str2 = PoliticUtils.GetPoliticFullName(gameState, Characters.Kosolapov);
        if (gameState.characters[Characters.Sokolov].status == CharacterInfo.PoliticStatus.Alive)
        {
          str3 = PoliticUtils.GetPoliticFullName(gameState, Characters.Sokolov);
          break;
        }
        break;
      case 1:
        if (gameState.characters[Characters.Ponomarev].status == CharacterInfo.PoliticStatus.Alive)
          str1 = PoliticUtils.GetPoliticFullName(gameState, Characters.Ponomarev);
        if (gameState.characters[Characters.Demichev].status == CharacterInfo.PoliticStatus.Alive)
          str2 = PoliticUtils.GetPoliticFullName(gameState, Characters.Demichev);
        if (gameState.characters[Characters.Kuznetsov].status == CharacterInfo.PoliticStatus.Alive)
        {
          str3 = PoliticUtils.GetPoliticFullName(gameState, Characters.Kuznetsov);
          break;
        }
        break;
      case 2:
        if (gameState.characters[Characters.Smyrtioukov].status == CharacterInfo.PoliticStatus.Alive)
          str1 = PoliticUtils.GetPoliticFullName(gameState, Characters.Smyrtioukov);
        if (gameState.characters[Characters.Dumachev].status == CharacterInfo.PoliticStatus.Alive)
          str2 = PoliticUtils.GetPoliticFullName(gameState, Characters.Dumachev);
        if (gameState.characters[Characters.Mesiats].status == CharacterInfo.PoliticStatus.Alive)
        {
          str3 = PoliticUtils.GetPoliticFullName(gameState, Characters.Mesiats);
          break;
        }
        break;
      case 3:
        if (gameState.characters[Characters.Ligachyov].status == CharacterInfo.PoliticStatus.Alive)
          str1 = PoliticUtils.GetPoliticFullName(gameState, Characters.Ligachyov);
        if (gameState.characters[Characters.Ryzhkov].status == CharacterInfo.PoliticStatus.Alive)
          str2 = PoliticUtils.GetPoliticFullName(gameState, Characters.Ryzhkov);
        if (gameState.characters[Characters.Chebrikov].status == CharacterInfo.PoliticStatus.Alive)
        {
          str3 = PoliticUtils.GetPoliticFullName(gameState, Characters.Chebrikov);
          break;
        }
        break;
      case 4:
        if (gameState.characters[Characters.Shevardnadze].status == CharacterInfo.PoliticStatus.Alive)
          str1 = PoliticUtils.GetPoliticFullName(gameState, Characters.Shevardnadze);
        if (gameState.characters[Characters.Dolgikh].status == CharacterInfo.PoliticStatus.Alive)
          str2 = PoliticUtils.GetPoliticFullName(gameState, Characters.Dolgikh);
        if (gameState.characters[Characters.Zaykov].status == CharacterInfo.PoliticStatus.Alive)
        {
          str3 = PoliticUtils.GetPoliticFullName(gameState, Characters.Zaykov);
          break;
        }
        break;
      case 5:
        GameState gameState1 = gameState;
        politicPosition1 = gameState.politicPositions[PoliticPosition.ChairmanOfTheKGB];
        int character1 = (int) politicPosition1.Value;
        str1 = PoliticUtils.GetPoliticFullName(gameState1, (Characters) character1);
        GameState gameState2 = gameState;
        politicPosition1 = gameState.politicPositions[PoliticPosition.MinisterOfDefense];
        int character2 = (int) politicPosition1.Value;
        str2 = PoliticUtils.GetPoliticFullName(gameState2, (Characters) character2);
        break;
    }
    PoliticPosition? politicPosition2 = gameState.politicPositions[Characters.Chernenko];
    PoliticPosition politicPosition3 = PoliticPosition.President;
    int num1;
    if (!(politicPosition2.GetValueOrDefault() == politicPosition3 & politicPosition2.HasValue))
    {
      PoliticPosition? politicPosition4 = gameState.politicPositions[Characters.CustomCharacter];
      PoliticPosition politicPosition5 = PoliticPosition.President;
      if (!(politicPosition4.GetValueOrDefault() == politicPosition5 & politicPosition4.HasValue))
      {
        num1 = 13;
        goto label_36;
      }
    }
    num1 = 14;
label_36:
    int num2 = num1;
    GameState gameState3 = gameState;
    politicPosition1 = gameState.politicPositions[PoliticPosition.President];
    int character3 = (int) politicPosition1.Value;
    string politicFullName = PoliticUtils.GetPoliticFullName(gameState3, (Characters) character3);
    this.MarkEventAsDone(gameState, choice);
    foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (country => country.Value.activeInGame)))
      CountryUtils.MakeBoundaryForCountry(gameState, keyValuePair.Key);
    int num3;
    if (!gameState.eventsDone.ContainsKey(98))
    {
      PoliticPosition? politicPosition6 = gameState.politicPositions[Characters.Chernenko];
      PoliticPosition politicPosition7 = PoliticPosition.President;
      num3 = politicPosition6.GetValueOrDefault() == politicPosition7 & politicPosition6.HasValue ? 1 : 0;
    }
    else
      num3 = 0;
    if (num3 != 0)
      EventManager.inst.ProccessEventImmediately(gameState, 98, false);
    if (choice == 5)
    {
      LanguageManager inst = LanguageManager.inst;
      PoliticPosition? politicPosition8 = gameState.politicPositions[Characters.Chernenko];
      PoliticPosition politicPosition9 = PoliticPosition.President;
      string str4 = !(politicPosition8.GetValueOrDefault() == politicPosition9 & politicPosition8.HasValue) ? "events3Result5Var0" : "events3Result5Var1";
      return string.Format(inst["events", str4], (object) str1, (object) str2);
    }
    return string.Format(LanguageManager.inst["events", $"events3Result{choice}"], (object) num2, (object) str1, (object) str2, (object) str3, (object) politicFullName);
  }
}
