
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Profile
{
  [ProtoContract(Name = "SkillWithRune")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class SkillWithRune : IExtensible
  {
    private int _skill;
    private int _rune_type = -1;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "skill")]
    public int skill
    {
      get => this._skill;
      set => this._skill = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "rune_type")]
    [DefaultValue(-1)]
    public int rune_type
    {
      get => this._rune_type;
      set => this._rune_type = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
