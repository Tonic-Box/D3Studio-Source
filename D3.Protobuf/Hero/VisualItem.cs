
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "VisualItem")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class VisualItem : IExtensible
  {
    private int _gbid = -1;
    private int _dye_type = 0;
    private int _item_effect_type = 0;
    private int _effect_level = -1;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.FixedSize, IsRequired = false, Name = "gbid")]
    [DefaultValue(-1)]
    public int gbid
    {
      get => this._gbid;
      set => this._gbid = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "dye_type")]
    [DefaultValue(0)]
    public int dye_type
    {
      get => this._dye_type;
      set => this._dye_type = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "item_effect_type")]
    [DefaultValue(0)]
    public int item_effect_type
    {
      get => this._item_effect_type;
      set => this._item_effect_type = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "effect_level")]
    [DefaultValue(-1)]
    public int effect_level
    {
      get => this._effect_level;
      set => this._effect_level = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
