
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Account
{
  [ProtoContract(Name = "Avenger")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class Avenger : IExtensible
  {
    private uint _player_kills = 1;
    private string _avenger_name = nameof (Avenger);
    private int _monster_sno = -1;
    private bool _resolved = false;
    private Avenger.State _result = Avenger.State.ALIVE;
    private ulong _sent_from = 0;
    private int _affix_bucket = 0;
    private List<AvengerVictim> _victims = new List<AvengerVictim>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "player_kills")]
    [DefaultValue(1)]
    public uint player_kills
    {
      get => this._player_kills;
      set => this._player_kills = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "avenger_name")]
    [DefaultValue("Avenger")]
    public string avenger_name
    {
      get => this._avenger_name;
      set => this._avenger_name = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "monster_sno")]
    [DefaultValue(-1)]
    public int monster_sno
    {
      get => this._monster_sno;
      set => this._monster_sno = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.Default, IsRequired = true, Name = "resolved")]
    [DefaultValue(false)]
    public bool resolved
    {
      get => this._resolved;
      set => this._resolved = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "result")]
    [DefaultValue(Avenger.State.ALIVE)]
    public Avenger.State result
    {
      get => this._result;
      set => this._result = value;
    }

    [ProtoMember(6, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "sent_from")]
    [DefaultValue(0.0f)]
    public ulong sent_from
    {
      get => this._sent_from;
      set => this._sent_from = value;
    }

    [ProtoMember(7, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "affix_bucket")]
    [DefaultValue(0)]
    public int affix_bucket
    {
      get => this._affix_bucket;
      set => this._affix_bucket = value;
    }

    [ProtoMember(8, DataFormat = DataFormat.Default, Name = "victims")]
    public List<AvengerVictim> victims
    {
      get => this._victims;
      set => this._victims = value;
    }


        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoContract(Name = "State")]
    public enum State
    {
      [ProtoEnum(Name = "ALIVE", Value = 0)] ALIVE,
      [ProtoEnum(Name = "KILLED_PLAYER", Value = 1)] KILLED_PLAYER,
      [ProtoEnum(Name = "KILLED", Value = 2)] KILLED,
    }
  }
}
