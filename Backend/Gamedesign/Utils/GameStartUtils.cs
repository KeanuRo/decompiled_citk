// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.Utils.GameStartUtils
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign.ScenarioSettings.Utils;
using Backend.Managers;
using System;
using System.Collections.Generic;

#nullable disable
namespace Backend.Gamedesign.Utils;

public static class GameStartUtils
{
  public static ScenarioType ScenarioFromYearAndCountry(Countries country, int year)
  {
    if (country != Countries.USSR)
      throw new NotImplementedException();
    return year == 1985 ? ScenarioType.USSR1985 : ScenarioType.USSR1991;
  }

  public static void LoadGameStateAndGameRulesFromStartSettings(
    ScenarioType scenarioType,
    Difficulty difficulty,
    Characters character,
    bool lastHeroMode,
    Countries country)
  {
    GameStateManager.inst.LoadStartGameState(scenarioType);
    GameStateManager.inst.GameState.playerCountry = country;
    GameStateManager.inst.GameState.difficulty = difficulty;
    GameStateManager.inst.GameState.lastHeroMode = lastHeroMode;
    GameStateManager.inst.GameState.guid = Guid.NewGuid();
    GameStateManager.inst.GameState.gameCharacter = character;
    GameStateManager.inst.GameState.politicPositions[character] = new PoliticPosition?(PoliticPosition.President);
  }

  public static void FillInfoAboutCustomCharacter(
    Characters character,
    CharacterInfo.PoliticStatus status,
    string name,
    string surname,
    int pictureNumber,
    HashSet<Traits> traits,
    Dictionary<CharacterInfo.PoliticCharacteristic, int> characteristics,
    int age,
    bool wasEnoughPoints,
    Countries homeland)
  {
    CustomCharacterInfo customCharacterInfo = new CustomCharacterInfo()
    {
      politicName = name,
      politicSurname = surname,
      pictureNumber = pictureNumber,
      wasEnoughPoints = wasEnoughPoints
    };
    GameStateManager.inst.GameState.characters[character] = new CharacterInfo()
    {
      birthDay = GameStateManager.inst.GameState.date.AddYears(-age),
      status = status,
      traits = traits,
      charLevel = characteristics,
      homeLand = homeland,
      customCharacterInfo = customCharacterInfo
    };
  }

  public static void MakeFinalScenarioPreparations()
  {
    GameState gameState = GameStateManager.inst.GameState;
    GameScenario gameScenario = GameStateManager.inst.GameScenario;
    GameRules gameRules = GameStateManager.inst.GameRules;
    ScenarioSettingsManager.inst.GetScenarioSettings(gameState.scenarioType).SetUpScenario(gameState, gameScenario, gameRules);
  }
}
