
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "Timestamps")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class Timestamps : IExtensible
  {
    private long _create_time;
    private long _delete_time = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "create_time")]
    public long create_time
    {
      get => this._create_time;
      set => this._create_time = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "delete_time")]
    [DefaultValue(0)]
    public long delete_time
    {
      get => this._delete_time;
      set => this._delete_time = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
