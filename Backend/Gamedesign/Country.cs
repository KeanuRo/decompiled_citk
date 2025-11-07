// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.Country
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Newtonsoft.Json;
using UnityEngine;

#nullable disable
namespace Backend.Gamedesign;

public class Country
{
  [JsonProperty]
  public float population = 0.0f;
  [JsonProperty]
  public bool activeInGame = false;
  [JsonProperty]
  public Country.EconomyAllianceType economyAlliance = Country.EconomyAllianceType.None;
  [JsonProperty]
  public Country.MilitaryAllianceType militaryAlliance = Country.MilitaryAllianceType.None;
  [JsonProperty]
  public Country.LeaderType leaderType = Country.LeaderType.None;
  [JsonProperty]
  public Country.GovernmentType? governmentType = new Country.GovernmentType?();
  [JsonProperty]
  public Country.ZoneType zoneType = Country.ZoneType.Space;
  [JsonProperty]
  public Country.PartyName rulingPartyName = Country.PartyName.None;
  [JsonProperty]
  public Country.PuppetType puppetType = Country.PuppetType.None;
  [JsonProperty]
  public Country.BasesType hasBase = Country.BasesType.None;
  [JsonProperty]
  public Countries? puppetOf = new Countries?();
  [JsonProperty]
  private float relationshipWithPlayer = 0.0f;
  [JsonProperty]
  public bool needRelations = false;
  [JsonProperty]
  public bool isCoupAvailable = false;
  [JsonProperty]
  public bool trade = false;
  [JsonProperty]
  public bool underOurSanctions = false;
  [JsonProperty]
  public int stateOfEmergency = 0;
  [JsonProperty]
  public int treasonTimer = 0;
  [JsonProperty]
  private float foreignPolicyVector = 0.0f;
  [JsonProperty]
  private float liberalizationVector = 0.0f;

  [JsonIgnore]
  public float RelationshipWithPlayer
  {
    get => this.relationshipWithPlayer;
    set => this.relationshipWithPlayer = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float ForeignPolicyVector
  {
    get => this.foreignPolicyVector;
    set => this.foreignPolicyVector = Mathf.Clamp(value, 0.0f, 100f);
  }

  [JsonIgnore]
  public float LiberalizationVector
  {
    get => this.liberalizationVector;
    set => this.liberalizationVector = Mathf.Clamp(value, 0.0f, 100f);
  }

  public enum MilitaryAllianceType
  {
    NATO,
    PartnershipNATO,
    WarsawPact,
    OfficialNeutrality,
    AACS,
    None,
  }

  public enum LeaderType
  {
    Loyal,
    Moderate,
    Separatist,
    None,
  }

  public enum EconomyAllianceType
  {
    EU,
    COMECON,
    AssociativeCOMECON,
    WAFT,
    Trade,
    TiesDisruption,
    None,
  }

  public enum ZoneType
  {
    Space,
    WestEurope,
    EastEurope,
    SovietZone,
    SouthEastAsia,
    MiddleEast,
    OtherAsia,
    Africa,
    NorthAmerica,
    SouthAmerica,
    Oceania,
  }

  public enum GovernmentType
  {
    ConstructingCommunism,
    ConservativeSocialism,
    SocialistReformism,
    SocialismNationalSpecific,
    LeftNationalism,
    LeftPragmatism,
    DemocraticSocialism,
    SocialDemocracy,
    Centrism,
    LiberalProgressive,
    LiberalConservative,
    PopulistConservative,
    RightPopulism,
    MarketAuthoritarian,
    ReactonaryAuthoritarian,
    ClassicalLiberalism,
    LiberalCorporativism,
  }

  public enum PuppetType
  {
    Autonomy,
    InnerState,
    EqualState,
    PuppetOtherState,
    Occupied,
    UnderInfluence,
    None,
  }

  public enum PartyName
  {
    CommunistParty,
    SocialistParty,
    LeftNationalismParty,
    LeftPragmatismParty,
    SocialDemocracyParty,
    CentristParty,
    LiberalConservativeParty,
    LiberalProgressiveParty,
    PopulistConservativeParty,
    RightPopulismParty,
    MarketAuthoritarianParty,
    ReactonaryAuthoritarianParty,
    ClassicalLiberalismParty,
    LiberalCorporativismParty,
    None,
  }

  public enum BasesType
  {
    American,
    Soviet,
    None,
  }
}
