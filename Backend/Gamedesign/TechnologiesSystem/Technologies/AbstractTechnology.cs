// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.TechnologiesSystem.Technologies.AbstractTechnology
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Managers;
using System;
using System.Reflection;

#nullable disable
namespace Backend.Gamedesign.TechnologiesSystem.Technologies;

public abstract class AbstractTechnology
{
  public abstract bool CanBeResearchedByPlayer { get; }

  public ScienceTree ScienceTreeCurrent
  {
    get
    {
      return ((TechnologyAttribute) Attribute.GetCustomAttribute((MemberInfo) this.GetType(), typeof (TechnologyAttribute))).scienceTree;
    }
  }

  public abstract ScienceCost GetTechnologyCost(int number);

  public abstract TechnologyTreeType TreeType { get; }

  public abstract int[] SubTechnologiesIds { get; }

  public virtual int GetPoliticalPowerResearchCostPerTick(int number) => 5;

  public virtual void CompleteTechnology(int number, GameState gameState)
  {
    gameState.technologies[this.ScienceTreeCurrent][number].state = TechnologyStatus.TechnologyState.Completed;
  }

  public int GetTotalSubTechnologiesCount => this.TreeType != TechnologyTreeType.OneLine ? 10 : 5;

  public virtual (string condition, bool hasCondition) AdditionalConditions(
    int number,
    GameState gameState)
  {
    return (string.Empty, false);
  }

  public abstract void DoInfluence(GameState gameState);

  public virtual void CancelResearch(int number, GameState gameState)
  {
    gameState.technologies[this.ScienceTreeCurrent][number].state = TechnologyStatus.TechnologyState.NotStarted;
    gameState.PoliticalPower += 25f;
  }

  public virtual void StartResearch(int number, GameState gameState)
  {
    gameState.PoliticalPower -= 25f;
    gameState.technologies[this.ScienceTreeCurrent][number].state = TechnologyStatus.TechnologyState.InProgess;
  }

  public virtual string GetTechResearchStartConditions(int number, GameState gameState)
  {
    return string.Format(LanguageManager.inst["science_window", "political_points_required"], (object) 5);
  }

  public virtual bool CheckIfTechCanBeCanceled(int number, GameState gameState)
  {
    return gameState.technologies[this.ScienceTreeCurrent][number].state == TechnologyStatus.TechnologyState.InProgess && gameState.technologies[this.ScienceTreeCurrent][number].investedCost.Sum() == 0;
  }

  public virtual bool CheckIfTechCanBeResearched(int number, GameState gameState)
  {
    if ((double) gameState.PoliticalPower < 5.0 || !this.CanBeResearchedByPlayer || ResearchUtils.IfAnythingIsBeingResearchedByPlayer(gameState))
      return false;
    if (this.TreeType == TechnologyTreeType.OneLine)
      return number == 0 || gameState.technologies[this.ScienceTreeCurrent][number - 1].state == TechnologyStatus.TechnologyState.Completed;
    if (this.TreeType == TechnologyTreeType.TwoLines)
      return number == 0 || number == 5 || gameState.technologies[this.ScienceTreeCurrent][number - 1].state == TechnologyStatus.TechnologyState.Completed;
    if (this.TreeType == TechnologyTreeType.TwoLinesOneByOne)
    {
      if (number < 5)
      {
        if (gameState.technologies[this.ScienceTreeCurrent][5].state != 0)
        {
          if (gameState.technologies[this.ScienceTreeCurrent][9].state != TechnologyStatus.TechnologyState.Completed)
            return false;
          return number == 0 || gameState.technologies[this.ScienceTreeCurrent][number - 1].state == TechnologyStatus.TechnologyState.Completed;
        }
        return number == 0 || gameState.technologies[this.ScienceTreeCurrent][number - 1].state == TechnologyStatus.TechnologyState.Completed;
      }
      if (gameState.technologies[this.ScienceTreeCurrent][0].state != 0)
      {
        if (gameState.technologies[this.ScienceTreeCurrent][4].state != TechnologyStatus.TechnologyState.Completed)
          return false;
        return number == 5 || gameState.technologies[this.ScienceTreeCurrent][number - 1].state == TechnologyStatus.TechnologyState.Completed;
      }
      return number == 5 || gameState.technologies[this.ScienceTreeCurrent][number - 1].state == TechnologyStatus.TechnologyState.Completed;
    }
    if (number < 5)
    {
      if (gameState.technologies[this.ScienceTreeCurrent][5].state != 0)
        return false;
      return number == 0 || gameState.technologies[this.ScienceTreeCurrent][number - 1].state == TechnologyStatus.TechnologyState.Completed;
    }
    if (gameState.technologies[this.ScienceTreeCurrent][0].state != 0)
      return false;
    return number == 5 || gameState.technologies[this.ScienceTreeCurrent][number - 1].state == TechnologyStatus.TechnologyState.Completed;
  }

  public virtual bool CheckIfSecondBranchActive(GameState gameState)
  {
    TechnologyStatus[] technology = GameStateManager.inst.GameState.technologies[this.ScienceTreeCurrent];
    return this.TreeType != TechnologyTreeType.TwoLinesOneByOne && this.TreeType != TechnologyTreeType.TwoLinesOneByOne || technology[0].state == TechnologyStatus.TechnologyState.NotStarted && technology[5].state == TechnologyStatus.TechnologyState.NotStarted || technology[4].state == TechnologyStatus.TechnologyState.Completed || technology[9].state == TechnologyStatus.TechnologyState.Completed;
  }
}
