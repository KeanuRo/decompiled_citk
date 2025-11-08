// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.Utils.HighCouncilUtils
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1AEE2D60-F9AC-4BB1-9F59-FC7C8812BBA8
// Assembly location: C:\Users\Киану\RiderProjects\SampleCitK2Mod\lib\Assembly-CSharp.dll

using Backend.Gamedesign.DoctrinesSystem.Doctrines;
using Backend.Gamedesign.EventSystem.Utils;
using Backend.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
namespace Backend.Gamedesign.Utils;

public static class HighCouncilUtils
{
  public static (bool status, string desc, string header) GetInvestigateButtonState(
    GameState gameState)
  {
    Backend.Gamedesign.Utils.ConditionsFormatter.ConditionsFormatter conditionsFormatter = Backend.Gamedesign.Utils.ConditionsFormatter.ConditionsFormatter.StartCreation(Backend.Gamedesign.Utils.ConditionsFormatter.ConditionsFormatter.MainConditionOperator.AND);
    conditionsFormatter.AddCondition($"{PoliticUtils.GetPositionStringName(gameState, PoliticPosition.ChairmanOfTheKGB)} - {LanguageManager.inst["politics_window", "has_position"]}", gameState.politicPositions[PoliticPosition.ChairmanOfTheKGB].HasValue);
    conditionsFormatter.AddCondition(LanguageManager.inst["high_council_window", "one_banned"], gameState.factionsStates.Any<KeyValuePair<Factions, FactionState>>((Func<KeyValuePair<Factions, FactionState>, bool>) (fac => fac.Value.factionBanState == FactionState.FactionBanState.Banned)));
    (bool, string) tuple = conditionsFormatter.Finalize();
    return (tuple.Item1, $"{LanguageManager.inst["high_council_window", "investigate_desc"]}\n{tuple.Item2}", LanguageManager.inst["high_council_window", "investigate"]);
  }

  public static void ProcessInvestigateButton(GameState gameState)
  {
    EventManager.inst.ProccessEventImmediately(gameState, 33, true);
  }

  public static (string title, string description) GetFactionDescription(
    GameState gameState,
    Factions faction)
  {
    List<string> values = new List<string>();
    if (HighCouncilUtils.GetLeadingFaction(gameState) == faction)
      values.Add($"<sprite=57> <color=blue>{LanguageManager.inst["high_council_window", "leading"]}</color>");
    if (gameState.partyStates[faction].lastSurvDate.AddYears(20) > gameState.date)
    {
      values.Add($"{LanguageManager.inst["high_council_window", "last_surv_date"]}: {gameState.partyStates[faction].lastSurvDate.Month}.{gameState.partyStates[faction].lastSurvDate.Year}");
      values.Add($"{LanguageManager.inst["high_council_window", "last_numb_date"]}: {gameState.partyStates[faction].numbers}");
    }
    if (!DoctrineUtils.IsOneParty(gameState))
    {
      if (gameState.partyStates[faction].type == 3)
      {
        values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu"]}</color>\"");
        values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
        values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "PoliticalPower"]} +5</color>");
        values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "MilitaryStaffLoyalty"]} +1</color>");
        values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "SpecialServicesLoyalty"]} +1</color>");
        values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "RadicalsPower"]} +1</color>");
      }
      else
      {
        switch (faction)
        {
          case Factions.SocialPatriot:
            if (gameState.partyStates[faction].type == 1)
            {
              values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu1"]}</color>\"");
              values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "LiberalizationLevel"]} -1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "UnityLevel"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "RadicalsPower"]} -1</color>");
              values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "PoliticalPower"]} -5</color>");
              break;
            }
            values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu2"]}</color>\"");
            values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "OrderLevel"]} +1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "ArmyQuantityLevel"]} +1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "SpiritualContentment"]} +1</color>");
            values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "UnityLevel"]} -1</color>");
            break;
          case Factions.NeoTrotskyist:
            if (gameState.partyStates[faction].type == 4)
            {
              values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "yakovlev_4"]}</color>\"");
              values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "EmploymentLevel"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "HealthCareAccess"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "EducationAccess"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "Ecology"]} +1</color>");
              values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "CorruptionLevel"]} +1</color>");
              break;
            }
            if (gameState.partyStates[faction].type == 5)
            {
              values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "yakovlev_5"]}</color>\"");
              values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "IntelligentsiaLoyalty"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "FreedomLevel"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "SpiritualContentment"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "RadicalsPower"]} -1</color>");
              values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "ForgeryLevel"]} +1</color>");
              break;
            }
            if (gameState.partyStates[faction].type == 1)
            {
              values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu3"]}</color>\"");
              values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "PoliticalPower"]} +5</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "CorruptionLevel"]} -1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "LiberalizationLevel"]} +1</color>");
              values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "SpecialServicesLoyalty"]} -1</color>");
              break;
            }
            values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu4"]}</color>\"");
            values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "Ecology"]} +1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "FreedomLevel"]} +1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "LiberalizationLevel"]} +1</color>");
            values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "RadicalsPower"]} +1</color>");
            break;
          case Factions.NeoStalinist:
            if (gameState.partyStates[faction].type == 1)
            {
              values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu5"]}</color>\"");
              values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "MilitaryStaffLoyalty"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "SpecialServicesLoyalty"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "ArmyIndustryEffectiveness"]} +1</color>");
              values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "ForgeryLevel"]} +1</color>");
              break;
            }
            values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu6"]}</color>\"");
            values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "HousingLevel"]} +1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "EmploymentLevel"]} +1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "FirstNeedsGoods"]} +1</color>");
            values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "RadicalsPower"]} +1</color>");
            break;
          case Factions.Conservative:
            if (gameState.partyStates[faction].type == 1)
            {
              values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu7"]}</color>\"");
              values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "MilitaryStaffLoyalty"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "ArmyLoyalty"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "HeavyIndustryEffectiveness"]} +1</color>");
              values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "CorruptionLevel"]} +1</color>");
              break;
            }
            values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu8"]}</color>\"");
            values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "HousingLevel"]} +1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "EmploymentLevel"]} +1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "FirstNeedsGoods"]} +1</color>");
            values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "CorruptionLevel"]} +1</color>");
            break;
          case Factions.Moderate:
            if (gameState.partyStates[faction].type == 4)
            {
              values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "yakovlev_4"]}</color>\"");
              values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "EmploymentLevel"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "HealthCareAccess"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "EducationAccess"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "Ecology"]} +1</color>");
              values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "CorruptionLevel"]} +1</color>");
              break;
            }
            if (gameState.partyStates[faction].type == 5)
            {
              values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "yakovlev_5"]}</color>\"");
              values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "IntelligentsiaLoyalty"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "FreedomLevel"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "SpiritualContentment"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "RadicalsPower"]} -1</color>");
              values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "ForgeryLevel"]} +1</color>");
              break;
            }
            if (gameState.partyStates[faction].type == 1)
            {
              values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu9"]}</color>\"");
              values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "OrderLevel"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "EmploymentLevel"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "LiberalizationLevel"]} +1</color>");
              values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "RadicalsPower"]} +1</color>");
              break;
            }
            values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu10"]}</color>\"");
            values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "MilitaryStaffLoyalty"]} +1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "EmploymentLevel"]} +1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "SpecialServicesLoyalty"]} +1</color>");
            values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "CorruptionLevel"]} +1</color>");
            break;
          case Factions.Reformist:
            if (gameState.partyStates[faction].type == 4)
            {
              values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "yakovlev_4"]}</color>\"");
              values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "EmploymentLevel"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "HealthCareAccess"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "EducationAccess"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "Ecology"]} +1</color>");
              values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "CorruptionLevel"]} +1</color>");
              break;
            }
            if (gameState.partyStates[faction].type == 5)
            {
              values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "yakovlev_5"]}</color>\"");
              values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "IntelligentsiaLoyalty"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "FreedomLevel"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "SpiritualContentment"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "RadicalsPower"]} -1</color>");
              values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "ForgeryLevel"]} +1</color>");
              break;
            }
            if (gameState.partyStates[faction].type == 1)
            {
              values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu11"]}</color>\"");
              values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "FreedomLevel"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "IntelligentsiaLoyalty"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "SpiritualContentment"]} +1</color>");
              values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "RadicalsPower"]} +1</color>");
              break;
            }
            values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu12"]}</color>\"");
            values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "FreedomLevel"]} +1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "IntelligentsiaLoyalty"]} +1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "LiberalizationLevel"]} +1</color>");
            values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "RadicalsPower"]} +1</color>");
            break;
          case Factions.LiberalDemocracy:
            if (gameState.partyStates[faction].type == 1)
            {
              values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu13"]}</color>\"");
              values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "CompetitivenessLevel"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "IntelligentsiaLoyalty"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "SpiritualContentment"]} +1</color>");
              values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "CorruptionLevel"]} +1</color>");
              break;
            }
            values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu14"]}</color>\"");
            values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "FreedomLevel"]} +1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "CorruptionLevel"]} -1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "LiberalizationLevel"]} +1</color>");
            values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "RadicalsPower"]} +1</color=red>");
            break;
          case Factions.NationalLiberal:
            if (gameState.partyStates[faction].type == 1)
            {
              values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu15"]}</color>\"");
              values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "OrderLevel"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "ArmyQuantityLevel"]} +1</color>");
              values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "WarheadsQuantity"]} +1</color>");
              values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "UnityLevel"]} -1</color>");
              break;
            }
            values.Add($"\"<color=#006A0E>{LanguageManager.inst["high_council_window", "cpsu16"]}</color>\"");
            values.Add(LanguageManager.inst["high_council_window", "if_leading"] + ":");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "OrderLevel"]} +1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "MilitaryStaffLoyalty"]} +1</color>");
            values.Add($"<color=blue>{LanguageManager.inst["statistic_values_names", "SpecialServicesLoyalty"]} +1</color>");
            values.Add($"<color=red>{LanguageManager.inst["statistic_values_names", "CorruptionLevel"]} +1</color>");
            break;
        }
      }
    }
    values.Add($"<color=#AB5600>{LanguageManager.inst["high_council_window", $"{faction}"]}</color>");
    return ($"{LanguageManager.inst["high_council_window", "ideology"]}: {LanguageManager.inst["factions_names", $"{gameState.playerCountry}_faction{(int) faction}_{0}"]}", string.Join("\n", (IEnumerable<string>) values));
  }

  public static void TickParties(GameState gameState)
  {
    if (DoctrineUtils.IsOneParty(gameState))
      return;
    Factions leadingFaction = HighCouncilUtils.GetLeadingFaction(gameState);
    if (gameState.partyStates[leadingFaction].type == 3)
    {
      gameState.PoliticalPower += 5f;
      ++gameState.MilitaryStaffLoyalty;
      ++gameState.SpecialServicesLoyalty;
      ++gameState.RadicalsPower;
    }
    else
    {
      switch (leadingFaction)
      {
        case Factions.SocialPatriot:
          if (gameState.partyStates[leadingFaction].type == 1)
          {
            gameState.PoliticalPower -= 5f;
            --gameState.RadicalsPower;
            --gameState.LiberalizationLevel;
            ++gameState.UnityLevel;
            break;
          }
          ++gameState.OrderLevel;
          ++gameState.ArmyQuantityLevel;
          ++gameState.SpiritualContentment;
          --gameState.UnityLevel;
          break;
        case Factions.NeoTrotskyist:
          if (gameState.partyStates[leadingFaction].type == 4)
          {
            ++gameState.EmploymentLevel;
            ++gameState.HealthCareAccess;
            ++gameState.EducationAccess;
            ++gameState.Ecology;
            ++gameState.CorruptionLevel;
            break;
          }
          if (gameState.partyStates[leadingFaction].type == 5)
          {
            ++gameState.IntelligentsiaLoyalty;
            ++gameState.FreedomLevel;
            ++gameState.SpiritualContentment;
            --gameState.RadicalsPower;
            ++gameState.ForgeryLevel;
            break;
          }
          if (gameState.partyStates[leadingFaction].type == 1)
          {
            gameState.PoliticalPower += 5f;
            --gameState.SpecialServicesLoyalty;
            --gameState.CorruptionLevel;
            ++gameState.LiberalizationLevel;
            break;
          }
          ++gameState.Ecology;
          ++gameState.FreedomLevel;
          ++gameState.LiberalizationLevel;
          ++gameState.RadicalsPower;
          break;
        case Factions.NeoStalinist:
          if (gameState.partyStates[leadingFaction].type == 1)
          {
            ++gameState.MilitaryStaffLoyalty;
            ++gameState.SpecialServicesLoyalty;
            ++gameState.ForgeryLevel;
            ++gameState.ArmyIndustryEffectiveness;
            break;
          }
          ++gameState.HousingLevel;
          ++gameState.EmploymentLevel;
          ++gameState.FirstNeedsGoods;
          ++gameState.RadicalsPower;
          break;
        case Factions.Conservative:
          if (gameState.partyStates[leadingFaction].type == 1)
          {
            ++gameState.MilitaryStaffLoyalty;
            ++gameState.ArmyLoyalty;
            ++gameState.CorruptionLevel;
            ++gameState.HeavyIndustryEffectiveness;
            break;
          }
          ++gameState.HousingLevel;
          ++gameState.EmploymentLevel;
          ++gameState.FirstNeedsGoods;
          ++gameState.CorruptionLevel;
          break;
        case Factions.Moderate:
          if (gameState.partyStates[leadingFaction].type == 4)
          {
            ++gameState.EmploymentLevel;
            ++gameState.HealthCareAccess;
            ++gameState.EducationAccess;
            ++gameState.Ecology;
            ++gameState.CorruptionLevel;
            break;
          }
          if (gameState.partyStates[leadingFaction].type == 5)
          {
            ++gameState.IntelligentsiaLoyalty;
            ++gameState.FreedomLevel;
            ++gameState.SpiritualContentment;
            --gameState.RadicalsPower;
            ++gameState.ForgeryLevel;
            break;
          }
          if (gameState.partyStates[leadingFaction].type == 1)
          {
            ++gameState.OrderLevel;
            ++gameState.EmploymentLevel;
            ++gameState.LiberalizationLevel;
            ++gameState.RadicalsPower;
            break;
          }
          ++gameState.MilitaryStaffLoyalty;
          ++gameState.EmploymentLevel;
          ++gameState.SpecialServicesLoyalty;
          ++gameState.CorruptionLevel;
          break;
        case Factions.Reformist:
          if (gameState.partyStates[leadingFaction].type == 4)
          {
            ++gameState.EmploymentLevel;
            ++gameState.HealthCareAccess;
            ++gameState.EducationAccess;
            ++gameState.Ecology;
            ++gameState.CorruptionLevel;
            break;
          }
          if (gameState.partyStates[leadingFaction].type == 5)
          {
            ++gameState.IntelligentsiaLoyalty;
            ++gameState.FreedomLevel;
            ++gameState.SpiritualContentment;
            --gameState.RadicalsPower;
            ++gameState.ForgeryLevel;
            break;
          }
          if (gameState.partyStates[leadingFaction].type == 1)
          {
            ++gameState.FreedomLevel;
            ++gameState.IntelligentsiaLoyalty;
            ++gameState.SpiritualContentment;
            ++gameState.RadicalsPower;
            break;
          }
          ++gameState.FreedomLevel;
          ++gameState.IntelligentsiaLoyalty;
          ++gameState.LiberalizationLevel;
          ++gameState.RadicalsPower;
          break;
        case Factions.LiberalDemocracy:
          if (gameState.partyStates[leadingFaction].type == 1)
          {
            ++gameState.CompetitivenessLevel;
            ++gameState.IntelligentsiaLoyalty;
            ++gameState.SpiritualContentment;
            ++gameState.CorruptionLevel;
            break;
          }
          ++gameState.FreedomLevel;
          --gameState.CorruptionLevel;
          ++gameState.LiberalizationLevel;
          ++gameState.RadicalsPower;
          break;
        case Factions.NationalLiberal:
          if (gameState.partyStates[leadingFaction].type == 1)
          {
            ++gameState.OrderLevel;
            ++gameState.ArmyQuantityLevel;
            ++gameState.WarheadsQuantity;
            --gameState.UnityLevel;
            break;
          }
          ++gameState.OrderLevel;
          ++gameState.MilitaryStaffLoyalty;
          ++gameState.SpecialServicesLoyalty;
          ++gameState.CorruptionLevel;
          break;
      }
    }
  }

  public static string GetCurrentHighCounciName(
    GameState gameState,
    int padej = 0,
    Countries cou = Countries.USSR,
    int name = 0)
  {
    if (DoctrineUtils.IsOneParty(gameState) && name == 0 || name == 1)
      return $"{LanguageManager.inst["SupremeSoviet_names", $"CK{padej}"]} {CountryUtils.GetPartyName(gameState, cou, gameState.countries[cou].rulingPartyName).Item1}";
    if (gameState.doctrines[DoctrineType.StateStructure].branch == AbstractDoctrine.DoctrineBranchType.Bottom || name == 3)
      return $"{LanguageManager.inst["SupremeSoviet_names", $"MA{padej}"]} {CountryUtils.GetCountryName(gameState, cou, true)}";
    if (gameState.acceptedDecisions.Contains(112 /*0x70*/) && name == 0 || name == 2)
      return LanguageManager.inst["SupremeSoviet_names", $"GD{padej}"];
    if (name != 0 && name != 4)
      return "HighCouncilName";
    return !gameState.acceptedDecisions.Contains(112 /*0x70*/) ? $"{LanguageManager.inst["SupremeSoviet_names", $"SS{padej}"]} {CountryUtils.GetCountryName(gameState, cou, true)}" : $"{LanguageManager.inst["SupremeSoviet_names", $"PR{padej}"]} {CountryUtils.GetCountryName(gameState, cou, true)}";
  }

  public static Factions GetLeadingFaction(GameState gameState)
  {
    Dictionary<Factions, int> dictionary = new Dictionary<Factions, int>();
    gameState.GetDisplayableParliamentState(dictionary);
    KeyValuePair<Factions, int> keyValuePair = dictionary.Aggregate<KeyValuePair<Factions, int>>((Func<KeyValuePair<Factions, int>, KeyValuePair<Factions, int>, KeyValuePair<Factions, int>>) ((max, next) => next.Value <= max.Value ? max : next));
    if (!DoctrineUtils.IsOneParty(gameState) && (double) keyValuePair.Value >= (double) dictionary.Sum<KeyValuePair<Factions, int>>((Func<KeyValuePair<Factions, int>, int>) (par => par.Value)) / 2.0)
      return keyValuePair.Key;
    if (dictionary[Factions.NationalLiberal] + dictionary[Factions.SocialPatriot] / 5 > dictionary[Factions.NeoTrotskyist] + dictionary[Factions.NeoStalinist] + dictionary[Factions.Conservative] + dictionary[Factions.Moderate] + dictionary[Factions.Reformist] + dictionary[Factions.LiberalDemocracy] / 3)
      return Factions.NationalLiberal;
    if (dictionary[Factions.LiberalDemocracy] + dictionary[Factions.Reformist] / 5 > dictionary[Factions.NeoTrotskyist] / 3 + dictionary[Factions.NeoStalinist] + dictionary[Factions.Conservative] + dictionary[Factions.Moderate] + dictionary[Factions.SocialPatriot] + dictionary[Factions.NationalLiberal] / 3)
      return Factions.LiberalDemocracy;
    if ((double) dictionary[Factions.Reformist] > (double) dictionary[Factions.Moderate] * 0.699999988079071 && dictionary[Factions.Reformist] + dictionary[Factions.Moderate] / 5 > dictionary[Factions.NeoTrotskyist] + dictionary[Factions.NeoStalinist] + dictionary[Factions.Conservative] + dictionary[Factions.LiberalDemocracy] / 3 + dictionary[Factions.SocialPatriot] + dictionary[Factions.NationalLiberal])
      return Factions.Reformist;
    if ((double) dictionary[Factions.Moderate] > (double) dictionary[Factions.Conservative] * 0.699999988079071 && dictionary[Factions.Moderate] + dictionary[Factions.Conservative] / 5 > dictionary[Factions.NeoTrotskyist] + dictionary[Factions.NeoStalinist] + dictionary[Factions.Reformist] / 3 + dictionary[Factions.LiberalDemocracy] + dictionary[Factions.SocialPatriot] + dictionary[Factions.NationalLiberal])
      return Factions.Moderate;
    if (dictionary[Factions.NeoStalinist] + dictionary[Factions.SocialPatriot] / 5 > dictionary[Factions.NeoTrotskyist] + dictionary[Factions.Conservative] / 3 + dictionary[Factions.Moderate] + dictionary[Factions.Reformist] + dictionary[Factions.LiberalDemocracy] + dictionary[Factions.NationalLiberal])
      return Factions.NeoStalinist;
    if (dictionary[Factions.NeoTrotskyist] + dictionary[Factions.LiberalDemocracy] / 5 > dictionary[Factions.NeoStalinist] + dictionary[Factions.Conservative] + dictionary[Factions.Moderate] + dictionary[Factions.Reformist] / 3 + dictionary[Factions.SocialPatriot] + dictionary[Factions.NationalLiberal])
      return Factions.NeoTrotskyist;
    if (dictionary[Factions.SocialPatriot] + dictionary[Factions.NationalLiberal] / 5 > dictionary[Factions.NeoTrotskyist] + dictionary[Factions.NeoStalinist] / 3 + dictionary[Factions.Conservative] + dictionary[Factions.Moderate] + dictionary[Factions.Reformist] + dictionary[Factions.LiberalDemocracy])
      return Factions.SocialPatriot;
    return dictionary[Factions.Conservative] + dictionary[Factions.Moderate] / 5 > dictionary[Factions.NeoStalinist] + dictionary[Factions.NeoTrotskyist] + dictionary[Factions.LiberalDemocracy] + dictionary[Factions.Reformist] / 3 + dictionary[Factions.SocialPatriot] + dictionary[Factions.NationalLiberal] ? Factions.Conservative : keyValuePair.Key;
  }

  public static void GetDisplayableParliamentState(
    this GameState gameState,
    Dictionary<Factions, int> places)
  {
    places.Clear();
    Factions[] values = (Factions[]) Enum.GetValues(typeof (Factions));
    foreach (Factions factions in values)
    {
      if (gameState.factionsStates[factions].factionBanState == FactionState.FactionBanState.Legal)
        places.Add(factions, gameState.parliamentState[factions]);
      else
        places.Add(factions, 0);
    }
    Factions factions1 = (Factions) (values.Length / 2);
    IEnumerable<int> source = Enumerable.Range(0, ((IEnumerable<Factions>) values).Count<Factions>()).Where<int>((Func<int, bool>) (i => gameState.factionsStates[(Factions) i].factionBanState == FactionState.FactionBanState.Legal));
    foreach (Factions factions2 in ((IEnumerable<Factions>) values).Where<Factions>((Func<Factions, bool>) (faction => gameState.factionsStates[faction].factionBanState == FactionState.FactionBanState.Banned)))
    {
      Factions faction = factions2;
      int? nullable1 = source.Select<int, int?>((Func<int, int?>) (f => new int?(f))).FirstOrDefault<int?>((Func<int?, bool>) (fac =>
      {
        int num = (int) faction;
        int? nullable2 = fac;
        int valueOrDefault = nullable2.GetValueOrDefault();
        return num < valueOrDefault & nullable2.HasValue;
      }));
      int? nullable3 = source.Select<int, int?>((Func<int, int?>) (f => new int?(f))).LastOrDefault<int?>((Func<int?, bool>) (fac =>
      {
        int num = (int) faction;
        int? nullable4 = fac;
        int valueOrDefault = nullable4.GetValueOrDefault();
        return num > valueOrDefault & nullable4.HasValue;
      }));
      int key = source.OrderBy<int, int>((Func<int, int>) (fac => Mathf.Min(Mathf.Abs((int) (fac - faction)), Mathf.Abs((int) (faction - fac))))).First<int>();
      if (faction <= factions1)
      {
        if (nullable1.HasValue)
          places[(Factions) nullable1.Value] += gameState.parliamentState[faction];
        else if (nullable3.HasValue)
          places[(Factions) nullable3.Value] += gameState.parliamentState[faction];
        else
          places[(Factions) key] += gameState.parliamentState[faction];
      }
      else if (nullable3.HasValue)
        places[(Factions) nullable3.Value] += gameState.parliamentState[faction];
      else if (nullable1.HasValue)
        places[(Factions) nullable1.Value] += gameState.parliamentState[faction];
      else
        places[(Factions) key] += gameState.parliamentState[faction];
    }
  }

  public static float GetHiddenPercent(GameState gameState, Factions fac)
  {
    return (float) gameState.parliamentState[(int) fac] * 100f / gameState.parliamentState.GetSum();
  }

  public static float GetOpenPercent(GameState gameState, Factions fac)
  {
    Dictionary<Factions, int> places = new Dictionary<Factions, int>();
    gameState.GetDisplayableParliamentState(places);
    return (float) places[fac] * 100f / (float) places.Values.Sum();
  }

  public static string GetCurrentFactionName(GameState gameState, Factions faction)
  {
    return DoctrineUtils.IsOneParty(gameState) ? LanguageManager.inst["factions_names", $"{gameState.playerCountry}_faction{(int) faction}_{0}"] : LanguageManager.inst["factions_names", $"{gameState.playerCountry}_faction{(int) faction}_{gameState.partyStates[faction].nameType}"];
  }

  public static int GetLeadingWing(GameState gameState, Factions faction)
  {
    if (DoctrineUtils.IsOneParty(gameState))
      throw new ArgumentException("ОДНОПАРТИЙНОЕ ГОСУДАРСТВО!!!!!!!!!");
    int num = (int) ((double) gameState.FreedomLevel - 50.0) / 10 + (int) (50.0 - (double) gameState.LuxuryGoodsLevel) / 10 + (int) (50.0 - (double) gameState.SelfFulfillment) / 10 + (gameState.doctrines[DoctrineType.StateStructure].branch != AbstractDoctrine.DoctrineBranchType.Bottom ? 5 : -5) + (DoctrineUtils.IsPlannedEconomy(gameState) ? 5 : -5);
    switch (faction)
    {
      case Factions.SocialPatriot:
        num = num + (gameState.doctrines[DoctrineType.LawEnforcement].branch == AbstractDoctrine.DoctrineBranchType.Top || gameState.doctrines[DoctrineType.LawEnforcement].branch == AbstractDoctrine.DoctrineBranchType.Central ? 5 : -5) + (gameState.doctrines[DoctrineType.JudicialPower].branch == AbstractDoctrine.DoctrineBranchType.Bottom ? -5 : 5) + (gameState.activeModificators.ContainsKey(46) || gameState.activeModificators.ContainsKey(49) ? -5 : 0) + (gameState.activeModificators.ContainsKey(47) || gameState.activeModificators.ContainsKey(48 /*0x30*/) ? 5 : 0) + (gameState.doctrines[DoctrineType.DiplomacyLine].branch != AbstractDoctrine.DoctrineBranchType.Top ? -5 : 5);
        break;
      case Factions.NeoTrotskyist:
        num = num + (gameState.doctrines[DoctrineType.LawEnforcement].branch == AbstractDoctrine.DoctrineBranchType.Top || gameState.doctrines[DoctrineType.LawEnforcement].branch == AbstractDoctrine.DoctrineBranchType.Central ? -5 : 5) + (gameState.doctrines[DoctrineType.JudicialPower].branch == AbstractDoctrine.DoctrineBranchType.Bottom ? 5 : -5) + (gameState.activeModificators.ContainsKey(46) || gameState.activeModificators.ContainsKey(49) ? 5 : 0) + (gameState.activeModificators.ContainsKey(47) || gameState.activeModificators.ContainsKey(48 /*0x30*/) ? -5 : 0) + (gameState.doctrines[DoctrineType.DiplomacyLine].branch != AbstractDoctrine.DoctrineBranchType.Top ? 5 : -5);
        break;
      case Factions.NeoStalinist:
        num = num + (gameState.doctrines[DoctrineType.ChambersOfParliament].branch == AbstractDoctrine.DoctrineBranchType.Top || gameState.doctrines[DoctrineType.ChambersOfParliament].branch == AbstractDoctrine.DoctrineBranchType.Central ? 5 : -5) + (gameState.doctrines[DoctrineType.AppointmentOfHeadOfState].branch != AbstractDoctrine.DoctrineBranchType.BottomLeft && gameState.doctrines[DoctrineType.AppointmentOfHeadOfState].branch != AbstractDoctrine.DoctrineBranchType.BottomRight || gameState.doctrines[DoctrineType.AppointmentOfHeadOfState].number <= 0 ? -5 : 5) + (gameState.doctrines[DoctrineType.TradeUnions].branch != AbstractDoctrine.DoctrineBranchType.BottomLeft || gameState.doctrines[DoctrineType.TradeUnions].number <= 0 ? -5 : 5) + (int) (50.0 - (double) gameState.UnityLevel) / 10 + (int) (50.0 - (double) gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
        {
          Countries? puppetOf = cou.Value.puppetOf;
          Countries playerCountry = gameState.playerCountry;
          return puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue && cou.Value.puppetType <= Country.PuppetType.EqualState;
        })).Average<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, float>) (cou => cou.Value.RelationshipWithPlayer))) / 10;
        break;
      case Factions.Conservative:
        num = num + (gameState.doctrines[DoctrineType.LawEnforcement].branch == AbstractDoctrine.DoctrineBranchType.Top || gameState.doctrines[DoctrineType.LawEnforcement].branch == AbstractDoctrine.DoctrineBranchType.Central ? 5 : -5) + (gameState.doctrines[DoctrineType.JudicialPower].branch == AbstractDoctrine.DoctrineBranchType.Bottom ? 5 : -5) + (gameState.doctrines[DoctrineType.AppointmentOfHeadOfState].branch != AbstractDoctrine.DoctrineBranchType.BottomLeft && gameState.doctrines[DoctrineType.AppointmentOfHeadOfState].branch != AbstractDoctrine.DoctrineBranchType.BottomRight || gameState.doctrines[DoctrineType.AppointmentOfHeadOfState].number <= 0 ? 5 : -5) + (gameState.doctrines[DoctrineType.TradeUnions].branch != AbstractDoctrine.DoctrineBranchType.BottomLeft || gameState.doctrines[DoctrineType.TradeUnions].number <= 0 ? 5 : -5) + (int) (50.0 - (double) gameState.UnityLevel) / 10;
        break;
      case Factions.Moderate:
        num = num + (int) ((double) gameState.LiberalizationLevel - 50.0) / 10 + (gameState.doctrines[DoctrineType.AppointmentOfHeadOfState].branch != AbstractDoctrine.DoctrineBranchType.BottomLeft && gameState.doctrines[DoctrineType.AppointmentOfHeadOfState].branch != AbstractDoctrine.DoctrineBranchType.BottomRight || gameState.doctrines[DoctrineType.AppointmentOfHeadOfState].number <= 0 ? 5 : -5) + (gameState.doctrines[DoctrineType.TradeUnions].branch != AbstractDoctrine.DoctrineBranchType.BottomLeft || gameState.doctrines[DoctrineType.TradeUnions].number <= 0 ? 5 : -5) + (gameState.doctrines[DoctrineType.DiplomacyLine].branch != AbstractDoctrine.DoctrineBranchType.Top ? 5 : -5) + (int) (50.0 - (double) gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
        {
          Countries? puppetOf = cou.Value.puppetOf;
          Countries playerCountry = gameState.playerCountry;
          return puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue && cou.Value.puppetType <= Country.PuppetType.EqualState;
        })).Average<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, float>) (cou => cou.Value.RelationshipWithPlayer))) / 10;
        break;
      case Factions.Reformist:
        num = num + (int) (50.0 - (double) gameState.LiberalizationLevel) / 10 + (gameState.doctrines[DoctrineType.LawEnforcement].branch == AbstractDoctrine.DoctrineBranchType.Top || gameState.doctrines[DoctrineType.LawEnforcement].branch == AbstractDoctrine.DoctrineBranchType.Central ? -5 : 5) + (gameState.doctrines[DoctrineType.JudicialPower].branch == AbstractDoctrine.DoctrineBranchType.Bottom ? 5 : -5) + (gameState.doctrines[DoctrineType.AppointmentOfHeadOfState].branch != AbstractDoctrine.DoctrineBranchType.BottomLeft && gameState.doctrines[DoctrineType.AppointmentOfHeadOfState].branch != AbstractDoctrine.DoctrineBranchType.BottomRight || gameState.doctrines[DoctrineType.AppointmentOfHeadOfState].number <= 0 ? -5 : 5) + (gameState.doctrines[DoctrineType.TradeUnions].branch != AbstractDoctrine.DoctrineBranchType.BottomLeft || gameState.doctrines[DoctrineType.TradeUnions].number <= 0 ? -5 : 5);
        break;
      case Factions.LiberalDemocracy:
        num = num + (int) ((double) gameState.LiberalizationLevel - 50.0) / 10 + (gameState.doctrines[DoctrineType.LawEnforcement].branch == AbstractDoctrine.DoctrineBranchType.Top || gameState.doctrines[DoctrineType.LawEnforcement].branch == AbstractDoctrine.DoctrineBranchType.Central ? 5 : -5) + (gameState.doctrines[DoctrineType.JudicialPower].branch == AbstractDoctrine.DoctrineBranchType.Bottom ? -5 : 5) + (gameState.doctrines[DoctrineType.DiplomacyLine].branch != AbstractDoctrine.DoctrineBranchType.Top ? -5 : 5) + (int) (50.0 - (double) gameState.UnityLevel) / 10;
        break;
      case Factions.NationalLiberal:
        num = num + (gameState.doctrines[DoctrineType.LawEnforcement].branch == AbstractDoctrine.DoctrineBranchType.Top || gameState.doctrines[DoctrineType.LawEnforcement].branch == AbstractDoctrine.DoctrineBranchType.Central ? -5 : 5) + (gameState.doctrines[DoctrineType.JudicialPower].branch == AbstractDoctrine.DoctrineBranchType.Bottom ? 5 : -5) + (gameState.activeModificators.ContainsKey(47) || gameState.activeModificators.ContainsKey(48 /*0x30*/) ? -5 : 0) + (int) ((double) gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
        {
          Countries? puppetOf = cou.Value.puppetOf;
          Countries playerCountry = gameState.playerCountry;
          return puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue && cou.Value.puppetType <= Country.PuppetType.EqualState;
        })).Average<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, float>) (cou => cou.Value.RelationshipWithPlayer)) - 50.0) / 10 + (int) ((double) gameState.UnityLevel - 50.0) / 10;
        break;
    }
    return num > 0 ? 2 : 1;
  }

  public static (bool, string) GetBanButtonState(GameState gameState, Factions faction, bool toBan)
  {
    Factions leadingFaction = HighCouncilUtils.GetLeadingFaction(gameState);
    if (toBan && leadingFaction != faction)
    {
      if (gameState.doctrines[DoctrineType.TypeOfGovernment].branch == AbstractDoctrine.DoctrineBranchType.BottomRight && gameState.doctrines[DoctrineType.TypeOfGovernment].number == 1 || gameState.doctrines[DoctrineType.TypeOfGovernment].branch == AbstractDoctrine.DoctrineBranchType.TopRight && gameState.doctrines[DoctrineType.TypeOfGovernment].number == 0)
        return (false, LanguageManager.inst["faction_window", "cant_ban_doctrine"]);
      if (faction == Factions.SocialPatriot && (leadingFaction == Factions.NeoStalinist || leadingFaction == Factions.NationalLiberal))
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_factions"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.NeoStalinist)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.NationalLiberal)}");
      if (faction == Factions.NeoTrotskyist && (leadingFaction == Factions.Reformist || leadingFaction == Factions.LiberalDemocracy))
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_factions"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.Reformist)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.LiberalDemocracy)}");
      if (faction == Factions.NeoStalinist && (leadingFaction == Factions.SocialPatriot || leadingFaction == Factions.Conservative || leadingFaction == Factions.NationalLiberal))
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_factions"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.SocialPatriot)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.Conservative)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.NationalLiberal)}");
      if (faction == Factions.Conservative && leadingFaction != Factions.LiberalDemocracy)
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_wo_factions"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.LiberalDemocracy)}");
      if (faction == Factions.Moderate && (leadingFaction == Factions.NeoTrotskyist || leadingFaction == Factions.Conservative || leadingFaction == Factions.Reformist))
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_factions"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.NeoTrotskyist)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.Conservative)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.Reformist)}");
      if (faction == Factions.Reformist && (leadingFaction == Factions.NeoTrotskyist || leadingFaction == Factions.Moderate || leadingFaction == Factions.LiberalDemocracy))
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_factions"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.NeoTrotskyist)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.Moderate)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.LiberalDemocracy)}");
      if (faction == Factions.LiberalDemocracy && (leadingFaction == Factions.NeoTrotskyist || leadingFaction == Factions.Reformist))
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_factions"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.NeoTrotskyist)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.Reformist)}");
      if (faction == Factions.NationalLiberal && (leadingFaction == Factions.SocialPatriot || leadingFaction == Factions.Reformist || leadingFaction == Factions.LiberalDemocracy))
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_factions"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.SocialPatriot)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.Reformist)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.LiberalDemocracy)}");
    }
    else if (!toBan)
    {
      if (gameState.doctrines[DoctrineType.TypeOfGovernment].branch == AbstractDoctrine.DoctrineBranchType.BottomRight && gameState.doctrines[DoctrineType.TypeOfGovernment].number == 1 || gameState.doctrines[DoctrineType.TypeOfGovernment].branch == AbstractDoctrine.DoctrineBranchType.TopRight && gameState.doctrines[DoctrineType.TypeOfGovernment].number == 0)
        return (false, LanguageManager.inst["faction_window", "cant_ban_doctrine"]);
      if (faction == Factions.SocialPatriot && leadingFaction != Factions.NeoStalinist && leadingFaction != Factions.NationalLiberal)
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_wo_factions"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.NeoStalinist)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.NationalLiberal)}");
      if (faction == Factions.NeoTrotskyist && leadingFaction != Factions.Reformist && leadingFaction != Factions.LiberalDemocracy)
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_wo_factions"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.Reformist)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.LiberalDemocracy)}");
      if (faction == Factions.NeoStalinist && leadingFaction != Factions.SocialPatriot && leadingFaction != Factions.Conservative && leadingFaction != Factions.NationalLiberal)
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_wo_factions"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.SocialPatriot)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.Conservative)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.NationalLiberal)}");
      if (faction == Factions.Conservative && leadingFaction == Factions.LiberalDemocracy)
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_faction"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.LiberalDemocracy)}");
      if (faction == Factions.Moderate && leadingFaction != Factions.NeoTrotskyist && leadingFaction != Factions.Conservative && leadingFaction != Factions.Reformist)
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_wo_factions"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.NeoTrotskyist)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.Conservative)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.Reformist)}");
      if (faction == Factions.Reformist && leadingFaction != Factions.NeoTrotskyist && leadingFaction != Factions.Moderate && leadingFaction != Factions.LiberalDemocracy)
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_wo_factions"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.NeoTrotskyist)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.Moderate)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.LiberalDemocracy)}");
      if (faction == Factions.LiberalDemocracy && leadingFaction != Factions.NeoTrotskyist && leadingFaction != Factions.Reformist)
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_wo_factions"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.NeoTrotskyist)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.Reformist)}");
      if (faction == Factions.NationalLiberal && leadingFaction != Factions.SocialPatriot && leadingFaction != Factions.Reformist && leadingFaction != Factions.LiberalDemocracy)
        return (false, $" {LanguageManager.inst["faction_window", "cant_ban_wo_factions"]} {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.SocialPatriot)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.Reformist)}, {HighCouncilUtils.GetCurrentFactionName(gameState, Factions.LiberalDemocracy)}");
    }
    else if (leadingFaction == faction)
      return (false, LanguageManager.inst["faction_window", "cant_selfban"]);
    return gameState.activeModificators.ContainsKey(69) ? (true, $"{(toBan ? LanguageManager.inst["faction_window", "ban"] : LanguageManager.inst["faction_window", "unban"])}\n<color=red>{LanguageManager.inst["faction_window", "yakovlev_dem_off"]}</color>") : (true, toBan ? LanguageManager.inst["faction_window", "ban"] : LanguageManager.inst["faction_window", "unban"]);
  }

  public static void TickHighCouncilUtils(GameState gameState)
  {
    HighCouncilUtils.TickFactions(gameState);
    HighCouncilUtils.TickParties(gameState);
  }

  public static void TickFactions(GameState gameState)
  {
    foreach (KeyValuePair<Factions, FactionState> keyValuePair in gameState.factionsStates.Where<KeyValuePair<Factions, FactionState>>((Func<KeyValuePair<Factions, FactionState>, bool>) (fac => fac.Value.isBeingSupported)))
    {
      gameState.parliamentState[keyValuePair.Key]++;
      --gameState.SpecialServices;
      gameState.PoliticalPower -= 5f;
      if ((double) gameState.SpecialServices < 10.0 || (double) gameState.PoliticalPower < 10.0)
        keyValuePair.Value.isBeingSupported = false;
    }
  }

  public static bool GetSummFactionPolitician(GameState gameState, Factions faction, int max)
  {
    Traits needTrate = (Traits) (30 + faction);
    return (double) gameState.parliamentState[faction] + (double) gameState.characters.Where<KeyValuePair<Characters, CharacterInfo>>((Func<KeyValuePair<Characters, CharacterInfo>, bool>) (pol => pol.Value.traits.Contains(needTrate))).Sum<KeyValuePair<Characters, CharacterInfo>>((Func<KeyValuePair<Characters, CharacterInfo>, float>) (pol => pol.Value.Power / 10f)) > (double) max;
  }

  public static float GetSummFactionPoliticianNum(GameState gameState, Factions faction)
  {
    Traits needTrate = (Traits) (30 + faction);
    return (float) gameState.parliamentState[faction] + gameState.characters.Where<KeyValuePair<Characters, CharacterInfo>>((Func<KeyValuePair<Characters, CharacterInfo>, bool>) (pol => pol.Value.traits.Contains(needTrate))).Sum<KeyValuePair<Characters, CharacterInfo>>((Func<KeyValuePair<Characters, CharacterInfo>, float>) (pol => pol.Value.Power / 10f));
  }

  public static Factions GetLargestSummFactionPolitician(GameState gameState)
  {
    return gameState.factionsStates.Select<KeyValuePair<Factions, FactionState>, (Factions, FactionState, float)>((Func<KeyValuePair<Factions, FactionState>, (Factions, FactionState, float)>) (fac => (fac.Key, fac.Value, HighCouncilUtils.GetSummFactionPoliticianNum(gameState, fac.Key)))).OrderByDescending<(Factions, FactionState, float), float>((Func<(Factions, FactionState, float), float>) (fac => fac.Power)).First<(Factions, FactionState, float)>().Item1;
  }

  public static (bool, string) GetSupportButtonState(GameState gameState, Factions faction)
  {
    if (gameState.factionsStates[faction].factionBanState != FactionState.FactionBanState.Legal)
      return (false, LanguageManager.inst["faction_window", "banned_forbidden"]);
    if (gameState.factionsStates[faction].isBeingSupported)
      return (true, LanguageManager.inst["faction_window", "supported"]);
    return (true, $"{LanguageManager.inst["faction_window", "unsupported"]}\n{LanguageManager.inst["faction_window", "evr"]}:\n<color=red>{LanguageManager.inst["faction_window", "spec_power"]} -1\n{LanguageManager.inst["faction_window", "pp"]} -5</color>\n<color=blue>{LanguageManager.inst["faction_window", "fac_change"]} +0.25%</color>\n{LanguageManager.inst["faction_window", "stop"]}");
  }

  public static void ChangeFactionBanState(
    GameState gameState,
    Factions faction,
    FactionState.FactionBanState newState)
  {
    gameState.factionsStates[faction].factionBanState = newState;
    PoliticUtils.ChangeLoyalByFaction(gameState, faction, newState == FactionState.FactionBanState.Legal ? 15f : -30f);
    if (gameState.factionsStates[faction].isBeingSupported && newState == FactionState.FactionBanState.Banned)
      HighCouncilUtils.ChangeFactionSupportState(gameState, faction, false);
    if (!gameState.activeModificators.ContainsKey(69))
      return;
    gameState.activeModificators.Remove(69);
    EventManager.inst.ProccessEventImmediately(gameState, 30, true);
  }

  public static void ChangeFactionSupportState(
    GameState gameState,
    Factions faction,
    bool newState)
  {
    gameState.factionsStates[faction].isBeingSupported = newState;
  }
}
