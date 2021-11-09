
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "LearnedLore")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class LearnedLore : IExtensible
  {
    private List<int> _sno_lore_learned = new List<int>();
    private byte[] _sno_lore_learned_bitfield = (byte[]) null;
    private int _bitfield_leading_null_bytes = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.FixedSize, Name = "sno_lore_learned")]
    public List<int> sno_lore_learned
    {
      get => this._sno_lore_learned;
      set => this._sno_lore_learned = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "sno_lore_learned_bitfield")]
    [DefaultValue(null)]
    public byte[] sno_lore_learned_bitfield
    {
      get => this._sno_lore_learned_bitfield;
      set => this._sno_lore_learned_bitfield = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "bitfield_leading_null_bytes")]
    [DefaultValue(0)]
    public int bitfield_leading_null_bytes
    {
      get => this._bitfield_leading_null_bytes;
      set => this._bitfield_leading_null_bytes = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
