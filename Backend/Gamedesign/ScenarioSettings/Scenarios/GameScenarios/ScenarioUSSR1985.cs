// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.ScenarioSettings.Scenarios.GameScenarios.ScenarioUSSR1985
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Backend.Gamedesign.ScenarioSettings.Scenarios.GameScenarios;

[Scenario(ScenarioType.USSR1985)]
public class ScenarioUSSR1985 : AbstractScenario
{
  public override void SetUpScenario(
    GameState gameState,
    GameScenario gameScenario,
    GameRules gameRules)
  {
    gameState.Population = (int) CountryUtils.GetRepublicsOfPlayerValues(gameState).Sum<Country>((Func<Country, float>) (c => c.population));
    Characters? politicPosition1 = gameState.politicPositions[PoliticPosition.President];
    if (politicPosition1.HasValue)
    {
      switch (politicPosition1.GetValueOrDefault())
      {
        case Characters.CustomCharacter:
          gameState.politicPositions[Characters.Gorbachev] = new PoliticPosition?(PoliticPosition.SecondSecretary);
          gameState.politicPositions[Characters.Tikhonov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheCouncilOfMinisters);
          gameState.politicPositions[Characters.Gromyko] = new PoliticPosition?(PoliticPosition.ForeignSecretary);
          gameState.politicPositions[Characters.Baibakov] = new PoliticPosition?(PoliticPosition.MinisterOfFinance);
          gameState.politicPositions[Characters.Kuznetsov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheSupremeCouncil);
          gameState.politicPositions[Characters.Chebrikov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheKGB);
          gameState.politicPositions[Characters.Mesiats] = new PoliticPosition?(PoliticPosition.MinisterOfAgriculture);
          gameState.politicPositions[Characters.Lomako] = new PoliticPosition?(PoliticPosition.MinisterOfIndustry);
          gameState.politicPositions[Characters.Yelutin] = new PoliticPosition?(PoliticPosition.MinisterOfEducation);
          gameState.politicPositions[Characters.Mishin] = new PoliticPosition?(PoliticPosition.MinisterForYouthAffairs);
          gameState.politicPositions[Characters.Fedorchuk] = new PoliticPosition?(PoliticPosition.MinisterOfInternalAffairs);
          gameState.politicPositions[Characters.Sokolov] = new PoliticPosition?(PoliticPosition.MinisterOfDefense);
          gameState.politicPositions[Characters.Ivashutin] = new PoliticPosition?(PoliticPosition.GRU);
          gameState.characters[Characters.Chernenko].status = CharacterInfo.PoliticStatus.Dead;
          gameState.characters[Characters.CustomCharacter].Power = 80f;
          gameState.characters[Characters.Gromyko].Power -= 5f;
          gameState.characters[Characters.Gorbachev].Power -= 5f;
          gameState.characters[Characters.Shcherbytsky].Power -= 5f;
          gameState.characters[Characters.Grishin].Power -= 5f;
          gameState.characters[Characters.Romanov].Power -= 5f;
          using (IEnumerator<KeyValuePair<Characters, CharacterInfo>> enumerator = gameState.characters.Where<KeyValuePair<Characters, CharacterInfo>>((Func<KeyValuePair<Characters, CharacterInfo>, bool>) (pol => pol.Value.status == CharacterInfo.PoliticStatus.Alive && pol.Key != gameState.gameCharacter)).GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              KeyValuePair<Characters, CharacterInfo> current = enumerator.Current;
              if ((double) current.Value.RelationsToPlayer > 75.0)
                current.Value.RelationsToPlayer -= 10f;
            }
            break;
          }
        case Characters.Gorbachev:
          gameState.politicPositions[Characters.Tikhonov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheCouncilOfMinisters);
          gameState.politicPositions[Characters.Gromyko] = new PoliticPosition?(PoliticPosition.ForeignSecretary);
          gameState.politicPositions[Characters.Baibakov] = new PoliticPosition?(PoliticPosition.MinisterOfFinance);
          gameState.politicPositions[Characters.Kuznetsov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheSupremeCouncil);
          gameState.politicPositions[Characters.Chebrikov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheKGB);
          gameState.politicPositions[Characters.Mesiats] = new PoliticPosition?(PoliticPosition.MinisterOfAgriculture);
          gameState.politicPositions[Characters.Lomako] = new PoliticPosition?(PoliticPosition.MinisterOfIndustry);
          gameState.politicPositions[Characters.Yelutin] = new PoliticPosition?(PoliticPosition.MinisterOfEducation);
          gameState.politicPositions[Characters.Mishin] = new PoliticPosition?(PoliticPosition.MinisterForYouthAffairs);
          gameState.politicPositions[Characters.Fedorchuk] = new PoliticPosition?(PoliticPosition.MinisterOfInternalAffairs);
          gameState.politicPositions[Characters.Sokolov] = new PoliticPosition?(PoliticPosition.MinisterOfDefense);
          gameState.politicPositions[Characters.Ivashutin] = new PoliticPosition?(PoliticPosition.GRU);
          gameState.politicPositions[Characters.Ligachyov] = new PoliticPosition?(PoliticPosition.SecondSecretary);
          gameState.characters[Characters.Chernenko].status = CharacterInfo.PoliticStatus.Dead;
          gameState.characters[Characters.Gromyko].RelationsToPlayer += 70f;
          gameState.characters[Characters.Ligachyov].RelationsToPlayer += 70f;
          gameState.characters[Characters.Tikhonov].RelationsToPlayer += 50f;
          gameState.characters[Characters.Solomentsev].RelationsToPlayer += 50f;
          gameState.characters[Characters.Yakovlev].RelationsToPlayer += 60f;
          gameState.characters[Characters.Shevardnadze].RelationsToPlayer += 60f;
          gameState.characters[Characters.Vorotnikov].RelationsToPlayer += 40f;
          gameState.characters[Characters.Kolbin].RelationsToPlayer += 40f;
          gameState.characters[Characters.Chebrikov].RelationsToPlayer += 20f;
          gameState.characters[Characters.Fedorchuk].RelationsToPlayer += 20f;
          gameState.characters[Characters.Sokolov].RelationsToPlayer += 20f;
          break;
        case Characters.Grishin:
          gameState.politicPositions[Characters.Gorbachev] = new PoliticPosition?(PoliticPosition.SecondSecretary);
          gameState.politicPositions[Characters.Tikhonov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheCouncilOfMinisters);
          gameState.politicPositions[Characters.Gromyko] = new PoliticPosition?(PoliticPosition.ForeignSecretary);
          gameState.politicPositions[Characters.Baibakov] = new PoliticPosition?(PoliticPosition.MinisterOfFinance);
          gameState.politicPositions[Characters.Kuznetsov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheSupremeCouncil);
          gameState.politicPositions[Characters.Chebrikov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheKGB);
          gameState.politicPositions[Characters.Mesiats] = new PoliticPosition?(PoliticPosition.MinisterOfAgriculture);
          gameState.politicPositions[Characters.Lomako] = new PoliticPosition?(PoliticPosition.MinisterOfIndustry);
          gameState.politicPositions[Characters.Yelutin] = new PoliticPosition?(PoliticPosition.MinisterOfEducation);
          gameState.politicPositions[Characters.Mishin] = new PoliticPosition?(PoliticPosition.MinisterForYouthAffairs);
          gameState.politicPositions[Characters.Fedorchuk] = new PoliticPosition?(PoliticPosition.MinisterOfInternalAffairs);
          gameState.politicPositions[Characters.Sokolov] = new PoliticPosition?(PoliticPosition.MinisterOfDefense);
          gameState.politicPositions[Characters.Ivashutin] = new PoliticPosition?(PoliticPosition.GRU);
          gameState.characters[Characters.Chernenko].status = CharacterInfo.PoliticStatus.Dead;
          gameState.characters[Characters.Gromyko].Power -= 10f;
          gameState.characters[Characters.Tikhonov].Power += 5f;
          gameState.characters[Characters.Fedorchuk].Power += 5f;
          gameState.characters[Characters.Shcherbytsky].Power += 5f;
          gameState.characters[Characters.Grishin].Power = 80f;
          gameState.characters[Characters.Ligachyov].Power -= 10f;
          gameState.characters[Characters.Yakovlev].Power -= 10f;
          gameState.characters[Characters.Gorbachev].Power -= 15f;
          gameState.characters[Characters.Shcherbytsky].RelationsToPlayer += 35f;
          gameState.characters[Characters.Gromyko].RelationsToPlayer -= 35f;
          gameState.characters[Characters.Ligachyov].RelationsToPlayer -= 45f;
          gameState.characters[Characters.Fedorchuk].RelationsToPlayer += 35f;
          gameState.characters[Characters.Romanov].RelationsToPlayer -= 50f;
          gameState.characters[Characters.Gorbachev].RelationsToPlayer -= 30f;
          using (IEnumerator<KeyValuePair<Characters, CharacterInfo>> enumerator = gameState.characters.Where<KeyValuePair<Characters, CharacterInfo>>((Func<KeyValuePair<Characters, CharacterInfo>, bool>) (pol => pol.Value.status == CharacterInfo.PoliticStatus.Alive && pol.Key != gameState.gameCharacter)).GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              KeyValuePair<Characters, CharacterInfo> current = enumerator.Current;
              if ((double) current.Value.RelationsToPlayer > 60.0)
                current.Value.RelationsToPlayer -= 25f;
            }
            break;
          }
        case Characters.Gromyko:
          gameState.politicPositions[Characters.Gorbachev] = new PoliticPosition?(PoliticPosition.SecondSecretary);
          gameState.politicPositions[Characters.Tikhonov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheCouncilOfMinisters);
          gameState.politicPositions[Characters.Troyanovsky] = new PoliticPosition?(PoliticPosition.ForeignSecretary);
          gameState.politicPositions[Characters.Baibakov] = new PoliticPosition?(PoliticPosition.MinisterOfFinance);
          gameState.politicPositions[Characters.Kuznetsov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheSupremeCouncil);
          gameState.politicPositions[Characters.Chebrikov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheKGB);
          gameState.politicPositions[Characters.Mesiats] = new PoliticPosition?(PoliticPosition.MinisterOfAgriculture);
          gameState.politicPositions[Characters.Lomako] = new PoliticPosition?(PoliticPosition.MinisterOfIndustry);
          gameState.politicPositions[Characters.Yelutin] = new PoliticPosition?(PoliticPosition.MinisterOfEducation);
          gameState.politicPositions[Characters.Mishin] = new PoliticPosition?(PoliticPosition.MinisterForYouthAffairs);
          gameState.politicPositions[Characters.Fedorchuk] = new PoliticPosition?(PoliticPosition.MinisterOfInternalAffairs);
          gameState.politicPositions[Characters.Sokolov] = new PoliticPosition?(PoliticPosition.MinisterOfDefense);
          gameState.politicPositions[Characters.Ivashutin] = new PoliticPosition?(PoliticPosition.GRU);
          gameState.characters[Characters.Chernenko].status = CharacterInfo.PoliticStatus.Dead;
          gameState.characters[Characters.Shcherbytsky].Power -= 10f;
          gameState.characters[Characters.Gromyko].Power = 80f;
          gameState.characters[Characters.Ligachyov].Power -= 15f;
          gameState.characters[Characters.Yakovlev].Power -= 10f;
          gameState.characters[Characters.Gorbachev].Power -= 15f;
          gameState.characters[Characters.Grishin].RelationsToPlayer -= 55f;
          gameState.characters[Characters.Romanov].RelationsToPlayer -= 50f;
          gameState.characters[Characters.Tikhonov].RelationsToPlayer -= 35f;
          gameState.characters[Characters.Gorbachev].RelationsToPlayer += 20f;
          using (IEnumerator<KeyValuePair<Characters, CharacterInfo>> enumerator = gameState.characters.Where<KeyValuePair<Characters, CharacterInfo>>((Func<KeyValuePair<Characters, CharacterInfo>, bool>) (pol => pol.Value.status == CharacterInfo.PoliticStatus.Alive && pol.Key != gameState.gameCharacter)).GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              KeyValuePair<Characters, CharacterInfo> current = enumerator.Current;
              if ((double) current.Value.RelationsToPlayer < 60.0)
                current.Value.RelationsToPlayer += 15f;
            }
            break;
          }
        case Characters.Romanov:
          gameState.politicPositions[Characters.Gorbachev] = new PoliticPosition?(PoliticPosition.SecondSecretary);
          gameState.politicPositions[Characters.Tikhonov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheCouncilOfMinisters);
          gameState.politicPositions[Characters.Gromyko] = new PoliticPosition?(PoliticPosition.ForeignSecretary);
          gameState.politicPositions[Characters.Baibakov] = new PoliticPosition?(PoliticPosition.MinisterOfFinance);
          gameState.politicPositions[Characters.Kuznetsov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheSupremeCouncil);
          gameState.politicPositions[Characters.Chebrikov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheKGB);
          gameState.politicPositions[Characters.Mesiats] = new PoliticPosition?(PoliticPosition.MinisterOfAgriculture);
          gameState.politicPositions[Characters.Lomako] = new PoliticPosition?(PoliticPosition.MinisterOfIndustry);
          gameState.politicPositions[Characters.Yelutin] = new PoliticPosition?(PoliticPosition.MinisterOfEducation);
          gameState.politicPositions[Characters.Mishin] = new PoliticPosition?(PoliticPosition.MinisterForYouthAffairs);
          gameState.politicPositions[Characters.Fedorchuk] = new PoliticPosition?(PoliticPosition.MinisterOfInternalAffairs);
          gameState.politicPositions[Characters.Sokolov] = new PoliticPosition?(PoliticPosition.MinisterOfDefense);
          gameState.politicPositions[Characters.Ivashutin] = new PoliticPosition?(PoliticPosition.GRU);
          gameState.characters[Characters.Chernenko].status = CharacterInfo.PoliticStatus.Dead;
          gameState.characters[Characters.Romanov].Power = 85f;
          gameState.characters[Characters.Shcherbytsky].Power = 75f;
          gameState.characters[Characters.Gromyko].Power = 75f;
          gameState.characters[Characters.Ligachyov].Power -= 15f;
          gameState.characters[Characters.Yakovlev].Power -= 15f;
          gameState.characters[Characters.Kosolapov].Power += 10f;
          gameState.characters[Characters.Gorbachev].Power -= 15f;
          gameState.characters[Characters.Gromyko].RelationsToPlayer += 30f;
          gameState.characters[Characters.Zaykov].RelationsToPlayer += 25f;
          gameState.characters[Characters.Shcherbytsky].RelationsToPlayer += 35f;
          gameState.characters[Characters.Kosolapov].RelationsToPlayer += 30f;
          gameState.characters[Characters.Grishin].RelationsToPlayer -= 25f;
          gameState.characters[Characters.Gorbachev].RelationsToPlayer -= 50f;
          break;
        case Characters.Chernenko:
          gameState.politicPositions[Characters.Gorbachev] = new PoliticPosition?(PoliticPosition.SecondSecretary);
          gameState.politicPositions[Characters.Tikhonov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheCouncilOfMinisters);
          gameState.politicPositions[Characters.Gromyko] = new PoliticPosition?(PoliticPosition.ForeignSecretary);
          gameState.politicPositions[Characters.Baibakov] = new PoliticPosition?(PoliticPosition.MinisterOfFinance);
          gameState.politicPositions[Characters.Kuznetsov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheSupremeCouncil);
          gameState.politicPositions[Characters.Chebrikov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheKGB);
          gameState.politicPositions[Characters.Mesiats] = new PoliticPosition?(PoliticPosition.MinisterOfAgriculture);
          gameState.politicPositions[Characters.Lomako] = new PoliticPosition?(PoliticPosition.MinisterOfIndustry);
          gameState.politicPositions[Characters.Yelutin] = new PoliticPosition?(PoliticPosition.MinisterOfEducation);
          gameState.politicPositions[Characters.Mishin] = new PoliticPosition?(PoliticPosition.MinisterForYouthAffairs);
          gameState.politicPositions[Characters.Fedorchuk] = new PoliticPosition?(PoliticPosition.MinisterOfInternalAffairs);
          gameState.politicPositions[Characters.Sokolov] = new PoliticPosition?(PoliticPosition.MinisterOfDefense);
          gameState.politicPositions[Characters.Ivashutin] = new PoliticPosition?(PoliticPosition.GRU);
          break;
        case Characters.Shcherbytsky:
          gameState.politicPositions[Characters.Gorbachev] = new PoliticPosition?(PoliticPosition.SecondSecretary);
          gameState.politicPositions[Characters.Tikhonov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheCouncilOfMinisters);
          gameState.politicPositions[Characters.Gromyko] = new PoliticPosition?(PoliticPosition.ForeignSecretary);
          gameState.politicPositions[Characters.Baibakov] = new PoliticPosition?(PoliticPosition.MinisterOfFinance);
          gameState.politicPositions[Characters.Kuznetsov] = new PoliticPosition?(PoliticPosition.ChairmanOfTheSupremeCouncil);
          gameState.politicPositions[Characters.Fedorchuk] = new PoliticPosition?(PoliticPosition.ChairmanOfTheKGB);
          gameState.politicPositions[Characters.Mesiats] = new PoliticPosition?(PoliticPosition.MinisterOfAgriculture);
          gameState.politicPositions[Characters.Lomako] = new PoliticPosition?(PoliticPosition.MinisterOfIndustry);
          gameState.politicPositions[Characters.Yelutin] = new PoliticPosition?(PoliticPosition.MinisterOfEducation);
          gameState.politicPositions[Characters.Mishin] = new PoliticPosition?(PoliticPosition.MinisterForYouthAffairs);
          gameState.politicPositions[Characters.Vlasov] = new PoliticPosition?(PoliticPosition.MinisterOfInternalAffairs);
          gameState.politicPositions[Characters.Sokolov] = new PoliticPosition?(PoliticPosition.MinisterOfDefense);
          gameState.politicPositions[Characters.Ivashutin] = new PoliticPosition?(PoliticPosition.GRU);
          gameState.characters[Characters.Chernenko].status = CharacterInfo.PoliticStatus.Dead;
          gameState.characters[Characters.Afanasyev].status = CharacterInfo.PoliticStatus.NotPresented;
          gameState.characters[Characters.Vlasov].status = CharacterInfo.PoliticStatus.Alive;
          gameState.characters[Characters.Gromyko].Power -= 10f;
          gameState.characters[Characters.Tikhonov].Power += 10f;
          gameState.characters[Characters.Fedorchuk].Power += 15f;
          gameState.characters[Characters.Vlasov].Power += 15f;
          gameState.characters[Characters.Shcherbytsky].Power = 80f;
          gameState.characters[Characters.Ligachyov].Power -= 15f;
          gameState.characters[Characters.Yakovlev].Power -= 10f;
          gameState.characters[Characters.Gorbachev].Power -= 15f;
          gameState.characters[Characters.Vlasov].RelationsToPlayer += 35f;
          gameState.characters[Characters.Fedorchuk].RelationsToPlayer += 35f;
          gameState.characters[Characters.Grishin].RelationsToPlayer -= 30f;
          gameState.characters[Characters.Romanov].RelationsToPlayer -= 50f;
          gameState.characters[Characters.Gorbachev].RelationsToPlayer -= 30f;
          break;
      }
    }
    gameState.eventsDone.Add(34, new EventCompletionState(2, DateTime.MaxValue));
    foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.activeInGame && cou.Value.hasBase == Country.BasesType.Soviet)))
    {
      if (!gameState.activeDiplomacyButtons.ContainsKey(3))
        gameState.activeDiplomacyButtons.Add(3, new Dictionary<Countries, DiplomacyButtonState>());
      gameState.activeDiplomacyButtons[3].Add(keyValuePair.Key, new DiplomacyButtonState());
      gameState.activeDiplomacyButtons[3][keyValuePair.Key].level = 0;
    }
    Characters? politicPosition2 = gameState.politicPositions[PoliticPosition.President];
    Characters characters = Characters.Chernenko;
    if (!(politicPosition2.GetValueOrDefault() == characters & politicPosition2.HasValue))
    {
      ModificatorState modificatorState = new ModificatorState()
      {
        endingDate = new DateTime?(gameState.date.AddMonths(12)),
        level = 1
      };
      gameState.activeModificators.Add(91, modificatorState);
    }
    if (gameState.difficulty == Difficulty.FreeMode)
      gameState.Reserve = 1500;
    else if (gameState.difficulty == Difficulty.Arcade)
    {
      gameState.Reserve = 1000;
    }
    else
    {
      if (gameState.difficulty != Difficulty.AntiSovietDream)
        return;
      gameState.MilitaryStaffLoyalty = 100f;
      gameState.ArmyLoyalty = 100f;
      gameState.SpecialServicesLoyalty = 100f;
      gameState.SpecialServices = 100f;
      gameState.FreedomLevel = 0.0f;
      gameState.RadicalsPower = 40f;
      gameState.LiberalizationLevel = 60f;
      gameState.LuxuryGoodsLevel = 20f;
      gameState.FirstNeedsGoods = 40f;
      gameState.AgroEffectiveness = 40f;
      gameState.LightIndustryEffectiveness = 30f;
      gameState.ServicesEffectiveness = 20f;
      gameState.HeavyIndustryEffectiveness = 100f;
      gameState.ArmyIndustryEffectiveness = 100f;
      gameState.IntelligentsiaLoyalty = 30f;
      gameState.SpiritualContentment = 30f;
      gameState.ArmyQuantityLevel = 100f;
      gameState.WarheadsQuantity = 100f;
      foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
      {
        Countries? puppetOf = cou.Value.puppetOf;
        Countries playerCountry = gameState.playerCountry;
        return puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue && cou.Value.puppetType <= Country.PuppetType.EqualState;
      })))
        keyValuePair.Value.RelationshipWithPlayer = 40f;
    }
  }
}
