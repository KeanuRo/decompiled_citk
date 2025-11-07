// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.Utils.CountryUtils
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign.DiplomacyButtonsSystem.Utils;
using Backend.Gamedesign.DiplomacyIconsSystem.Utils;
using Backend.Gamedesign.DoctrinesSystem.Doctrines;
using Backend.Gamedesign.DoctrinesSystem.Utils;
using Backend.Gamedesign.TechnologiesSystem.Utils;
using Backend.Gamedesign.Utils.TextFormatter;
using Backend.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
namespace Backend.Gamedesign.Utils;

public static class CountryUtils
{
  public static string GetRelationsDescription(GameState gameState, Countries country)
  {
    Country country1 = gameState.countries[country];
    Backend.Gamedesign.Utils.TextFormatter.TextFormatter textFormatter1 = Backend.Gamedesign.Utils.TextFormatter.TextFormatter.StartCreation();
    Backend.Gamedesign.Utils.TextFormatter.TextFormatter textFormatter2 = Backend.Gamedesign.Utils.TextFormatter.TextFormatter.StartCreation();
    Backend.Gamedesign.Utils.TextFormatter.TextFormatter textFormatter3 = Backend.Gamedesign.Utils.TextFormatter.TextFormatter.StartCreation();
    float num1 = 0.0f;
    Country country2 = gameState.countries[gameState.playerCountry];
    if (country1.puppetType == Country.PuppetType.Occupied)
    {
      switch (country1.puppetOf.Value)
      {
        case Countries.USSR:
          if (gameState.playerCountry == Countries.USSR)
          {
            textFormatter2.AddText($"— {LanguageManager.inst["icon_desc", "icon2"]}: 100 ({string.Format(LanguageManager.inst["puppet_type_name", "Occupied"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true))})", "#006400");
            break;
          }
          textFormatter2.AddText($"— {LanguageManager.inst["icon_desc", "icon20"]} {CountryUtils.GetCountryName(gameState, Countries.USSR)} ({string.Format(LanguageManager.inst["puppet_type_name", "Occupied"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true))})", "#FF0000");
          break;
        case Countries.USA:
          textFormatter2.AddText($"— {LanguageManager.inst["icon_desc", "icon20"]} {CountryUtils.GetCountryName(gameState, Countries.USA)} ({string.Format(LanguageManager.inst["puppet_type_name", "Occupied"], (object) CountryUtils.GetCountryName(gameState, Countries.USA, true))})", "#FF0000");
          break;
        default:
          textFormatter2.AddText($"— {LanguageManager.inst["icon_desc", "icon20"]} {CountryUtils.GetCountryName(gameState, country1.puppetOf.Value)} ({string.Format(LanguageManager.inst["puppet_type_name", "Occupied"], (object) CountryUtils.GetCountryName(gameState, country1.puppetOf.Value))})", "#FF0000");
          break;
      }
    }
    List<Country.GovernmentType> governmentTypeList1 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LeftNationalism,
      Country.GovernmentType.ConservativeSocialism,
      Country.GovernmentType.SocialismNationalSpecific,
      Country.GovernmentType.LeftPragmatism
    };
    List<Country.GovernmentType> governmentTypeList2 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalConservative,
      Country.GovernmentType.PopulistConservative,
      Country.GovernmentType.RightPopulism,
      Country.GovernmentType.ReactonaryAuthoritarian,
      Country.GovernmentType.MarketAuthoritarian
    };
    List<Country.GovernmentType> governmentTypeList3 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.DemocraticSocialism,
      Country.GovernmentType.SocialistReformism,
      Country.GovernmentType.SocialDemocracy,
      Country.GovernmentType.ConstructingCommunism
    };
    List<Country.GovernmentType> governmentTypeList4 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalCorporativism,
      Country.GovernmentType.LiberalProgressive,
      Country.GovernmentType.ClassicalLiberalism,
      Country.GovernmentType.Centrism
    };
    if (country1.hasBase == Country.BasesType.American)
      textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon1"]}: 75 ({string.Format(LanguageManager.inst["map_left_panel_ui", "military_base"], (object) CountryUtils.GetCountryName(gameState, Countries.USA, true))})", "#FF0000");
    else if (country1.leaderType == Country.LeaderType.Separatist)
      textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon1"]}: 75 ({LanguageManager.inst["leader_type_name", "Icon_name"]}: {LanguageManager.inst["leader_type_name", "Separatist"]})", "#FF0000");
    else if (country1.economyAlliance == Country.EconomyAllianceType.WAFT)
      textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon1"]}: 75 ({LanguageManager.inst["icon_desc", "icon25"]} {CountryUtils.GetEconomicAllianceName(gameState, Country.EconomyAllianceType.WAFT)})", "#FF0000");
    Countries? puppetOf;
    int num2;
    if (country1.economyAlliance == Country.EconomyAllianceType.EU && country2.economyAlliance == Country.EconomyAllianceType.EU)
    {
      puppetOf = country1.puppetOf;
      Countries countries = Countries.USSR;
      num2 = puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue ? 1 : (country1.puppetType != Country.PuppetType.PuppetOtherState ? 1 : 0);
    }
    else
      num2 = 0;
    if (num2 != 0)
      textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon2"]}: 10 ({LanguageManager.inst["icon_desc", "icon25"]} {CountryUtils.GetEconomicAllianceName(gameState, Country.EconomyAllianceType.EU)})", "#006400");
    else if (gameState.activeDiplomacyButtons.ContainsKey(6) && gameState.activeDiplomacyButtons[6].ContainsKey(country))
      textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon2"]}: 20 ({LanguageManager.inst["icon_desc", "icon28"]})", "#006400");
    textFormatter3.AddText(LanguageManager.inst["icon_desc", "icon_infl"], "blue");
    int num3;
    if (country1.activeInGame)
    {
      Country.GovernmentType? governmentType1 = country1.governmentType;
      Country.GovernmentType? governmentType2 = country2.governmentType;
      num3 = governmentType1.GetValueOrDefault() == governmentType2.GetValueOrDefault() & governmentType1.HasValue == governmentType2.HasValue ? 1 : 0;
    }
    else
      num3 = 0;
    if (num3 != 0)
    {
      puppetOf = country1.puppetOf;
      Countries playerCountry = gameState.playerCountry;
      if (!(puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue))
      {
        textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon24"] + ": +0.5", "#006400");
        num1 += 0.5f;
      }
      else
      {
        textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon24"] + ": +1", "#006400");
        ++num1;
      }
    }
    else if (country1.activeInGame && (governmentTypeList1.Contains(country1.governmentType.Value) && governmentTypeList1.Contains(country2.governmentType.Value) || governmentTypeList2.Contains(country1.governmentType.Value) && governmentTypeList2.Contains(country2.governmentType.Value) || governmentTypeList3.Contains(country1.governmentType.Value) && governmentTypeList3.Contains(country2.governmentType.Value) || governmentTypeList4.Contains(country1.governmentType.Value) && governmentTypeList4.Contains(country2.governmentType.Value)))
    {
      puppetOf = country1.puppetOf;
      Countries playerCountry = gameState.playerCountry;
      if (!(puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue))
      {
        if (CountryUtils.ShouldRelationsBeDisplayed(gameState, country))
        {
          textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon24"] + ": +0.25", "#006400");
          num1 += 0.25f;
        }
      }
      else
      {
        textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon24"] + ": +0.5", "#006400");
        num1 += 0.5f;
      }
    }
    else if (country1.activeInGame && ((governmentTypeList1.Contains(country1.governmentType.Value) || governmentTypeList3.Contains(country1.governmentType.Value)) && (governmentTypeList3.Contains(country2.governmentType.Value) || governmentTypeList1.Contains(country2.governmentType.Value)) || (governmentTypeList2.Contains(country1.governmentType.Value) || governmentTypeList2.Contains(country2.governmentType.Value)) && (governmentTypeList4.Contains(country1.governmentType.Value) || governmentTypeList4.Contains(country2.governmentType.Value))))
    {
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon24"] + ": +0.2", "#006400");
      num1 += 0.2f;
    }
    else if (country1.activeInGame && (!governmentTypeList1.Contains(country1.governmentType.Value) && !governmentTypeList3.Contains(country1.governmentType.Value) || !governmentTypeList3.Contains(country2.governmentType.Value) && !governmentTypeList1.Contains(country2.governmentType.Value)) && (!governmentTypeList2.Contains(country1.governmentType.Value) && !governmentTypeList2.Contains(country2.governmentType.Value) || !governmentTypeList4.Contains(country1.governmentType.Value) && !governmentTypeList4.Contains(country2.governmentType.Value)))
    {
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon24"] + ": -0.5", "#FF0000");
      num1 -= 0.5f;
    }
    if (gameState.activeDiplomacyButtons.ContainsKey(4) && gameState.activeDiplomacyButtons[4].ContainsKey(country))
    {
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon27"] + ": +2", "#006400");
      num1 += 2f;
    }
    if (gameState.activeDiplomacyButtons.ContainsKey(5) && gameState.activeDiplomacyButtons[5].ContainsKey(country))
    {
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon27"] + ": +1", "#006400");
      ++num1;
    }
    List<Countries> list = gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.activeInGame && cou.Value.economyAlliance == Country.EconomyAllianceType.TiesDisruption)).Select<KeyValuePair<Countries, Country>, Countries>((Func<KeyValuePair<Countries, Country>, Countries>) (cou => cou.Key)).ToList<Countries>();
    if (list != null)
    {
      int num4 = 0;
      List<Countries> source1 = new List<Countries>()
      {
        Countries.Estonia,
        Countries.Latvia,
        Countries.Litva
      };
      List<Countries> source2 = new List<Countries>()
      {
        Countries.Tajikistan,
        Countries.Turkmenia,
        Countries.Kazakhstan,
        Countries.Uzbekistan,
        Countries.Kyrgizia
      };
      int num5;
      if (list.Contains(Countries.Ukraine) && country == Countries.Moldavia)
      {
        puppetOf = country1.puppetOf;
        Countries countries = Countries.USSR;
        if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue)
        {
          num5 = country1.puppetType < Country.PuppetType.PuppetOtherState ? 1 : 0;
          goto label_46;
        }
      }
      num5 = 0;
label_46:
      if (num5 != 0)
        ++num4;
      int num6;
      if (list.Contains(Countries.Belorussia) && country == Countries.Litva)
      {
        puppetOf = country1.puppetOf;
        Countries countries = Countries.USSR;
        if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue)
        {
          num6 = country1.puppetType < Country.PuppetType.PuppetOtherState ? 1 : 0;
          goto label_52;
        }
      }
      num6 = 0;
label_52:
      if (num6 != 0)
        ++num4;
      int num7;
      if ((list.Contains(Countries.Litva) || list.Contains(Countries.Estonia) || list.Contains(Countries.Latvia)) && source1.Contains(country))
      {
        puppetOf = country1.puppetOf;
        Countries countries = Countries.USSR;
        if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue)
        {
          num7 = country1.puppetType < Country.PuppetType.PuppetOtherState ? 1 : 0;
          goto label_58;
        }
      }
      num7 = 0;
label_58:
      if (num7 != 0)
      {
        int num8 = 0;
        int num9;
        if (country != Countries.Litva)
        {
          puppetOf = gameState.countries[Countries.Litva].puppetOf;
          Countries countries = Countries.USSR;
          if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue)
          {
            num9 = gameState.countries[Countries.Litva].puppetType < Country.PuppetType.PuppetOtherState ? 1 : 0;
            goto label_63;
          }
        }
        num9 = 0;
label_63:
        if (num9 != 0)
          ++num8;
        int num10;
        if (country != Countries.Estonia)
        {
          puppetOf = gameState.countries[Countries.Estonia].puppetOf;
          Countries countries = Countries.USSR;
          if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue)
          {
            num10 = gameState.countries[Countries.Estonia].puppetType < Country.PuppetType.PuppetOtherState ? 1 : 0;
            goto label_69;
          }
        }
        num10 = 0;
label_69:
        if (num10 != 0)
          ++num8;
        int num11;
        if (country != Countries.Latvia)
        {
          puppetOf = gameState.countries[Countries.Latvia].puppetOf;
          Countries countries = Countries.USSR;
          if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue)
          {
            num11 = gameState.countries[Countries.Latvia].puppetType < Country.PuppetType.PuppetOtherState ? 1 : 0;
            goto label_75;
          }
        }
        num11 = 0;
label_75:
        if (num11 != 0)
          ++num8;
        num4 += num8;
      }
      if (source1.Where<Countries>((Func<Countries, bool>) (str => gameState.countries[str].activeInGame && gameState.countries[str].economyAlliance == Country.EconomyAllianceType.TiesDisruption)).Count<Countries>() > 2)
      {
        int num12;
        if (country == Countries.Ukraine)
        {
          puppetOf = country1.puppetOf;
          Countries countries = Countries.USSR;
          if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue)
          {
            num12 = country1.puppetType < Country.PuppetType.PuppetOtherState ? 1 : 0;
            goto label_83;
          }
        }
        num12 = 0;
label_83:
        if (num12 != 0)
          ++num4;
        int num13;
        if (country == Countries.Belorussia)
        {
          puppetOf = country1.puppetOf;
          Countries countries = Countries.USSR;
          if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue)
          {
            num13 = country1.puppetType < Country.PuppetType.PuppetOtherState ? 1 : 0;
            goto label_89;
          }
        }
        num13 = 0;
label_89:
        if (num13 != 0)
          ++num4;
      }
      if (source2.Where<Countries>((Func<Countries, bool>) (str => gameState.countries[str].activeInGame && gameState.countries[str].economyAlliance == Country.EconomyAllianceType.TiesDisruption && str != country)).Count<Countries>() > 0 && source2.Contains(country))
        num4 += source2.Where<Countries>((Func<Countries, bool>) (str => gameState.countries[str].activeInGame && gameState.countries[str].economyAlliance == Country.EconomyAllianceType.TiesDisruption && str != country)).Count<Countries>();
      if (num4 != 0)
        textFormatter1.AddText($"«{LanguageManager.inst["endings_names", "ending10"]}»: -{num4}", "#FF0000");
      num1 -= (float) num4;
    }
    if (country1.hasBase == Country.BasesType.Soviet && gameState.playerCountry == Countries.USSR)
    {
      float num14 = 0.0f;
      (AbstractDoctrine.DoctrineBranchType, int) valueTuple = (gameState.doctrines[DoctrineType.COMECON].branch, gameState.doctrines[DoctrineType.COMECON].number);
      switch (valueTuple.Item1)
      {
        case AbstractDoctrine.DoctrineBranchType.Central:
          if (valueTuple.Item2 == 0)
          {
            num14 = 0.0f;
            break;
          }
          break;
        case AbstractDoctrine.DoctrineBranchType.Top:
          switch (valueTuple.Item2)
          {
            case 0:
              num14 = 0.2f;
              break;
            case 1:
              num14 = 0.4f;
              break;
            case 2:
              num14 = 0.6f;
              break;
          }
          break;
        case AbstractDoctrine.DoctrineBranchType.Bottom:
          switch (valueTuple.Item2)
          {
            case 0:
              num14 = -0.3f;
              break;
            case 1:
              num14 = -0.6f;
              break;
          }
          break;
      }
      int num15;
      if (gameState.countries[country].zoneType == Country.ZoneType.EastEurope || gameState.countries[country].zoneType == Country.ZoneType.SovietZone)
      {
        puppetOf = gameState.countries[country].puppetOf;
        Countries countries = Countries.USSR;
        num15 = !(puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue) ? 1 : 0;
      }
      else
        num15 = 0;
      if (num15 != 0)
        num14 = -2f;
      textFormatter1.AddText($"{string.Format(LanguageManager.inst["map_left_panel_ui", "military_base"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true))}: {num14:+0.##;-0.##}", (double) num14 >= 0.0 ? "#006400" : "#FF0000");
      num1 += num14;
    }
    if (country1.trade)
    {
      float num16 = 0.0f;
      switch (gameState.countries[country].zoneType)
      {
        case Country.ZoneType.SouthEastAsia:
        case Country.ZoneType.Africa:
        case Country.ZoneType.SouthAmerica:
        case Country.ZoneType.Oceania:
          if (gameState.doctrines[DoctrineType.InternationalDepartment].branch == AbstractDoctrine.DoctrineBranchType.BottomLeft && gameState.doctrines[DoctrineType.InternationalDepartment].number == 1)
          {
            --num16;
            break;
          }
          break;
        case Country.ZoneType.NorthAmerica:
          if (country != Countries.Mexica && country != Countries.Canada && country != Countries.USA && gameState.doctrines[DoctrineType.InternationalDepartment].branch == AbstractDoctrine.DoctrineBranchType.BottomLeft && gameState.doctrines[DoctrineType.InternationalDepartment].number == 1)
          {
            --num16;
            break;
          }
          break;
      }
      if ((double) num16 != 0.0)
        textFormatter1.AddText($"{LanguageManager.inst["icon_desc", "icon33"]}: {num16:+0.##;-0.##}", (double) num16 >= 0.0 ? "#006400" : "#FF0000");
      num1 += num16;
    }
    if (country1.militaryAlliance != Country.MilitaryAllianceType.None)
    {
      float num17 = 0.0f;
      switch (country1.militaryAlliance)
      {
        case Country.MilitaryAllianceType.PartnershipNATO:
          if (country2.militaryAlliance != Country.MilitaryAllianceType.NATO || country2.militaryAlliance != Country.MilitaryAllianceType.PartnershipNATO)
          {
            float num18 = num17 - 1f;
            break;
          }
          break;
        case Country.MilitaryAllianceType.WarsawPact:
          if (country2.militaryAlliance == Country.MilitaryAllianceType.WarsawPact)
          {
            (AbstractDoctrine.DoctrineBranchType, int) valueTuple = (gameState.doctrines[DoctrineType.COMECON].branch, gameState.doctrines[DoctrineType.COMECON].number);
            switch (valueTuple.Item1)
            {
              case AbstractDoctrine.DoctrineBranchType.Central:
                if (valueTuple.Item2 == 0)
                {
                  num17 = -0.2f;
                  break;
                }
                break;
              case AbstractDoctrine.DoctrineBranchType.Top:
                switch (valueTuple.Item2)
                {
                  case 0:
                    num17 = -0.2f;
                    break;
                  case 1:
                    num17 = -0.4f;
                    break;
                  case 2:
                    num17 = -0.6f;
                    break;
                }
                break;
              case AbstractDoctrine.DoctrineBranchType.Bottom:
                switch (valueTuple.Item2)
                {
                  case 0:
                    num17 = -0.4f;
                    break;
                  case 1:
                    num17 = -0.6f;
                    break;
                }
                break;
            }
          }
          num1 += num17;
          if ((double) num17 != 0.0)
          {
            textFormatter1.AddText($"{LanguageManager.inst["icon_desc", "icon25"]} {CountryUtils.GetMilitaryAllianceName(gameState, country1.militaryAlliance)}: {num17:+0.##;-0.##}", (double) num17 >= 0.0 ? "#006400" : "#FF0000");
            break;
          }
          break;
      }
    }
    if (country1.leaderType != Country.LeaderType.None)
    {
      float num19 = 0.0f;
      switch (country1.leaderType)
      {
        case Country.LeaderType.Loyal:
          if ((double) country1.RelationshipWithPlayer < 75.0)
          {
            ++num19;
            break;
          }
          break;
        case Country.LeaderType.Moderate:
          if ((double) country1.RelationshipWithPlayer < 50.0)
          {
            num19 += 0.5f;
            break;
          }
          break;
        case Country.LeaderType.Separatist:
          if ((double) country1.RelationshipWithPlayer > 25.0)
          {
            --num19;
            break;
          }
          break;
      }
      num1 += num19;
      if ((double) num19 != 0.0)
        textFormatter1.AddText($"{LanguageManager.inst["leader_type_name", "Icon_name"]}: {num19:+0.##;-0.##}", (double) num19 >= 0.0 ? "#006400" : "#FF0000");
    }
    puppetOf = country1.puppetOf;
    Countries countries1 = Countries.USSR;
    if (puppetOf.GetValueOrDefault() == countries1 & puppetOf.HasValue && gameState.playerCountry == Countries.USSR && country1.puppetType == Country.PuppetType.UnderInfluence)
    {
      textFormatter1.AddText(string.Format(LanguageManager.inst["puppet_type_name", "UnderInfluence"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true)) + ": +0.1", "#006400");
      num1 += 0.1f;
    }
    else
    {
      puppetOf = country1.puppetOf;
      Countries countries2 = Countries.USSR;
      if (puppetOf.GetValueOrDefault() == countries2 & puppetOf.HasValue && gameState.playerCountry == Countries.USSR && country1.puppetType == Country.PuppetType.PuppetOtherState)
      {
        textFormatter1.AddText(string.Format(LanguageManager.inst["puppet_type_name", "UnderInfluence"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true)) + ": +0.2", "#006400");
        num1 += 0.2f;
      }
    }
    puppetOf = country1.puppetOf;
    Countries countries3 = Countries.USSR;
    if (puppetOf.GetValueOrDefault() == countries3 & puppetOf.HasValue && gameState.playerCountry == Countries.USSR && country1.puppetType == Country.PuppetType.InnerState)
    {
      textFormatter1.AddText(string.Format(LanguageManager.inst["puppet_type_name", "InnerState"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true)) + ": +0.2", "#006400");
      num1 += 0.2f;
    }
    else
    {
      puppetOf = country1.puppetOf;
      Countries countries4 = Countries.USSR;
      if (puppetOf.GetValueOrDefault() == countries4 & puppetOf.HasValue && gameState.playerCountry == Countries.USSR && country1.puppetType == Country.PuppetType.EqualState && gameState.doctrines[DoctrineType.StateStructure].branch != AbstractDoctrine.DoctrineBranchType.Bottom)
      {
        textFormatter1.AddText(string.Format(LanguageManager.inst["puppet_type_name", "InnerState"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true)) + ": -0.5", "#FF0000");
        num1 -= 0.5f;
      }
    }
    if (gameState.activeDiplomacyButtons.ContainsKey(25))
    {
      List<Countries> countriesList1 = new List<Countries>()
      {
        Countries.Estonia,
        Countries.Latvia,
        Countries.Litva
      };
      List<Countries> countriesList2 = new List<Countries>()
      {
        Countries.Moldavia,
        Countries.Russia,
        Countries.Ukraine,
        Countries.Belorussia
      };
      List<Countries> countriesList3 = new List<Countries>()
      {
        Countries.Azerbaijan,
        Countries.Armenia,
        Countries.Georgia
      };
      List<Countries> countriesList4 = new List<Countries>()
      {
        Countries.Tajikistan,
        Countries.Turkmenia,
        Countries.Kazakhstan,
        Countries.Uzbekistan,
        Countries.Kyrgizia
      };
      int num20 = 0;
      if (gameState.activeDiplomacyButtons[25].ContainsKey(country))
        --num20;
      foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (c => c.Key != country && c.Value.activeInGame && gameState.activeDiplomacyButtons.ContainsKey(25) && gameState.activeDiplomacyButtons[25].ContainsKey(c.Key))))
      {
        if (countriesList4.Contains(keyValuePair.Key) && countriesList4.Contains(country))
          --num20;
        else if (countriesList2.Contains(keyValuePair.Key) && countriesList2.Contains(country))
          --num20;
        else if (countriesList3.Contains(keyValuePair.Key) && countriesList3.Contains(country))
          --num20;
        else if (countriesList1.Contains(keyValuePair.Key) && countriesList1.Contains(country))
          --num20;
      }
      if (num20 < 0)
        textFormatter1.AddText($"{LanguageManager.inst["icon_desc", "icon55"]}: {num20}", "#FF0000");
      num1 += (float) num20;
    }
    bool flag = false;
    if (gameState.gameStateHistory.lastRelationsValuesChangesSources.ContainsKey(country))
    {
      foreach (KeyValuePair<StatisticImpactSourceType, float> keyValuePair in gameState.gameStateHistory.lastRelationsValuesChangesSources[country])
      {
        if (keyValuePair.Key == StatisticImpactSourceType.Diplomacy)
        {
          if ((double) keyValuePair.Value - (double) num1 != 0.0)
          {
            flag = true;
            textFormatter1.AddText($"{LanguageManager.inst["statistic_impact_source_name", keyValuePair.Key.ToString()]}: {(ValueType) (float) ((double) keyValuePair.Value - (double) num1):+0.##;-0.##}", (double) keyValuePair.Value - (double) num1 > 0.0 ? "#006400" : "#FF0000");
          }
        }
        else if ((double) keyValuePair.Value != 0.0)
        {
          flag = true;
          textFormatter1.AddText($"{LanguageManager.inst["statistic_impact_source_name", keyValuePair.Key.ToString()]}: {keyValuePair.Value:+0.##;-0.##}", (double) keyValuePair.Value > 0.0 ? "#006400" : "#FF0000");
        }
      }
    }
    if ((double) num1 == 0.0 && !flag)
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon26"] ?? "", "#FF0000");
    textFormatter3.AddLine(textFormatter1.FinalizeInColor());
    return country1.puppetType == Country.PuppetType.Occupied ? textFormatter2.Finalize() : textFormatter3.Finalize();
  }

  public static string GetLibVectorDescription(GameState gameState, Countries country)
  {
    Backend.Gamedesign.Utils.TextFormatter.TextFormatter textFormatter1 = Backend.Gamedesign.Utils.TextFormatter.TextFormatter.StartCreation();
    Backend.Gamedesign.Utils.TextFormatter.TextFormatter textFormatter2 = Backend.Gamedesign.Utils.TextFormatter.TextFormatter.StartCreation();
    textFormatter2.AddText(LanguageManager.inst["icon_desc", "icon_infl"], "blue");
    Country country1 = gameState.countries[country];
    Country country2 = gameState.countries[gameState.playerCountry];
    float num1 = 0.0f;
    List<Country.GovernmentType> governmentTypeList1 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LeftNationalism,
      Country.GovernmentType.ConservativeSocialism,
      Country.GovernmentType.SocialismNationalSpecific,
      Country.GovernmentType.LeftPragmatism
    };
    List<Country.GovernmentType> governmentTypeList2 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalConservative,
      Country.GovernmentType.PopulistConservative,
      Country.GovernmentType.RightPopulism,
      Country.GovernmentType.ReactonaryAuthoritarian,
      Country.GovernmentType.MarketAuthoritarian
    };
    List<Country.GovernmentType> governmentTypeList3 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.DemocraticSocialism,
      Country.GovernmentType.SocialistReformism,
      Country.GovernmentType.SocialDemocracy,
      Country.GovernmentType.ConstructingCommunism
    };
    List<Country.GovernmentType> governmentTypeList4 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalCorporativism,
      Country.GovernmentType.LiberalProgressive,
      Country.GovernmentType.ClassicalLiberalism,
      Country.GovernmentType.Centrism
    };
    int num2;
    if (country1.activeInGame)
    {
      Country.GovernmentType? governmentType1 = country1.governmentType;
      Country.GovernmentType? governmentType2 = country2.governmentType;
      num2 = governmentType1.GetValueOrDefault() == governmentType2.GetValueOrDefault() & governmentType1.HasValue == governmentType2.HasValue ? 1 : 0;
    }
    else
      num2 = 0;
    if (num2 != 0)
    {
      Countries? puppetOf = country1.puppetOf;
      Countries playerCountry = gameState.playerCountry;
      if (!(puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue))
      {
        if (CountryUtils.ShouldLibVectorBeDisplayed(gameState, country))
        {
          textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon24"] + ": -0.25", "#006400");
          num1 -= 0.25f;
        }
      }
      else if (CountryUtils.ShouldLibVectorBeDisplayed(gameState, country))
      {
        textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon24"] + ": -0.5", "#006400");
        num1 -= 0.5f;
      }
    }
    else if (country1.activeInGame && (governmentTypeList1.Contains(country1.governmentType.Value) && governmentTypeList1.Contains(country2.governmentType.Value) || governmentTypeList2.Contains(country1.governmentType.Value) && governmentTypeList2.Contains(country2.governmentType.Value) || governmentTypeList3.Contains(country1.governmentType.Value) && governmentTypeList3.Contains(country2.governmentType.Value) || governmentTypeList4.Contains(country1.governmentType.Value) && governmentTypeList4.Contains(country2.governmentType.Value)))
    {
      Countries? puppetOf = country1.puppetOf;
      Countries playerCountry = gameState.playerCountry;
      if (!(puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue))
      {
        if (CountryUtils.ShouldLibVectorBeDisplayed(gameState, country))
        {
          textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon24"] + ": -0.1", "#006400");
          num1 -= 0.1f;
        }
      }
      else if (CountryUtils.ShouldLibVectorBeDisplayed(gameState, country))
      {
        textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon24"] + ": -0.2", "#006400");
        num1 -= 0.2f;
      }
    }
    if (gameState.activeDiplomacyButtons.ContainsKey(5) && gameState.activeDiplomacyButtons[5].ContainsKey(country))
    {
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon27"] + ": -0.5", "#006400");
      num1 -= 0.5f;
    }
    if (country1.hasBase == Country.BasesType.Soviet && gameState.playerCountry == Countries.USSR && gameState.activeDiplomacyButtons.ContainsKey(3) && gameState.activeDiplomacyButtons[3].ContainsKey(country) && gameState.activeDiplomacyButtons[3][country].level <= 0)
    {
      textFormatter1.AddText(string.Format(LanguageManager.inst["map_left_panel_ui", "military_base"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true)) + ": -0.4", "#006400");
      num1 -= 0.4f;
    }
    if (country2.militaryAlliance == Country.MilitaryAllianceType.WarsawPact && country1.militaryAlliance == Country.MilitaryAllianceType.WarsawPact)
    {
      float num3 = 0.0f;
      (AbstractDoctrine.DoctrineBranchType, int) valueTuple = (gameState.doctrines[DoctrineType.COMECON].branch, gameState.doctrines[DoctrineType.COMECON].number);
      switch (valueTuple.Item1)
      {
        case AbstractDoctrine.DoctrineBranchType.Central:
          if (valueTuple.Item2 == 0)
          {
            num3 = 0.2f;
            break;
          }
          break;
        case AbstractDoctrine.DoctrineBranchType.Top:
          switch (valueTuple.Item2)
          {
            case 0:
              num3 = -0.2f;
              break;
            case 1:
              num3 = -0.4f;
              break;
            case 2:
              num3 = -0.6f;
              break;
          }
          break;
        case AbstractDoctrine.DoctrineBranchType.Bottom:
          switch (valueTuple.Item2)
          {
            case 0:
              num3 = 0.4f;
              break;
            case 1:
              num3 = 0.6f;
              break;
          }
          break;
      }
      num1 += num3;
      if ((double) num3 != 0.0)
        textFormatter1.AddText($"{LanguageManager.inst["icon_desc", "icon25"]} {CountryUtils.GetMilitaryAllianceName(gameState, country1.militaryAlliance)}: {num3:+0.##;-0.##}", (double) num3 <= 0.0 ? "#006400" : "#FF0000");
    }
    Countries? puppetOf1 = country1.puppetOf;
    Countries countries1 = Countries.USSR;
    if (puppetOf1.GetValueOrDefault() == countries1 & puppetOf1.HasValue && gameState.playerCountry == Countries.USSR && country1.puppetType == Country.PuppetType.UnderInfluence)
    {
      textFormatter1.AddText(string.Format(LanguageManager.inst["puppet_type_name", "UnderInfluence"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true)) + ": -0.1", "#006400");
      num1 -= 0.1f;
    }
    else
    {
      puppetOf1 = country1.puppetOf;
      Countries countries2 = Countries.USSR;
      if (puppetOf1.GetValueOrDefault() == countries2 & puppetOf1.HasValue && gameState.playerCountry == Countries.USSR && country1.puppetType == Country.PuppetType.PuppetOtherState)
      {
        textFormatter1.AddText(string.Format(LanguageManager.inst["puppet_type_name", "UnderInfluence"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true)) + ": -0.5", "#006400");
        num1 -= 0.5f;
      }
    }
    bool flag = false;
    if (gameState.gameStateHistory.lastLiberalizationVectorValuesChangesSources.ContainsKey(country))
    {
      foreach (KeyValuePair<StatisticImpactSourceType, float> keyValuePair in gameState.gameStateHistory.lastLiberalizationVectorValuesChangesSources[country])
      {
        if (keyValuePair.Key == StatisticImpactSourceType.Diplomacy)
        {
          if ((double) keyValuePair.Value - (double) num1 != 0.0)
          {
            flag = true;
            textFormatter1.AddText($"{LanguageManager.inst["statistic_impact_source_name", keyValuePair.Key.ToString()]}: {(ValueType) (float) ((double) keyValuePair.Value - (double) num1):+0.##;-0.##}", (double) keyValuePair.Value - (double) num1 < 0.0 ? "#006400" : "#FF0000");
          }
        }
        else if ((double) keyValuePair.Value != 0.0)
        {
          flag = true;
          textFormatter1.AddText($"{LanguageManager.inst["statistic_impact_source_name", keyValuePair.Key.ToString()]}: {keyValuePair.Value:+0.##;-0.##}", (double) keyValuePair.Value < 0.0 ? "#006400" : "#FF0000");
        }
      }
    }
    if ((double) num1 == 0.0 && !flag)
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon26"] ?? "", "#FF0000");
    textFormatter2.AddLine(textFormatter1.FinalizeInColor());
    return textFormatter2.Finalize();
  }

  public static string GetDiplomacyVectorDescription(GameState gameState, Countries country)
  {
    Backend.Gamedesign.Utils.TextFormatter.TextFormatter textFormatter1 = Backend.Gamedesign.Utils.TextFormatter.TextFormatter.StartCreation();
    Backend.Gamedesign.Utils.TextFormatter.TextFormatter textFormatter2 = Backend.Gamedesign.Utils.TextFormatter.TextFormatter.StartCreation();
    Backend.Gamedesign.Utils.TextFormatter.TextFormatter textFormatter3 = Backend.Gamedesign.Utils.TextFormatter.TextFormatter.StartCreation();
    Country country1 = gameState.countries[country];
    Country country2 = gameState.countries[gameState.playerCountry];
    float num1 = 0.0f;
    List<Country.GovernmentType> governmentTypeList1 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalConservative,
      Country.GovernmentType.PopulistConservative,
      Country.GovernmentType.RightPopulism,
      Country.GovernmentType.ReactonaryAuthoritarian,
      Country.GovernmentType.MarketAuthoritarian,
      Country.GovernmentType.DemocraticSocialism,
      Country.GovernmentType.SocialistReformism,
      Country.GovernmentType.SocialDemocracy,
      Country.GovernmentType.LiberalCorporativism,
      Country.GovernmentType.LiberalProgressive,
      Country.GovernmentType.ClassicalLiberalism,
      Country.GovernmentType.Centrism
    };
    List<Country.GovernmentType> governmentTypeList2 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalConservative,
      Country.GovernmentType.DemocraticSocialism,
      Country.GovernmentType.SocialistReformism,
      Country.GovernmentType.SocialDemocracy,
      Country.GovernmentType.LiberalCorporativism,
      Country.GovernmentType.LiberalProgressive,
      Country.GovernmentType.ClassicalLiberalism,
      Country.GovernmentType.Centrism
    };
    Countries? puppetOf1;
    if (country1.treasonTimer > 0 || country1.economyAlliance == Country.EconomyAllianceType.TiesDisruption || country1.economyAlliance == Country.EconomyAllianceType.None && country1.zoneType == Country.ZoneType.EastEurope && (governmentTypeList1.Contains(country1.governmentType.Value) || governmentTypeList2.Contains(country1.governmentType.Value)))
    {
      if (gameState.countries[Countries.USA].militaryAlliance == Country.MilitaryAllianceType.NATO)
      {
        if (country1.hasBase == Country.BasesType.Soviet)
          textFormatter1.AddText(string.Format(LanguageManager.inst["icon_desc", "icon48"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true)), "#006400");
        else if (country1.treasonTimer > 0)
        {
          if (!country1.puppetOf.HasValue)
            textFormatter1.AddText(string.Format(LanguageManager.inst["icon_desc", "icon45"], (object) CountryUtils.GetCountryName(gameState, Countries.USA, true), (object) country1.treasonTimer), "#FF0000");
          if (country1.militaryAlliance != Country.MilitaryAllianceType.PartnershipNATO)
          {
            Backend.Gamedesign.Utils.TextFormatter.TextFormatter textFormatter4 = textFormatter1;
            string format = LanguageManager.inst["icon_desc", "icon46"];
            string militaryAllianceName = CountryUtils.GetMilitaryAllianceName(gameState, Country.MilitaryAllianceType.PartnershipNATO);
            puppetOf1 = country1.puppetOf;
            Countries countries = Countries.USA;
            // ISSUE: variable of a boxed type
            __Boxed<int> local = (ValueType) (puppetOf1.GetValueOrDefault() == countries & puppetOf1.HasValue ? country1.treasonTimer : country1.treasonTimer + 6);
            string first_text = string.Format(format, (object) militaryAllianceName, (object) local);
            textFormatter4.AddText(first_text, "#FF0000");
          }
          if (country1.militaryAlliance != 0)
          {
            Backend.Gamedesign.Utils.TextFormatter.TextFormatter textFormatter5 = textFormatter1;
            string format = LanguageManager.inst["icon_desc", "icon46"];
            string militaryAllianceName = CountryUtils.GetMilitaryAllianceName(gameState, Country.MilitaryAllianceType.NATO);
            int num2;
            if (country1.militaryAlliance != Country.MilitaryAllianceType.PartnershipNATO)
            {
              puppetOf1 = country1.puppetOf;
              Countries countries = Countries.USA;
              num2 = !(puppetOf1.GetValueOrDefault() == countries & puppetOf1.HasValue) ? country1.treasonTimer + 12 : country1.treasonTimer + 6;
            }
            else
              num2 = country1.treasonTimer;
            // ISSUE: variable of a boxed type
            __Boxed<int> local = (ValueType) num2;
            string first_text = string.Format(format, (object) militaryAllianceName, (object) local);
            textFormatter5.AddText(first_text, "#FF0000");
          }
        }
        else if (!country1.puppetOf.HasValue)
          textFormatter1.AddText(string.Format(LanguageManager.inst["icon_desc", "icon49"], (object) CountryUtils.GetCountryName(gameState, Countries.USA, true)), "#FF0000");
        else if (country1.militaryAlliance != Country.MilitaryAllianceType.PartnershipNATO)
          textFormatter1.AddText(string.Format(LanguageManager.inst["icon_desc", "icon50"], (object) CountryUtils.GetMilitaryAllianceName(gameState, Country.MilitaryAllianceType.PartnershipNATO)), "#FF0000");
        else if (country1.militaryAlliance != 0)
          textFormatter1.AddText(string.Format(LanguageManager.inst["icon_desc", "icon50"], (object) CountryUtils.GetMilitaryAllianceName(gameState, Country.MilitaryAllianceType.NATO)), "#FF0000");
      }
      else if (gameState.countries[Countries.Luxemburg].economyAlliance == Country.EconomyAllianceType.EU && gameState.countries[Countries.USSR].economyAlliance != 0)
      {
        if (country1.hasBase == Country.BasesType.Soviet)
          textFormatter1.AddText(string.Format(LanguageManager.inst["icon_desc", "icon48"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true)), "#006400");
        else if (country1.treasonTimer > 0)
        {
          if (country1.economyAlliance != 0)
            textFormatter1.AddText(string.Format(LanguageManager.inst["icon_desc", "icon47"], (object) CountryUtils.GetEconomicAllianceName(gameState, Country.EconomyAllianceType.EU), (object) country1.treasonTimer), "#FF0000");
        }
        else if (country1.economyAlliance != 0)
          textFormatter1.AddText(string.Format(LanguageManager.inst["icon_desc", "icon50"], (object) CountryUtils.GetEconomicAllianceName(gameState, Country.EconomyAllianceType.EU)), "#FF0000");
      }
    }
    if (country1.puppetType == Country.PuppetType.Occupied)
    {
      switch (country1.puppetOf.Value)
      {
        case Countries.USSR:
          if (gameState.playerCountry == Countries.USSR)
          {
            textFormatter2.AddText($"— {LanguageManager.inst["icon_desc", "icon4"]}: 100 ({string.Format(LanguageManager.inst["puppet_type_name", "Occupied"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true))})", "#006400");
            break;
          }
          textFormatter2.AddText($"— {LanguageManager.inst["icon_desc", "icon19"]} {CountryUtils.GetCountryName(gameState, Countries.USSR)} ({string.Format(LanguageManager.inst["puppet_type_name", "Occupied"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true))})", "#FF0000");
          break;
        case Countries.USA:
          textFormatter2.AddText($"— {LanguageManager.inst["icon_desc", "icon19"]} {CountryUtils.GetCountryName(gameState, Countries.USA)} ({string.Format(LanguageManager.inst["puppet_type_name", "Occupied"], (object) CountryUtils.GetCountryName(gameState, Countries.USA, true))})", "#FF0000");
          break;
        default:
          textFormatter2.AddText($"— {LanguageManager.inst["icon_desc", "icon19"]} {CountryUtils.GetCountryName(gameState, country1.puppetOf.Value)} ({string.Format(LanguageManager.inst["puppet_type_name", "Occupied"], (object) CountryUtils.GetCountryName(gameState, country1.puppetOf.Value))})", "#FF0000");
          break;
      }
    }
    else
    {
      int num3;
      if (country1.puppetType == Country.PuppetType.PuppetOtherState)
      {
        puppetOf1 = country1.puppetOf;
        Countries countries1 = Countries.USA;
        if (!(puppetOf1.GetValueOrDefault() == countries1 & puppetOf1.HasValue))
        {
          puppetOf1 = country1.puppetOf;
          Countries countries2 = Countries.USSR;
          num3 = !(puppetOf1.GetValueOrDefault() == countries2 & puppetOf1.HasValue) ? 1 : 0;
          goto label_45;
        }
      }
      num3 = 0;
label_45:
      if (num3 != 0)
        textFormatter2.AddText($"— {LanguageManager.inst["icon_desc", "icon19"]} {CountryUtils.GetCountryName(gameState, country1.puppetOf.Value)} ({string.Format(LanguageManager.inst["puppet_type_name", "PuppetOtherState"], (object) CountryUtils.GetCountryName(gameState, country1.puppetOf.Value))})", "#FF0000");
    }
    puppetOf1 = country1.puppetOf;
    Countries countries3 = Countries.USA;
    if (puppetOf1.GetValueOrDefault() == countries3 & puppetOf1.HasValue && country1.puppetType == Country.PuppetType.PuppetOtherState)
      textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon3"]}: 25 ({string.Format(LanguageManager.inst["puppet_type_name", "PuppetOtherState"], (object) CountryUtils.GetCountryName(gameState, Countries.USA, true))})", "#FF0000");
    else if (country1.economyAlliance == Country.EconomyAllianceType.WAFT)
    {
      textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon3"]}: 50 ({LanguageManager.inst["icon_desc", "icon25"]} {CountryUtils.GetEconomicAllianceName(gameState, Country.EconomyAllianceType.WAFT)})", "#FF0000");
    }
    else
    {
      int num4;
      if (country1.economyAlliance == Country.EconomyAllianceType.EU && country2.economyAlliance != Country.EconomyAllianceType.EU)
      {
        puppetOf1 = country1.puppetOf;
        Countries countries4 = Countries.USSR;
        num4 = puppetOf1.GetValueOrDefault() == countries4 & puppetOf1.HasValue ? 1 : (country1.puppetType != Country.PuppetType.PuppetOtherState ? 1 : 0);
      }
      else
        num4 = 0;
      if (num4 != 0)
        textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon3"]}: 60 ({LanguageManager.inst["icon_desc", "icon25"]} {CountryUtils.GetEconomicAllianceName(gameState, Country.EconomyAllianceType.EU)})", "#FF0000");
      else if (country1.militaryAlliance == Country.MilitaryAllianceType.OfficialNeutrality)
        textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon3"]}: 75 ({LanguageManager.inst["diplomacy_country_icons", "neutral"]})", "#FF0000");
      else if (country1.leaderType == Country.LeaderType.Separatist)
        textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon3"]}: 75 ({LanguageManager.inst["leader_type_name", "Icon_name"]}: {LanguageManager.inst["leader_type_name", "Separatist"]})", "#FF0000");
      else if (country1.economyAlliance == Country.EconomyAllianceType.TiesDisruption)
        textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon3"]}: 90 ({CountryUtils.GetEconomicAllianceName(gameState, Country.EconomyAllianceType.TiesDisruption)})", "#FF0000");
    }
    puppetOf1 = country1.puppetOf;
    Countries countries5 = Countries.USSR;
    if (puppetOf1.GetValueOrDefault() == countries5 & puppetOf1.HasValue && country1.puppetType == Country.PuppetType.PuppetOtherState && gameState.playerCountry == Countries.USSR)
    {
      textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon4"]}: 75 ({string.Format(LanguageManager.inst["puppet_type_name", "PuppetOtherState"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true))})", "#006400");
    }
    else
    {
      puppetOf1 = country1.puppetOf;
      Countries playerCountry1 = gameState.playerCountry;
      if (puppetOf1.GetValueOrDefault() == playerCountry1 & puppetOf1.HasValue && country1.puppetType == Country.PuppetType.Autonomy)
      {
        textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon4"]}: 75 ({string.Format(LanguageManager.inst["puppet_type_name", "Autonomy"], (object) CountryUtils.GetCountryName(gameState, gameState.playerCountry, true))})", "#006400");
      }
      else
      {
        puppetOf1 = country1.puppetOf;
        Countries playerCountry2 = gameState.playerCountry;
        if (puppetOf1.GetValueOrDefault() == playerCountry2 & puppetOf1.HasValue && country1.puppetType == Country.PuppetType.InnerState)
        {
          textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon4"]}: 50 ({string.Format(LanguageManager.inst["puppet_type_name", "InnerState"], (object) CountryUtils.GetCountryName(gameState, gameState.playerCountry, true))})", "#006400");
        }
        else
        {
          puppetOf1 = country1.puppetOf;
          Countries playerCountry3 = gameState.playerCountry;
          if (puppetOf1.GetValueOrDefault() == playerCountry3 & puppetOf1.HasValue && country1.puppetType == Country.PuppetType.EqualState)
            textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon4"]}: 25 ({string.Format(LanguageManager.inst["puppet_type_name", "EqualState"], (object) CountryUtils.GetCountryName(gameState, gameState.playerCountry, true))})", "#006400");
          else if (country1.militaryAlliance == Country.MilitaryAllianceType.OfficialNeutrality)
          {
            textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon4"]}: 25 ({LanguageManager.inst["diplomacy_country_icons", "neutral"]})", "#006400");
          }
          else
          {
            int num5;
            if (country1.economyAlliance == Country.EconomyAllianceType.EU)
            {
              puppetOf1 = gameState.countries[country].puppetOf;
              Countries countries6 = Countries.USSR;
              num5 = puppetOf1.GetValueOrDefault() == countries6 & puppetOf1.HasValue ? 1 : (gameState.countries[country].puppetType != Country.PuppetType.PuppetOtherState ? 1 : 0);
            }
            else
              num5 = 0;
            if (num5 != 0)
              textFormatter3.AddText($"— {LanguageManager.inst["icon_desc", "icon4"]}: 10 ({LanguageManager.inst["icon_desc", "icon25"]} {CountryUtils.GetEconomicAllianceName(gameState, Country.EconomyAllianceType.EU)})", "#006400");
          }
        }
      }
    }
    List<Country.GovernmentType> governmentTypeList3 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LeftNationalism,
      Country.GovernmentType.ConservativeSocialism,
      Country.GovernmentType.SocialismNationalSpecific,
      Country.GovernmentType.LeftPragmatism
    };
    List<Country.GovernmentType> governmentTypeList4 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalConservative,
      Country.GovernmentType.PopulistConservative,
      Country.GovernmentType.RightPopulism,
      Country.GovernmentType.ReactonaryAuthoritarian,
      Country.GovernmentType.MarketAuthoritarian
    };
    List<Country.GovernmentType> governmentTypeList5 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.DemocraticSocialism,
      Country.GovernmentType.SocialistReformism,
      Country.GovernmentType.SocialDemocracy,
      Country.GovernmentType.ConstructingCommunism
    };
    List<Country.GovernmentType> governmentTypeList6 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalCorporativism,
      Country.GovernmentType.LiberalProgressive,
      Country.GovernmentType.ClassicalLiberalism,
      Country.GovernmentType.Centrism
    };
    textFormatter3.AddText(LanguageManager.inst["icon_desc", "icon_infl"], "blue");
    int num6;
    if (country1.activeInGame)
    {
      Country.GovernmentType? governmentType1 = country1.governmentType;
      Country.GovernmentType? governmentType2 = country2.governmentType;
      num6 = governmentType1.GetValueOrDefault() == governmentType2.GetValueOrDefault() & governmentType1.HasValue == governmentType2.HasValue ? 1 : 0;
    }
    else
      num6 = 0;
    if (num6 != 0)
    {
      puppetOf1 = country1.puppetOf;
      Countries playerCountry = gameState.playerCountry;
      if (!(puppetOf1.GetValueOrDefault() == playerCountry & puppetOf1.HasValue))
      {
        textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon24"] + ": +0.5", "#006400");
        num1 += 0.5f;
      }
      else
      {
        textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon24"] + ": +1", "#006400");
        ++num1;
      }
    }
    else if (country1.activeInGame && (governmentTypeList3.Contains(country1.governmentType.Value) && governmentTypeList3.Contains(country2.governmentType.Value) || governmentTypeList4.Contains(country1.governmentType.Value) && governmentTypeList4.Contains(country2.governmentType.Value) || governmentTypeList5.Contains(country1.governmentType.Value) && governmentTypeList5.Contains(country2.governmentType.Value) || governmentTypeList6.Contains(country1.governmentType.Value) && governmentTypeList6.Contains(country2.governmentType.Value)))
    {
      puppetOf1 = country1.puppetOf;
      Countries playerCountry = gameState.playerCountry;
      if (!(puppetOf1.GetValueOrDefault() == playerCountry & puppetOf1.HasValue))
      {
        textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon24"] + ": +0.25", "#006400");
        num1 += 0.25f;
      }
      else
      {
        textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon24"] + ": +0.5", "#006400");
        num1 += 0.5f;
      }
    }
    else if (country1.activeInGame && (!governmentTypeList3.Contains(country1.governmentType.Value) && !governmentTypeList5.Contains(country1.governmentType.Value) || !governmentTypeList5.Contains(country2.governmentType.Value) && !governmentTypeList3.Contains(country2.governmentType.Value)) && (!governmentTypeList4.Contains(country1.governmentType.Value) && !governmentTypeList4.Contains(country2.governmentType.Value) || !governmentTypeList6.Contains(country1.governmentType.Value) && !governmentTypeList6.Contains(country2.governmentType.Value)))
    {
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon24"] + ": -0.5", "#FF0000");
      num1 -= 0.5f;
    }
    if (gameState.activeDiplomacyButtons.ContainsKey(4) && gameState.activeDiplomacyButtons[4].ContainsKey(country))
    {
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon27"] + ": +2", "#006400");
      num1 += 2f;
    }
    if (gameState.activeDiplomacyButtons.ContainsKey(5) && gameState.activeDiplomacyButtons[5].ContainsKey(country))
    {
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon27"] + ": +0.5", "#006400");
      num1 += 0.5f;
    }
    if ((double) country1.ForeignPolicyVector < 75.0 && gameState.activeDiplomacyButtons.ContainsKey(8) && gameState.activeDiplomacyButtons[8].ContainsKey(country))
    {
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon29"] + ": +1", "#006400");
      ++num1;
    }
    if ((double) country1.ForeignPolicyVector < 75.0 && gameState.activeDiplomacyButtons.ContainsKey(9) && gameState.activeDiplomacyButtons[9].ContainsKey(country))
    {
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon30"] + ": +1", "#006400");
      ++num1;
    }
    if (gameState.activeDiplomacyButtons.ContainsKey(13) && gameState.activeDiplomacyButtons[13].ContainsKey(country))
    {
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon31"] + ": +0.2", "#006400");
      num1 += 0.2f;
    }
    if (gameState.activeDiplomacyButtons.ContainsKey(25) && gameState.activeDiplomacyButtons[25].ContainsKey(country))
    {
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon55"] + ": +2", "#006400");
      num1 += 2f;
    }
    if (gameState.activeDiplomacyButtons.ContainsKey(26) && gameState.activeDiplomacyButtons[26].ContainsKey(country))
    {
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon56"] + ": +1", "#006400");
      ++num1;
    }
    if (country1.economyAlliance == Country.EconomyAllianceType.TiesDisruption)
    {
      textFormatter1.AddText($"«{LanguageManager.inst["endings_names", "ending10"]}»: -1", "#FF0000");
      --num1;
    }
    if (gameState.activeDiplomacyButtons.ContainsKey(15) && gameState.activeDiplomacyButtons[15].ContainsKey(country) && gameState.activeDiplomacyButtons[15][country].level <= 0)
    {
      float num7 = (float) ((double) ((!gameState.countries[country].puppetOf.HasValue ? 1f : 2f) + Mathf.Min((float) (gameState.expenses[ExpenseType.DiplomaticMissions] / 100) * 0.2f, 1f) + (float) (gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
      {
        if (cou.Value.zoneType != gameState.countries[country].zoneType)
          return false;
        Countries? puppetOf2 = cou.Value.puppetOf;
        Countries playerCountry = gameState.playerCountry;
        return puppetOf2.GetValueOrDefault() == playerCountry & puppetOf2.HasValue;
      })).Count<KeyValuePair<Countries, Country>>() / 5) / 10f - (float) (gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
      {
        if (cou.Value.zoneType != gameState.countries[country].zoneType)
          return false;
        Countries? puppetOf3 = cou.Value.puppetOf;
        Countries countries7 = Countries.USA;
        if (puppetOf3.GetValueOrDefault() == countries7 & puppetOf3.HasValue)
          return true;
        puppetOf3 = cou.Value.puppetOf;
        Countries countries8 = Countries.France;
        return puppetOf3.GetValueOrDefault() == countries8 & puppetOf3.HasValue;
      })).Count<KeyValuePair<Countries, Country>>() / 5) / 10f) + (double) (gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.militaryAlliance == Country.MilitaryAllianceType.WarsawPact)).Count<KeyValuePair<Countries, Country>>() / 5) / 10.0 - (double) (gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.militaryAlliance == Country.MilitaryAllianceType.AACS || cou.Value.militaryAlliance == Country.MilitaryAllianceType.NATO || cou.Value.militaryAlliance == Country.MilitaryAllianceType.PartnershipNATO)).Count<KeyValuePair<Countries, Country>>() / 5) / 10.0 + (double) (gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.economyAlliance == Country.EconomyAllianceType.COMECON || cou.Value.economyAlliance == Country.EconomyAllianceType.AssociativeCOMECON)).Count<KeyValuePair<Countries, Country>>() / 5) / 10.0 - (double) (gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.economyAlliance == Country.EconomyAllianceType.EU || cou.Value.economyAlliance == Country.EconomyAllianceType.WAFT)).Count<KeyValuePair<Countries, Country>>() / 5) / 10.0);
      if ((double) gameState.AmericanArmyLevel > 50.0 && (double) gameState.AmericanEconomyLevel > 25.0)
        num7 -= 0.5f;
      textFormatter1.AddText($"{LanguageManager.inst["icon_desc", "icon32"]}: {num1:+0.##;-0.##}", (double) num1 >= 0.0 ? "#006400" : "#FF0000");
      float num8 = num7 + num1;
    }
    if (country1.hasBase == Country.BasesType.Soviet && gameState.playerCountry == Countries.USSR)
    {
      float num9 = 0.2f;
      int num10;
      if (gameState.countries[country].zoneType == Country.ZoneType.EastEurope || gameState.countries[country].zoneType == Country.ZoneType.SovietZone)
      {
        puppetOf1 = gameState.countries[country].puppetOf;
        Countries countries9 = Countries.USSR;
        num10 = !(puppetOf1.GetValueOrDefault() == countries9 & puppetOf1.HasValue) ? 1 : 0;
      }
      else
        num10 = 0;
      if (num10 != 0)
        num9 = 1f;
      textFormatter1.AddText($"{string.Format(LanguageManager.inst["map_left_panel_ui", "military_base"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true))}: {num9:+0.##;-0.##}", "#006400");
      num1 += num9;
    }
    if (country1.trade)
    {
      float num11 = 0.0f;
      switch (gameState.countries[country].zoneType)
      {
        case Country.ZoneType.SouthEastAsia:
        case Country.ZoneType.Africa:
        case Country.ZoneType.SouthAmerica:
        case Country.ZoneType.Oceania:
          if (gameState.doctrines[DoctrineType.InternationalDepartment].branch == AbstractDoctrine.DoctrineBranchType.Top)
            num11 += 0.4f;
          if (gameState.doctrines[DoctrineType.InternationalDepartment].branch == AbstractDoctrine.DoctrineBranchType.BottomLeft && gameState.doctrines[DoctrineType.InternationalDepartment].number == 1)
          {
            num11 += 0.2f;
            break;
          }
          break;
        case Country.ZoneType.MiddleEast:
          if (gameState.doctrines[DoctrineType.InternationalDepartment].branch == AbstractDoctrine.DoctrineBranchType.Top)
          {
            num11 += 0.2f;
            break;
          }
          break;
        case Country.ZoneType.NorthAmerica:
          if (country != Countries.Mexica && country != Countries.Canada && country != Countries.USA)
          {
            if (gameState.doctrines[DoctrineType.InternationalDepartment].branch == AbstractDoctrine.DoctrineBranchType.Top)
              num11 += 0.4f;
            if (gameState.doctrines[DoctrineType.InternationalDepartment].branch == AbstractDoctrine.DoctrineBranchType.BottomLeft && gameState.doctrines[DoctrineType.InternationalDepartment].number == 1)
              num11 += 0.2f;
            break;
          }
          break;
      }
      if ((double) num11 != 0.0)
        textFormatter1.AddText($"{LanguageManager.inst["icon_desc", "icon33"]}: {num11:+0.##;-0.##}", (double) num11 >= 0.0 ? "#006400" : "#FF0000");
      num1 += num11;
    }
    puppetOf1 = country1.puppetOf;
    Countries countries10 = Countries.USSR;
    if (puppetOf1.GetValueOrDefault() == countries10 & puppetOf1.HasValue && gameState.playerCountry == Countries.USSR && country1.puppetType == Country.PuppetType.UnderInfluence)
    {
      textFormatter1.AddText(string.Format(LanguageManager.inst["puppet_type_name", "UnderInfluence"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true)) + ": +0.1", "#006400");
      num1 += 0.1f;
    }
    if (country1.leaderType != Country.LeaderType.None)
    {
      float num12 = 0.0f;
      switch (country1.leaderType)
      {
        case Country.LeaderType.Loyal:
          if ((double) country1.ForeignPolicyVector < 75.0)
          {
            ++num12;
            break;
          }
          break;
        case Country.LeaderType.Moderate:
          if ((double) country1.ForeignPolicyVector < 50.0)
          {
            num12 += 0.5f;
            break;
          }
          break;
        case Country.LeaderType.Separatist:
          if ((double) country1.ForeignPolicyVector > 25.0)
          {
            --num12;
            break;
          }
          break;
      }
      num1 += num12;
      if ((double) num12 != 0.0)
        textFormatter1.AddText($"{LanguageManager.inst["leader_type_name", "Icon_name"]}: {num12:+0.##;-0.##}", (double) num12 >= 0.0 ? "#006400" : "#FF0000");
    }
    puppetOf1 = country1.puppetOf;
    Countries countries11 = Countries.USSR;
    if (puppetOf1.GetValueOrDefault() == countries11 & puppetOf1.HasValue && gameState.playerCountry == Countries.USSR && country1.puppetType == Country.PuppetType.EqualState && gameState.doctrines[DoctrineType.StateStructure].branch != AbstractDoctrine.DoctrineBranchType.Bottom && (double) country1.ForeignPolicyVector > 25.0)
    {
      textFormatter1.AddText(string.Format(LanguageManager.inst["puppet_type_name", "InnerState"], (object) CountryUtils.GetCountryName(gameState, Countries.USSR, true)) + " -0.2", "#FF0000");
      num1 -= 0.2f;
    }
    bool flag = false;
    StatisticImpactSourceType key;
    if (gameState.gameStateHistory.lastDiplomacyVectorValuesChangesSources.ContainsKey(country))
    {
      foreach (KeyValuePair<StatisticImpactSourceType, float> keyValuePair in gameState.gameStateHistory.lastDiplomacyVectorValuesChangesSources[country])
      {
        if (keyValuePair.Key == StatisticImpactSourceType.Diplomacy)
        {
          if ((double) keyValuePair.Value - (double) num1 != 0.0)
          {
            Backend.Gamedesign.Utils.TextFormatter.TextFormatter textFormatter6 = textFormatter1;
            LanguageManager inst = LanguageManager.inst;
            key = keyValuePair.Key;
            string str = key.ToString();
            string first_text = $"{inst["statistic_impact_source_name", str]}: {(ValueType) (float) ((double) keyValuePair.Value - (double) num1):+0.##;-0.##}";
            string color = (double) keyValuePair.Value - (double) num1 > 0.0 ? "#006400" : "#FF0000";
            textFormatter6.AddText(first_text, color);
            flag = true;
          }
        }
        else if ((double) keyValuePair.Value != 0.0)
        {
          Backend.Gamedesign.Utils.TextFormatter.TextFormatter textFormatter7 = textFormatter1;
          LanguageManager inst = LanguageManager.inst;
          key = keyValuePair.Key;
          string str = key.ToString();
          string first_text = $"{inst["statistic_impact_source_name", str]}: {keyValuePair.Value:+0.##;-0.##}";
          string color = (double) keyValuePair.Value > 0.0 ? "#006400" : "#FF0000";
          textFormatter7.AddText(first_text, color);
          flag = true;
        }
      }
    }
    if ((double) num1 == 0.0 && !flag)
      textFormatter1.AddText(LanguageManager.inst["icon_desc", "icon26"] ?? "", "#FF0000");
    textFormatter3.AddLine(textFormatter1.FinalizeInColor());
    string vectorDescription;
    if (country1.puppetType != Country.PuppetType.Occupied)
    {
      puppetOf1 = country1.puppetOf;
      Countries countries12 = Countries.USSR;
      if (!(puppetOf1.GetValueOrDefault() == countries12 & puppetOf1.HasValue))
      {
        puppetOf1 = country1.puppetOf;
        Countries countries13 = Countries.USA;
        if (!(puppetOf1.GetValueOrDefault() == countries13 & puppetOf1.HasValue) && (country1.puppetType == Country.PuppetType.PuppetOtherState || country1.puppetType == Country.PuppetType.Occupied))
          goto label_167;
      }
      vectorDescription = textFormatter3.Finalize();
      goto label_168;
    }
label_167:
    vectorDescription = textFormatter2.Finalize();
label_168:
    return vectorDescription;
  }

  public static bool ShouldLibVectorBeDisplayed(GameState gameState, Countries country)
  {
    Country country1 = gameState.countries[country];
    int num;
    if (country1.zoneType != Country.ZoneType.SovietZone)
    {
      if (country1.militaryAlliance != Country.MilitaryAllianceType.WarsawPact)
      {
        if (country1.economyAlliance == Country.EconomyAllianceType.COMECON)
        {
          Countries? puppetOf = country1.puppetOf;
          Countries playerCountry = gameState.playerCountry;
          if (puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue && country1.puppetType > Country.PuppetType.EqualState)
          {
            num = country1.zoneType < Country.ZoneType.SouthEastAsia ? 1 : 0;
            goto label_8;
          }
        }
        num = 0;
      }
      else
        num = 1;
    }
    else
      num = 0;
label_8:
    return num != 0;
  }

  public static bool ShouldRelationsBeDisplayed(GameState gameState, Countries country)
  {
    return gameState.countries[country].needRelations;
  }

  private static void TickLeavePlayerAlliance(GameState gameState)
  {
    List<Country.GovernmentType> governmentTypeList1 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalConservative,
      Country.GovernmentType.PopulistConservative,
      Country.GovernmentType.RightPopulism,
      Country.GovernmentType.ReactonaryAuthoritarian,
      Country.GovernmentType.MarketAuthoritarian,
      Country.GovernmentType.DemocraticSocialism,
      Country.GovernmentType.SocialistReformism,
      Country.GovernmentType.SocialDemocracy,
      Country.GovernmentType.LiberalCorporativism,
      Country.GovernmentType.LiberalProgressive,
      Country.GovernmentType.ClassicalLiberalism,
      Country.GovernmentType.Centrism
    };
    List<Country.GovernmentType> governmentTypeList2 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalConservative,
      Country.GovernmentType.DemocraticSocialism,
      Country.GovernmentType.SocialistReformism,
      Country.GovernmentType.SocialDemocracy,
      Country.GovernmentType.LiberalCorporativism,
      Country.GovernmentType.LiberalProgressive,
      Country.GovernmentType.ClassicalLiberalism,
      Country.GovernmentType.Centrism
    };
    if (gameState.playerCountry != Countries.USSR)
      return;
    List<Countries> countriesList1 = new List<Countries>()
    {
      Countries.Estonia,
      Countries.Latvia,
      Countries.Litva
    };
    List<Countries> countriesList2 = new List<Countries>()
    {
      Countries.Moldavia,
      Countries.Russia,
      Countries.Ukraine,
      Countries.Belorussia
    };
    List<Countries> countriesList3 = new List<Countries>()
    {
      Countries.Azerbaijan,
      Countries.Armenia,
      Countries.Georgia
    };
    List<Countries> countriesList4 = new List<Countries>()
    {
      Countries.Tajikistan,
      Countries.Turkmenia,
      Countries.Kazakhstan,
      Countries.Uzbekistan,
      Countries.Kyrgizia
    };
    List<Countries> list = gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
    {
      if (cou.Value.activeInGame)
      {
        Countries? puppetOf = cou.Value.puppetOf;
        Countries countries = Countries.USSR;
        if (!(puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue) && cou.Value.militaryAlliance == Country.MilitaryAllianceType.None && (cou.Value.economyAlliance == Country.EconomyAllianceType.None || cou.Value.economyAlliance == Country.EconomyAllianceType.TiesDisruption) && cou.Value.puppetType >= Country.PuppetType.PuppetOtherState)
          return cou.Value.zoneType == Country.ZoneType.SovietZone || cou.Value.zoneType == Country.ZoneType.EastEurope;
      }
      return false;
    })).Select<KeyValuePair<Countries, Country>, Countries>((Func<KeyValuePair<Countries, Country>, Countries>) (cou => cou.Key)).ToList<Countries>();
    if (list != null)
    {
      if (gameState.countries[Countries.USA].militaryAlliance == Country.MilitaryAllianceType.NATO)
      {
        foreach (Countries key in list)
        {
          Country country = gameState.countries[key];
          if (country.hasBase != Country.BasesType.Soviet && country.treasonTimer > 0)
            --country.treasonTimer;
          if (country.treasonTimer <= 0 && (double) country.ForeignPolicyVector < 25.0 && !country.puppetOf.HasValue && governmentTypeList1.Contains(country.governmentType.Value) && country.militaryAlliance != Country.MilitaryAllianceType.OfficialNeutrality)
          {
            country.puppetOf = new Countries?(Countries.USA);
            country.puppetType = Country.PuppetType.UnderInfluence;
            country.treasonTimer += 6;
          }
          else
          {
            Countries? puppetOf;
            int num1;
            if (country.treasonTimer <= 0 && (double) country.ForeignPolicyVector <= 0.0)
            {
              puppetOf = country.puppetOf;
              Countries countries = Countries.USA;
              if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue && governmentTypeList1.Contains(country.governmentType.Value))
              {
                num1 = country.militaryAlliance == Country.MilitaryAllianceType.None ? 1 : 0;
                goto label_13;
              }
            }
            num1 = 0;
label_13:
            if (num1 != 0)
            {
              country.militaryAlliance = Country.MilitaryAllianceType.PartnershipNATO;
              country.treasonTimer += 6;
            }
            else
            {
              int num2;
              if (country.treasonTimer <= 0 && (double) country.ForeignPolicyVector <= 0.0)
              {
                puppetOf = country.puppetOf;
                Countries countries = Countries.USA;
                if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue && governmentTypeList1.Contains(country.governmentType.Value) && country.militaryAlliance == Country.MilitaryAllianceType.PartnershipNATO)
                {
                  num2 = countriesList1.Contains(key) || countriesList2.Contains(key) ? 1 : (country.zoneType == Country.ZoneType.EastEurope ? 1 : 0);
                  goto label_19;
                }
              }
              num2 = 0;
label_19:
              if (num2 != 0)
              {
                country.militaryAlliance = Country.MilitaryAllianceType.NATO;
                country.economyAlliance = Country.EconomyAllianceType.None;
              }
            }
          }
        }
      }
      else if (gameState.countries[Countries.Luxemburg].economyAlliance == Country.EconomyAllianceType.EU && gameState.countries[Countries.USSR].economyAlliance != 0)
      {
        foreach (Countries key in list)
        {
          Country country = gameState.countries[key];
          if (country.hasBase != Country.BasesType.Soviet && country.treasonTimer > 0)
            --country.treasonTimer;
          if (country.treasonTimer <= 0 && (double) country.ForeignPolicyVector <= 10.0 && country.economyAlliance == Country.EconomyAllianceType.None && !country.puppetOf.HasValue && governmentTypeList2.Contains(country.governmentType.Value) && (countriesList1.Contains(key) || countriesList2.Contains(key) || countriesList3.Contains(key) || country.zoneType == Country.ZoneType.EastEurope))
            country.economyAlliance = Country.EconomyAllianceType.EU;
        }
      }
    }
  }

  public static void TickSubjectsLeader(GameState gameState, Countries country)
  {
    Country country1 = gameState.countries[country];
    int num1 = 0;
    int num2 = (double) country1.RelationshipWithPlayer < 75.0 ? ((double) country1.RelationshipWithPlayer < 50.0 ? ((double) country1.RelationshipWithPlayer > 25.0 ? num1 - 1 : num1 - 2) : num1 + 1) : num1 + 2;
    int num3 = ((double) country1.ForeignPolicyVector < 75.0 ? ((double) country1.ForeignPolicyVector < 50.0 ? num2 - 2 : num2 + 1) : num2 + 2) + (country1.puppetType == Country.PuppetType.InnerState ? 0 : (country1.puppetType == Country.PuppetType.Autonomy ? 2 : -2));
    List<Countries> countriesList1 = new List<Countries>()
    {
      Countries.Estonia,
      Countries.Latvia,
      Countries.Litva
    };
    List<Countries> countriesList2 = new List<Countries>()
    {
      Countries.Moldavia,
      Countries.Russia,
      Countries.Ukraine,
      Countries.Belorussia
    };
    List<Countries> countriesList3 = new List<Countries>()
    {
      Countries.Azerbaijan,
      Countries.Armenia,
      Countries.Georgia
    };
    List<Countries> countriesList4 = new List<Countries>()
    {
      Countries.Tajikistan,
      Countries.Turkmenia,
      Countries.Kazakhstan,
      Countries.Uzbekistan,
      Countries.Kyrgizia
    };
    foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (c => c.Value.activeInGame && c.Value.zoneType == Country.ZoneType.SovietZone)))
    {
      int num4;
      if (gameState.playerCountry == Countries.USSR)
      {
        Countries? puppetOf = keyValuePair.Value.puppetOf;
        Countries countries = Countries.USSR;
        num4 = puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue || keyValuePair.Value.puppetType < Country.PuppetType.PuppetOtherState ? (keyValuePair.Value.puppetType != Country.PuppetType.EqualState ? 0 : (gameState.doctrines[DoctrineType.StateStructure].branch == AbstractDoctrine.DoctrineBranchType.Bottom ? 1 : 0)) : 1;
      }
      else
        num4 = 0;
      if (num4 != 0)
      {
        if (countriesList1.Contains(keyValuePair.Key) && countriesList1.Contains(country) && keyValuePair.Key != country)
          ++num3;
        else if (countriesList2.Contains(keyValuePair.Key) && countriesList2.Contains(country) && keyValuePair.Key != country)
          ++num3;
        else if (countriesList3.Contains(keyValuePair.Key) && countriesList3.Contains(country) && keyValuePair.Key != country)
          ++num3;
        else if (countriesList4.Contains(keyValuePair.Key) && countriesList4.Contains(country) && keyValuePair.Key != country)
          ++num3;
      }
    }
    int num5 = gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
    {
      if (!cou.Value.activeInGame || cou.Value.puppetType >= Country.PuppetType.PuppetOtherState)
        return false;
      Countries? puppetOf = cou.Value.puppetOf;
      Countries playerCountry = gameState.playerCountry;
      return puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue;
    })).Count<KeyValuePair<Countries, Country>>();
    if (gameState.playerCountry == Countries.USSR)
    {
      if (num5 == 15)
        ++num3;
      else if (num5 > 12)
        num3 = num3;
      else if (num5 > 9)
        --num3;
      else if (num5 > 6)
        num3 -= 2;
      else
        num3 -= 3;
    }
    if ((double) gameState.RadicalsPower > 75.0)
      --num3;
    else if ((double) gameState.RadicalsPower < 25.0)
      ++num3;
    if ((double) gameState.LiberalizationLevel > 75.0)
      --num3;
    else if ((double) gameState.LiberalizationLevel < 25.0)
      ++num3;
    if ((double) gameState.UnityLevel > 75.0)
      ++num3;
    else if ((double) gameState.UnityLevel < 25.0)
      --num3;
    List<Characters> powerfulPoliticians = PoliticUtils.GetPowerfulPoliticians(gameState, 10);
    foreach (KeyValuePair<Characters, CharacterInfo> keyValuePair in gameState.characters.Where<KeyValuePair<Characters, CharacterInfo>>((Func<KeyValuePair<Characters, CharacterInfo>, bool>) (p =>
    {
      if (p.Value.status != CharacterInfo.PoliticStatus.Alive)
        return false;
      if (p.Value.homeLand == country && country != Countries.Russia)
        return true;
      return country == Countries.Russia && p.Value.traits.Contains(Traits.Chauvinist);
    })))
    {
      if (powerfulPoliticians.Contains(keyValuePair.Key))
        ++num3;
    }
    if (country1.puppetType < Country.PuppetType.PuppetOtherState)
    {
      if (num3 > 0)
        country1.leaderType = Country.LeaderType.Loyal;
      else if (num3 < -7 && country1.puppetType != 0)
        country1.leaderType = Country.LeaderType.Separatist;
      else
        country1.leaderType = Country.LeaderType.Moderate;
    }
    else
    {
      int num6;
      if (country1.leaderType == Country.LeaderType.Loyal)
      {
        Countries? puppetOf = country1.puppetOf;
        Countries countries = Countries.USSR;
        if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue)
        {
          num6 = (double) country1.ForeignPolicyVector < 50.0 ? 1 : 0;
          goto label_61;
        }
      }
      num6 = 0;
label_61:
      if (num6 != 0)
      {
        country1.puppetType = Country.PuppetType.None;
        country1.puppetOf = new Countries?();
      }
    }
  }

  private static void TickIdeologyRelations(GameState gameState, Countries country)
  {
    Country country1 = gameState.countries[country];
    Country country2 = gameState.countries[gameState.playerCountry];
    List<Country.GovernmentType> governmentTypeList1 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LeftNationalism,
      Country.GovernmentType.ConservativeSocialism,
      Country.GovernmentType.SocialismNationalSpecific,
      Country.GovernmentType.LeftPragmatism
    };
    List<Country.GovernmentType> governmentTypeList2 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalConservative,
      Country.GovernmentType.PopulistConservative,
      Country.GovernmentType.RightPopulism,
      Country.GovernmentType.ReactonaryAuthoritarian,
      Country.GovernmentType.MarketAuthoritarian
    };
    List<Country.GovernmentType> governmentTypeList3 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.DemocraticSocialism,
      Country.GovernmentType.SocialistReformism,
      Country.GovernmentType.SocialDemocracy,
      Country.GovernmentType.ConstructingCommunism
    };
    List<Country.GovernmentType> governmentTypeList4 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalCorporativism,
      Country.GovernmentType.LiberalProgressive,
      Country.GovernmentType.ClassicalLiberalism,
      Country.GovernmentType.Centrism
    };
    int num;
    if (country1.activeInGame)
    {
      Country.GovernmentType? governmentType1 = country1.governmentType;
      Country.GovernmentType? governmentType2 = country2.governmentType;
      num = governmentType1.GetValueOrDefault() == governmentType2.GetValueOrDefault() & governmentType1.HasValue == governmentType2.HasValue ? 1 : 0;
    }
    else
      num = 0;
    if (num != 0)
    {
      Countries? puppetOf = country1.puppetOf;
      Countries playerCountry = gameState.playerCountry;
      if (!(puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue))
      {
        if (CountryUtils.ShouldRelationsBeDisplayed(gameState, country))
          country1.RelationshipWithPlayer += 0.5f;
        if (CountryUtils.ShouldLibVectorBeDisplayed(gameState, country))
          country1.LiberalizationVector -= 0.25f;
        else
          country1.ForeignPolicyVector += 0.5f;
      }
      else
      {
        if (CountryUtils.ShouldRelationsBeDisplayed(gameState, country))
          ++country1.RelationshipWithPlayer;
        if (CountryUtils.ShouldLibVectorBeDisplayed(gameState, country))
          country1.LiberalizationVector -= 0.5f;
        else
          ++country1.ForeignPolicyVector;
      }
    }
    else if (country1.activeInGame && (governmentTypeList1.Contains(country1.governmentType.Value) && governmentTypeList1.Contains(country2.governmentType.Value) || governmentTypeList2.Contains(country1.governmentType.Value) && governmentTypeList2.Contains(country2.governmentType.Value) || governmentTypeList3.Contains(country1.governmentType.Value) && governmentTypeList3.Contains(country2.governmentType.Value) || governmentTypeList4.Contains(country1.governmentType.Value) && governmentTypeList4.Contains(country2.governmentType.Value)))
    {
      Countries? puppetOf = country1.puppetOf;
      Countries playerCountry = gameState.playerCountry;
      if (!(puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue))
      {
        if (CountryUtils.ShouldRelationsBeDisplayed(gameState, country))
          country1.RelationshipWithPlayer += 0.25f;
        if (CountryUtils.ShouldLibVectorBeDisplayed(gameState, country))
          country1.LiberalizationVector -= 0.1f;
        else
          country1.ForeignPolicyVector += 0.25f;
      }
      else
      {
        if (CountryUtils.ShouldRelationsBeDisplayed(gameState, country))
          country1.RelationshipWithPlayer += 0.5f;
        if (CountryUtils.ShouldLibVectorBeDisplayed(gameState, country))
          country1.LiberalizationVector -= 0.2f;
        else
          country1.ForeignPolicyVector += 0.5f;
      }
    }
    else if (country1.activeInGame && ((governmentTypeList1.Contains(country1.governmentType.Value) || governmentTypeList3.Contains(country1.governmentType.Value)) && (governmentTypeList3.Contains(country2.governmentType.Value) || governmentTypeList1.Contains(country2.governmentType.Value)) || (governmentTypeList2.Contains(country1.governmentType.Value) || governmentTypeList2.Contains(country2.governmentType.Value)) && (governmentTypeList4.Contains(country1.governmentType.Value) || governmentTypeList4.Contains(country2.governmentType.Value))))
    {
      country1.RelationshipWithPlayer += 0.2f;
    }
    else
    {
      if (!country1.activeInGame || (governmentTypeList1.Contains(country1.governmentType.Value) || governmentTypeList3.Contains(country1.governmentType.Value)) && (governmentTypeList3.Contains(country2.governmentType.Value) || governmentTypeList1.Contains(country2.governmentType.Value)) || (governmentTypeList2.Contains(country1.governmentType.Value) || governmentTypeList2.Contains(country2.governmentType.Value)) && (governmentTypeList4.Contains(country1.governmentType.Value) || governmentTypeList4.Contains(country2.governmentType.Value)))
        return;
      country1.RelationshipWithPlayer -= 0.5f;
      country1.ForeignPolicyVector -= 0.5f;
    }
  }

  private static void TickDiplomacyIcons(GameState gameState)
  {
    foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (country => country.Value.activeInGame)))
    {
      foreach (int Id in DiplomacyIconsManager.inst.GetActiveIconsForCountry(gameState, keyValuePair.Key))
        DiplomacyIconsManager.inst.TickIcon(gameState, keyValuePair.Key, Id);
    }
  }

  public static void TickCountries(GameState gameState)
  {
    foreach (KeyValuePair<int, Dictionary<Countries, DiplomacyButtonState>> activeDiplomacyButton in gameState.activeDiplomacyButtons)
    {
      foreach (KeyValuePair<Countries, DiplomacyButtonState> keyValuePair in activeDiplomacyButton.Value.ToList<KeyValuePair<Countries, DiplomacyButtonState>>())
        DiplomacyButtonsManager.inst.TickButton(gameState, keyValuePair.Key, activeDiplomacyButton.Key);
    }
    CountryUtils.FillPlayersCountryInfo(gameState);
    if (gameState.playerCountry != Countries.USA && (gameState.countries[Countries.USA].militaryAlliance == Country.MilitaryAllianceType.NATO || gameState.countries[Countries.USA].militaryAlliance == Country.MilitaryAllianceType.AACS))
      CountryUtils.RealizeUSAI(gameState);
    CountryUtils.RealizeFederalStatesAI(gameState);
    CountryUtils.TickDiplomacyIcons(gameState);
    CountryUtils.CoupThirdWorld(gameState);
    foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (country => country.Value.activeInGame)))
    {
      CountryUtils.TickIdeologyRelations(gameState, keyValuePair.Key);
      CountryUtils.MakeBoundaryForCountry(gameState, keyValuePair.Key);
      int num;
      if (gameState.playerCountry == Countries.USSR)
      {
        Countries? puppetOf = keyValuePair.Value.puppetOf;
        Countries countries = Countries.USSR;
        if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue && keyValuePair.Value.puppetType < Country.PuppetType.PuppetOtherState)
        {
          num = 1;
          goto label_17;
        }
      }
      num = gameState.countries[keyValuePair.Key].economyAlliance == Country.EconomyAllianceType.TiesDisruption ? 1 : 0;
label_17:
      if (num != 0)
        CountryUtils.TickSubjectsLeader(gameState, keyValuePair.Key);
    }
    CountryUtils.TickLeavePlayerAlliance(gameState);
  }

  public static void MakeBoundaryForCountry(GameState gameState, Countries country)
  {
    float a1 = gameState.countries[country].RelationshipWithPlayer;
    float a2 = gameState.countries[country].ForeignPolicyVector;
    float liberalizationVector = gameState.countries[country].LiberalizationVector;
    if (gameState.countries[country].hasBase == Country.BasesType.American)
      a1 = Mathf.Min(a1, 75f);
    Countries? puppetOf = gameState.countries[country].puppetOf;
    Countries playerCountry1 = gameState.playerCountry;
    if (puppetOf.GetValueOrDefault() == playerCountry1 & puppetOf.HasValue && gameState.countries[country].puppetType == Country.PuppetType.Autonomy)
    {
      a2 = Mathf.Max(a2, 75f);
    }
    else
    {
      puppetOf = gameState.countries[country].puppetOf;
      Countries playerCountry2 = gameState.playerCountry;
      if (puppetOf.GetValueOrDefault() == playerCountry2 & puppetOf.HasValue && gameState.countries[country].puppetType == Country.PuppetType.InnerState)
      {
        a2 = Mathf.Max(a2, 50f);
      }
      else
      {
        puppetOf = gameState.countries[country].puppetOf;
        Countries playerCountry3 = gameState.playerCountry;
        if (puppetOf.GetValueOrDefault() == playerCountry3 & puppetOf.HasValue && gameState.countries[country].puppetType == Country.PuppetType.EqualState)
          a2 = Mathf.Max(a2, 25f);
      }
    }
    puppetOf = gameState.countries[country].puppetOf;
    Countries countries1 = Countries.USSR;
    if (puppetOf.GetValueOrDefault() == countries1 & puppetOf.HasValue && gameState.countries[country].puppetType == Country.PuppetType.PuppetOtherState)
      a2 = Mathf.Max(a2, 75f);
    puppetOf = gameState.countries[country].puppetOf;
    Countries countries2 = Countries.USA;
    if (puppetOf.GetValueOrDefault() == countries2 & puppetOf.HasValue && gameState.countries[country].puppetType == Country.PuppetType.PuppetOtherState)
      a2 = Mathf.Min(a2, 25f);
    puppetOf = gameState.countries[country].puppetOf;
    Countries countries3 = Countries.USSR;
    if (puppetOf.GetValueOrDefault() == countries3 & puppetOf.HasValue && gameState.countries[country].puppetType == Country.PuppetType.Occupied)
    {
      a1 = Mathf.Max(a1, 100f);
      a2 = Mathf.Max(a2, 100f);
    }
    if (gameState.countries[country].leaderType == Country.LeaderType.Separatist)
    {
      a1 = Mathf.Min(a1, 75f);
      a2 = Mathf.Min(a2, 75f);
    }
    if (gameState.countries[country].economyAlliance == Country.EconomyAllianceType.TiesDisruption)
      a2 = Mathf.Min(a2, 90f);
    if (gameState.countries[country].militaryAlliance == Country.MilitaryAllianceType.OfficialNeutrality)
      a2 = Mathf.Max(Mathf.Min(a2, 75f), 25f);
    if (gameState.countries[country].economyAlliance == Country.EconomyAllianceType.WAFT)
    {
      a1 = Mathf.Min(a1, 75f);
      a2 = Mathf.Max(a2, 50f);
    }
    if (gameState.countries[country].economyAlliance == Country.EconomyAllianceType.EU)
    {
      if (gameState.countries[gameState.playerCountry].economyAlliance != 0)
      {
        a2 = Mathf.Min(a2, 60f);
        puppetOf = gameState.countries[country].puppetOf;
        Countries playerCountry4 = gameState.playerCountry;
        if (puppetOf.GetValueOrDefault() == playerCountry4 & puppetOf.HasValue || gameState.countries[country].puppetType != Country.PuppetType.PuppetOtherState)
          a2 = Mathf.Max(a2, 10f);
      }
      else
      {
        puppetOf = gameState.countries[country].puppetOf;
        Countries playerCountry5 = gameState.playerCountry;
        if (puppetOf.GetValueOrDefault() == playerCountry5 & puppetOf.HasValue || gameState.countries[country].puppetType != Country.PuppetType.PuppetOtherState)
        {
          a1 = Mathf.Max(a1, 20f);
          a2 = Mathf.Max(a2, 10f);
        }
      }
    }
    gameState.countries[country].LiberalizationVector = liberalizationVector;
    gameState.countries[country].RelationshipWithPlayer = a1;
    gameState.countries[country].ForeignPolicyVector = a2;
  }

  private static void RealizeFederalStatesAI(GameState gameState)
  {
    List<Countries> republicsOfPlayerKeys = CountryUtils.GetRepublicsOfPlayerKeys(gameState);
    Country country1 = gameState.countries[gameState.playerCountry];
    List<Country.GovernmentType> governmentTypeList1 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LeftNationalism,
      Country.GovernmentType.ConservativeSocialism,
      Country.GovernmentType.SocialismNationalSpecific,
      Country.GovernmentType.LeftPragmatism
    };
    List<Country.GovernmentType> governmentTypeList2 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalConservative,
      Country.GovernmentType.PopulistConservative,
      Country.GovernmentType.RightPopulism,
      Country.GovernmentType.ReactonaryAuthoritarian,
      Country.GovernmentType.MarketAuthoritarian
    };
    List<Country.GovernmentType> governmentTypeList3 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.DemocraticSocialism,
      Country.GovernmentType.SocialistReformism,
      Country.GovernmentType.SocialDemocracy,
      Country.GovernmentType.ConstructingCommunism
    };
    List<Country.GovernmentType> governmentTypeList4 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalCorporativism,
      Country.GovernmentType.LiberalProgressive,
      Country.GovernmentType.ClassicalLiberalism,
      Country.GovernmentType.Centrism
    };
    foreach (Countries key in republicsOfPlayerKeys)
    {
      Country country2 = gameState.countries[key];
      if (country2.puppetType < Country.PuppetType.EqualState)
      {
        country2.governmentType = gameState.countries[country2.puppetOf.Value].governmentType;
        country2.rulingPartyName = gameState.countries[country2.puppetOf.Value].rulingPartyName;
      }
      else
      {
        switch (country2.leaderType)
        {
          case Country.LeaderType.Loyal:
            country2.governmentType = gameState.countries[country2.puppetOf.Value].governmentType;
            country2.rulingPartyName = gameState.countries[country2.puppetOf.Value].rulingPartyName;
            break;
          case Country.LeaderType.Moderate:
            if (governmentTypeList1.Contains(country1.governmentType.Value))
            {
              governmentTypeList1.Remove(country1.governmentType.Value);
              country2.governmentType = new Country.GovernmentType?(governmentTypeList1[UnityEngine.Random.Range(0, governmentTypeList1.Count)]);
            }
            else if (governmentTypeList2.Contains(country1.governmentType.Value))
            {
              governmentTypeList2.Remove(country1.governmentType.Value);
              country2.governmentType = new Country.GovernmentType?(governmentTypeList2[UnityEngine.Random.Range(0, governmentTypeList2.Count)]);
            }
            else if (governmentTypeList3.Contains(country1.governmentType.Value))
            {
              governmentTypeList3.Remove(country1.governmentType.Value);
              country2.governmentType = new Country.GovernmentType?(governmentTypeList3[UnityEngine.Random.Range(0, governmentTypeList3.Count)]);
            }
            else if (governmentTypeList4.Contains(country1.governmentType.Value))
            {
              governmentTypeList4.Remove(country1.governmentType.Value);
              country2.governmentType = new Country.GovernmentType?(governmentTypeList4[UnityEngine.Random.Range(0, governmentTypeList4.Count)]);
            }
            country2.rulingPartyName = CountryUtils.GetPartyNameFromGovernmentType(country2.governmentType.Value);
            break;
          case Country.LeaderType.Separatist:
            if (governmentTypeList1.Contains(country1.governmentType.Value) || governmentTypeList3.Contains(country1.governmentType.Value))
              country2.governmentType = new Country.GovernmentType?(governmentTypeList4[UnityEngine.Random.Range(0, governmentTypeList4.Count)]);
            else if (governmentTypeList2.Contains(country1.governmentType.Value) || governmentTypeList4.Contains(country1.governmentType.Value))
              country2.governmentType = new Country.GovernmentType?(governmentTypeList3[UnityEngine.Random.Range(0, governmentTypeList3.Count)]);
            country2.rulingPartyName = CountryUtils.GetPartyNameFromGovernmentType(country2.governmentType.Value);
            break;
        }
      }
      if (country2.stateOfEmergency > 0)
        ++country2.stateOfEmergency;
    }
  }

  private static void RealizeSEVAI(GameState gameState)
  {
    foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.economyAlliance == Country.EconomyAllianceType.COMECON || cou.Value.militaryAlliance == Country.MilitaryAllianceType.WarsawPact)))
    {
      if ((double) keyValuePair.Value.LiberalizationVector > 85.0 && gameState.date.Year < 1989)
        keyValuePair.Value.LiberalizationVector -= 5f;
      else if ((double) keyValuePair.Value.LiberalizationVector > 90.0 && gameState.date.Year < 1988)
        keyValuePair.Value.LiberalizationVector -= 10f;
      else if ((double) keyValuePair.Value.LiberalizationVector > 80.0 && gameState.date.Year < 1987)
        keyValuePair.Value.LiberalizationVector -= 8f;
      else if ((double) keyValuePair.Value.LiberalizationVector > 70.0 && gameState.date.Year < 1987)
        keyValuePair.Value.LiberalizationVector -= 5f;
      else if ((double) keyValuePair.Value.RelationshipWithPlayer < 70.0 && gameState.date.Year < 1987)
        ++keyValuePair.Value.RelationshipWithPlayer;
      else if ((double) keyValuePair.Value.RelationshipWithPlayer < 60.0 && gameState.date.Year < 1987)
        keyValuePair.Value.RelationshipWithPlayer += 4f;
      else if ((double) keyValuePair.Value.RelationshipWithPlayer < 50.0 && gameState.date.Year < 1987)
        keyValuePair.Value.RelationshipWithPlayer += 6f;
      else if ((double) keyValuePair.Value.RelationshipWithPlayer < 40.0 && gameState.date.Year < 1988)
        keyValuePair.Value.RelationshipWithPlayer += 8f;
      if ((double) keyValuePair.Value.LiberalizationVector > 90.0)
        keyValuePair.Value.RelationshipWithPlayer -= 3f;
      else if ((double) keyValuePair.Value.LiberalizationVector > 70.0)
        keyValuePair.Value.RelationshipWithPlayer -= 2f;
      else if ((double) keyValuePair.Value.LiberalizationVector > 50.0)
        --keyValuePair.Value.RelationshipWithPlayer;
      Country.GovernmentType? governmentType1 = keyValuePair.Value.governmentType;
      Country.GovernmentType governmentType2 = Country.GovernmentType.LiberalConservative;
      if (governmentType1.GetValueOrDefault() >= governmentType2 & governmentType1.HasValue)
        --keyValuePair.Value.LiberalizationVector;
    }
  }

  private static void CoupThirdWorld(GameState gameState)
  {
    List<Country.GovernmentType> governmentTypeList1 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LeftNationalism,
      Country.GovernmentType.ConservativeSocialism,
      Country.GovernmentType.SocialismNationalSpecific,
      Country.GovernmentType.LeftPragmatism
    };
    List<Country.GovernmentType> governmentTypeList2 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalConservative,
      Country.GovernmentType.PopulistConservative,
      Country.GovernmentType.RightPopulism,
      Country.GovernmentType.ReactonaryAuthoritarian,
      Country.GovernmentType.MarketAuthoritarian
    };
    List<Country.GovernmentType> governmentTypeList3 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.DemocraticSocialism,
      Country.GovernmentType.SocialistReformism,
      Country.GovernmentType.SocialDemocracy,
      Country.GovernmentType.ConstructingCommunism
    };
    List<Country.GovernmentType> governmentTypeList4 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalCorporativism,
      Country.GovernmentType.LiberalProgressive,
      Country.GovernmentType.ClassicalLiberalism,
      Country.GovernmentType.Centrism
    };
    foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
    {
      if (!cou.Value.activeInGame || !cou.Value.isCoupAvailable)
        return false;
      return gameState.activeDiplomacyButtons.ContainsKey(15) ? !gameState.activeDiplomacyButtons[15].ContainsKey(cou.Key) : !gameState.activeDiplomacyButtons.ContainsKey(15);
    })))
    {
      Countries? puppetOf;
      int num1;
      if ((double) gameState.countries[keyValuePair.Key].ForeignPolicyVector >= 75.0)
      {
        puppetOf = gameState.countries[keyValuePair.Key].puppetOf;
        Countries countries1 = Countries.USSR;
        if (!(puppetOf.GetValueOrDefault() == countries1 & puppetOf.HasValue))
        {
          puppetOf = gameState.countries[keyValuePair.Key].puppetOf;
          Countries countries2 = Countries.France;
          num1 = !(puppetOf.GetValueOrDefault() == countries2 & puppetOf.HasValue) ? 1 : 0;
          goto label_6;
        }
      }
      num1 = 0;
label_6:
      if (num1 != 0)
      {
        gameState.countries[keyValuePair.Key].puppetOf = new Countries?(Countries.USSR);
        gameState.countries[keyValuePair.Key].puppetType = Country.PuppetType.UnderInfluence;
        if (governmentTypeList1.Contains(gameState.countries[Countries.USSR].governmentType.Value))
        {
          governmentTypeList1.Remove(gameState.countries[Countries.USSR].governmentType.Value);
          gameState.countries[keyValuePair.Key].governmentType = new Country.GovernmentType?(governmentTypeList1[UnityEngine.Random.Range(0, governmentTypeList1.Count)]);
        }
        else if (governmentTypeList2.Contains(gameState.countries[Countries.USSR].governmentType.Value))
        {
          governmentTypeList2.Remove(gameState.countries[Countries.USSR].governmentType.Value);
          gameState.countries[keyValuePair.Key].governmentType = new Country.GovernmentType?(governmentTypeList2[UnityEngine.Random.Range(0, governmentTypeList2.Count)]);
        }
        else if (governmentTypeList3.Contains(gameState.countries[Countries.USSR].governmentType.Value))
        {
          governmentTypeList3.Remove(gameState.countries[Countries.USSR].governmentType.Value);
          governmentTypeList3.Remove(Country.GovernmentType.ConstructingCommunism);
          gameState.countries[keyValuePair.Key].governmentType = new Country.GovernmentType?(governmentTypeList3[UnityEngine.Random.Range(0, governmentTypeList3.Count)]);
        }
        else
        {
          governmentTypeList4.Remove(gameState.countries[Countries.USSR].governmentType.Value);
          gameState.countries[keyValuePair.Key].governmentType = new Country.GovernmentType?(governmentTypeList4[UnityEngine.Random.Range(0, governmentTypeList4.Count)]);
        }
        gameState.countries[keyValuePair.Key].rulingPartyName = CountryUtils.GetPartyNameFromGovernmentType(gameState.countries[keyValuePair.Key].governmentType.Value);
      }
      else
      {
        int num2;
        if ((double) gameState.countries[keyValuePair.Key].ForeignPolicyVector < 50.0)
        {
          puppetOf = gameState.countries[keyValuePair.Key].puppetOf;
          Countries countries = Countries.USSR;
          if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue)
          {
            num2 = 1;
            goto label_21;
          }
        }
        if ((double) gameState.countries[keyValuePair.Key].ForeignPolicyVector > 50.0)
        {
          puppetOf = gameState.countries[keyValuePair.Key].puppetOf;
          Countries countries = Countries.USA;
          num2 = puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue ? 1 : 0;
        }
        else
          num2 = 0;
label_21:
        if (num2 != 0)
        {
          gameState.countries[keyValuePair.Key].puppetOf = new Countries?();
          gameState.countries[keyValuePair.Key].puppetType = Country.PuppetType.None;
          if (governmentTypeList1.Contains(gameState.countries[keyValuePair.Key].governmentType.Value))
          {
            governmentTypeList1.Remove(gameState.countries[keyValuePair.Key].governmentType.Value);
            gameState.countries[keyValuePair.Key].governmentType = new Country.GovernmentType?(governmentTypeList1[UnityEngine.Random.Range(0, governmentTypeList1.Count)]);
          }
          else if (governmentTypeList2.Contains(gameState.countries[keyValuePair.Key].governmentType.Value))
          {
            governmentTypeList2.Remove(gameState.countries[keyValuePair.Key].governmentType.Value);
            gameState.countries[keyValuePair.Key].governmentType = new Country.GovernmentType?(governmentTypeList2[UnityEngine.Random.Range(0, governmentTypeList2.Count)]);
          }
          else if (governmentTypeList3.Contains(gameState.countries[keyValuePair.Key].governmentType.Value))
          {
            governmentTypeList3.Remove(gameState.countries[keyValuePair.Key].governmentType.Value);
            governmentTypeList3.Remove(Country.GovernmentType.ConstructingCommunism);
            gameState.countries[keyValuePair.Key].governmentType = new Country.GovernmentType?(governmentTypeList3[UnityEngine.Random.Range(0, governmentTypeList3.Count)]);
          }
          else
          {
            governmentTypeList4.Remove(gameState.countries[keyValuePair.Key].governmentType.Value);
            gameState.countries[keyValuePair.Key].governmentType = new Country.GovernmentType?(governmentTypeList4[UnityEngine.Random.Range(0, governmentTypeList4.Count)]);
          }
          gameState.countries[keyValuePair.Key].rulingPartyName = CountryUtils.GetPartyNameFromGovernmentType(gameState.countries[keyValuePair.Key].governmentType.Value);
        }
      }
      int num3;
      if ((double) gameState.countries[keyValuePair.Key].ForeignPolicyVector <= 25.0)
      {
        puppetOf = gameState.countries[keyValuePair.Key].puppetOf;
        Countries countries3 = Countries.USA;
        if (!(puppetOf.GetValueOrDefault() == countries3 & puppetOf.HasValue))
        {
          puppetOf = gameState.countries[keyValuePair.Key].puppetOf;
          Countries countries4 = Countries.France;
          num3 = !(puppetOf.GetValueOrDefault() == countries4 & puppetOf.HasValue) ? 1 : 0;
          goto label_34;
        }
      }
      num3 = 0;
label_34:
      if (num3 != 0)
      {
        gameState.countries[keyValuePair.Key].puppetOf = new Countries?(Countries.USA);
        gameState.countries[keyValuePair.Key].puppetType = Country.PuppetType.UnderInfluence;
        if (governmentTypeList1.Contains(gameState.countries[Countries.USA].governmentType.Value))
        {
          governmentTypeList1.Remove(gameState.countries[Countries.USA].governmentType.Value);
          gameState.countries[keyValuePair.Key].governmentType = new Country.GovernmentType?(governmentTypeList1[UnityEngine.Random.Range(0, governmentTypeList1.Count)]);
        }
        else if (governmentTypeList2.Contains(gameState.countries[Countries.USA].governmentType.Value))
        {
          governmentTypeList2.Remove(gameState.countries[Countries.USA].governmentType.Value);
          governmentTypeList3.Remove(Country.GovernmentType.ConstructingCommunism);
          gameState.countries[keyValuePair.Key].governmentType = new Country.GovernmentType?(governmentTypeList2[UnityEngine.Random.Range(0, governmentTypeList2.Count)]);
        }
        else if (governmentTypeList3.Contains(gameState.countries[Countries.USA].governmentType.Value))
        {
          governmentTypeList3.Remove(gameState.countries[Countries.USA].governmentType.Value);
          gameState.countries[keyValuePair.Key].governmentType = new Country.GovernmentType?(governmentTypeList3[UnityEngine.Random.Range(0, governmentTypeList3.Count)]);
        }
        else
        {
          governmentTypeList4.Remove(gameState.countries[Countries.USA].governmentType.Value);
          gameState.countries[keyValuePair.Key].governmentType = new Country.GovernmentType?(governmentTypeList4[UnityEngine.Random.Range(0, governmentTypeList4.Count)]);
        }
        gameState.countries[keyValuePair.Key].rulingPartyName = CountryUtils.GetPartyNameFromGovernmentType(gameState.countries[keyValuePair.Key].governmentType.Value);
      }
      int num4;
      if ((double) gameState.countries[keyValuePair.Key].ForeignPolicyVector >= 99.0)
      {
        puppetOf = gameState.countries[keyValuePair.Key].puppetOf;
        Countries countries = Countries.USSR;
        if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue)
        {
          Country.GovernmentType? governmentType1 = gameState.countries[keyValuePair.Key].governmentType;
          Country.GovernmentType? governmentType2 = gameState.countries[Countries.USSR].governmentType;
          num4 = !(governmentType1.GetValueOrDefault() == governmentType2.GetValueOrDefault() & governmentType1.HasValue == governmentType2.HasValue) ? 1 : 0;
          goto label_47;
        }
      }
      num4 = 0;
label_47:
      if (num4 != 0)
        gameState.countries[keyValuePair.Key].governmentType = gameState.countries[Countries.USSR].governmentType;
      int num5;
      if ((double) gameState.countries[keyValuePair.Key].ForeignPolicyVector <= 1.0)
      {
        puppetOf = gameState.countries[keyValuePair.Key].puppetOf;
        Countries countries = Countries.USA;
        if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue)
        {
          Country.GovernmentType? governmentType3 = gameState.countries[keyValuePair.Key].governmentType;
          Country.GovernmentType? governmentType4 = gameState.countries[Countries.USA].governmentType;
          num5 = !(governmentType3.GetValueOrDefault() == governmentType4.GetValueOrDefault() & governmentType3.HasValue == governmentType4.HasValue) ? 1 : 0;
          goto label_53;
        }
      }
      num5 = 0;
label_53:
      if (num5 != 0)
        gameState.countries[keyValuePair.Key].governmentType = gameState.countries[Countries.USA].governmentType;
    }
  }

  private static void RealizeUSAI(GameState gameState)
  {
    gameState.countries[Countries.USA].RelationshipWithPlayer += (float) ((5 - gameState.Defcon) * 2);
    float num1 = (float) gameState.countries.Select<KeyValuePair<Countries, Country>, (Countries, int)>((Func<KeyValuePair<Countries, Country>, (Countries, int)>) (cou =>
    {
      int key = (int) cou.Key;
      int num2;
      if (cou.Value.militaryAlliance != Country.MilitaryAllianceType.NATO)
      {
        if (cou.Value.militaryAlliance != Country.MilitaryAllianceType.PartnershipNATO)
        {
          if (cou.Value.militaryAlliance != Country.MilitaryAllianceType.AACS)
          {
            Countries? puppetOf = cou.Value.puppetOf;
            Countries countries = Countries.USA;
            num2 = !(puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue) || cou.Value.puppetType >= Country.PuppetType.None ? (!cou.Value.puppetOf.HasValue || gameState.countries[cou.Value.puppetOf.Value].militaryAlliance != Country.MilitaryAllianceType.NATO ? (!cou.Value.puppetOf.HasValue || gameState.countries[cou.Value.puppetOf.Value].militaryAlliance != Country.MilitaryAllianceType.PartnershipNATO ? (!cou.Value.puppetOf.HasValue || gameState.countries[cou.Value.puppetOf.Value].militaryAlliance != Country.MilitaryAllianceType.AACS ? 0 : 1) : 1) : 2) : 1;
          }
          else
            num2 = 2;
        }
        else
          num2 = 3;
      }
      else
        num2 = 5;
      return ((Countries) key, num2);
    })).Sum<(Countries, int)>((Func<(Countries, int), int>) (cou => cou.Point));
    gameState.AmericanEconomyLevel -= (float) gameState.countries.Count<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.economyAlliance == Country.EconomyAllianceType.COMECON));
    gameState.AmericanArmyLevel -= (float) gameState.countries.Count<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.militaryAlliance == Country.MilitaryAllianceType.WarsawPact));
    if (gameState.countries[gameState.playerCountry].economyAlliance != gameState.countries[Countries.USA].economyAlliance && gameState.countries[gameState.playerCountry].militaryAlliance != gameState.countries[Countries.USA].militaryAlliance)
      gameState.AmericanEconomyLevel -= gameState.Export / 50f;
    int count = 10;
    int num3 = gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.activeInGame && cou.Value.isCoupAvailable)).Count<KeyValuePair<Countries, Country>>();
    if (gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
    {
      if (!cou.Value.activeInGame || !cou.Value.isCoupAvailable)
        return false;
      Countries? puppetOf = cou.Value.puppetOf;
      Countries countries = Countries.USSR;
      return puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue;
    })).Count<KeyValuePair<Countries, Country>>() > num3 / 2)
      count += 5;
    IEnumerable<KeyValuePair<Countries, Country>> source = gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
    {
      if (cou.Value.activeInGame && cou.Value.isCoupAvailable)
      {
        Countries? puppetOf1 = cou.Value.puppetOf;
        Countries countries1 = Countries.France;
        if (!(puppetOf1.GetValueOrDefault() == countries1 & puppetOf1.HasValue))
        {
          if ((double) cou.Value.ForeignPolicyVector < 50.0 && (double) cou.Value.ForeignPolicyVector > 20.0)
          {
            Countries? puppetOf2 = cou.Value.puppetOf;
            Countries countries2 = Countries.USA;
            if (puppetOf2.GetValueOrDefault() == countries2 & puppetOf2.HasValue)
              goto label_8;
          }
          if ((double) cou.Value.ForeignPolicyVector >= 75.0 || cou.Value.puppetOf.HasValue)
          {
            if ((double) cou.Value.ForeignPolicyVector >= 75.0)
              return false;
            Countries? puppetOf3 = cou.Value.puppetOf;
            Countries countries3 = Countries.USSR;
            return puppetOf3.GetValueOrDefault() == countries3 & puppetOf3.HasValue;
          }
label_8:
          return true;
        }
      }
      return false;
    }));
    Dictionary<Countries, Country> dictionary = source.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
    {
      Countries? puppetOf = cou.Value.puppetOf;
      Countries countries = Countries.USA;
      return puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue;
    })).OrderByDescending<KeyValuePair<Countries, Country>, float>((Func<KeyValuePair<Countries, Country>, float>) (cou => cou.Value.ForeignPolicyVector)).ToDictionary<KeyValuePair<Countries, Country>, Countries, Country>((Func<KeyValuePair<Countries, Country>, Countries>) (x => x.Key), (Func<KeyValuePair<Countries, Country>, Country>) (x => x.Value));
    if (dictionary.Count<KeyValuePair<Countries, Country>>() < count)
      dictionary = dictionary.Union<KeyValuePair<Countries, Country>>((IEnumerable<KeyValuePair<Countries, Country>>) source.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => !cou.Value.puppetOf.HasValue)).OrderBy<KeyValuePair<Countries, Country>, float>((Func<KeyValuePair<Countries, Country>, float>) (cou => cou.Value.ForeignPolicyVector))).ToDictionary<KeyValuePair<Countries, Country>, Countries, Country>((Func<KeyValuePair<Countries, Country>, Countries>) (x => x.Key), (Func<KeyValuePair<Countries, Country>, Country>) (x => x.Value));
    if (dictionary.Count<KeyValuePair<Countries, Country>>() < count)
      dictionary = dictionary.Union<KeyValuePair<Countries, Country>>((IEnumerable<KeyValuePair<Countries, Country>>) source.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
      {
        Countries? puppetOf = cou.Value.puppetOf;
        Countries countries = Countries.USSR;
        return puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue;
      })).OrderBy<KeyValuePair<Countries, Country>, float>((Func<KeyValuePair<Countries, Country>, float>) (cou => cou.Value.ForeignPolicyVector))).ToDictionary<KeyValuePair<Countries, Country>, Countries, Country>((Func<KeyValuePair<Countries, Country>, Countries>) (x => x.Key), (Func<KeyValuePair<Countries, Country>, Country>) (x => x.Value));
    if (dictionary.Count<KeyValuePair<Countries, Country>>() > count)
      dictionary = dictionary.Take<KeyValuePair<Countries, Country>>(count).ToDictionary<KeyValuePair<Countries, Country>, Countries, Country>((Func<KeyValuePair<Countries, Country>, Countries>) (x => x.Key), (Func<KeyValuePair<Countries, Country>, Country>) (x => x.Value));
    while ((double) gameState.AmericanArmyLevel > 50.0 && (double) gameState.AmericanPopularHappiness > 50.0 && dictionary.Count<KeyValuePair<Countries, Country>>() > 0)
    {
      if (gameState.countries[Countries.USA].militaryAlliance == Country.MilitaryAllianceType.NATO || gameState.countries[Countries.USA].militaryAlliance == Country.MilitaryAllianceType.AACS)
      {
        KeyValuePair<Countries, Country> keyValuePair = dictionary.FirstOrDefault<KeyValuePair<Countries, Country>>();
        Countries? puppetOf = keyValuePair.Value.puppetOf;
        Countries countries4 = Countries.USA;
        if (puppetOf.GetValueOrDefault() == countries4 & puppetOf.HasValue)
        {
          gameState.AmericanArmyLevel -= 0.2f;
          gameState.AmericanPopularHappiness -= 0.2f;
        }
        else
        {
          keyValuePair = dictionary.FirstOrDefault<KeyValuePair<Countries, Country>>();
          puppetOf = keyValuePair.Value.puppetOf;
          Countries countries5 = Countries.USSR;
          if (puppetOf.GetValueOrDefault() == countries5 & puppetOf.HasValue)
          {
            gameState.AmericanArmyLevel -= 0.4f;
            gameState.AmericanPopularHappiness -= 0.4f;
          }
          else
          {
            gameState.AmericanArmyLevel -= 0.25f;
            gameState.AmericanPopularHappiness -= 0.25f;
          }
        }
        Dictionary<Countries, Country> countries6 = gameState.countries;
        keyValuePair = dictionary.FirstOrDefault<KeyValuePair<Countries, Country>>();
        int key = (int) keyValuePair.Key;
        --countries6[(Countries) key].ForeignPolicyVector;
      }
      dictionary.Remove(dictionary.Keys.First<Countries>());
    }
    if ((double) gameState.AmericanEconomyLevel < 25.0 && (gameState.countries[Countries.USA].militaryAlliance == Country.MilitaryAllianceType.NATO || gameState.countries[Countries.USA].militaryAlliance == Country.MilitaryAllianceType.AACS))
    {
      foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
      {
        if (!cou.Value.activeInGame || !cou.Value.isCoupAvailable)
          return false;
        Countries? puppetOf = cou.Value.puppetOf;
        Countries countries = Countries.USA;
        return puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue;
      })))
      {
        gameState.AmericanEconomyLevel += 0.2f;
        gameState.countries[keyValuePair.Key].ForeignPolicyVector += 0.5f;
      }
    }
    gameState.AmericanPopularHappiness -= (float) ((100.0 - (double) gameState.AmericanEconomyLevel) / 10.0);
    if ((double) gameState.AmericanArmyLevel > 75.0)
    {
      float num4 = (float) (((double) gameState.AmericanArmyLevel - 75.0) * 0.25);
      num1 += num4;
      gameState.AmericanArmyLevel -= num4;
    }
    if ((double) gameState.AmericanEconomyLevel > 75.0)
    {
      float num5 = (float) (((double) gameState.AmericanEconomyLevel - 75.0) * 0.25);
      num1 += num5;
      gameState.AmericanArmyLevel -= num5;
    }
    if ((double) gameState.AmericanPopularHappiness > 75.0)
    {
      float num6 = (float) (((double) gameState.AmericanPopularHappiness - 75.0) * 0.25);
      num1 += num6;
      gameState.AmericanArmyLevel -= num6;
    }
    if ((double) gameState.AmericanArmyLevel < 75.0)
    {
      if ((double) num1 / 10.0 > 75.0 - (double) gameState.AmericanArmyLevel)
      {
        gameState.AmericanArmyLevel += 75f - gameState.AmericanArmyLevel;
        num1 -= (float) ((75.0 - (double) gameState.AmericanArmyLevel) * 10.0);
      }
      else
      {
        gameState.AmericanArmyLevel += num1 / 10f;
        num1 = 0.0f;
        if ((double) gameState.AmericanArmyLevel < 75.0)
        {
          gameState.AmericanArmyLevel += gameState.AmericanEconomyLevel / 5f;
          gameState.AmericanEconomyLevel *= 0.75f;
        }
      }
    }
    if ((double) gameState.AmericanEconomyLevel < 75.0)
    {
      if ((double) num1 / 10.0 > 75.0 - (double) gameState.AmericanEconomyLevel)
      {
        gameState.AmericanEconomyLevel += 75f - gameState.AmericanEconomyLevel;
        num1 -= (float) ((75.0 - (double) gameState.AmericanEconomyLevel) * 10.0);
      }
      else
      {
        gameState.AmericanEconomyLevel += num1 / 10f;
        num1 = 0.0f;
        if ((double) gameState.AmericanEconomyLevel < 75.0)
        {
          gameState.AmericanEconomyLevel += gameState.AmericanPopularHappiness / 5f;
          gameState.AmericanPopularHappiness *= 0.75f;
        }
      }
    }
    if ((double) gameState.AmericanPopularHappiness < 75.0)
    {
      if ((double) num1 / 10.0 > 75.0 - (double) gameState.AmericanPopularHappiness)
      {
        gameState.AmericanPopularHappiness += 75f - gameState.AmericanPopularHappiness;
        num1 -= (float) ((75.0 - (double) gameState.AmericanPopularHappiness) * 10.0);
      }
      else
      {
        gameState.AmericanPopularHappiness += num1 / 10f;
        num1 = 0.0f;
      }
    }
    gameState.AmericanPopularHappiness -= gameState.AmericanPopularHappiness / 100f;
    gameState.AmericanEconomyLevel -= gameState.AmericanEconomyLevel / 100f;
    gameState.AmericanArmyLevel -= gameState.AmericanArmyLevel / 100f;
    if ((double) num1 <= 0.0 || gameState.technologies[ScienceTree.American][9].state == TechnologyStatus.TechnologyState.Completed && gameState.technologies[ScienceTree.American][4].state == TechnologyStatus.TechnologyState.Completed)
      return;
    int num7 = 0;
    if (gameState.countries.Count<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.militaryAlliance == Country.MilitaryAllianceType.WarsawPact)) > 0)
      ++num7;
    if (gameState.countries.Count<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.economyAlliance == Country.EconomyAllianceType.COMECON)) > 0)
      ++num7;
    if (gameState.doctrines[DoctrineType.DiplomacyLine].branch == AbstractDoctrine.DoctrineBranchType.Top)
      num7 += gameState.doctrines[DoctrineType.DiplomacyLine].number + 1;
    else if (gameState.doctrines[DoctrineType.DiplomacyLine].branch == AbstractDoctrine.DoctrineBranchType.Bottom)
      num7 -= gameState.doctrines[DoctrineType.DiplomacyLine].number + 1;
    if (gameState.doctrines[DoctrineType.InternationalTreaties].branch == AbstractDoctrine.DoctrineBranchType.Top)
      num7 += gameState.doctrines[DoctrineType.InternationalTreaties].number;
    else if (gameState.doctrines[DoctrineType.InternationalTreaties].branch == AbstractDoctrine.DoctrineBranchType.Bottom)
      num7 -= gameState.doctrines[DoctrineType.InternationalTreaties].number + 1;
    if (gameState.doctrines[DoctrineType.InternationalDepartment].branch == AbstractDoctrine.DoctrineBranchType.Top)
      num7 += gameState.doctrines[DoctrineType.InternationalDepartment].number + 1;
    else if (gameState.doctrines[DoctrineType.InternationalDepartment].branch != 0)
      num7 -= gameState.doctrines[DoctrineType.InternationalDepartment].number + 1;
    int num8 = gameState.doctrines[DoctrineType.TradePolicy].branch != AbstractDoctrine.DoctrineBranchType.Top ? (gameState.doctrines[DoctrineType.TradePolicy].branch != AbstractDoctrine.DoctrineBranchType.Central ? num7 - 2 : num7 - 1) : num7 + (gameState.doctrines[DoctrineType.TradePolicy].number + 1);
    int num9 = gameState.doctrines[DoctrineType.TypeOfEconomy].branch != AbstractDoctrine.DoctrineBranchType.Top ? (gameState.doctrines[DoctrineType.TypeOfEconomy].branch != AbstractDoctrine.DoctrineBranchType.Central ? num8 - gameState.doctrines[DoctrineType.TypeOfEconomy].number : num8 + 1) : num8 + (gameState.doctrines[DoctrineType.TypeOfEconomy].number + 1);
    int index1 = 0;
    int num10 = 0;
    if (num9 < 8 && gameState.technologies[ScienceTree.American][9].state != TechnologyStatus.TechnologyState.Completed || gameState.technologies[ScienceTree.American][4].state == TechnologyStatus.TechnologyState.Completed)
      num10 = 5;
    for (int index2 = num10; index2 < gameState.technologies[ScienceTree.American].Length; ++index2)
    {
      if (gameState.technologies[ScienceTree.American][index2].state == TechnologyStatus.TechnologyState.NotStarted || gameState.technologies[ScienceTree.American][index2].state == TechnologyStatus.TechnologyState.InProgess)
      {
        index1 = index2;
        break;
      }
    }
    if (gameState.technologies[ScienceTree.American][index1].state != TechnologyStatus.TechnologyState.Completed && gameState.technologies[ScienceTree.American][index1].state != TechnologyStatus.TechnologyState.InProgess)
      gameState.technologies[ScienceTree.American][index1].state = TechnologyStatus.TechnologyState.InProgess;
    else if (gameState.technologies[ScienceTree.American][index1].state == TechnologyStatus.TechnologyState.InProgess)
    {
      int num11 = (int) ((double) num1 / 3.0);
      if (gameState.technologies[ScienceTree.American][index1].investedCost.physicPoints + num11 < TechnologiesManager.inst.GetTechnology(ScienceTree.American).GetTechnologyCost(index1).physicPoints)
        gameState.technologies[ScienceTree.American][index1].investedCost.physicPoints += num11;
      else
        gameState.technologies[ScienceTree.American][index1].investedCost.physicPoints = TechnologiesManager.inst.GetTechnology(ScienceTree.American).GetTechnologyCost(index1).physicPoints;
      if (gameState.technologies[ScienceTree.American][index1].investedCost.civilPoints + num11 < TechnologiesManager.inst.GetTechnology(ScienceTree.American).GetTechnologyCost(index1).civilPoints)
        gameState.technologies[ScienceTree.American][index1].investedCost.civilPoints += num11;
      else
        gameState.technologies[ScienceTree.American][index1].investedCost.civilPoints = TechnologiesManager.inst.GetTechnology(ScienceTree.American).GetTechnologyCost(index1).civilPoints;
      if (gameState.technologies[ScienceTree.American][index1].investedCost.cyberneticPoints + num11 < TechnologiesManager.inst.GetTechnology(ScienceTree.American).GetTechnologyCost(index1).cyberneticPoints)
        gameState.technologies[ScienceTree.American][index1].investedCost.cyberneticPoints += num11;
      else
        gameState.technologies[ScienceTree.American][index1].investedCost.cyberneticPoints = TechnologiesManager.inst.GetTechnology(ScienceTree.American).GetTechnologyCost(index1).cyberneticPoints;
      if (gameState.technologies[ScienceTree.American][index1].investedCost.militaryPoints + num11 < TechnologiesManager.inst.GetTechnology(ScienceTree.American).GetTechnologyCost(index1).militaryPoints)
        gameState.technologies[ScienceTree.American][index1].investedCost.militaryPoints += num11;
      else
        gameState.technologies[ScienceTree.American][index1].investedCost.militaryPoints = TechnologiesManager.inst.GetTechnology(ScienceTree.American).GetTechnologyCost(index1).militaryPoints;
      if (gameState.technologies[ScienceTree.American][index1].investedCost == TechnologiesManager.inst.GetTechnology(ScienceTree.American).GetTechnologyCost(index1))
      {
        TechnologiesManager.inst.GetTechnology(ScienceTree.American).CompleteTechnology(index1, gameState);
        CountryUtils.GetAmericanScienceResults(gameState, index1);
      }
    }
  }

  private static void GetAmericanScienceResults(GameState gameState, int num)
  {
    switch (num)
    {
      case 0:
        gameState.activeModificators.Add(87, new ModificatorState()
        {
          level = 1
        });
        break;
      case 1:
        ++gameState.activeModificators[87].level;
        break;
      case 3:
        gameState.activeModificators[87].level += gameState.technologies[ScienceTree.SpaceProgram][8].state == TechnologyStatus.TechnologyState.Completed ? 1 : 3;
        break;
      case 4:
        gameState.activeModificators[87].level += gameState.technologies[ScienceTree.SpaceProgram][9].state == TechnologyStatus.TechnologyState.Completed ? 1 : 3;
        break;
      case 5:
        ++gameState.activeModificators[61].level;
        break;
      case 6:
        gameState.activeModificators.Add(57, new ModificatorState()
        {
          level = 1,
          progressToNextLevel = 100
        });
        break;
      case 7:
        gameState.activeModificators[61].level += gameState.technologies[ScienceTree.Computers][2].state == TechnologyStatus.TechnologyState.Completed ? 1 : 3;
        break;
      case 8:
        gameState.activeModificators[61].level += gameState.technologies[ScienceTree.Agriculture][8].state == TechnologyStatus.TechnologyState.Completed ? 1 : 3;
        break;
    }
  }

  private static void FillPlayersCountryInfo(GameState gameState)
  {
    gameState.countries[gameState.playerCountry].governmentType = new Country.GovernmentType?(CountryUtils.GetPlayerCountryGovernmentType(gameState));
  }

  public static List<Countries> GetRepublicsOfPlayerKeys(GameState gameState)
  {
    return CountryUtils.GetRepublicsOfPlayer(gameState).Select<KeyValuePair<Countries, Country>, Countries>((Func<KeyValuePair<Countries, Country>, Countries>) (cou => cou.Key)).ToList<Countries>();
  }

  public static Dictionary<Countries, Country> GetRepublicsOfPlayer(GameState gameState)
  {
    return gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => CountryUtils.IsItPlayeresCountry(gameState, cou.Value))).ToDictionary<KeyValuePair<Countries, Country>, Countries, Country>((Func<KeyValuePair<Countries, Country>, Countries>) (k => k.Key), (Func<KeyValuePair<Countries, Country>, Country>) (k => k.Value));
  }

  public static List<Country> GetRepublicsOfPlayerValues(GameState gameState)
  {
    return CountryUtils.GetRepublicsOfPlayer(gameState).Select<KeyValuePair<Countries, Country>, Country>((Func<KeyValuePair<Countries, Country>, Country>) (cou => cou.Value)).ToList<Country>();
  }

  public static void AddLoyaltyToRepublicsOfPlayer(GameState gameState, float loyalty)
  {
    foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => CountryUtils.IsItPlayeresCountry(gameState, cou.Value))))
      keyValuePair.Value.RelationshipWithPlayer += loyalty;
  }

  public static bool IsItPlayeresCountry(GameState gameState, Country cou)
  {
    Countries? puppetOf = cou.puppetOf;
    Countries playerCountry = gameState.playerCountry;
    return puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue && cou.puppetType < Country.PuppetType.PuppetOtherState;
  }

  public static int GetNumberOfRepublicsOfPlayer(GameState gameState)
  {
    return gameState.countries.Count<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => CountryUtils.IsItPlayeresCountry(gameState, cou.Value)));
  }

  public static int GetNumberOfCountriesInMilitaryAlliance(
    GameState gameState,
    Country.MilitaryAllianceType militaryAlliance = Country.MilitaryAllianceType.None)
  {
    return gameState.countries.Count<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.militaryAlliance == militaryAlliance));
  }

  public static int GetNumberOfCountriesInEconomicAlliance(
    GameState gameState,
    Country.EconomyAllianceType economyAlliance = Country.EconomyAllianceType.None)
  {
    return gameState.countries.Count<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.economyAlliance == economyAlliance));
  }

  public static float GetAverageLoyalty(GameState gameState)
  {
    return gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => CountryUtils.IsItPlayeresCountry(gameState, cou.Value))).Average<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, float>) (cou => cou.Value.RelationshipWithPlayer));
  }

  public static string GetButtonEndDate(GameState gameState, Countries country, int Id, bool date = false)
  {
    if (gameState.diplomacyButtonsTimeouts[Id] == null)
      return (string) null;
    string str = LanguageManager.inst["decisions_window", $"month{gameState.diplomacyButtonsTimeouts[Id][country].Month}"] ?? "";
    string buttonEndDate;
    if (date)
      buttonEndDate = $"{gameState.diplomacyButtonsTimeouts[Id][country].Day} {str} {gameState.diplomacyButtonsTimeouts[Id][country].Year}";
    else
      buttonEndDate = $"{LanguageManager.inst["decisions_window", "add_decision_until3"]}: {gameState.diplomacyButtonsTimeouts[Id][country].Day} {str} {gameState.diplomacyButtonsTimeouts[Id][country].Year}";
    return buttonEndDate;
  }

  public static void ChangeZoneRelations(GameState gameState, float num, Country.ZoneType zone = Country.ZoneType.WestEurope)
  {
    foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.zoneType == zone)))
      keyValuePair.Value.RelationshipWithPlayer += num;
  }

  public static void ChangeZoneForeignPolicyVector(
    GameState gameState,
    float num,
    Country.ZoneType zone = Country.ZoneType.WestEurope)
  {
    foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.zoneType == zone)))
      keyValuePair.Value.ForeignPolicyVector += num;
  }

  public static void ChangeLiberalizationVector(GameState gameState, float num, bool change = false)
  {
    foreach (KeyValuePair<Countries, Country> keyValuePair in gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
    {
      if (cou.Value.militaryAlliance != Country.MilitaryAllianceType.WarsawPact)
      {
        if (cou.Value.economyAlliance == Country.EconomyAllianceType.COMECON)
        {
          Countries? puppetOf = cou.Value.puppetOf;
          Countries playerCountry = gameState.playerCountry;
          if (puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue && cou.Value.puppetType > Country.PuppetType.EqualState)
            goto label_3;
        }
        return false;
      }
label_3:
      return cou.Value.zoneType < Country.ZoneType.SouthEastAsia;
    })))
      keyValuePair.Value.LiberalizationVector += num;
  }

  public static bool IsCountryInEnemyMilitaryAlliance(
    GameState gameState,
    Country countryInfo,
    bool includeNeutrality = false)
  {
    Country country = gameState.countries[gameState.playerCountry];
    return country.militaryAlliance == Country.MilitaryAllianceType.WarsawPact || country.economyAlliance == Country.EconomyAllianceType.COMECON || country.economyAlliance == Country.EconomyAllianceType.AssociativeCOMECON || country.militaryAlliance == Country.MilitaryAllianceType.OfficialNeutrality ? countryInfo.militaryAlliance == Country.MilitaryAllianceType.NATO || countryInfo.militaryAlliance == Country.MilitaryAllianceType.PartnershipNATO || countryInfo.militaryAlliance == Country.MilitaryAllianceType.AACS || includeNeutrality && countryInfo.militaryAlliance == Country.MilitaryAllianceType.OfficialNeutrality : (country.militaryAlliance == Country.MilitaryAllianceType.NATO || country.militaryAlliance == Country.MilitaryAllianceType.PartnershipNATO || country.militaryAlliance == Country.MilitaryAllianceType.AACS || country.economyAlliance == Country.EconomyAllianceType.EU || country.economyAlliance == Country.EconomyAllianceType.WAFT || country.militaryAlliance == Country.MilitaryAllianceType.OfficialNeutrality ? countryInfo.militaryAlliance == Country.MilitaryAllianceType.WarsawPact || includeNeutrality && countryInfo.militaryAlliance == Country.MilitaryAllianceType.OfficialNeutrality : includeNeutrality && country.militaryAlliance != Country.MilitaryAllianceType.OfficialNeutrality && countryInfo.militaryAlliance == Country.MilitaryAllianceType.OfficialNeutrality);
  }

  public static bool IsCountryInEnemyEconomicAlliance(GameState gameState, Country countryInfo)
  {
    Country country = gameState.countries[gameState.playerCountry];
    return country.militaryAlliance == Country.MilitaryAllianceType.WarsawPact || country.economyAlliance == Country.EconomyAllianceType.COMECON || country.economyAlliance == Country.EconomyAllianceType.AssociativeCOMECON || country.militaryAlliance == Country.MilitaryAllianceType.OfficialNeutrality ? countryInfo.economyAlliance == Country.EconomyAllianceType.EU || countryInfo.economyAlliance == Country.EconomyAllianceType.WAFT : (country.militaryAlliance == Country.MilitaryAllianceType.NATO || country.militaryAlliance == Country.MilitaryAllianceType.PartnershipNATO || country.militaryAlliance == Country.MilitaryAllianceType.AACS || country.economyAlliance == Country.EconomyAllianceType.EU || country.economyAlliance == Country.EconomyAllianceType.WAFT || country.militaryAlliance == Country.MilitaryAllianceType.OfficialNeutrality) && (countryInfo.economyAlliance == Country.EconomyAllianceType.COMECON || countryInfo.economyAlliance == Country.EconomyAllianceType.AssociativeCOMECON);
  }

  public static bool IsCountryInFriendlyMilitaryAlliance(GameState gameState, Country countryInfo)
  {
    Country country = gameState.countries[gameState.playerCountry];
    return country.militaryAlliance == Country.MilitaryAllianceType.WarsawPact && countryInfo.militaryAlliance == Country.MilitaryAllianceType.WarsawPact || (country.militaryAlliance == Country.MilitaryAllianceType.NATO || country.militaryAlliance == Country.MilitaryAllianceType.PartnershipNATO || country.militaryAlliance == Country.MilitaryAllianceType.AACS) && (countryInfo.militaryAlliance == Country.MilitaryAllianceType.NATO || countryInfo.militaryAlliance == Country.MilitaryAllianceType.PartnershipNATO || countryInfo.militaryAlliance == Country.MilitaryAllianceType.AACS) || country.militaryAlliance == Country.MilitaryAllianceType.OfficialNeutrality && countryInfo.militaryAlliance == Country.MilitaryAllianceType.OfficialNeutrality;
  }

  public static bool IsCountryInFriendlyEconomicAlliance(GameState gameState, Country countryInfo)
  {
    Country country = gameState.countries[gameState.playerCountry];
    return (country.economyAlliance == Country.EconomyAllianceType.COMECON || country.economyAlliance == Country.EconomyAllianceType.AssociativeCOMECON) && (countryInfo.economyAlliance == Country.EconomyAllianceType.COMECON || countryInfo.economyAlliance == Country.EconomyAllianceType.AssociativeCOMECON) || (country.economyAlliance == Country.EconomyAllianceType.EU || country.economyAlliance == Country.EconomyAllianceType.WAFT) && (countryInfo.economyAlliance == Country.EconomyAllianceType.EU || countryInfo.economyAlliance == Country.EconomyAllianceType.WAFT);
  }

  public static void SecessionFromPlayer(
    GameState gameState,
    Countries country,
    Country.PuppetType puppetType = Country.PuppetType.None,
    Country.MilitaryAllianceType milTyupe = Country.MilitaryAllianceType.None,
    Country.EconomyAllianceType ecType = Country.EconomyAllianceType.None,
    Country.LeaderType leader = Country.LeaderType.None)
  {
    Country country1 = gameState.countries[country];
    Country country2 = gameState.countries[gameState.playerCountry];
    List<Country.GovernmentType> governmentTypeList1 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LeftNationalism,
      Country.GovernmentType.ConservativeSocialism,
      Country.GovernmentType.SocialismNationalSpecific,
      Country.GovernmentType.LeftPragmatism
    };
    List<Country.GovernmentType> governmentTypeList2 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalConservative,
      Country.GovernmentType.PopulistConservative,
      Country.GovernmentType.RightPopulism,
      Country.GovernmentType.ReactonaryAuthoritarian,
      Country.GovernmentType.MarketAuthoritarian
    };
    List<Country.GovernmentType> governmentTypeList3 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.DemocraticSocialism,
      Country.GovernmentType.SocialistReformism,
      Country.GovernmentType.SocialDemocracy
    };
    List<Country.GovernmentType> governmentTypeList4 = new List<Country.GovernmentType>()
    {
      Country.GovernmentType.LiberalCorporativism,
      Country.GovernmentType.LiberalProgressive,
      Country.GovernmentType.ClassicalLiberalism,
      Country.GovernmentType.Centrism
    };
    if (governmentTypeList1.Contains(country2.governmentType.Value) || governmentTypeList3.Contains(country2.governmentType.Value))
      country1.governmentType = new Country.GovernmentType?(governmentTypeList4[UnityEngine.Random.Range(0, governmentTypeList4.Count)]);
    else if (governmentTypeList2.Contains(country2.governmentType.Value) || governmentTypeList4.Contains(country2.governmentType.Value))
      country1.governmentType = new Country.GovernmentType?(governmentTypeList3[UnityEngine.Random.Range(0, governmentTypeList3.Count)]);
    country1.leaderType = leader;
    country1.rulingPartyName = CountryUtils.GetPartyNameFromGovernmentType(country1.governmentType.Value);
    country1.puppetType = puppetType;
    if (puppetType == Country.PuppetType.None)
      country1.puppetOf = new Countries?();
    country1.militaryAlliance = milTyupe;
    country1.economyAlliance = ecType;
    country1.activeInGame = true;
    foreach (KeyValuePair<Characters, CharacterInfo> keyValuePair in gameState.characters.Where<KeyValuePair<Characters, CharacterInfo>>((Func<KeyValuePair<Characters, CharacterInfo>, bool>) (pol =>
    {
      if (pol.Value.status == CharacterInfo.PoliticStatus.Dead || pol.Key == gameState.gameCharacter || pol.Value.homeLand != country)
        return false;
      PoliticPosition? politicPosition1 = gameState.politicPositions[pol.Key];
      PoliticPosition politicPosition2 = PoliticPosition.President;
      return !(politicPosition1.GetValueOrDefault() == politicPosition2 & politicPosition1.HasValue);
    })))
      PoliticUtils.ImmgirateFromCountry(gameState, keyValuePair.Key);
  }

  public static List<Countries> PuppetList(
    GameState gameState,
    Countries country,
    Country.PuppetType pupType)
  {
    return gameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
    {
      if (cou.Value.puppetType != pupType)
        return false;
      Countries? puppetOf = cou.Value.puppetOf;
      Countries countries = country;
      return puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue;
    })).Select<KeyValuePair<Countries, Country>, Countries>((Func<KeyValuePair<Countries, Country>, Countries>) (cou => cou.Key)).ToList<Countries>();
  }

  public static List<Country.GovernmentType> PlayerFactionsGovernmentTypeList(Factions faction)
  {
    return GameStateManager.inst.GameRules.supportedStateSys[faction].ToList<Country.GovernmentType>();
  }

  public static Country.PartyName GetPartyNameFromGovernmentType(Country.GovernmentType type)
  {
    Country.PartyName fromGovernmentType = Country.PartyName.None;
    switch (type)
    {
      case Country.GovernmentType.ConstructingCommunism:
      case Country.GovernmentType.ConservativeSocialism:
      case Country.GovernmentType.SocialismNationalSpecific:
        fromGovernmentType = Country.PartyName.CommunistParty;
        break;
      case Country.GovernmentType.SocialistReformism:
      case Country.GovernmentType.DemocraticSocialism:
        fromGovernmentType = Country.PartyName.SocialistParty;
        break;
      case Country.GovernmentType.LeftNationalism:
        fromGovernmentType = Country.PartyName.LeftNationalismParty;
        break;
      case Country.GovernmentType.LeftPragmatism:
        fromGovernmentType = Country.PartyName.LeftPragmatismParty;
        break;
      case Country.GovernmentType.SocialDemocracy:
        fromGovernmentType = Country.PartyName.SocialDemocracyParty;
        break;
      case Country.GovernmentType.Centrism:
        fromGovernmentType = Country.PartyName.CentristParty;
        break;
      case Country.GovernmentType.LiberalProgressive:
      case Country.GovernmentType.ClassicalLiberalism:
      case Country.GovernmentType.LiberalCorporativism:
        fromGovernmentType = Country.PartyName.LiberalProgressiveParty;
        break;
      case Country.GovernmentType.LiberalConservative:
        fromGovernmentType = Country.PartyName.LiberalConservativeParty;
        break;
      case Country.GovernmentType.PopulistConservative:
        fromGovernmentType = Country.PartyName.PopulistConservativeParty;
        break;
      case Country.GovernmentType.RightPopulism:
        fromGovernmentType = Country.PartyName.RightPopulismParty;
        break;
      case Country.GovernmentType.MarketAuthoritarian:
        fromGovernmentType = Country.PartyName.MarketAuthoritarianParty;
        break;
      case Country.GovernmentType.ReactonaryAuthoritarian:
        fromGovernmentType = Country.PartyName.ReactonaryAuthoritarianParty;
        break;
    }
    return fromGovernmentType;
  }

  public static int GetPlayersLeftism(GameState gameState, GameRules gameRules)
  {
    return gameState.doctrines.Sum<KeyValuePair<DoctrineType, DoctrineState>>((Func<KeyValuePair<DoctrineType, DoctrineState>, int>) (d => gameRules.leftismOfDoctrines[DoctrinesManager.inst.GetDoctrine(d.Key).Variants[d.Value.branch][d.Value.number]]));
  }

  public static int GetPlayersAuthism(GameState gameState, GameRules gameRules)
  {
    return gameState.doctrines.Sum<KeyValuePair<DoctrineType, DoctrineState>>((Func<KeyValuePair<DoctrineType, DoctrineState>, int>) (d => gameRules.authismOfDoctrines[DoctrinesManager.inst.GetDoctrine(d.Key).Variants[d.Value.branch][d.Value.number]]));
  }

  public static float GetNormalizedLeftism(float absLeft)
  {
    return (float) ((((double) absLeft - -45.0) / 85.0 * 2.0 - 1.0) * -1.0);
  }

  public static float GetNormalizedAuthism(float absAuth)
  {
    return (float) (((double) absAuth - -75.0) / 175.0 * 2.0 - 1.0);
  }

  public static Country.GovernmentType GetPlayerCountryGovernmentType(GameState gameState)
  {
    int leftism = CountryUtils.GetPlayersLeftism(gameState, GameStateManager.inst.GameRules);
    int autorism = CountryUtils.GetPlayersAuthism(gameState, GameStateManager.inst.GameRules);
    return gameState.doctrines[DoctrineType.TypeOfEconomy].branch != AbstractDoctrine.DoctrineBranchType.Top || gameState.doctrines[DoctrineType.TypeOfEconomy].number != 0 ? GameStateManager.inst.GameRules.governmentTypeArea.FirstOrDefault<KeyValuePair<Country.GovernmentType, GameRules.GovernmentTypeArea>>((Func<KeyValuePair<Country.GovernmentType, GameRules.GovernmentTypeArea>, bool>) (s => (double) leftism <= (double) s.Value.topX && (double) leftism >= (double) s.Value.bottomX && (double) autorism <= (double) s.Value.topY && (double) autorism >= (double) s.Value.bottomY)).Key : Country.GovernmentType.ConstructingCommunism;
  }

  public static (string, string) GetPartyName(
    GameState gameState,
    Countries country,
    Country.PartyName party)
  {
    KeyValuePair<Factions, MultiPartyClass> keyValuePair = gameState.partyStates.FirstOrDefault<KeyValuePair<Factions, MultiPartyClass>>((Func<KeyValuePair<Factions, MultiPartyClass>, bool>) (fra => fra.Value.playersAlly));
    if (country == gameState.playerCountry)
      return gameState.activeModificators.ContainsKey(69) && gameState.playerCountry == Countries.USSR ? (LanguageManager.inst["foreign_party_names", "USSR_Yakovlev"], LanguageManager.inst["foreign_party_desc", "USSR_Yakovlev"]) : (LanguageManager.inst["foreign_party_names", $"{gameState.playerCountry.ToString()}_party{(int) keyValuePair.Key}_{gameState.partyStates[keyValuePair.Key].nameType}"], LanguageManager.inst["foreign_party_desc", $"{gameState.playerCountry.ToString()}_party{(int) keyValuePair.Key}_{gameState.partyStates[keyValuePair.Key].nameType}"]);
    int num;
    if (gameState.playerCountry == Countries.USSR)
    {
      Countries? puppetOf = gameState.countries[country].puppetOf;
      Countries countries = Countries.USSR;
      if (puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue && gameState.countries[country].puppetType < Country.PuppetType.PuppetOtherState)
      {
        num = gameState.activeModificators.ContainsKey(69) ? 1 : 0;
        goto label_8;
      }
    }
    num = 0;
label_8:
    if (num != 0)
      return (LanguageManager.inst["foreign_party_names", "USSR_Yakovlev"], LanguageManager.inst["foreign_party_desc", "USSR_Yakovlev"]);
    if (!LanguageManager.inst.CheckItemAvailabilityInCategory("foreign_party_names", $"{country.ToString()}_{party.ToString()}"))
      return (LanguageManager.inst["foreign_party_names", "default_" + party.ToString()], LanguageManager.inst["foreign_party_desc", "default_" + party.ToString()]);
    return gameState.playerCountry == Countries.USSR && gameState.countries[country].puppetType == Country.PuppetType.Autonomy ? CountryUtils.GetPartyName(gameState, Countries.USSR, gameState.countries[Countries.USSR].rulingPartyName) : (LanguageManager.inst["foreign_party_names", $"{country.ToString()}_{party.ToString()}"], LanguageManager.inst["foreign_party_desc", $"{country.ToString()}_{party.ToString()}"]);
  }

  public static (string, string) GetCountryPlayerName(GameState gameState, Countries country)
  {
    string str1 = "";
    string str2 = (string) null;
    if (gameState.playerCountry == Countries.USSR)
    {
      if (country == Countries.USSR)
      {
        string str3 = gameState.doctrines[DoctrineType.ChambersOfParliament].branch != AbstractDoctrine.DoctrineBranchType.BottomRight || gameState.doctrines[DoctrineType.StateStructure].branch != AbstractDoctrine.DoctrineBranchType.Bottom ? "union" : "сommonwealth";
        string str4 = gameState.doctrines[DoctrineType.ChambersOfParliament].branch != AbstractDoctrine.DoctrineBranchType.BottomRight ? (gameState.acceptedDecisions.Contains(112 /*0x70*/) ? "democratic" : "soviet") : "federal";
        string str5;
        if (gameState.doctrines[DoctrineType.StateStructure].branch == AbstractDoctrine.DoctrineBranchType.Central || gameState.doctrines[DoctrineType.StateStructure].branch == AbstractDoctrine.DoctrineBranchType.Bottom)
        {
          str5 = "sovereign";
        }
        else
        {
          Country.GovernmentType? governmentType1 = gameState.countries[country].governmentType;
          Country.GovernmentType governmentType2 = Country.GovernmentType.ConstructingCommunism;
          str5 = !(governmentType1.GetValueOrDefault() == governmentType2 & governmentType1.HasValue) ? (gameState.countries[country].governmentType.Value <= Country.GovernmentType.ConstructingCommunism || gameState.countries[country].governmentType.Value >= Country.GovernmentType.SocialDemocracy ? "people" : "socialist") : "communism";
        }
        string str6 = gameState.doctrines[DoctrineType.StateStructure].branch != AbstractDoctrine.DoctrineBranchType.Top || gameState.doctrines[DoctrineType.StateStructure].number != 2 ? (gameState.doctrines[DoctrineType.StateStructure].branch != AbstractDoctrine.DoctrineBranchType.Bottom ? "republic" : "state") : "autonomy";
        if (str5 != null)
        {
          str1 = $"{LanguageManager.inst["player_country_desc", str3 ?? ""]} {LanguageManager.inst["player_country_desc", str4 ?? ""]} {LanguageManager.inst["player_country_desc", str5 ?? ""]} {LanguageManager.inst["player_country_desc", str6 ?? ""]}";
          str2 = LanguageManager.inst["player_country_desc", str3 ?? ""].Substring(0, 1) + LanguageManager.inst["player_country_desc", str4 ?? ""].Substring(0, 1) + LanguageManager.inst["player_country_desc", str5 ?? ""].Substring(0, 1) + LanguageManager.inst["player_country_desc", str6 ?? ""].Substring(0, 1);
        }
        else
        {
          str1 = $"{LanguageManager.inst["player_country_desc", str3 ?? ""]} {LanguageManager.inst["player_country_desc", str4 ?? ""]} {LanguageManager.inst["player_country_desc", str6 ?? ""]}";
          str2 = LanguageManager.inst["player_country_desc", str3 ?? ""].Substring(0, 1) + LanguageManager.inst["player_country_desc", str4 ?? ""].Substring(0, 1) + LanguageManager.inst["player_country_desc", str6 ?? ""].Substring(0, 1);
        }
      }
      else
      {
        string str7 = country.ToString();
        int length = country != Countries.Azerbaijan && country != Countries.Kazakhstan && country != Countries.Litva && country != Countries.Turkmenia ? (country != Countries.Kyrgizia && country != Countries.Tajikistan && country != Countries.Latvia && country != Countries.Moldavia && country != Countries.Mongolia && country != Countries.Georgia ? (country != Countries.Estonia && country != Countries.Armenia && country != Countries.Uzbekistan && country != Countries.Finland ? 1 : 3) : 4) : 5;
        string str8 = gameState.doctrines[DoctrineType.ChambersOfParliament].branch != AbstractDoctrine.DoctrineBranchType.BottomRight || country == Countries.Russia ? (gameState.acceptedDecisions.Contains(112 /*0x70*/) ? "democratic" : "soviet_rep") : "federal_rep";
        string str9;
        if (gameState.doctrines[DoctrineType.StateStructure].branch == AbstractDoctrine.DoctrineBranchType.Central || gameState.doctrines[DoctrineType.StateStructure].branch == AbstractDoctrine.DoctrineBranchType.Bottom)
        {
          str9 = "sovereign_rep";
        }
        else
        {
          Country.GovernmentType? governmentType3 = gameState.countries[Countries.USSR].governmentType;
          Country.GovernmentType governmentType4 = Country.GovernmentType.ConstructingCommunism;
          str9 = !(governmentType3.GetValueOrDefault() == governmentType4 & governmentType3.HasValue) ? (gameState.countries[Countries.USSR].governmentType.Value <= Country.GovernmentType.ConstructingCommunism || gameState.countries[Countries.USSR].governmentType.Value >= Country.GovernmentType.SocialDemocracy ? "people_rep" : "socialist_rep") : "communism_rep";
        }
        string str10 = gameState.doctrines[DoctrineType.StateStructure].branch != AbstractDoctrine.DoctrineBranchType.Top || gameState.doctrines[DoctrineType.StateStructure].number != 2 ? "republic_rep" : "autonomy_rep";
        if (country != Countries.Russia)
        {
          str1 = $"{LanguageManager.inst["player_country_desc", str7 ?? ""]} {LanguageManager.inst["player_country_desc", str8 ?? ""]} {LanguageManager.inst["player_country_desc", str9 ?? ""]} {LanguageManager.inst["player_country_desc", str10 ?? ""]}";
          str2 = LanguageManager.inst["player_country_desc", str7 ?? ""].Substring(0, length) + LanguageManager.inst["player_country_desc", str8 ?? ""].Substring(0, 1) + LanguageManager.inst["player_country_desc", str9 ?? ""].Substring(0, 1) + LanguageManager.inst["player_country_desc", str10 ?? ""].Substring(0, 1);
        }
        else
        {
          str1 = $"{LanguageManager.inst["player_country_desc", str7 ?? ""]} {LanguageManager.inst["player_country_desc", str8 ?? ""]} {LanguageManager.inst["player_country_desc", "federal_rep"]} {LanguageManager.inst["player_country_desc", str9 ?? ""]} {LanguageManager.inst["player_country_desc", str10 ?? ""]}";
          str2 = LanguageManager.inst["player_country_desc", str7 ?? ""].Substring(0, length) + LanguageManager.inst["player_country_desc", str8 ?? ""].Substring(0, 1) + LanguageManager.inst["player_country_desc", "federal_rep"].Substring(0, 1) + LanguageManager.inst["player_country_desc", str9 ?? ""].Substring(0, 1) + LanguageManager.inst["player_country_desc", str10 ?? ""].Substring(0, 1);
        }
        if (gameState.activeModificators.ContainsKey(53))
        {
          str1 = LanguageManager.inst["player_country_desc", country.ToString() + "_empire"];
          str2 = LanguageManager.inst["player_country_desc", country.ToString() + "_empire"];
        }
      }
    }
    return (str1, str2);
  }

  public static string GetCountryName(GameState gameState, Countries country, bool letters = false)
  {
    int num;
    if (country != gameState.playerCountry)
    {
      Countries? puppetOf = gameState.countries[country].puppetOf;
      Countries countries = Countries.USSR;
      num = !(puppetOf.GetValueOrDefault() == countries & puppetOf.HasValue) ? 0 : (gameState.countries[country].puppetType < Country.PuppetType.PuppetOtherState ? 1 : 0);
    }
    else
      num = 1;
    if (num != 0)
      return letters ? CountryUtils.GetCountryPlayerName(gameState, country).Item2 : CountryUtils.GetCountryPlayerName(gameState, country).Item1;
    return LanguageManager.inst.CheckItemAvailabilityInCategory("country_names", $"{country.ToString()}_{gameState.countries[country].governmentType.ToString()}") ? (letters ? string.Concat<char>(LanguageManager.inst["country_names", $"{country.ToString()}_{gameState.countries[country].governmentType.ToString()}"].Where<char>((Func<char, bool>) (c => char.IsUpper(c)))) : LanguageManager.inst["country_names", $"{country.ToString()}_{gameState.countries[country].governmentType.ToString()}"]) : (letters ? string.Concat<char>(LanguageManager.inst["country_names", country.ToString() + "_default"].Where<char>((Func<char, bool>) (c => char.IsUpper(c)))) : LanguageManager.inst["country_names", country.ToString() + "_default"]);
  }

  public static string GetMilitaryAllianceNameForCountry(GameState gameState, Countries country)
  {
    string str;
    switch (gameState.countries[country].militaryAlliance)
    {
      case Country.MilitaryAllianceType.NATO:
        str = "nato";
        break;
      case Country.MilitaryAllianceType.PartnershipNATO:
        str = "nato_partner";
        break;
      case Country.MilitaryAllianceType.WarsawPact:
        str = gameState.countries[Countries.Poland].militaryAlliance != Country.MilitaryAllianceType.WarsawPact ? "omd" : "ovd";
        break;
      case Country.MilitaryAllianceType.OfficialNeutrality:
        str = "neutral";
        break;
      case Country.MilitaryAllianceType.AACS:
        str = "adkb";
        break;
      default:
        str = "none";
        break;
    }
    return LanguageManager.inst["diplomacy_country_icons", str ?? ""];
  }

  public static string GetMilitaryAllianceName(
    GameState gameState,
    Country.MilitaryAllianceType milTyupe = Country.MilitaryAllianceType.None)
  {
    string str;
    switch (milTyupe)
    {
      case Country.MilitaryAllianceType.NATO:
        str = "nato";
        break;
      case Country.MilitaryAllianceType.PartnershipNATO:
        str = "nato_partner";
        break;
      case Country.MilitaryAllianceType.WarsawPact:
        str = gameState.countries[Countries.Poland].militaryAlliance != Country.MilitaryAllianceType.WarsawPact ? "omd" : "ovd";
        break;
      case Country.MilitaryAllianceType.OfficialNeutrality:
        str = "neutral";
        break;
      case Country.MilitaryAllianceType.AACS:
        str = "adkb";
        break;
      default:
        str = "none";
        break;
    }
    return LanguageManager.inst["diplomacy_country_icons", str ?? ""];
  }

  public static string GetEconomicAllianceNameForCountry(GameState gameState, Countries country)
  {
    Country.EconomyAllianceType economyAlliance = gameState.countries[country].economyAlliance;
    string str = economyAlliance != Country.EconomyAllianceType.EU ? (economyAlliance != Country.EconomyAllianceType.COMECON ? (economyAlliance != Country.EconomyAllianceType.AssociativeCOMECON ? (economyAlliance != Country.EconomyAllianceType.WAFT ? (economyAlliance != Country.EconomyAllianceType.WAFT ? (economyAlliance != Country.EconomyAllianceType.Trade ? (economyAlliance != Country.EconomyAllianceType.TiesDisruption ? "none" : "ties_disruption") : "trade") : "free_trade") : "free_trade") : "sev_partner") : "sev") : "eu";
    return LanguageManager.inst["diplomacy_country_icons", str ?? ""];
  }

  public static string GetEconomicAllianceName(
    GameState gameState,
    Country.EconomyAllianceType ecType = Country.EconomyAllianceType.None)
  {
    string str;
    switch (ecType)
    {
      case Country.EconomyAllianceType.EU:
        str = "eu";
        break;
      case Country.EconomyAllianceType.COMECON:
        str = "sev";
        break;
      case Country.EconomyAllianceType.AssociativeCOMECON:
        str = "sev_partner";
        break;
      case Country.EconomyAllianceType.WAFT:
        str = "free_trade";
        break;
      default:
        str = "none";
        break;
    }
    return LanguageManager.inst["diplomacy_country_icons", str ?? ""];
  }
}
