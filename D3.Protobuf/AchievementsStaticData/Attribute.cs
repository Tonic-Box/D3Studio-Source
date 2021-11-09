
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.AchievementsStaticData
{
  [ProtoContract(Name = "Attribute")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class Attribute : IExtensible
  {
    private string _key;
    private string _value;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "key")]
    public string key
    {
      get => this._key;
      set => this._key = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "value")]
    public string value
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
