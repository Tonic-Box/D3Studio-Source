
using PB.Profile;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Console
{
  [ProtoContract(Name = "Profile")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class Profile : IExtensible
  {
    private AccountProfile _account_profile;
    private List<HeroInfo> _fallen_heroes = new List<HeroInfo>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "account_profile")]
    public AccountProfile account_profile
    {
      get => this._account_profile;
      set => this._account_profile = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, Name = "fallen_heroes")]
    public List<HeroInfo> fallen_heroes
    {
      get => this._fallen_heroes;
      set => this._fallen_heroes = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
