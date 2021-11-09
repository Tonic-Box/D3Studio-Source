
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Profile
{
  [ProtoContract(Name = "SkillsWithRunes")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class SkillsWithRunes : IExtensible
  {
    private List<SkillWithRune> _runes = new List<SkillWithRune>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "runes")]
    public List<SkillWithRune> runes
    {
      get => this._runes;
      set => this._runes = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
