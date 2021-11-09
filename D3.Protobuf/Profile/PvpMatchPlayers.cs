
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Profile
{
  [ProtoContract(Name = "PvpMatchPlayers")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class PvpMatchPlayers : IExtensible
  {
    private List<PvpMatchPlayer> _team_0 = new List<PvpMatchPlayer>();
    private List<PvpMatchPlayer> _team_1 = new List<PvpMatchPlayer>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "team_0")]
    public List<PvpMatchPlayer> team_0
    {
      get => this._team_0;
      set => this._team_0 = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, Name = "team_1")]
    public List<PvpMatchPlayer> team_1
    {
      get => this._team_1;
      set => this._team_1 = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
