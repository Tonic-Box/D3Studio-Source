
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.AchievementsStaticData
{
  [ProtoContract(Name = "CriteriaEvent")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class CriteriaEvent : IExtensible
  {
    private ulong _id;
    private ulong _comparand = 0;
    private List<CriteriaModifier> _modifier = new List<CriteriaModifier>();
    private uint _timer_duration = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "id")]
    public ulong id
    {
      get => this._id;
      set => this._id = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "comparand")]
    [DefaultValue(0.0f)]
    public ulong comparand
    {
      get => this._comparand;
      set => this._comparand = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.Default, Name = "modifier")]
    public List<CriteriaModifier> modifier
    {
      get => this._modifier;
      set => this._modifier = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "timer_duration")]
    [DefaultValue(0)]
    public uint timer_duration
    {
      get => this._timer_duration;
      set => this._timer_duration = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
