
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.ItemCrafting
{
  [ProtoContract(Name = "CrafterTransmogData")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class CrafterTransmogData : IExtensible
  {
    private List<int> _unlocked_transmogs = new List<int>();
    private byte[] _unlocked_transmogs_bitfield = (byte[]) null;
    private int _bitfield_leading_null_bytes = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.FixedSize, Name = "unlocked_transmogs")]
    public List<int> unlocked_transmogs
    {
      get => this._unlocked_transmogs;
      set => this._unlocked_transmogs = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = false, Name = "unlocked_transmogs_bitfield")]
    [DefaultValue(null)]
    public byte[] unlocked_transmogs_bitfield
    {
      get => this._unlocked_transmogs_bitfield;
      set => this._unlocked_transmogs_bitfield = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "bitfield_leading_null_bytes")]
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
