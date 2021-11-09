
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Hero
{
    [ProtoContract(Name = "SkillWithRune")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class SkillWithRune : IExtensible
    {
        private int _sno_skill = -1;
        private int _rune_type = -1;
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "sno_skill")]
        public int sno_skill
        {
            get => this._sno_skill;
            set => this._sno_skill = value;
        }

        [ProtoMember(2, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "rune_type")]
        [DefaultValue(-1)]
        public int rune_type
        {
            get => this._rune_type;
            set => this._rune_type = value;
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
