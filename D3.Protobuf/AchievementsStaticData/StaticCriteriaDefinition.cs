
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.AchievementsStaticData
{
  [ProtoContract(Name = "StaticCriteriaDefinition")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class StaticCriteriaDefinition : IExtensible
  {
    private ulong _criteria_id;
    private ulong _parent_achievement_id;
    private CriteriaEvent _start_event = (CriteriaEvent) null;
    private CriteriaEvent _advance_event = (CriteriaEvent) null;
    private CriteriaEvent _fail_event = (CriteriaEvent) null;
    private ulong _necessary_quantity;
    private uint _order_hint = 0;
    private uint _evalutation_class;
    private uint _flags;
    private List<Attribute> _attributes = new List<Attribute>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "criteria_id")]
    public ulong criteria_id
    {
      get => this._criteria_id;
      set => this._criteria_id = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "parent_achievement_id")]
    public ulong parent_achievement_id
    {
      get => this._parent_achievement_id;
      set => this._parent_achievement_id = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = false, Name = "start_event")]
    [DefaultValue(null)]
    public CriteriaEvent start_event
    {
      get => this._start_event;
      set => this._start_event = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.Default, IsRequired = false, Name = "advance_event")]
    [DefaultValue(null)]
    public CriteriaEvent advance_event
    {
      get => this._advance_event;
      set => this._advance_event = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.Default, IsRequired = false, Name = "fail_event")]
    [DefaultValue(null)]
    public CriteriaEvent fail_event
    {
      get => this._fail_event;
      set => this._fail_event = value;
    }

    [ProtoMember(6, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "necessary_quantity")]
    public ulong necessary_quantity
    {
      get => this._necessary_quantity;
      set => this._necessary_quantity = value;
    }

    [ProtoMember(7, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "order_hint")]
    [DefaultValue(0)]
    public uint order_hint
    {
      get => this._order_hint;
      set => this._order_hint = value;
    }

    [ProtoMember(8, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "evalutation_class")]
    public uint evalutation_class
    {
      get => this._evalutation_class;
      set => this._evalutation_class = value;
    }

    [ProtoMember(9, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "flags")]
    public uint flags
    {
      get => this._flags;
      set => this._flags = value;
    }

    [ProtoMember(10, DataFormat = DataFormat.Default, Name = "attributes")]
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
