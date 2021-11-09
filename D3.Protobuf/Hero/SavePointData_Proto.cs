
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "SavePointData_Proto")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class SavePointData_Proto : IExtensible
  {
    private int _sno_world;
    private int _savepoint_number;
    private uint _creates_portal;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "sno_world")]
    public int sno_world
    {
      get => this._sno_world;
      set => this._sno_world = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "savepoint_number")]
    public int savepoint_number
    {
      get => this._savepoint_number;
      set => this._savepoint_number = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "creates_portal")]
    public uint creates_portal
    {
      get => this._creates_portal;
      set => this._creates_portal = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
