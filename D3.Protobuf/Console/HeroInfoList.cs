
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Console
{
  [ProtoContract(Name = "HeroInfoList")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class HeroInfoList : IExtensible
  {
    private List<HeroInfo> _heroes = new List<HeroInfo>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "heroes")]
    public List<HeroInfo> heroes
    {
      get => this._heroes;
      set => this._heroes = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
