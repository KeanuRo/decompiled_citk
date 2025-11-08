// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.Utils.UnitsOfWork.UnitOfWorkExtensions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign.DoctrinesSystem.Doctrines;
using Backend.Gamedesign.EventSystem.Utils;
using Backend.Gamedesign.Utils.TextFormatter;
using Backend.Managers;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Backend.Gamedesign.Utils.UnitsOfWork;

public static class UnitOfWorkExtensions
{
  public static UnitOfWork AddReserveAction(
    this UnitOfWork unitOfWork,
    int value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddReserveAction((float) value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.Reserve += value));
    return unitOfWork;
  }

  public static UnitOfWork AddPoliticalPower(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddPoliticalPower(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.PoliticalPower += value));
    return unitOfWork;
  }

  public static UnitOfWork AddSpecialServices(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddSpecialServices(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.SpecialServices += value));
    return unitOfWork;
  }

  public static UnitOfWork AddSpecialServicesLoyalty(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddSpecialServicesLoyalty(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.SpecialServicesLoyalty += value));
    return unitOfWork;
  }

  public static UnitOfWork AddMilitaryStaffLoyalty(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddMilitaryStaffLoyalty(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.MilitaryStaffLoyalty += value));
    return unitOfWork;
  }

  public static UnitOfWork AddCombatability(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCombatability(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.Combatability += value));
    return unitOfWork;
  }

  public static UnitOfWork AddArmyLoyalty(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddArmyLoyalty(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.ArmyLoyalty += value));
    return unitOfWork;
  }

  public static UnitOfWork AddIntelligentsiaLoyalty(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddIntelligentsiaLoyalty(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.IntelligentsiaLoyalty += value));
    return unitOfWork;
  }

  public static UnitOfWork AddSelfFulfillment(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddSelfFulfillment(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.SelfFulfillment += value));
    return unitOfWork;
  }

  public static UnitOfWork AddCompetitivenessLevel(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCompetitivenessLevel(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.CompetitivenessLevel += value));
    return unitOfWork;
  }

  public static UnitOfWork AddForgeryLevel(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddForgeryLevel(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.ForgeryLevel += value));
    return unitOfWork;
  }

  public static UnitOfWork AddCorruptionLevel(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCorruptionLevel(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.CorruptionLevel += value));
    return unitOfWork;
  }

  public static UnitOfWork AddEducation(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddEducation(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.Education += value));
    return unitOfWork;
  }

  public static UnitOfWork AddEducationAccess(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddEducationAccess(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.EducationAccess += value));
    return unitOfWork;
  }

  public static UnitOfWork AddHealthCare(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddHealthCare(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.HealthCare += value));
    return unitOfWork;
  }

  public static UnitOfWork AddHealthCareAccess(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddHealthCareAccess(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.HealthCareAccess += value));
    return unitOfWork;
  }

  public static UnitOfWork AddArmyQuantityLevel(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddArmyQuantityLevel(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.ArmyQuantityLevel += value));
    return unitOfWork;
  }

  public static UnitOfWork AddExport(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddExport(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.Export += value));
    return unitOfWork;
  }

  public static UnitOfWork AddLightIndustryEffectiveness(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddLightIndustryEffectiveness(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.LightIndustryEffectiveness += value));
    return unitOfWork;
  }

  public static UnitOfWork AddHeavyIndustryEffectiveness(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddHeavyIndustryEffectiveness(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.HeavyIndustryEffectiveness += value));
    return unitOfWork;
  }

  public static UnitOfWork AddServicesEffectiveness(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddServicesEffectiveness(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.ServicesEffectiveness += value));
    return unitOfWork;
  }

  public static UnitOfWork AddAgroEffectiveness(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddAgroEffectiveness(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.AgroEffectiveness += value));
    return unitOfWork;
  }

  public static UnitOfWork AddArmyIndustryEffectiveness(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddArmyIndustryEffectiveness(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.ArmyIndustryEffectiveness += value));
    return unitOfWork;
  }

  public static UnitOfWork AddHousingLevel(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddHousingLevel(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.HousingLevel += value));
    return unitOfWork;
  }

  public static UnitOfWork AddEmploymentLevel(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddEmploymentLevel(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.EmploymentLevel += value));
    return unitOfWork;
  }

  public static UnitOfWork AddFirstNeedsGoods(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddFirstNeedsGoods(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.FirstNeedsGoods += value));
    return unitOfWork;
  }

  public static UnitOfWork AddLuxuryGoodsLevel(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddLuxuryGoodsLevel(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.LuxuryGoodsLevel += value));
    return unitOfWork;
  }

  public static UnitOfWork AddOrderLevel(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddOrderLevel(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.OrderLevel += value));
    return unitOfWork;
  }

  public static UnitOfWork AddSpiritualContentment(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddSpiritualContentment(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.SpiritualContentment += value));
    return unitOfWork;
  }

  public static UnitOfWork AddWarheadsQuantity(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddWarheadsQuantity(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.WarheadsQuantity += value));
    return unitOfWork;
  }

  public static UnitOfWork AddFreedomLevel(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddFreedomLevel(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.FreedomLevel += value));
    return unitOfWork;
  }

  public static UnitOfWork AddRadicalsPower(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddRadicalsPower(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.RadicalsPower += value));
    return unitOfWork;
  }

  public static UnitOfWork AddLiberalizationLevel(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddLiberalizationLevel(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.LiberalizationLevel += value));
    return unitOfWork;
  }

  public static UnitOfWork AddAmericanArmyLevel(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddAmericanArmyLevel(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.AmericanArmyLevel += value));
    return unitOfWork;
  }

  public static UnitOfWork AddAmericanEconomyLevel(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddAmericanEconomyLevel(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.AmericanEconomyLevel += value));
    return unitOfWork;
  }

  public static UnitOfWork AddUnityLevel(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddUnityLevel(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.UnityLevel += value));
    return unitOfWork;
  }

  public static UnitOfWork AddEcology(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddEcology(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.Ecology += value));
    return unitOfWork;
  }

  public static UnitOfWork AddAmericanPopularHappiness(
    this UnitOfWork unitOfWork,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddAmericanPopularHappiness(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.AmericanPopularHappiness += value));
    return unitOfWork;
  }

  public static UnitOfWork AddDefcon(
    this UnitOfWork unitOfWork,
    int value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddDefcon(value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.Defcon += value));
    return unitOfWork;
  }

  public static UnitOfWork AddCountryRelations(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    int value,
    Countries country,
    bool needParagraph = false,
    bool change_color = false,
    bool change_name = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCountryRelations(gameState1, (float) value, country, needParagraph, change_color, change_name)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) => gameState2.countries[country].RelationshipWithPlayer += (float) value));
    return unitOfWork;
  }

  public static UnitOfWork AddDiplomacyVector(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    Countries country,
    float value,
    bool yes = false,
    bool needParagraph = false,
    bool change_color = false,
    bool change_name = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddDiplomacyVector(gameState1, country, value, yes, needParagraph, change_color, change_name)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      if (!yes)
      {
        gameState2.countries[country].ForeignPolicyVector += value;
      }
      else
      {
        foreach (KeyValuePair<Countries, Country> keyValuePair in gameState2.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (c => c.Value.activeInGame && !CountryUtils.ShouldLibVectorBeDisplayed(gameState2, c.Key))))
          keyValuePair.Value.ForeignPolicyVector += value;
      }
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddCountryLiberalization(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    Countries country,
    bool yes = false,
    bool needParagraph = false,
    bool change_color = false,
    bool change_name = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCountryLiberalization(gameState1, value, country, yes, needParagraph, change_color, change_name)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      if (!yes)
      {
        gameState2.countries[country].LiberalizationVector += value;
      }
      else
      {
        foreach (KeyValuePair<Countries, Country> keyValuePair in gameState2.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (c => c.Value.activeInGame && CountryUtils.ShouldLibVectorBeDisplayed(gameState2, c.Key))))
          keyValuePair.Value.LiberalizationVector += value;
      }
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddCountryZoneRelations(
    this UnitOfWork unitOfWork,
    float value,
    Country.ZoneType zone = Country.ZoneType.WestEurope,
    bool needParagraph = false,
    bool change_color = false,
    bool change_name = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCountryZoneRelations(value, zone, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => CountryUtils.ChangeZoneRelations(gameState, value, zone)));
    return unitOfWork;
  }

  public static UnitOfWork AddCountryZoneDiplomacyVector(
    this UnitOfWork unitOfWork,
    float value,
    Country.ZoneType zone = Country.ZoneType.WestEurope,
    bool needParagraph = false,
    bool change_color = false,
    bool change_name = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCountryZoneDiplomacyVector(value, zone, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => CountryUtils.ChangeZoneForeignPolicyVector(gameState, value, zone)));
    return unitOfWork;
  }

  public static UnitOfWork AddChangePuppetType(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    Countries cou1,
    Countries cou2,
    Country.PuppetType puppet = Country.PuppetType.None,
    bool yes = false,
    bool change_name1 = false,
    bool change_name2 = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddChangePuppetType(gameState1, cou1, cou2, puppet, !yes, change_name1, change_name2)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      if (puppet == Country.PuppetType.None || !yes)
      {
        gameState2.countries[cou1].puppetType = Country.PuppetType.None;
        gameState2.countries[cou1].puppetOf = new Countries?();
      }
      else
      {
        gameState2.countries[cou1].puppetType = puppet;
        gameState2.countries[cou1].puppetOf = new Countries?(cou2);
      }
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddCountryIdeology(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    Countries country,
    Country.GovernmentType govtype,
    bool change_party = false,
    bool change_name = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCountryIdeology(gameState1, country, govtype, change_name)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      gameState2.countries[country].governmentType = new Country.GovernmentType?(govtype);
      if (!change_party)
        return;
      gameState2.countries[country].rulingPartyName = CountryUtils.GetPartyNameFromGovernmentType(govtype);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddCountryGovTypeRelationsByList(
    this UnitOfWork unitOfWork,
    float value,
    List<Country.GovernmentType> govtype)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter =>
    {
      string str1 = "";
      foreach (Country.GovernmentType governmentType in govtype)
        str1 = $"{str1} {LanguageManager.inst["government_type", governmentType.ToString() ?? ""]}{","}";
      string str2 = str1.Remove(str1.Length - 1);
      textFormatter.AddText($"{LanguageManager.inst["conditions", $"Adds{(govtype.Count == 1 ? 60 : 61)}"]}{str2}: {value:+0.##;-0.##}", (double) value >= 0.0 ? "#006400" : "#FF0000");
    }), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) =>
    {
      foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (c => c.Value.activeInGame && c.Key != gameState.playerCountry && govtype.Contains(c.Value.governmentType.Value))))
        keyValuePair.Value.RelationshipWithPlayer += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddCountryGovTypeDipVectorByList(
    this UnitOfWork unitOfWork,
    float value,
    List<Country.GovernmentType> govtype)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter =>
    {
      string str1 = "";
      foreach (Country.GovernmentType governmentType in govtype)
        str1 = $"{str1} {LanguageManager.inst["government_type", governmentType.ToString() ?? ""]}{","}";
      string str2 = str1.Remove(str1.Length - 1);
      textFormatter.AddText($"{LanguageManager.inst["conditions", $"Adds{(govtype.Count == 1 ? 34 : 59)}"]}{str2}: {value:+0.##;-0.##}", (double) value >= 0.0 ? "#006400" : "#FF0000");
    }), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) =>
    {
      foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (c => c.Value.activeInGame && c.Key != gameState.playerCountry && govtype.Contains(c.Value.governmentType.Value) && c.Value.puppetType > Country.PuppetType.EqualState)))
        keyValuePair.Value.RelationshipWithPlayer += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddCountryBase(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    Countries cou1,
    Countries cou2,
    bool yes = false,
    bool change_name = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCountryBase(gameState1, cou1, cou2, yes, change_name)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) => gameState2.countries[cou1].hasBase = yes ? (cou2 == Countries.USSR ? Country.BasesType.Soviet : Country.BasesType.American) : Country.BasesType.None));
    return unitOfWork;
  }

  public static UnitOfWork AddCountryTrade(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    Countries country,
    bool yes,
    bool needParagraph = false,
    bool change_color = false,
    bool change_name = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCountryTrade(gameState1, country, yes, needParagraph, change_color, change_name)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) => gameState2.countries[country].trade = yes));
    return unitOfWork;
  }

  public static UnitOfWork AddCountrySanctions(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    Countries country,
    bool yes,
    bool needParagraph = false,
    bool change_color = false,
    bool change_name = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCountrySanctions(gameState1, country, yes, needParagraph, change_color, change_name)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) => gameState2.countries[country].underOurSanctions = yes));
    return unitOfWork;
  }

  public static UnitOfWork AddCountryMilitaryAlliance(
    this UnitOfWork unitOfWork,
    bool yes,
    GameState gameState1,
    Countries country,
    Country.MilitaryAllianceType milTyupe = Country.MilitaryAllianceType.None)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCountryMilitaryAlliance(yes, gameState1, country, milTyupe)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) => gameState2.countries[country].militaryAlliance = yes ? milTyupe : Country.MilitaryAllianceType.None));
    return unitOfWork;
  }

  public static UnitOfWork AddCountryEconomyAlliance(
    this UnitOfWork unitOfWork,
    bool yes,
    GameState gameState1,
    Countries country,
    Country.EconomyAllianceType econTuype = Country.EconomyAllianceType.None,
    bool change_name = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCountryEconomyAlliance(yes, gameState1, country, econTuype, change_name)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) => gameState2.countries[country].economyAlliance = yes ? econTuype : Country.EconomyAllianceType.None));
    return unitOfWork;
  }

  public static UnitOfWork AddCountryLiberalizationAlliance(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    Country.MilitaryAllianceType miltipe = Country.MilitaryAllianceType.None,
    Country.EconomyAllianceType econtype = Country.EconomyAllianceType.None,
    bool needParagraph = false,
    bool change_color = false,
    Countries cou2 = Countries.USSR)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCountryLiberalizationAlliance(gameState1, value, miltipe, econtype, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      if (miltipe != Country.MilitaryAllianceType.None)
      {
        foreach (KeyValuePair<Countries, Country> keyValuePair in gameState2.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (c => c.Value.activeInGame && c.Value.militaryAlliance == miltipe && c.Key != cou2)))
          keyValuePair.Value.LiberalizationVector += value;
      }
      else
      {
        foreach (KeyValuePair<Countries, Country> keyValuePair in gameState2.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (c => c.Value.activeInGame && c.Value.economyAlliance == econtype && c.Key != cou2)))
          keyValuePair.Value.LiberalizationVector += value;
      }
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddSubjectRels(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    Countries country,
    float value,
    bool needParagraph = false,
    bool change_color = false,
    bool change_name = false,
    Countries cou2 = Countries.USSR)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddSubjectRels(gameState1, country, value, needParagraph, change_color, change_name, cou2)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (KeyValuePair<Countries, Country> keyValuePair in gameState2.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (c =>
      {
        if (c.Value.activeInGame)
        {
          Countries? puppetOf = c.Value.puppetOf;
          Countries playerCountry = gameState2.playerCountry;
          if (puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue && c.Value.puppetType < Country.PuppetType.PuppetOtherState)
            return c.Key != cou2;
        }
        return false;
      })))
        keyValuePair.Value.RelationshipWithPlayer += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddSubjectDipVector(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    Countries country,
    float value,
    bool needParagraph = false,
    bool change_color = false,
    bool change_name = false,
    Countries cou2 = Countries.USSR)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddSubjectDipVector(gameState1, country, value, needParagraph, change_color, change_name, cou2)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (KeyValuePair<Countries, Country> keyValuePair in gameState2.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (c =>
      {
        if (c.Value.activeInGame)
        {
          Countries? puppetOf = c.Value.puppetOf;
          Countries playerCountry = gameState2.playerCountry;
          if (puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue && c.Value.puppetType < Country.PuppetType.PuppetOtherState)
            return cou2 != 0;
        }
        return false;
      })))
        keyValuePair.Value.ForeignPolicyVector += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddCountryMilitaryAllianceRels(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    Country.MilitaryAllianceType miltipe = Country.MilitaryAllianceType.None,
    bool needParagraph = false,
    bool change_color = false,
    Countries cou2 = Countries.USSR)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCountryMilitaryAllianceRels(gameState1, value, miltipe, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      if (miltipe == Country.MilitaryAllianceType.None)
        return;
      foreach (KeyValuePair<Countries, Country> keyValuePair in gameState2.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (c => c.Value.activeInGame && c.Value.militaryAlliance == miltipe && c.Key != cou2)))
        keyValuePair.Value.RelationshipWithPlayer += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddDiplomacyVectorOfMilitaryAlliance(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    Country.MilitaryAllianceType miltipe = Country.MilitaryAllianceType.None,
    bool needParagraph = false,
    bool change_color = false,
    Countries cou2 = Countries.USSR)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddDiplomacyVectorOfMilitaryAlliance(gameState1, value, miltipe, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      if (miltipe == Country.MilitaryAllianceType.None)
        return;
      foreach (KeyValuePair<Countries, Country> keyValuePair in gameState2.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (c => c.Value.activeInGame && c.Value.militaryAlliance == miltipe && c.Key != cou2)))
        keyValuePair.Value.ForeignPolicyVector += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddCountryEconomyAllianceRels(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    Country.EconomyAllianceType econtype = Country.EconomyAllianceType.None,
    bool needParagraph = false,
    bool change_color = false,
    Countries cou2 = Countries.USSR)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCountryEconomyAllianceRels(gameState1, value, econtype, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (KeyValuePair<Countries, Country> keyValuePair in gameState2.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (c => c.Value.activeInGame && c.Value.economyAlliance == econtype && c.Key != cou2)))
        keyValuePair.Value.RelationshipWithPlayer += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddFactionLoyalNum(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    Factions fac0,
    float value,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddFactionLoyalNum(gameState1, fac0, value, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) => PoliticUtils.ChangeLoyalByFaction(gameState2, fac0, value)));
    return unitOfWork;
  }

  public static UnitOfWork AddFactionLoyalNumByList(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    List<Factions> factions)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter =>
    {
      string str1 = "";
      foreach (Factions faction in factions)
        str1 = $"{str1} {HighCouncilUtils.GetCurrentFactionName(gameState1, faction)}{","}";
      string str2 = str1.Remove(str1.Length - 1);
      textFormatter.AddText($"{LanguageManager.inst["conditions", DoctrineUtils.IsOneParty(gameState1) ? (factions.Count == 1 ? "FactionLoyalPlusNum" : "FactionLoyalPlus2") : (factions.Count == 1 ? "FactionLoyalPlus4" : "FactionLoyalPlus3")]}{str2}: {value:+0.##;-0.##}", (double) value >= 0.0 ? "#006400" : "#FF0000");
    }), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions faction in factions)
        PoliticUtils.ChangeLoyalByFaction(gameState2, faction, value);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddTwoFactionLoyalNum(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    Factions fac0,
    Factions fac1,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddTwoFactionLoyalNum(gameState1, value, fac0, fac1, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions faction in new List<Factions>()
      {
        fac0,
        fac1
      })
        PoliticUtils.ChangeLoyalByFaction(gameState2, faction, value);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddThreeFactionLoyalNum(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    Factions fac0,
    Factions fac1,
    Factions fac2,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddThreeFactionLoyalNum(gameState1, value, fac0, fac1, fac2, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions faction in new List<Factions>()
      {
        fac0,
        fac1,
        fac2
      })
        PoliticUtils.ChangeLoyalByFaction(gameState2, faction, value);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddFourFactionLoyalNum(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    Factions fac0,
    Factions fac1,
    Factions fac2,
    Factions fac3,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddFourFactionLoyalNum(gameState1, value, fac0, fac1, fac2, fac3, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions faction in new List<Factions>()
      {
        fac0,
        fac1,
        fac2,
        fac3
      })
        PoliticUtils.ChangeLoyalByFaction(gameState2, faction, value);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddIncomeSource(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    bool yes,
    IncomeSource income = IncomeSource.Base,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddIncomeSource(gameState1, value, yes, income, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) => { }));
    return unitOfWork;
  }

  public static UnitOfWork AddFiveFactionLoyalNum(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    Factions fac0,
    Factions fac1,
    Factions fac2,
    Factions fac3,
    Factions fac4,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddFiveFactionLoyalNum(gameState1, value, fac0, fac1, fac2, fac3, fac4, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions faction in new List<Factions>()
      {
        fac0,
        fac1,
        fac2,
        fac3,
        fac4
      })
        PoliticUtils.ChangeLoyalByFaction(gameState2, faction, value);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddSixFactionLoyalNum(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    Factions fac0,
    Factions fac1,
    Factions fac2,
    Factions fac3,
    Factions fac4,
    Factions fac5,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddSixFactionLoyalNum(gameState1, value, fac0, fac1, fac2, fac3, fac4, fac5, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions faction in new List<Factions>()
      {
        fac0,
        fac1,
        fac2,
        fac3,
        fac4,
        fac5
      })
        PoliticUtils.ChangeLoyalByFaction(gameState2, faction, value);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddFactionPowerNum(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    Factions fac0,
    int value,
    bool needParagraph = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddFactionPowerNum(gameState1, fac0, value, needParagraph)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) => gameState2.parliamentState[(int) fac0] += value));
    return unitOfWork;
  }

  public static UnitOfWork AddFactionPowerNumByList(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    int value,
    List<Factions> factions)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter =>
    {
      string str1 = "";
      foreach (Factions faction in factions)
        str1 = $"{str1} {HighCouncilUtils.GetCurrentFactionName(gameState1, faction)}{","}";
      string str2 = str1.Remove(str1.Length - 1);
      textFormatter.AddText($"{LanguageManager.inst["conditions", DoctrineUtils.IsOneParty(gameState1) ? (factions.Count == 1 ? "FactionsUpOneParty" : "FactionsUpOneParty0") : (factions.Count == 1 ? "FactionsUpManyParty" : "FactionsUpManyParty0")]}{str2}: {value:+0.##;-0.##}", "#C71585");
    }), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions faction in factions)
        gameState2.parliamentState[(int) faction] += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddTwoFactionPowerNum(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    int value,
    Factions fac0,
    Factions fac1,
    bool needParagraph = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddTwoFactionPowerNum(gameState1, (float) value, fac0, fac1, needParagraph)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions i in new List<Factions>()
      {
        fac0,
        fac1
      })
        gameState2.parliamentState[(int) i] += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddThreeFactionPowerNum(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    int value,
    Factions fac0,
    Factions fac1,
    Factions fac2,
    bool needParagraph = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddThreeFactionPowerNum(gameState1, (float) value, fac0, fac1, fac2, needParagraph)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions i in new List<Factions>()
      {
        fac0,
        fac1,
        fac2
      })
        gameState2.parliamentState[(int) i] += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddFourFactionPowerNum(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    int value,
    Factions fac0,
    Factions fac1,
    Factions fac2,
    Factions fac3,
    bool needParagraph = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddFourFactionPowerNum(gameState1, (float) value, fac0, fac1, fac2, fac3, needParagraph)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions i in new List<Factions>()
      {
        fac0,
        fac1,
        fac2,
        fac3
      })
        gameState2.parliamentState[(int) i] += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddFiveFactionPowerNum(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    int value,
    Factions fac0,
    Factions fac1,
    Factions fac2,
    Factions fac3,
    Factions fac4,
    bool needParagraph = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddFiveFactionPowerNum(gameState1, (float) value, fac0, fac1, fac2, fac3, fac4, needParagraph)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions i in new List<Factions>()
      {
        fac0,
        fac1,
        fac2,
        fac3,
        fac4
      })
        gameState2.parliamentState[(int) i] += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddSixFactionPowerNum(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    int value,
    Factions fac0,
    Factions fac1,
    Factions fac2,
    Factions fac3,
    Factions fac4,
    Factions fac5,
    bool needParagraph = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddSixFactionPowerNum(gameState1, (float) value, fac0, fac1, fac2, fac3, fac4, fac5, needParagraph)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions i in new List<Factions>()
      {
        fac0,
        fac1,
        fac2,
        fac3,
        fac4,
        fac5
      })
        gameState2.parliamentState[(int) i] += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddPowerOfPoliticByFaction(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    Factions fac0,
    int value,
    bool needParagraph = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddFactionPowerNum(gameState1, fac0, value, needParagraph, true)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) => PoliticUtils.ChangePoliticianPowerByFaction(gameState2, fac0, (float) value)));
    return unitOfWork;
  }

  public static UnitOfWork AddPowerOfPoliticByFactionByList(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    int value,
    List<Factions> factions)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter =>
    {
      string str1 = "";
      foreach (Factions faction in factions)
        str1 = $"{str1} {HighCouncilUtils.GetCurrentFactionName(gameState1, faction)}{","}";
      string str2 = str1.Remove(str1.Length - 1);
      textFormatter.AddText($"{LanguageManager.inst["conditions", DoctrineUtils.IsOneParty(gameState1) ? $"FactionPoliticalPower{(factions.Count == 1 ? 0 : 2)}" : $"FactionPoliticalPower{(factions.Count == 1 ? 1 : 3)}"]}{str2}: {value:+0.##;-0.##}", "#C71585");
    }), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions faction in factions)
        PoliticUtils.ChangePoliticianPowerByFaction(gameState2, faction, (float) value);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddPowerOfPoliticByTwoFaction(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    int value,
    Factions fac0,
    Factions fac1,
    bool needParagraph = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddTwoFactionPowerNum(gameState1, (float) value, fac0, fac1, needParagraph, true)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions faction in new List<Factions>()
      {
        fac0,
        fac1
      })
        PoliticUtils.ChangePoliticianPowerByFaction(gameState2, faction, (float) value);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddPowerOfPoliticByThreeFaction(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    int value,
    Factions fac0,
    Factions fac1,
    Factions fac2,
    bool needParagraph = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddThreeFactionPowerNum(gameState1, (float) value, fac0, fac1, fac2, needParagraph, true)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions faction in new List<Factions>()
      {
        fac0,
        fac1,
        fac2
      })
        PoliticUtils.ChangePoliticianPowerByFaction(gameState2, faction, (float) value);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddPowerOfPoliticByFourFaction(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    int value,
    Factions fac0,
    Factions fac1,
    Factions fac2,
    Factions fac3,
    bool needParagraph = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddFourFactionPowerNum(gameState1, (float) value, fac0, fac1, fac2, fac3, needParagraph, true)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions faction in new List<Factions>()
      {
        fac0,
        fac1,
        fac2,
        fac3
      })
        PoliticUtils.ChangePoliticianPowerByFaction(gameState2, faction, (float) value);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddPowerOfPoliticByFiveFaction(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    int value,
    Factions fac0,
    Factions fac1,
    Factions fac2,
    Factions fac3,
    Factions fac4,
    bool needParagraph = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddFiveFactionPowerNum(gameState1, (float) value, fac0, fac1, fac2, fac3, fac4, needParagraph, true)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions faction in new List<Factions>()
      {
        fac0,
        fac1,
        fac2,
        fac3,
        fac4
      })
        PoliticUtils.ChangePoliticianPowerByFaction(gameState2, faction, (float) value);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddPowerOfPoliticBySixFaction(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    int value,
    Factions fac0,
    Factions fac1,
    Factions fac2,
    Factions fac3,
    Factions fac4,
    Factions fac5,
    bool needParagraph = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddSixFactionPowerNum(gameState1, (float) value, fac0, fac1, fac2, fac3, fac4, fac5, needParagraph, true)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (Factions faction in new List<Factions>()
      {
        fac0,
        fac1,
        fac2,
        fac3,
        fac4,
        fac5
      })
        PoliticUtils.ChangePoliticianPowerByFaction(gameState2, faction, (float) value);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddTraitPoliticLoyality(
    this UnitOfWork unitOfWork,
    float value,
    Traits trait,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddTraitPoliticLoyality(value, trait, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => PoliticUtils.ChangeLoyalByTrait(gameState, trait, value)));
    return unitOfWork;
  }

  public static UnitOfWork AddTraitPoliticPower(
    this UnitOfWork unitOfWork,
    float value,
    Traits trait,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddTraitPoliticPower(value, trait, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => PoliticUtils.ChangePoliticalPowerByTrait(gameState, trait, value)));
    return unitOfWork;
  }

  public static UnitOfWork AddTraitPoliticPowerByList(
    this UnitOfWork unitOfWork,
    float value,
    List<Traits> trait)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter =>
    {
      string str1 = "";
      foreach (Traits traits in trait)
        str1 = $"{str1} {LanguageManager.inst["trait_titles", $"trait{(int) traits}"]}{","}";
      string str2 = str1.Remove(str1.Length - 1);
      textFormatter.AddText($"{LanguageManager.inst["conditions", $"AddManyTraitPoliticPower{(trait.Count<Traits>() == 1 ? 0 : 1)}"]}{str2}: {value:+0.##;-0.##}", (double) value >= 0.0 ? "#006400" : "#FF0000");
    }), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) =>
    {
      foreach (Traits trait1 in trait)
        PoliticUtils.ChangePoliticalPowerByTrait(gameState, trait1, value);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddTraitPoliticLoyalityByList(
    this UnitOfWork unitOfWork,
    float value,
    List<Traits> trait)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter =>
    {
      string str1 = "";
      foreach (Traits traits in trait)
        str1 = $"{str1} {LanguageManager.inst["trait_titles", $"trait{(int) traits}"]}{","}";
      string str2 = str1.Remove(str1.Length - 1);
      textFormatter.AddText($"{LanguageManager.inst["conditions", $"AddManyTraitPoliticLoyality{(trait.Count<Traits>() == 1 ? 0 : 1)}"]}{str2}: {value:+0.##;-0.##}", (double) value >= 0.0 ? "#006400" : "#FF0000");
    }), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) =>
    {
      foreach (Traits trait1 in trait)
        PoliticUtils.ChangeLoyalByTrait(gameState, trait1, value);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddPoliticLoyalty(
    this UnitOfWork unitOfWork,
    int value,
    Characters character)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddPoliticLoyality(value, character)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.characters[character].RelationsToPlayer += (float) value));
    return unitOfWork;
  }

  public static UnitOfWork AddPoliticPower(
    this UnitOfWork unitOfWork,
    int value,
    Characters character)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddPoliticPower(value, character)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => gameState.characters[character].Power += (float) value));
    return unitOfWork;
  }

  public static UnitOfWork AddSubjectPoliticLoyality(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    Countries country,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddSubjectPoliticLoyality(gameState1, value, country, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (KeyValuePair<Characters, CharacterInfo> keyValuePair in gameState2.characters.Where<KeyValuePair<Characters, CharacterInfo>>((Func<KeyValuePair<Characters, CharacterInfo>, bool>) (pol => pol.Value.status == CharacterInfo.PoliticStatus.Alive && pol.Value.homeLand == country && gameState2.countries[country].activeInGame)))
        keyValuePair.Value.RelationsToPlayer += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddSubjectPoliticPower(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    Countries country,
    bool needParagraph = false,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddSubjectPoliticPower(gameState1, value, country, needParagraph, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (KeyValuePair<Characters, CharacterInfo> keyValuePair in gameState2.characters.Where<KeyValuePair<Characters, CharacterInfo>>((Func<KeyValuePair<Characters, CharacterInfo>, bool>) (pol => pol.Value.status == CharacterInfo.PoliticStatus.Alive && pol.Value.homeLand == country && gameState2.countries[country].activeInGame)))
        keyValuePair.Value.Power += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddAllSubjectPoliticLoyality(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    Countries country,
    bool needParagraph = false,
    bool change_color = false,
    Countries cou2 = Countries.USSR)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddAllSubjectPoliticLoyality(gameState1, value, country, needParagraph, change_color, cou2)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (KeyValuePair<Characters, CharacterInfo> keyValuePair in gameState2.characters.Where<KeyValuePair<Characters, CharacterInfo>>((Func<KeyValuePair<Characters, CharacterInfo>, bool>) (pol => pol.Value.status == CharacterInfo.PoliticStatus.Alive && pol.Value.homeLand != cou2 && gameState2.countries[country].activeInGame)))
        keyValuePair.Value.RelationsToPlayer += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddAllSubjectPoliticPower(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    float value,
    Countries country,
    bool needParagraph = false,
    bool change_color = false,
    Countries cou2 = Countries.USSR)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddAllSubjectPoliticPower(gameState1, value, country, needParagraph, change_color, cou2)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      foreach (KeyValuePair<Characters, CharacterInfo> keyValuePair in gameState2.characters.Where<KeyValuePair<Characters, CharacterInfo>>((Func<KeyValuePair<Characters, CharacterInfo>, bool>) (pol => pol.Value.status == CharacterInfo.PoliticStatus.Alive && pol.Value.homeLand != cou2 && gameState2.countries[country].activeInGame)))
        keyValuePair.Value.Power += value;
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddCharacterTakesPost(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    Characters character,
    PoliticPosition position,
    bool yes)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddCharacterTakesPost(gameState1, character, position, yes)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      if (yes)
        gameState2.politicPositions[character] = new PoliticPosition?(position);
      else
        gameState2.politicPositions[character] = new PoliticPosition?();
    }));
    return unitOfWork;
  }

  public static UnitOfWork ChangeDoctrineToOnePoint(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    DoctrineType doctrine,
    bool higher,
    AbstractDoctrine.DoctrineBranchType branch = AbstractDoctrine.DoctrineBranchType.Central)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.ChangeDoctrineToOnePoint(gameState1, doctrine, higher, branch)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      DoctrineState doctrineState = DoctrineUtils.SetSpecialSubDoctrineState(gameState2, doctrine, higher, branch);
      DoctrineUtils.ChangeDoctrine(gameState2, doctrine, doctrineState.number, doctrineState.branch);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddChangeDoctrine(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    DoctrineType doctrine,
    AbstractDoctrine.DoctrineBranchType branch,
    int number)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddChangeDoctrine(gameState1, doctrine, branch, number)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) => DoctrineUtils.ChangeDoctrine(gameState2, doctrine, number, branch)));
    return unitOfWork;
  }

  public static UnitOfWork AddActiveModifies(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    int num,
    bool yes,
    bool time = false,
    int month = 0,
    int level = 0,
    int progressToNextLevel = 0,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddActiveModifies(gameState1, num, yes, time, month, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      if (yes)
      {
        if (gameState2.activeModificators.ContainsKey(num))
          return;
        gameState2.activeModificators.Add(num, new ModificatorState()
        {
          level = level,
          progressToNextLevel = progressToNextLevel
        });
        if (time)
          gameState2.activeModificators[num].endingDate = new DateTime?(gameState2.date.AddMonths(month));
      }
      else if (gameState2.activeModificators.ContainsKey(num))
        gameState2.activeModificators.Remove(num);
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddChangeModifies(
    this UnitOfWork unitOfWork,
    GameState gameState1,
    int num,
    int level,
    bool time = false,
    int month = 0,
    int progressToNextLevel = 0,
    bool change_color = false)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddChangeModifies(gameState1, num, level, time, month, change_color)), (Action<GameState, GameRules, GameScenario>) ((gameState2, gameRules, gameScenario) =>
    {
      if (gameState2.activeModificators.ContainsKey(num))
        return;
      gameState2.activeModificators.Add(num, new ModificatorState()
      {
        level = level,
        progressToNextLevel = progressToNextLevel
      });
      if (time)
        gameState2.activeModificators[num].endingDate = new DateTime?(gameState2.date.AddMonths(month));
    }));
    return unitOfWork;
  }

  public static UnitOfWork AddActiveEvent(this UnitOfWork unitOfWork, string name, int num)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddActiveEvent(name)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => EventManager.inst.ProccessEventImmediately(gameState, num, true)));
    return unitOfWork;
  }

  public static UnitOfWork AddDecisionAvailable(this UnitOfWork unitOfWork, int num)
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddDecisionAvailable(num)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => { }));
    return unitOfWork;
  }

  public static UnitOfWork AddText(this UnitOfWork unitOfWork, string text, string color = "")
  {
    unitOfWork.AddAction((Action<Backend.Gamedesign.Utils.TextFormatter.TextFormatter>) (textFormatter => textFormatter.AddText(text, color)), (Action<GameState, GameRules, GameScenario>) ((gameState, gameRules, gameScenario) => { }));
    return unitOfWork;
  }
}
