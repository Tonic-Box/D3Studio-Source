
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.ItemCrafting
{
  [ProtoContract(Name = "CrafterData")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class CrafterData : IExtensible
  {
    private List<int> _recipes = new List<int>();
        private List<int> _plans = new List<int>();
        private List<int> _deprecated_available_enchants = new List<int>();
    private int _level;
    private long _cooldown_end;
    private byte[] _recipes_bitfield = (byte[]) null;
    private int _bitfield_leading_null_bytes = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.FixedSize, Name = "recipes")]
    public List<int> recipes
    {
      get => this._recipes;
      set => this._recipes = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.FixedSize, Name = "deprecated_available_enchants")]
    public List<int> deprecated_available_enchants
    {
      get => this._deprecated_available_enchants;
      set => this._deprecated_available_enchants = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "level")]
    public int level
    {
      get => this._level;
      set => this._level = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "cooldown_end")]
    public long cooldown_end
    {
      get => this._cooldown_end;
      set => this._cooldown_end = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.Default, IsRequired = false, Name = "recipes_bitfield")]
    [DefaultValue(null)]
    public byte[] recipes_bitfield
    {
      get => this._recipes_bitfield;
      set => this._recipes_bitfield = value;
    }

    [ProtoMember(6, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "bitfield_leading_null_bytes")]
    [DefaultValue(0)]
    public int bitfield_leading_null_bytes
    {
      get => this._bitfield_leading_null_bytes;
      set => this._bitfield_leading_null_bytes = value;
    }

        [ProtoMember(7, DataFormat = DataFormat.FixedSize, Name = "plans")]
        public List<int> plans
        {
            get => this._plans;
            set => this._plans = value;
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
