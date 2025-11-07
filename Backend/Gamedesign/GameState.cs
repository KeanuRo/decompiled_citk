// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.GameState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Backend.Gamedesign;

[Serializable]
public class GameState
{
  [JsonProperty]
  public bool? tutorialEnabled = new bool?();
  [JsonProperty]
  public HashSet<int> tutorialPartsDone = new HashSet<int>();
  [JsonProperty]
  public int countryFlagId = 0;
  [JsonProperty]
  public AmericanPresident americanPresident = AmericanPresident.Raegan;
  public Dictionary<Wars, WarInfo> currentWars = new Dictionary<Wars, WarInfo>();
  [JsonProperty]
  public Dictionary<DoctrineType, DateTime> doctrineChangeBlocks = new Dictionary<DoctrineType, DateTime>();
  [JsonProperty]
  public RegionsStorage regionsStorage = (RegionsStorage) null;
  public GameStateHistory gameStateHistory = (GameStateHistory) null;
  [JsonProperty]
  private int population = 0;
  [JsonProperty]
  private int defcon = 0;
  [JsonProperty]
  private float politicalPower = 0.0f;
  [JsonProperty]
  private int reserve = 0;
  public int refinancingRate = 20;
  [JsonProperty]
  private float export = 0.0f;
  [JsonProperty]
  private float healthCare = 0.0f;
  [JsonProperty]
  private float education = 0.0f;
  [JsonProperty]
  private float ecology = 0.0f;
  [JsonProperty]
  private float militaryStaffLoyalty = 0.0f;
  [JsonProperty]
  private float armyStaffLoyalty = 0.0f;
  [JsonProperty]
  private float specialServicesLoyalty = 0.0f;
  [JsonProperty]
  private float specialServices = 0.0f;
  [JsonProperty]
  private float radicalsPower = 0.0f;
  [JsonProperty]
  private float freedomLevel = 0.0f;
  [JsonProperty]
  private float liberalizationLevel = 0.0f;
  [JsonProperty]
  private float educationAccess = 0.0f;
  [JsonProperty]
  private float healthCareAccess = 0.0f;
  [JsonProperty]
  private float selfFulfillment = 0.0f;
  [JsonProperty]
  private float luxuryGoodsLevel = 0.0f;
  [JsonProperty]
  private float orderLevel = 0.0f;
  [JsonProperty]
  private float firstNeedsGoods = 0.0f;
  [JsonProperty]
  private float housingLevel = 0.0f;
  [JsonProperty]
  private float employmentLevel = 0.0f;
  [JsonProperty]
  private float agroEffectiveness = 0.0f;
  [JsonProperty]
  private float servicesEffectiveness = 0.0f;
  [JsonProperty]
  private float lightIndustryEffectiveness = 0.0f;
  [JsonProperty]
  private float heavyIndustryEffectiveness = 0.0f;
  [JsonProperty]
  private float armyIndustryEffectiveness = 0.0f;
  [JsonProperty]
  private float intelligentsiaLoyalty = 0.0f;
  [JsonProperty]
  private float spiritualContentment = 0.0f;
  [JsonProperty]
  private float unityLevel = 0.0f;
  [JsonProperty]
  private float forgeryLevel = 0.0f;
  [JsonProperty]
  private float armyQuantityLevel = 0.0f;
  [JsonProperty]
  private float warheadsQuantity = 0.0f;
  [JsonProperty]
  private float combatability = 0.0f;
  [JsonProperty]
  private float competitivenessLevel = 0.0f;
  [JsonProperty]
  private float corruptionLevel = 0.0f;
  [JsonProperty]
  private float americanArmyLevel = 0.0f;
  [JsonProperty]
  private float americanEconomyLevel = 0.0f;
  [JsonProperty]
  private float americanPopularHappiness = 0.0f;
  [JsonProperty]
  private float priceIndex = 1f;
  [JsonProperty]
  private int usLoan = 0;
  [JsonProperty]
  private int fraLoan = 0;
  [JsonProperty]
  private int imfLoan = 0;
  public Stack<(int id, bool shouldNotConditionsBeCheckedAfterItsAdded)> currentEventsIds = new Stack<(int, bool)>();
  public PoliticPositionsState politicPositions = new PoliticPositionsState();
  public Dictionary<ExpenseType, int> expenses = new Dictionary<ExpenseType, int>();
  public List<ConspiracyInfo> conspiracies = new List<ConspiracyInfo>();
  public HashSet<int> acceptedDecisions = new HashSet<int>();
  public Dictionary<int, ModificatorState> activeModificators = new Dictionary<int, ModificatorState>();
  public Dictionary<int, Dictionary<Countries, DiplomacyButtonState>> activeDiplomacyButtons = new Dictionary<int, Dictionary<Countries, DiplomacyButtonState>>();
  public Dictionary<int, Dictionary<Countries, DateTime>> diplomacyButtonsTimeouts = new Dictionary<int, Dictionary<Countries, DateTime>>();
  public Dictionary<int, DecisionState> activeDecisions = new Dictionary<int, DecisionState>();
  public Dictionary<DoctrineType, DoctrineState> doctrines = new Dictionary<DoctrineType, DoctrineState>();
  public Dictionary<Countries, Country> countries = new Dictionary<Countries, Country>();
  public ParliamentState parliamentState;
  public Dictionary<Factions, FactionState> factionsStates = new Dictionary<Factions, FactionState>();
  public Dictionary<Factions, MultiPartyClass> partyStates = new Dictionary<Factions, MultiPartyClass>();
  public Dictionary<ScienceTree, TechnologyStatus[]> technologies = new Dictionary<ScienceTree, TechnologyStatus[]>();
  public Dictionary<int, EventCompletionState> eventsDone = new Dictionary<int, EventCompletionState>();
  public Countries playerCountry = Countries.USSR;
  public DateTime date;
  public int someInt = 0;
  public DateTime lastElectionsDate;
  public Characters gameCharacter = Characters.CustomCharacter;
  public Difficulty difficulty = Difficulty.Arcade;
  public ScenarioType scenarioType = ScenarioType.USSR1985;
  public bool lastHeroMode = false;
  public Guid guid;
  public Dictionary<Characters, CharacterInfo> characters = new Dictionary<Characters, CharacterInfo>();

  [JsonIgnore]
  public int Population
  {
    get => this.population;
    set => this.population = Mathf.Max(0, value);
  }

  [JsonIgnore]
  public int Defcon
  {
    get => this.defcon;
    set => this.defcon = Mathf.Clamp(value, 0, 5);
  }

  [JsonIgnore]
  public float PoliticalPower
  {
    get => this.politicalPower;
    set => this.politicalPower = Mathf.Max(-100f, value);
  }

  [JsonIgnore]
  public int Reserve
  {
    get => this.reserve;
    set => this.reserve = value;
  }

  [JsonIgnore]
  public float Export
  {
    get => Mathf.Clamp(this.export, 0.0f, 100f);
    set => this.export = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float ExportNotClamped
  {
    get => this.export;
    set => this.export = value;
  }

  [JsonIgnore]
  public float HealthCare
  {
    get => Mathf.Clamp(this.healthCare, 0.0f, 100f);
    set => this.healthCare = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float HealthCareNotClamped
  {
    get => this.healthCare;
    set => this.healthCare = value;
  }

  [JsonIgnore]
  public float Education
  {
    get => Mathf.Clamp(this.education, 0.0f, 100f);
    set => this.education = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float EducationNotClamped
  {
    get => this.education;
    set => this.education = value;
  }

  [JsonIgnore]
  public float Ecology
  {
    get => Mathf.Clamp(this.ecology, 0.0f, 100f);
    set => this.ecology = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float EcologyNotClamped
  {
    get => this.ecology;
    set => this.ecology = value;
  }

  [JsonIgnore]
  public float MilitaryStaffLoyalty
  {
    get => Mathf.Clamp(this.militaryStaffLoyalty, 0.0f, 100f);
    set => this.militaryStaffLoyalty = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float MilitaryStaffLoyaltyNotClamped
  {
    get => this.militaryStaffLoyalty;
    set => this.militaryStaffLoyalty = value;
  }

  [JsonIgnore]
  public float ArmyLoyalty
  {
    get => Mathf.Clamp(this.armyStaffLoyalty, 0.0f, 100f);
    set => this.armyStaffLoyalty = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float ArmyLoyaltyNotClamped
  {
    get => this.armyStaffLoyalty;
    set => this.armyStaffLoyalty = value;
  }

  [JsonIgnore]
  public float SpecialServicesLoyalty
  {
    get => Mathf.Clamp(this.specialServicesLoyalty, 0.0f, 100f);
    set => this.specialServicesLoyalty = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float SpecialServicesLoyaltyNotClamped
  {
    get => this.specialServicesLoyalty;
    set => this.specialServicesLoyalty = value;
  }

  [JsonIgnore]
  public float SpecialServices
  {
    get => Mathf.Clamp(this.specialServices, 0.0f, 100f);
    set => this.specialServices = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float SpecialServicesNotClamped
  {
    get => this.specialServices;
    set => this.specialServices = value;
  }

  [JsonIgnore]
  public float RadicalsPower
  {
    get => Mathf.Clamp(this.radicalsPower, 0.0f, 100f);
    set => this.radicalsPower = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float RadicalsPowerNotClamped
  {
    get => this.radicalsPower;
    set => this.radicalsPower = value;
  }

  [JsonIgnore]
  public float FreedomLevel
  {
    get => Mathf.Clamp(this.freedomLevel, 0.0f, 100f);
    set => this.freedomLevel = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float FreedomLevelNotClamped
  {
    get => this.freedomLevel;
    set => this.freedomLevel = value;
  }

  [JsonIgnore]
  public float LiberalizationLevel
  {
    get => Mathf.Clamp(this.liberalizationLevel, 0.0f, 100f);
    set => this.liberalizationLevel = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float LiberalizationLevelNotClamped
  {
    get => this.liberalizationLevel;
    set => this.liberalizationLevel = value;
  }

  [JsonIgnore]
  public float EducationAccess
  {
    get => Mathf.Clamp(this.educationAccess, 0.0f, 100f);
    set => this.educationAccess = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float EducationAccessNotClamped
  {
    get => this.educationAccess;
    set => this.educationAccess = value;
  }

  [JsonIgnore]
  public float HealthCareAccess
  {
    get => Mathf.Clamp(this.healthCareAccess, 0.0f, 100f);
    set => this.healthCareAccess = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float HealthCareAccessNotClamped
  {
    get => this.healthCareAccess;
    set => this.healthCareAccess = value;
  }

  [JsonIgnore]
  public float SelfFulfillment
  {
    get => Mathf.Clamp(this.selfFulfillment, 0.0f, 100f);
    set => this.selfFulfillment = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float SelfFulfillmentNotClamped
  {
    get => this.selfFulfillment;
    set => this.selfFulfillment = value;
  }

  [JsonIgnore]
  public float LuxuryGoodsLevel
  {
    get => Mathf.Clamp(this.luxuryGoodsLevel, 0.0f, 100f);
    set => this.luxuryGoodsLevel = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float LuxuryGoodsLevelNotClamped
  {
    get => this.luxuryGoodsLevel;
    set => this.luxuryGoodsLevel = value;
  }

  [JsonIgnore]
  public float OrderLevel
  {
    get => Mathf.Clamp(this.orderLevel, 0.0f, 100f);
    set => this.orderLevel = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float OrderLevelNotClamped
  {
    get => this.orderLevel;
    set => this.orderLevel = value;
  }

  [JsonIgnore]
  public float FirstNeedsGoods
  {
    get => Mathf.Clamp(this.firstNeedsGoods, 0.0f, 100f);
    set => this.firstNeedsGoods = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float FirstNeedsGoodsNotClamped
  {
    get => this.firstNeedsGoods;
    set => this.firstNeedsGoods = value;
  }

  [JsonIgnore]
  public float HousingLevel
  {
    get => Mathf.Clamp(this.housingLevel, 0.0f, 100f);
    set => this.housingLevel = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float HousingLevelNotClamped
  {
    get => this.housingLevel;
    set => this.housingLevel = value;
  }

  [JsonIgnore]
  public float EmploymentLevel
  {
    get => Mathf.Clamp(this.employmentLevel, 0.0f, 100f);
    set => this.employmentLevel = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float EmploymentLevelNotClamped
  {
    get => this.employmentLevel;
    set => this.employmentLevel = value;
  }

  [JsonIgnore]
  public float AgroEffectiveness
  {
    get => Mathf.Clamp(this.agroEffectiveness, 0.0f, 100f);
    set => this.agroEffectiveness = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float AgroEffectivenessNotClamped
  {
    get => this.agroEffectiveness;
    set => this.agroEffectiveness = value;
  }

  [JsonIgnore]
  public float ServicesEffectiveness
  {
    get => Mathf.Clamp(this.servicesEffectiveness, 0.0f, 100f);
    set => this.servicesEffectiveness = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float ServicesEffectivenessNotClamped
  {
    get => this.servicesEffectiveness;
    set => this.servicesEffectiveness = value;
  }

  [JsonIgnore]
  public float LightIndustryEffectiveness
  {
    get => Mathf.Clamp(this.lightIndustryEffectiveness, 0.0f, 100f);
    set => this.lightIndustryEffectiveness = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float LightIndustryEffectivenessNotClamped
  {
    get => this.lightIndustryEffectiveness;
    set => this.lightIndustryEffectiveness = value;
  }

  [JsonIgnore]
  public float HeavyIndustryEffectiveness
  {
    get => Mathf.Clamp(this.heavyIndustryEffectiveness, 0.0f, 100f);
    set => this.heavyIndustryEffectiveness = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float HeavyIndustryEffectivenessNotClamped
  {
    get => this.heavyIndustryEffectiveness;
    set => this.heavyIndustryEffectiveness = value;
  }

  [JsonIgnore]
  public float ArmyIndustryEffectiveness
  {
    get => Mathf.Clamp(this.armyIndustryEffectiveness, 0.0f, 100f);
    set => this.armyIndustryEffectiveness = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float ArmyIndustryEffectivenessNotClamped
  {
    get => this.armyIndustryEffectiveness;
    set => this.armyIndustryEffectiveness = value;
  }

  [JsonIgnore]
  public float IntelligentsiaLoyalty
  {
    get => Mathf.Clamp(this.intelligentsiaLoyalty, 0.0f, 100f);
    set => this.intelligentsiaLoyalty = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float IntelligentsiaLoyaltyNotClamped
  {
    get => this.intelligentsiaLoyalty;
    set => this.intelligentsiaLoyalty = value;
  }

  [JsonIgnore]
  public float SpiritualContentment
  {
    get => Mathf.Clamp(this.spiritualContentment, 0.0f, 100f);
    set => this.spiritualContentment = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float SpiritualContentmentNotClamped
  {
    get => this.spiritualContentment;
    set => this.spiritualContentment = value;
  }

  [JsonIgnore]
  public float UnityLevel
  {
    get => Mathf.Clamp(this.unityLevel, 0.0f, 100f);
    set => this.unityLevel = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float UnityLevelNotClamped
  {
    get => this.unityLevel;
    set => this.unityLevel = value;
  }

  [JsonIgnore]
  public float ForgeryLevel
  {
    get => Mathf.Clamp(this.forgeryLevel, 0.0f, 100f);
    set => this.forgeryLevel = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float ForgeryLevelNotClamped
  {
    get => this.forgeryLevel;
    set => this.forgeryLevel = value;
  }

  [JsonIgnore]
  public float ArmyQuantityLevel
  {
    get => Mathf.Clamp(this.armyQuantityLevel, 0.0f, 100f);
    set => this.armyQuantityLevel = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float ArmyQuantityLevelNotClamped
  {
    get => this.armyQuantityLevel;
    set => this.armyQuantityLevel = value;
  }

  [JsonIgnore]
  public float WarheadsQuantity
  {
    get => Mathf.Clamp(this.warheadsQuantity, 0.0f, 100f);
    set => this.warheadsQuantity = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float WarheadsQuantityNotClamped
  {
    get => this.warheadsQuantity;
    set => this.warheadsQuantity = value;
  }

  [JsonIgnore]
  public float Combatability
  {
    get => Mathf.Clamp(this.combatability, 0.0f, 100f);
    set => this.combatability = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float CombatabilityNotClamped
  {
    get => this.combatability;
    set => this.combatability = value;
  }

  [JsonIgnore]
  public float CompetitivenessLevel
  {
    get => Mathf.Clamp(this.competitivenessLevel, 0.0f, 100f);
    set => this.competitivenessLevel = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float CompetitivenessLevelNotClamped
  {
    get => this.competitivenessLevel;
    set => this.competitivenessLevel = value;
  }

  [JsonIgnore]
  public float CorruptionLevel
  {
    get => Mathf.Clamp(this.corruptionLevel, 0.0f, 100f);
    set => this.corruptionLevel = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float CorruptionLevelNotClamped
  {
    get => this.corruptionLevel;
    set => this.corruptionLevel = value;
  }

  [JsonIgnore]
  public float AmericanArmyLevel
  {
    get => Mathf.Clamp(this.americanArmyLevel, 0.0f, 100f);
    set => this.americanArmyLevel = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float AmericanArmyLevelNotClamped
  {
    get => this.americanArmyLevel;
    set => this.americanArmyLevel = value;
  }

  [JsonIgnore]
  public float AmericanEconomyLevel
  {
    get => Mathf.Clamp(this.americanEconomyLevel, 0.0f, 100f);
    set => this.americanEconomyLevel = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float AmericanEconomyLevelNotClamped
  {
    get => this.americanEconomyLevel;
    set => this.americanEconomyLevel = value;
  }

  [JsonIgnore]
  public float AmericanPopularHappiness
  {
    get => Mathf.Clamp(this.americanPopularHappiness, 0.0f, 100f);
    set => this.americanPopularHappiness = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float AmericanPopularHappinessNotClamped
  {
    get => this.americanPopularHappiness;
    set => this.americanPopularHappiness = value;
  }

  [JsonIgnore]
  public float PriceIndex
  {
    get => this.priceIndex;
    set => this.priceIndex = Mathf.Max(value, 1f);
  }

  [JsonIgnore]
  public int USLoan
  {
    get => this.usLoan;
    set => this.usLoan = Mathf.Max(0, value);
  }

  [JsonIgnore]
  public int FraLoan
  {
    get => this.fraLoan;
    set => this.fraLoan = Mathf.Max(0, value);
  }

  [JsonIgnore]
  public int IMFLoan
  {
    get => this.imfLoan;
    set => this.imfLoan = Mathf.Max(0, value);
  }
}
