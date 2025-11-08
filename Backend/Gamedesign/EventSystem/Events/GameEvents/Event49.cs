// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.EventSystem.Events.GameEvents.Event49
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign.EventSystem.DataStructures;
using Backend.Gamedesign.Utils;
using Backend.Gamedesign.Utils.TextFormatter;
using Backend.Gamedesign.Utils.UnitsOfWork;
using Backend.Managers;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Backend.Gamedesign.EventSystem.Events.GameEvents;

[Event(49)]
public class Event49 : AbstractEvent
{
  private readonly EventInfo eventInfo = new EventInfo()
  {
    priority = 210,
    startDate = DateTime.MinValue,
    endDate = DateTime.MaxValue,
    countryLimitation = new Countries?(Countries.USSR),
    eventType = EventType.Default
  };

  public override EventInfo EventInfo => this.eventInfo;

  public override bool CheckConditions(GameState gameState) => false;

  public override UnitOfWork[] StartEvent(GameState gameState, EventDrawInfo eventDrawInfo)
  {
    MinisterUtils.GetLeaderCallName(gameState, true);
    List<Characters> charactersList = new List<Characters>();
    if (gameState.characters[Characters.Tyazhelnikov].status == CharacterInfo.PoliticStatus.Alive)
    {
      ++eventDrawInfo.optionsCount;
      charactersList.Add(Characters.Tyazhelnikov);
    }
    if (gameState.characters[Characters.Troyanovsky].status == CharacterInfo.PoliticStatus.Alive)
    {
      ++eventDrawInfo.optionsCount;
      charactersList.Add(Characters.Troyanovsky);
    }
    if (gameState.characters[Characters.Bessmertnykh].status == CharacterInfo.PoliticStatus.Alive)
    {
      ++eventDrawInfo.optionsCount;
      charactersList.Add(Characters.Bessmertnykh);
    }
    if (gameState.characters[Characters.Shevardnadze].status == CharacterInfo.PoliticStatus.Alive)
    {
      ++eventDrawInfo.optionsCount;
      charactersList.Add(Characters.Shevardnadze);
    }
    string[] strArray = new string[eventDrawInfo.optionsCount];
    eventDrawInfo.eventTitle = LanguageManager.inst["events", "events49Title"];
    eventDrawInfo.eventDesc = string.Format(LanguageManager.inst["events", "events49Desc"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true));
    eventDrawInfo.image = 49;
    eventDrawInfo.optionsEnabled = new bool[eventDrawInfo.optionsCount];
    eventDrawInfo.optionsNames = new string[eventDrawInfo.optionsCount];
    eventDrawInfo.optionsNamesAlt = new string[eventDrawInfo.optionsCount];
    eventDrawInfo.optionsConditions = new string[eventDrawInfo.optionsCount];
    Backend.Gamedesign.Utils.TextFormatter.TextFormatter[] textFormatterArray = new Backend.Gamedesign.Utils.TextFormatter.TextFormatter[eventDrawInfo.optionsCount];
    UnitOfWork[] unitOfWorkArray = new UnitOfWork[eventDrawInfo.optionsCount];
    for (int index = 0; index < eventDrawInfo.optionsCount; ++index)
    {
      textFormatterArray[index] = Backend.Gamedesign.Utils.TextFormatter.TextFormatter.StartCreation();
      eventDrawInfo.optionsEnabled[index] = true;
    }
    for (int index = 0; index < eventDrawInfo.optionsCount; ++index)
    {
      foreach (Characters characters in charactersList)
      {
        eventDrawInfo.eventDesc += $"{LanguageManager.inst["events", $"events49Desc{(int) characters}"]} {(ValueType) '\n'}";
        eventDrawInfo.optionsNames[index] = $"{PoliticUtils.GetPoliticFullName(gameState, characters)} {LanguageManager.inst["events", "events49Answer"]}";
        textFormatterArray[index].AddCharacterTakesPost(gameState, characters, PoliticPosition.ForeignSecretary, true);
        textFormatterArray[index].AddPoliticLoyality(10, characters);
        textFormatterArray[index].AddPoliticPower(5, characters);
        textFormatterArray[index].AddFactionLoyalNum(gameState, PoliticUtils.GetFactionFromPolitician(gameState, characters), 5f);
        textFormatterArray[index].AddFactionPowerNum(gameState, PoliticUtils.GetFactionFromPolitician(gameState, characters), 5);
        // ISSUE: explicit reference operation
        ^ref strArray[index] += $"{LanguageManager.inst["events", "Characteristic"]} {(ValueType) '\n'}";
        // ISSUE: explicit reference operation
        ^ref strArray[index] += $"{LanguageManager.inst["events", "events50Adds0"]}: {gameState.characters[characters].Age(gameState.date)} {(ValueType) '\n'}";
        // ISSUE: explicit reference operation
        ^ref strArray[index] += string.Format("{1}: {2}{0}", (object) '\n', (object) ("<sprite=15>" + LanguageManager.inst["conditions", "diplomacy"]), (object) gameState.characters[characters].charLevel[CharacterInfo.PoliticCharacteristic.Diplomacy]);
        // ISSUE: explicit reference operation
        ^ref strArray[index] += string.Format("{1}: {2}{0}", (object) '\n', (object) ("<sprite=16>" + LanguageManager.inst["conditions", "intrigue"]), (object) gameState.characters[characters].charLevel[CharacterInfo.PoliticCharacteristic.Intrigue]);
        // ISSUE: explicit reference operation
        ^ref strArray[index] += string.Format("{1}: {2}{0}", (object) '\n', (object) ("<sprite=17>" + LanguageManager.inst["conditions", "thrift"]), (object) gameState.characters[characters].charLevel[CharacterInfo.PoliticCharacteristic.Thrift]);
        foreach (Traits trait in gameState.characters[characters].traits)
        {
          // ISSUE: explicit reference operation
          ^ref strArray[index] += string.Format($"<sprite={(int) (18 + trait)}>{LanguageManager.inst["trait_titles", $"trait{(int) trait}"]}\n");
        }
        textFormatterArray[index].AddText(strArray[index]);
        ++index;
      }
    }
    for (int index = 0; index < eventDrawInfo.optionsCount; ++index)
    {
      // ISSUE: explicit reference operation
      ^ref eventDrawInfo.optionsNamesAlt[index] += $"<color=blue>{LanguageManager.inst["events", "AnswerResult"]}</color> {(ValueType) '\n'} {textFormatterArray[index].Finalize()}";
    }
    return unitOfWorkArray;
  }

  public override string FinishEvent(GameState gameState, int choice)
  {
    this.MarkEventAsDone(gameState, choice);
    List<Characters> charactersList = new List<Characters>();
    int num = 0;
    if (gameState.characters[Characters.Tyazhelnikov].status == CharacterInfo.PoliticStatus.Alive)
    {
      charactersList.Add(Characters.Tyazhelnikov);
      ++num;
    }
    if (gameState.characters[Characters.Troyanovsky].status == CharacterInfo.PoliticStatus.Alive)
    {
      charactersList.Add(Characters.Troyanovsky);
      ++num;
    }
    if (gameState.characters[Characters.Bessmertnykh].status == CharacterInfo.PoliticStatus.Alive)
    {
      charactersList.Add(Characters.Bessmertnykh);
      ++num;
    }
    if (gameState.characters[Characters.Shevardnadze].status == CharacterInfo.PoliticStatus.Alive)
    {
      charactersList.Add(Characters.Shevardnadze);
      ++num;
    }
    for (int index = 0; index < num; ++index)
    {
      if (index == choice)
        gameState.politicPositions[PoliticPosition.ForeignSecretary] = new Characters?(charactersList[index]);
    }
    ParliamentState parliamentState = gameState.parliamentState;
    GameState gameState1 = gameState;
    Characters? politicPosition = gameState.politicPositions[PoliticPosition.ForeignSecretary];
    int character1 = (int) politicPosition.Value;
    int factionFromPolitician1 = (int) PoliticUtils.GetFactionFromPolitician(gameState1, (Characters) character1);
    parliamentState[factionFromPolitician1] += 5;
    Dictionary<Characters, CharacterInfo> characters1 = gameState.characters;
    politicPosition = gameState.politicPositions[PoliticPosition.ForeignSecretary];
    int key1 = (int) politicPosition.Value;
    characters1[(Characters) key1].RelationsToPlayer += 10f;
    Dictionary<Characters, CharacterInfo> characters2 = gameState.characters;
    politicPosition = gameState.politicPositions[PoliticPosition.ForeignSecretary];
    int key2 = (int) politicPosition.Value;
    characters2[(Characters) key2].Power += 5f;
    GameState gameState2 = gameState;
    GameState gameState3 = gameState;
    politicPosition = gameState.politicPositions[PoliticPosition.ForeignSecretary];
    int character2 = (int) politicPosition.Value;
    int factionFromPolitician2 = (int) PoliticUtils.GetFactionFromPolitician(gameState3, (Characters) character2);
    PoliticUtils.ChangeLoyalByFaction(gameState2, (Factions) factionFromPolitician2, 5f);
    foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (country => country.Value.activeInGame)))
      CountryUtils.MakeBoundaryForCountry(gameState, keyValuePair.Key);
    return string.Format(LanguageManager.inst["events", "events49Result"], (object) PoliticUtils.GetPoliticFullName(gameState, gameState.politicPositions[PoliticPosition.ForeignSecretary].Value), (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true));
  }
}
