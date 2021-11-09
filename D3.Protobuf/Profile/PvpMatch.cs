
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Profile
{
  [ProtoContract(Name = "PvpMatch")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class PvpMatch : IExtensible
  {
    private uint _arena = 0;
    private PvpMatchPlayers _players = (PvpMatchPlayers) null;
    private uint _score_team_0 = 0;
    private uint _score_team_1 = 0;
    private uint _play_time = 0;
    private uint _hero_id = 0;
    private uint _game_mode = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "arena")]
    [DefaultValue(0)]
    public uint arena
    {
      get => this._arena;
      set => this._arena = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = false, Name = "players")]
    [DefaultValue(null)]
    public PvpMatchPlayers players
    {
      get => this._players;
      set => this._players = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "score_team_0")]
    [DefaultValue(0)]
    public uint score_team_0
    {
      get => this._score_team_0;
      set => this._score_team_0 = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "score_team_1")]
    [DefaultValue(0)]
    public uint score_team_1
    {
      get => this._score_team_1;
      set => this._score_team_1 = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "play_time")]
    [DefaultValue(0)]
    public uint play_time
    {
      get => this._play_time;
      set => this._play_time = value;
    }

    [ProtoMember(6, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "hero_id")]
    [DefaultValue(0)]
    public uint hero_id
    {
      get => this._hero_id;
      set => this._hero_id = value;
    }

    [ProtoMember(7, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "game_mode")]
    [DefaultValue(0)]
    public uint game_mode
    {
      get => this._game_mode;
      set => this._game_mode = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
