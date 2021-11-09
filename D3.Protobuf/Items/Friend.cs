
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Items
{
  [ProtoContract(Name = "FrienDGIftInfo")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class Friend : IExtensible
  {
    private ulong _id = 0;
    private string _UserName;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "id_friend_recipient")]
    [DefaultValue(0.0f)]
    public ulong id
    {
      get => this._id;
      set => this._id = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = false, Name = "recipient_name")]
    [DefaultValue("")]
    public string username
    {
      get => this._UserName;
      set => this._UserName = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
