
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.AchievementsStaticData
{
  [ProtoContract(Name = "CriteriaModifier")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class CriteriaModifier : IExtensible
  {
    private ulong _necessary_condition;
    private uint _target;
    private uint _operand;
    private ulong _comparand;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "necessary_condition")]
    public ulong necessary_condition
    {
      get => this._necessary_condition;
      set => this._necessary_condition = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "target")]
    public uint target
    {
      get => this._target;
      set => this._target = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "operand")]
    public uint operand
    {
      get => this._operand;
      set => this._operand = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "comparand")]
    public ulong comparand
    {
      get => this._comparand;
      set => this._comparand = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
