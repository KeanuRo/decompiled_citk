// Decompiled with JetBrains decompiler
// Type: Frontend.UI.FlagDisplayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign;
using Backend.Gamedesign.Utils;
using Backend.Managers;
using Frontend.ButtonActions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace Frontend.UI;

public class FlagDisplayer : MonoBehaviour
{
  [SerializeField]
  private Image image;
  [SerializeField]
  private SimplePopUpShowerWithUpdate popUp;
  [SerializeField]
  private Sprite[] flags;

  public void DisplayFlag(int index)
  {
    this.image.sprite = this.flags[index];
    string newText = $"{$"{$"<b>{LanguageManager.inst["flag_desc", "flag_name"]}</b>: {CountryUtils.GetCountryName(GameStateManager.inst.GameState, GameStateManager.inst.GameState.playerCountry)}."}\n<b>{LanguageManager.inst["flag_desc", "flag_rulingPartyName"]}</b>: {CountryUtils.GetPartyName(GameStateManager.inst.GameState, GameStateManager.inst.GameState.playerCountry, GameStateManager.inst.GameState.countries[GameStateManager.inst.GameState.playerCountry].rulingPartyName).Item2}."}\n<b>{LanguageManager.inst["flag_desc", "flag_governmentType"]}</b>: {LanguageManager.inst["government_type", GameStateManager.inst.GameState.countries[GameStateManager.inst.GameState.playerCountry].governmentType.Value.ToString()]}.";
    if (GameStateManager.inst.GameState.playerCountry == Countries.USSR || GameStateManager.inst.GameState.playerCountry == Countries.Yugoslavia)
      newText += $"\n<b>{LanguageManager.inst["flag_desc", "flag_subjects"]}</b>: {GameStateManager.inst.GameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou =>
      {
        if (cou.Value.activeInGame)
        {
          Countries? puppetOf = cou.Value.puppetOf;
          Countries playerCountry = GameStateManager.inst.GameState.playerCountry;
          if (puppetOf.GetValueOrDefault() == playerCountry & puppetOf.HasValue)
            return cou.Value.puppetType < Country.PuppetType.PuppetOtherState;
        }
        return false;
      })).Count<KeyValuePair<Countries, Country>>()}.";
    if (GameStateManager.inst.GameState.countries[GameStateManager.inst.GameState.playerCountry].economyAlliance != Country.EconomyAllianceType.None)
      newText += $"\n<b>{LanguageManager.inst["flag_desc", "flag_alliance"]} {CountryUtils.GetEconomicAllianceNameForCountry(GameStateManager.inst.GameState, GameStateManager.inst.GameState.playerCountry)}</b>: {GameStateManager.inst.GameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.activeInGame && cou.Value.economyAlliance == GameStateManager.inst.GameState.countries[GameStateManager.inst.GameState.playerCountry].economyAlliance)).Count<KeyValuePair<Countries, Country>>()}.";
    if (GameStateManager.inst.GameState.countries[GameStateManager.inst.GameState.playerCountry].economyAlliance != Country.EconomyAllianceType.None)
      newText += $"\n<b>{LanguageManager.inst["flag_desc", "flag_alliance"]} {CountryUtils.GetMilitaryAllianceNameForCountry(GameStateManager.inst.GameState, GameStateManager.inst.GameState.playerCountry)}</b>: {GameStateManager.inst.GameState.countries.Where<KeyValuePair<Countries, Country>>((Func<KeyValuePair<Countries, Country>, bool>) (cou => cou.Value.activeInGame && cou.Value.militaryAlliance == GameStateManager.inst.GameState.countries[GameStateManager.inst.GameState.playerCountry].militaryAlliance)).Count<KeyValuePair<Countries, Country>>()}.";
    this.popUp.ChangeText(newText, LanguageManager.inst["flag_desc", "flag_status"]);
  }
}
