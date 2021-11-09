
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hireling
{
  [ProtoContract(Name = "Info")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class Info : IExtensible
  {
    private int _hireling_class = 0;
    private int _gbid_name = -1;
    private int _level = 0;
    private uint _attribute_experience_next = 0;
    private List<int> _power_key_params = new List<int>();
    private bool _dead = false;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "hireling_class")]
    [DefaultValue(0)]
    public int hireling_class
    {
      get => this._hireling_class;
      set => this._hireling_class = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "gbid_name")]
    [DefaultValue(-1)]
    public int gbid_name
    {
      get => this._gbid_name;
      set => this._gbid_name = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "level")]
    [DefaultValue(0)]
    public int level
    {
      get => this._level;
      set => this._level = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "attribute_experience_next")]
    [DefaultValue(0)]
    public uint attribute_experience_next
    {
      get => this._attribute_experience_next;
      set => this._attribute_experience_next = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.ZigZag, Name = "power_key_params")]
    public List<int> power_key_params
    {
      get => this._power_key_params;
      set => this._power_key_params = value;
    }

    [ProtoMember(6, DataFormat = DataFormat.Default, IsRequired = true, Name = "dead")]
    [DefaultValue(false)]
    public bool dead
    {
      get => this._dead;
      set => this._dead = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
