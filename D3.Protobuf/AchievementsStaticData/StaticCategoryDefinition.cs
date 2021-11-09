
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.AchievementsStaticData
{
  [ProtoContract(Name = "StaticCategoryDefinition")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class StaticCategoryDefinition : IExtensible
  {
    private uint _id;
    private ulong _parent_id = 0;
    private ulong _OBSOLETE_featured_achievement_id = 0;
    private uint _order_hint;
    private List<Attribute> _attributes = new List<Attribute>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "id")]
    public uint id
    {
      get => this._id;
      set => this._id = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "parent_id")]
    [DefaultValue(0.0f)]
    public ulong parent_id
    {
      get => this._parent_id;
      set => this._parent_id = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "OBSOLETE_featured_achievement_id")]
    [DefaultValue(0.0f)]
    public ulong OBSOLETE_featured_achievement_id
    {
      get => this._OBSOLETE_featured_achievement_id;
      set => this._OBSOLETE_featured_achievement_id = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "order_hint")]
    public uint order_hint
    {
      get => this._order_hint;
      set => this._order_hint = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.Default, Name = "attributes")]
    public List<Attribute> attributes
    {
      get => this._attributes;
      set => this._attributes = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
