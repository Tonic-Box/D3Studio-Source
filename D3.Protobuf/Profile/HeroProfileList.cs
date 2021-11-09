
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Profile
{
  [ProtoContract(Name = "HeroProfileList")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class HeroProfileList : IExtensible
  {
    private List<HeroProfile> _heros = new List<HeroProfile>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "heros")]
    public List<HeroProfile> heros
    {
      get => this._heros;
      set => this._heros = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
