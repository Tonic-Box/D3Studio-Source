
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Profile
{
  [ProtoContract(Name = "PvpMatchPlayer")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class PvpMatchPlayer : IExtensible
  {
    private ulong _account_id = 0;
    private uint _gbid_class = 0;
    private bool _is_female = false;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "account_id")]
    [DefaultValue(0.0f)]
    public ulong account_id
    {
      get => this._account_id;
      set => this._account_id = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "gbid_class")]
    [DefaultValue(0)]
    public uint gbid_class
    {
      get => this._gbid_class;
      set => this._gbid_class = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = false, Name = "is_female")]
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
