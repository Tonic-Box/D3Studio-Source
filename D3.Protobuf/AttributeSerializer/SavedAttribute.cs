
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.AttributeSerializer
{
  [ProtoContract(Name = "SavedAttribute")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class SavedAttribute : IExtensible
  {
    private int _key;
    private long _value;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "key")]
    public int key
    {
      get => this._key;
      set => this._key = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "value")]
    public long value
    {
      get => this._value;
      set => this._value = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
