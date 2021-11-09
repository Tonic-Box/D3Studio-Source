
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.OnlineService
{
  [ProtoContract(Name = "GameId")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class GameId : IExtensible
  {
    private ulong _factory;
    private ulong _id_high;
    private ulong _id_low;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "factory")]
    public ulong factory
    {
      get => this._factory;
      set => this._factory = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "id_high")]
    public ulong id_high
    {
      get => this._id_high;
      set => this._id_high = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "id_low")]
    public ulong id_low
    {
      get => this._id_low;
      set => this._id_low = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
