// Decompiled with JetBrains decompiler
// Type: Frontend.CharacterCreation.CharacterCreationController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign;
using Backend.Gamedesign.TraitsSystem.Utils;
using Backend.Gamedesign.Utils;
using Backend.Managers;
using Frontend.ButtonActions;
using Frontend.SceneLoadManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#nullable disable
namespace Frontend.CharacterCreation;

public class CharacterCreationController : MonoBehaviour
{
  [SerializeField]
  private GameObject traitsAttentionIcon;
  [SerializeField]
  private GameObject pointsNegativeAttentionIcon;
  [SerializeField]
  private int age = 50;
  [SerializeField]
  private int pointsAllowed = 5;
  private int[] featuresStatus = new int[3];
  public Sprite[] featuresStatusSprites;
  [SerializeField]
  private Image[] featuresStatusRenderers;
  [SerializeField]
  private Image portraitRenderer;
  private int currentPortrait = 0;
  [SerializeField]
  private TextMeshProUGUI pointsField;
  [SerializeField]
  private TextMeshProUGUI ageField;
  [SerializeField]
  private TextMeshProUGUI homelandField;
  [SerializeField]
  private Sprite[] traits;
  [SerializeField]
  private List<GameObject> selectedTraitsObjs;
  [SerializeField]
  private List<GameObject> potentialTraitsObjs;
  [SerializeField]
  private Button nextButton;
  [SerializeField]
  private Button createAnotherButton;
  private HashSet<Traits> potentailTraits = new HashSet<Traits>();
  private HashSet<Traits> selectedTraits = new HashSet<Traits>();
  private List<int> availablePortraitsIds;
  private string charName = "Name";
  private string charSurname = "Surname";
  public static Characters characterBeingCreated = Characters.CustomCharacter;
  private int currentHomeland = 0;
  private List<Countries> possibleHomelands;

  private int CurrentPoints
  {
    get
    {
      return this.pointsAllowed - ((IEnumerable<int>) this.featuresStatus).Sum() * 3 + (this.age - 62) + this.selectedTraits.Select<Traits, int>((Func<Traits, int>) (trait => GameStateManager.inst.GameRules.traitsPrices[trait])).Sum();
    }
  }

  public void ChangeName(TMP_InputField field) => this.charName = field.text;

  public void ChangeSurname(TMP_InputField field) => this.charSurname = field.text;

  private void RepaintOther()
  {
    this.portraitRenderer.sprite = PlayerCustomImagesManager.inst.GetSpriteByNumber(this.availablePortraitsIds[this.currentPortrait]);
    for (int index = 0; index < this.featuresStatus.Length; ++index)
      this.featuresStatusRenderers[index].sprite = this.featuresStatusSprites[this.featuresStatus[index]];
    ((TMP_Text) this.pointsField).SetText(string.Format(LanguageManager.inst["character_creation", "points"], (object) this.CurrentPoints), true);
    ((TMP_Text) this.ageField).SetText(this.age.ToString(), true);
    this.pointsNegativeAttentionIcon.SetActive(this.CurrentPoints < 0);
    ((Selectable) this.nextButton).interactable = this.CanProceed();
    ((Component) this.createAnotherButton).gameObject.SetActive(this.CanCreateAnother());
    ((Selectable) this.createAnotherButton).interactable = this.CanProceed();
  }

  private void RepaintTraits()
  {
    for (int index = 0; index < this.traits.Length; ++index)
    {
      this.selectedTraitsObjs[index].SetActive(this.selectedTraits.Contains((Traits) index));
      this.potentialTraitsObjs[index].SetActive(!this.selectedTraits.Contains((Traits) index));
      if (!this.selectedTraits.Contains((Traits) index))
        ((Selectable) this.potentialTraitsObjs[index].GetComponent<Button>()).interactable = CharacterUtils.CheckTraitAvaliability((Traits) index, this.selectedTraits);
    }
    this.traitsAttentionIcon.SetActive(!this.FactionTraitSelected());
    this.RepaintTraitsDesc();
  }

  private void RepaintTraitsDesc()
  {
    GameState gameState = GameStateManager.inst.GameState;
    GameRules gameRules = GameStateManager.inst.GameRules;
    for (int index = 0; index < this.traits.Length; ++index)
    {
      string newTitle = LanguageManager.inst["trait_titles", $"trait{index}"];
      string str = string.Format(LanguageManager.inst["character_creation", "points_cost"], (object) gameRules.traitsPrices[(Traits) index]);
      Factions factionTrait = this.selectedTraits.Any<Traits>((Func<Traits, bool>) (trait => trait >= Traits.ProSocialPatriot && trait <= Traits.ProNationalDemocrat)) ? PoliticUtils.GetFactionFromTrait(this.selectedTraits.First<Traits>((Func<Traits, bool>) (trait => trait >= Traits.ProSocialPatriot && trait <= Traits.ProNationalDemocrat))) : Factions.Conservative;
      string newText;
      if (CharacterCreationController.characterBeingCreated == Characters.CustomCharacter)
      {
        string description = TraitsManager.inst.GetTrait((Traits) index).GetDescription(gameState, this.featuresStatus[2], this.featuresStatus[1], this.featuresStatus[0], new PoliticPosition?(PoliticPosition.President), this.possibleHomelands[this.currentHomeland], factionTrait);
        newText = $"{str}\n{description}";
      }
      else
        newText = str;
      this.potentialTraitsObjs[index].GetComponent<SimplePopUpShowerWithUpdate>().ChangeText(newText, newTitle);
      this.selectedTraitsObjs[index].GetComponent<SimplePopUpShowerWithUpdate>().ChangeText(newText, newTitle);
    }
  }

  private void PrepareTraits()
  {
    Frontend.Utils.Utils.PopulateList(this.selectedTraitsObjs, this.traits.Length);
    Frontend.Utils.Utils.PopulateList(this.potentialTraitsObjs, this.traits.Length);
    for (int index = 0; index < this.traits.Length; ++index)
    {
      int j = index;
      this.potentialTraitsObjs[index].GetComponent<Image>().sprite = this.selectedTraitsObjs[index].GetComponent<Image>().sprite = this.traits[index];
      ((UnityEvent) this.selectedTraitsObjs[index].GetComponent<Button>().onClick).AddListener((UnityAction) (() => this.OnMouseTraitDown((Traits) j)));
      ((UnityEvent) this.potentialTraitsObjs[index].GetComponent<Button>().onClick).AddListener((UnityAction) (() => this.OnMouseTraitDown((Traits) j)));
      this.selectedTraitsObjs[index].SetActive(false);
      this.potentialTraitsObjs[index].SetActive(true);
      this.potentailTraits.Add((Traits) j);
    }
  }

  private void RepaintHomeland()
  {
    ((TMP_Text) this.homelandField).text = CountryUtils.GetCountryName(GameStateManager.inst.GameState, this.possibleHomelands[this.currentHomeland], true);
  }

  public void ChangeHomeland(int delta)
  {
    this.currentHomeland += delta;
    if (this.currentHomeland <= -1)
      this.currentHomeland = this.possibleHomelands.Count - 1;
    else if (this.currentHomeland >= this.possibleHomelands.Count)
      this.currentHomeland = 0;
    this.RepaintHomeland();
    this.RepaintTraitsDesc();
  }

  private void Start()
  {
    this.availablePortraitsIds = PlayerCustomImagesManager.inst.GetAvailableIds().ToList<int>();
    this.possibleHomelands = CharacterUtils.GetPossibleHomeLands(GameStateManager.inst.GameState.scenarioType);
    this.RepaintHomeland();
    this.RepaintOther();
    this.PrepareTraits();
    this.RepaintTraits();
    MessageManager.inst.AddMessage(new MessageManager.Message()
    {
      buttonsNumber = 1,
      headerText = string.Empty,
      messageText = string.Format(LanguageManager.inst["custom_images", "custom_images_notification"], (object) Path.Combine(Application.persistentDataPath, "custom_chars").ToString()),
      firstButtonText = "OK"
    });
  }

  public void ChangeAge(int delta)
  {
    this.age = Mathf.Clamp(this.age + delta, 35, 70);
    this.RepaintOther();
  }

  public void ChangePortrait(int delta)
  {
    this.currentPortrait = (this.currentPortrait + delta) % this.availablePortraitsIds.Count;
    if (this.currentPortrait < 0)
      this.currentPortrait = this.availablePortraitsIds.Count - 1;
    this.RepaintOther();
  }

  private bool FactionTraitSelected()
  {
    return this.selectedTraits.Any<Traits>((Func<Traits, bool>) (trait => trait <= Traits.ProNationalDemocrat && trait >= Traits.ProSocialPatriot));
  }

  private bool AllTraitsSelected() => this.selectedTraits.Count == 4;

  private bool CanCreateAnother() => false;

  private bool CanProceed() => this.FactionTraitSelected() && this.AllTraitsSelected();

  private void FillInfoAboutCurrentCharacter()
  {
    bool flag1 = CharacterCreationController.characterBeingCreated == Characters.CustomCharacter;
    bool flag2 = this.CurrentPoints >= 0;
    int characterBeingCreated = (int) CharacterCreationController.characterBeingCreated;
    int status = flag1 ? 1 : 0;
    string charName = this.charName;
    string charSurname = this.charSurname;
    int availablePortraitsId = this.availablePortraitsIds[this.currentPortrait];
    HashSet<Traits> selectedTraits = this.selectedTraits;
    Dictionary<CharacterInfo.PoliticCharacteristic, int> characteristics = new Dictionary<CharacterInfo.PoliticCharacteristic, int>();
    characteristics[CharacterInfo.PoliticCharacteristic.Diplomacy] = this.featuresStatus[0];
    characteristics[CharacterInfo.PoliticCharacteristic.Intrigue] = this.featuresStatus[1];
    characteristics[CharacterInfo.PoliticCharacteristic.Thrift] = this.featuresStatus[2];
    int age = this.age;
    int num = flag2 ? 1 : 0;
    int possibleHomeland = (int) this.possibleHomelands[this.currentHomeland];
    GameStartUtils.FillInfoAboutCustomCharacter((Characters) characterBeingCreated, (CharacterInfo.PoliticStatus) status, charName, charSurname, availablePortraitsId, selectedTraits, characteristics, age, num != 0, (Countries) possibleHomeland);
  }

  public void CreateAnother()
  {
    if (!this.CanCreateAnother())
      return;
    this.FillInfoAboutCurrentCharacter();
    --CharacterCreationController.characterBeingCreated;
    SceneLoadManager.inst.LoadScene(5);
  }

  public void NextScene()
  {
    if (!this.CanProceed())
      return;
    this.FillInfoAboutCurrentCharacter();
    GameStartUtils.MakeFinalScenarioPreparations();
    SceneLoadManager.inst.LoadScene(6);
  }

  public void ChangeFeature(int featureChange)
  {
    int index = featureChange / 10;
    int num = featureChange % 10 == 0 ? -1 : 1;
    this.featuresStatus[index] = Mathf.Clamp(this.featuresStatus[index] + num, 0, 5);
    this.RepaintOther();
    this.RepaintTraitsDesc();
  }

  public void OnMouseTraitDown(Traits trait)
  {
    if (this.potentailTraits.Contains(trait))
    {
      this.potentailTraits.Remove(trait);
      this.selectedTraits.Add(trait);
    }
    else
    {
      this.potentailTraits.Add(trait);
      this.selectedTraits.Remove(trait);
    }
    this.RepaintTraits();
    this.RepaintOther();
  }
}
