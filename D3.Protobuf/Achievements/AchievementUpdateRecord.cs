
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Achievements
{
  [ProtoContract(Name = "AchievementUpdateRecord")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class AchievementUpdateRecord : IExtensible
  {
    private ulong _achievement_id;
    private int _completion;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "achievement_id")]
    public ulong achievement_id
    {
      get => this._achievement_id;
      set => this._achievement_id = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "completion")]
    public int completion
    {
      get => this._completion;
      set => this._completion = value;
    }


        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
