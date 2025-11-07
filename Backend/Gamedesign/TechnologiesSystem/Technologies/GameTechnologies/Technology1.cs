// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.TechnologiesSystem.Technologies.GameTechnologies.Technology1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Backend.Gamedesign.TechnologiesSystem.Technologies.GameTechnologies;

[Technology(ScienceTree.SpaceProgram)]
public class Technology1 : AbstractTechnology
{
  private readonly int[] subTechnologiesIds = new int[10]
  {
    10,
    11,
    12,
    13,
    14,
    15,
    16 /*0x10*/,
    17,
    18,
    19
  };
  private readonly ScienceCost[] subTechnologiesCosts = new ScienceCost[10]
  {
    new ScienceCost() { physicPoints = 60, militaryPoints = 60 },
    new ScienceCost()
    {
      militaryPoints = 250,
      physicPoints = 250
    },
    new ScienceCost()
    {
      physicPoints = 400,
      cyberneticPoints = 400,
      militaryPoints = 800
    },
    new ScienceCost()
    {
      physicPoints = 625,
      civilPoints = 1250,
      militaryPoints = 1250
    },
    new ScienceCost()
    {
      physicPoints = 1500,
      militaryPoints = 1500,
      cyberneticPoints = 1500
    },
    new ScienceCost() { civilPoints = 60, physicPoints = 60 },
    new ScienceCost() { physicPoints = 250, civilPoints = 250 },
    new ScienceCost()
    {
      cyberneticPoints = 400,
      civilPoints = 400,
      physicPoints = 800
    },
    new ScienceCost()
    {
      civilPoints = 625,
      physicPoints = 1250,
      cyberneticPoints = 1250
    },
    new ScienceCost()
    {
      physicPoints = 1500,
      civilPoints = 1500,
      cyberneticPoints = 1500
    }
  };

  public override TechnologyTreeType TreeType => TechnologyTreeType.TwoLinesOneByOne;

  public override int[] SubTechnologiesIds => this.subTechnologiesIds;

  public override bool CanBeResearchedByPlayer => true;

  public override void CompleteTechnology(int number, GameState gameState)
  {
    base.CompleteTechnology(number, gameState);
    Debug.Log((object) number);
  }

  public override (string condition, bool hasCondition) AdditionalConditions(
    int number,
    GameState gameState)
  {
    return number < 5 ? ("NOT FOR POLAND", true) : base.AdditionalConditions(number, gameState);
  }

  public override void DoInfluence(GameState gameState)
  {
  }

  public override ScienceCost GetTechnologyCost(int number) => this.subTechnologiesCosts[number];
}
