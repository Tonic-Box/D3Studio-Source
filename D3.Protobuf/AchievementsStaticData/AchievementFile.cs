
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.AchievementsStaticData
{
  [ProtoContract(Name = "AchievementFile")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class AchievementFile : IExtensible
  {
    private List<StaticCategoryDefinition> _category = new List<StaticCategoryDefinition>();
    private List<StaticAchievementDefinition> _achievement = new List<StaticAchievementDefinition>();
    private List<StaticCriteriaDefinition> _criteria = new List<StaticCriteriaDefinition>();
    private List<Attribute> _attributes = new List<Attribute>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "category")]
    public List<StaticCategoryDefinition> category
    {
      get => this._category;
      set => this._category = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, Name = "achievement")]
    public List<StaticAchievementDefinition> achievement
    {
      get => this._achievement;
      set => this._achievement = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.Default, Name = "criteria")]
    public List<StaticCriteriaDefinition> criteria
    {
      get => this._criteria;
      set => this._criteria = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.Default, Name = "attributes")]
    public List<Attribute> attributes
    {
      get => this._attributes;
      set => this._attributes = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
