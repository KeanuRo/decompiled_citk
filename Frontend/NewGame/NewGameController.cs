// Decompiled with JetBrains decompiler
// Type: Frontend.NewGame.NewGameController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign;
using Backend.Gamedesign.Utils;
using Backend.Managers;
using Frontend.ButtonActions;
using Frontend.CharacterCreation;
using Frontend.MapWindow;
using Frontend.SceneLoadManagement;
using Frontend.UI;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace Frontend.NewGame;

public class NewGameController : MonoBehaviour
{
  [SerializeField]
  private GameObject achNotification;
  public GameObject DLCButton;
  public GameObject nextButton;
  public GameObject addPoliticianButton;
  public ElementsHorizontalSelect difficultySelection;
  public ElementsHorizontalSelect yearSelection;
  public GameObject[] lastHeroButtons;
  public TextMeshProUGUI descText;
  public GameObject[] politicSets;
  public ScenarioType[] politicSetsScenarios;
  public List<PoliticEntity> politics = new List<PoliticEntity>();
  public List<FlagEntity> flags = new List<FlagEntity>();
  private bool lastHeroActivated = false;
  private int currentYear = 0;
  public Characters? currentPolitic = new Characters?();
  public Countries? currentCountry = new Countries?(Countries.USSR);

  public void BuyDLC()
  {
    Application.OpenURL(DLCManager.inst.GetDLCReference(DLCManager.inst.GetDLCToOpenCountry(this.currentCountry.Value)));
  }

  private void Awake() => this.Repaint();

  public void SetYear(int year)
  {
    this.currentYear = year;
    this.currentPolitic = new Characters?();
    this.Repaint();
  }

  public void SetCountry(Countries country)
  {
    this.currentCountry = new Countries?(country);
    this.currentPolitic = new Characters?();
    this.Repaint();
  }

  public void SetPolitic(Characters character)
  {
    this.currentPolitic = new Characters?(character);
    this.Repaint();
    if (character != Characters.CustomCharacter)
      ((TMP_Text) this.descText).SetText(LanguageManager.inst["politics_long_desc", $"pol{(int) this.currentPolitic.Value}"], true);
    else
      ((TMP_Text) this.descText).SetText(LanguageManager.inst["politics_long_desc", "custom"], true);
  }

  public void AddPolitician()
  {
    int num;
    if (this.currentPolitic.HasValue && this.currentCountry.HasValue)
    {
      Characters? currentPolitic = this.currentPolitic;
      Characters characters = Characters.CustomCharacter;
      num = currentPolitic.GetValueOrDefault() == characters & currentPolitic.HasValue ? 1 : 0;
    }
    else
      num = 1;
    if (num != 0)
      return;
    MapWindowController.ResetGameSpeed();
    GameStartUtils.LoadGameStateAndGameRulesFromStartSettings(GameStartUtils.ScenarioFromYearAndCountry(this.currentCountry.Value, this.currentYear == 0 ? 1985 : 1991), (Difficulty) (1 + this.difficultySelection.GetSelected()), this.currentPolitic.Value, this.lastHeroActivated, this.currentCountry.Value);
    CharacterCreationController.characterBeingCreated = Characters.CustomCharacter1;
    SceneLoadManager.inst.LoadScene(5, shouldWaitCallBack: true);
  }

  public void NextScene()
  {
    if (!this.currentPolitic.HasValue || !this.currentCountry.HasValue)
      return;
    MapWindowController.ResetGameSpeed();
    GameStartUtils.LoadGameStateAndGameRulesFromStartSettings(GameStartUtils.ScenarioFromYearAndCountry(this.currentCountry.Value, this.currentYear == 0 ? 1985 : 1991), (Difficulty) (1 + this.difficultySelection.GetSelected()), this.currentPolitic.Value, this.lastHeroActivated, this.currentCountry.Value);
    Characters? currentPolitic = this.currentPolitic;
    Characters characters = Characters.CustomCharacter;
    if (currentPolitic.GetValueOrDefault() == characters & currentPolitic.HasValue)
    {
      CharacterCreationController.characterBeingCreated = Characters.CustomCharacter;
      SceneLoadManager.inst.LoadScene(5, shouldWaitCallBack: true);
    }
    else
    {
      GameStartUtils.MakeFinalScenarioPreparations();
      SceneLoadManager.inst.LoadScene(6, shouldWaitCallBack: true);
    }
  }

  public void ChangeLastHero()
  {
    this.lastHeroActivated = !this.lastHeroActivated;
    this.lastHeroButtons[0].SetActive(!this.lastHeroActivated);
    this.lastHeroButtons[1].SetActive(this.lastHeroActivated);
    this.Repaint();
  }

  private void RepaintAchNotification()
  {
    Difficulty difficulty = (Difficulty) (1 + this.difficultySelection.GetSelected());
    bool flag1 = difficulty != Difficulty.Arcade && difficulty != Difficulty.FreeMode;
    bool flag2 = this.lastHeroActivated & flag1;
    this.achNotification.GetComponent<Selectable>().interactable = flag2;
    if (flag2)
    {
      this.achNotification.GetComponent<SimplePopUpShowerWithUpdate>().ChangeText(LanguageManager.inst["gamestart", "ach_enabled"], string.Empty);
    }
    else
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (!this.lastHeroActivated)
        stringBuilder.AppendLine(LanguageManager.inst["gamestart", "last_hero_is_needed"]);
      if (!flag1)
        stringBuilder.AppendLine(LanguageManager.inst["gamestart", "wrong_diff"]);
      this.achNotification.GetComponent<SimplePopUpShowerWithUpdate>().ChangeText(stringBuilder.ToString(), LanguageManager.inst["gamestart", "ach_disabled"]);
    }
  }

  public void Repaint()
  {
    this.addPoliticianButton.SetActive(false);
    if (this.currentPolitic.HasValue && this.currentCountry.HasValue && DLCManager.inst.IfCountryPossibleToPick(this.currentCountry.Value))
    {
      this.nextButton.SetActive(true);
      this.DLCButton.SetActive(false);
    }
    else if (this.currentCountry.HasValue && !DLCManager.inst.IfCountryPossibleToPick(this.currentCountry.Value))
    {
      this.nextButton.SetActive(false);
      this.DLCButton.SetActive(true);
    }
    else
    {
      this.nextButton.SetActive(false);
      this.DLCButton.SetActive(false);
    }
    foreach (FlagEntity flag in this.flags)
      flag.Repaint();
    for (int index = 0; index < this.politicSets.Length; ++index)
      this.politicSets[index].SetActive(this.currentCountry.HasValue && this.politicSetsScenarios[index] == GameStartUtils.ScenarioFromYearAndCountry(this.currentCountry.Value, this.currentYear == 0 ? 1985 : 1991));
    foreach (PoliticEntity politic in this.politics)
      politic.Repaint();
    if (this.currentPolitic.HasValue)
    {
      Characters? currentPolitic = this.currentPolitic;
      Characters characters = Characters.CustomCharacter;
      if (!(currentPolitic.GetValueOrDefault() == characters & currentPolitic.HasValue))
        ((TMP_Text) this.descText).SetText(LanguageManager.inst["politics_long_desc", $"pol{(int) this.currentPolitic.Value}"], true);
      else
        ((TMP_Text) this.descText).SetText(LanguageManager.inst["politics_long_desc", "custom"], true);
    }
    else if (this.currentCountry.HasValue)
      ((TMP_Text) this.descText).SetText(LanguageManager.inst["scenario_desc", GameStartUtils.ScenarioFromYearAndCountry(this.currentCountry.Value, this.currentYear == 0 ? 1985 : 1991).ToString()], true);
    else
      ((TMP_Text) this.descText).SetText(string.Empty, true);
    this.RepaintAchNotification();
  }
}
