
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Account
{
  [ProtoContract(Name = "AvengerVictim")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class AvengerVictim : IExtensible
  {
    private uint _gbid_class = 0;
    private bool _is_female = false;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "gbid_class")]
    [DefaultValue(0)]
    public uint gbid_class
    {
      get => this._gbid_class;
      set => this._gbid_class = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "is_female")]
    [DefaultValue(false)]
    public bool is_female
    {
      get => this._is_female;
      set => this._is_female = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
