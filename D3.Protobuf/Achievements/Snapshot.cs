
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Achievements
{
  [ProtoContract(Name = "Snapshot")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class Snapshot : IExtensible
  {
    private List<AchievementUpdateRecord> _achievement_snapshot = new List<AchievementUpdateRecord>();
    private List<CriteriaUpdateRecord> _criteria_snapshot = new List<CriteriaUpdateRecord>();
    private ulong _header = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "achievement_snapshot")]
    public List<AchievementUpdateRecord> achievement_snapshot
    {
      get => this._achievement_snapshot;
      set => this._achievement_snapshot = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, Name = "criteria_snapshot")]
    public List<CriteriaUpdateRecord> criteria_snapshot
    {
      get => this._criteria_snapshot;
      set => this._criteria_snapshot = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "header")]
    [DefaultValue(0.0f)]
    public ulong header
    {
      get => this._header;
      set => this._header = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
