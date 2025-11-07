// Decompiled with JetBrains decompiler
// Type: System.Nullable`1
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 3020F90F-960F-4330-86D5-45C4E07AFDFD
// Assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll

using System.Runtime.Versioning;

#nullable disable
namespace System;

[NonVersionable]
[__DynamicallyInvokable]
[Serializable]
[method: NonVersionable]
[method: __DynamicallyInvokable]
public struct Nullable<T>(T value) where T : struct
{
  private bool hasValue = true;
  internal T value = value;

  [__DynamicallyInvokable]
  public bool HasValue
  {
    [NonVersionable, __DynamicallyInvokable] get => this.hasValue;
  }

  [__DynamicallyInvokable]
  public T Value
  {
    [__DynamicallyInvokable] get
    {
      if (!this.hasValue)
        ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_NoValue);
      return this.value;
    }
  }

  [NonVersionable]
  [__DynamicallyInvokable]
  public T GetValueOrDefault() => this.value;

  [NonVersionable]
  [__DynamicallyInvokable]
  public T GetValueOrDefault(T defaultValue) => !this.hasValue ? defaultValue : this.value;

  [__DynamicallyInvokable]
  public override bool Equals(object other)
  {
    if (!this.hasValue)
      return other == null;
    return other != null && this.value.Equals(other);
  }

  [__DynamicallyInvokable]
  public override int GetHashCode() => !this.hasValue ? 0 : this.value.GetHashCode();

  [__DynamicallyInvokable]
  public override string ToString() => !this.hasValue ? "" : this.value.ToString();

  [NonVersionable]
  [__DynamicallyInvokable]
  public static implicit operator T?(T value) => new T?(value);

  [NonVersionable]
  [__DynamicallyInvokable]
  public static explicit operator T(T? value) => value.Value;
}
