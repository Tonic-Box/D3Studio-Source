
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.AchievementsStaticData
{
  [ProtoContract(Name = "StaticAchievementDefinition")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class StaticAchievementDefinition : IExtensible
  {
    private ulong _id;
    private ulong _superseding_achievement_id = 0;
    private uint _category_id;
    private uint _minimum_criteria = 0;
    private uint _points_value;
    private uint _flags;
    private uint _order_hint;
    private ulong _criteria_shared_with_achievement_id = 0;
    private List<Attribute> _attributes = new List<Attribute>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "id")]
    public ulong id
    {
      get => this._id;
      set => this._id = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "superseding_achievement_id")]
    [DefaultValue(0.0f)]
    public ulong superseding_achievement_id
    {
      get => this._superseding_achievement_id;
      set => this._superseding_achievement_id = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "category_id")]
    public uint category_id
    {
      get => this._category_id;
      set => this._category_id = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "minimum_criteria")]
    [DefaultValue(0)]
    public uint minimum_criteria
    {
      get => this._minimum_criteria;
      set => this._minimum_criteria = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "points_value")]
    public uint points_value
    {
      get => this._points_value;
      set => this._points_value = value;
    }

    [ProtoMember(6, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "flags")]
    public uint flags
    {
      get => this._flags;
      set => this._flags = value;
    }

    [ProtoMember(7, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "order_hint")]
    public uint order_hint
    {
      get => this._order_hint;
      set => this._order_hint = value;
    }

    [ProtoMember(8, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "criteria_shared_with_achievement_id")]
    [DefaultValue(0.0f)]
    public ulong criteria_shared_with_achievement_id
    {
      get => this._criteria_shared_with_achievement_id;
      set => this._criteria_shared_with_achievement_id = value;
    }

    [ProtoMember(9, DataFormat = DataFormat.Default, Name = "attributes")]
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
