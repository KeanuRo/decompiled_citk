// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.ScenarioSettings.Scenarios.GameScenarios.ScenarioUSSR1991
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Backend.Gamedesign.ScenarioSettings.Scenarios.GameScenarios;

[Scenario(ScenarioType.USSR1991)]
public class ScenarioUSSR1991 : AbstractScenario
{
  public override void SetUpScenario(
    GameState gameState,
    GameScenario gameScenario,
    GameRules gameRules)
  {
    gameState.Population = (int) CountryUtils.GetRepublicsOfPlayerValues(gameState).Sum<Country>((Func<Country, float>) (c => c.population));
    gameState.eventsDone.Add(34, new EventCompletionState(6, DateTime.MaxValue));
    foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.activeInGame && cou.Value.hasBase == Country.BasesType.Soviet)))
    {
      if (!gameState.activeDiplomacyButtons.ContainsKey(3))
        gameState.activeDiplomacyButtons.Add(3, new Dictionary<Countries, DiplomacyButtonState>());
      gameState.activeDiplomacyButtons[3].Add(keyValuePair.Key, new DiplomacyButtonState());
      gameState.activeDiplomacyButtons[3][keyValuePair.Key].level = 0;
    }
    gameState.politicPositions[Characters.Ivashko] = new PoliticPosition?(PoliticPosition.SecondSecretary);
    gameState.politicPositions[Characters.Pavlov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheCouncilOfMinisters);
    gameState.politicPositions[Characters.Bessmertnykh] = new PoliticPosition?(PoliticPosition.ForeignSecretary);
    gameState.politicPositions[Characters.Sherbacov] = new PoliticPosition?(PoliticPosition.MinisterOfFinance);
    gameState.politicPositions[Characters.Lukyanov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheSupremeCouncil);
    gameState.politicPositions[Characters.Kryuchkov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheKGB);
    gameState.politicPositions[Characters.Starodubtsev] = new PoliticPosition?(PoliticPosition.MinisterOfAgriculture);
    gameState.politicPositions[Characters.Tizyakov] = new PoliticPosition?(PoliticPosition.MinisterOfIndustry);
    gameState.politicPositions[Characters.Yagodin] = new PoliticPosition?(PoliticPosition.MinisterOfEducation);
    gameState.politicPositions[Characters.Zyukin] = new PoliticPosition?(PoliticPosition.MinisterForYouthAffairs);
    gameState.politicPositions[Characters.Pugo] = new PoliticPosition?(PoliticPosition.MinisterOfInternalAffairs);
    gameState.politicPositions[Characters.Yazov] = new PoliticPosition?(PoliticPosition.MinisterOfDefense);
    gameState.politicPositions[Characters.Mikhailov] = new PoliticPosition?(PoliticPosition.GRU);
  }
}
