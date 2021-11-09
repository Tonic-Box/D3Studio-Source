
using ProtoBuf;

namespace PB.AchievementsStaticData
{
  [ProtoContract(Name = "ModiferTargetType")]
  public enum ModiferTargetType
  {
    [ProtoEnum(Name = "OBJECT", Value = 5202538)] OBJECT = 5202538, // 0x004F626A
    [ProtoEnum(Name = "SUBJECT", Value = 1400201834)] SUBJECT = 1400201834, // 0x5375626A
  }
}
