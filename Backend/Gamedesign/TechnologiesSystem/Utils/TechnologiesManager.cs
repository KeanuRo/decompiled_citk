// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.TechnologiesSystem.Utils.TechnologiesManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign.TechnologiesSystem.Technologies;
using Backend.Interfaces;
using Backend.OtherUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Backend.Gamedesign.TechnologiesSystem.Utils;

public class TechnologiesManager : MonoBehaviour, IInitializable
{
  public static TechnologiesManager inst;
  [SerializeField]
  private Dictionary<ScienceTree, AbstractTechnology> technologies = new Dictionary<ScienceTree, AbstractTechnology>();

  IEnumerator IInitializable.Initialize()
  {
    TechnologiesManager.inst = this;
    this.OrganizeTechnologies();
    yield return (object) null;
  }

  public void OrganizeTechnologies()
  {
    foreach (Type typesByAttribute in ReflectionUtils.GetTypesByAttributes(typeof (TechnologyAttribute)))
    {
      AbstractTechnology instance = Activator.CreateInstance(typesByAttribute) as AbstractTechnology;
      this.technologies.Add(instance.ScienceTreeCurrent, instance);
    }
  }

  public AbstractTechnology GetTechnology(ScienceTree tree) => this.technologies[tree];

  public AbstractTechnology GetTechnology(int tree) => this.technologies[(ScienceTree) tree];

  public IEnumerable<AbstractTechnology> GetAllTechnologies()
  {
    return (IEnumerable<AbstractTechnology>) this.technologies.Values;
  }
}
