
using PB.OnlineService;
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Items
{
  [ProtoContract(Name = "EmbeddedGenerator")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class EmbeddedGenerator : IExtensible
  {
    private ItemId _id;
    private Generator _generator;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "id")]
    public ItemId id
    {
      get => this._id;
      set => this._id = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "generator")]
    public Generator generator
    {
      get => this._generator;
      set => this._generator = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
