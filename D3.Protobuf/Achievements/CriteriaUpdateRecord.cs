
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Achievements
{
  [ProtoContract(Name = "CriteriaUpdateRecord")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class CriteriaUpdateRecord : IExtensible
  {
    private uint _criteria_Id_32_and_flags_8;
    private uint _start_time_32 = 0;
    private uint _quantity_32 = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "criteria_Id_32_and_flags_8")]
    public uint criteria_Id_32_and_flags_8
    {
      get => this._criteria_Id_32_and_flags_8;
      set => this._criteria_Id_32_and_flags_8 = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "start_time_32")]
    [DefaultValue(0)]
    public uint start_time_32
    {
      get => this._start_time_32;
      set => this._start_time_32 = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "quantity_32")]
    [DefaultValue(0)]
    public uint quantity_32
    {
      get => this._quantity_32;
      set => this._quantity_32 = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
