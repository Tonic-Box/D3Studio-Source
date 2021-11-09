
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hero
{
    [ProtoContract(Name = "SavedData")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class SavedData : IExtensible
    {
        private uint _time_played;
        private uint _activated_waypoints;
        private PB.Hireling.SavedData _hireling_saved_data;
        private uint _last_level_time;
        private LearnedLore _learned_lore;
        private SavedConversations _saved_conversations;
        private List<int> _sno_traits = new List<int>();
        private List<int> _cube_powers = new List<int>();
        private SavePointData_Proto _save_point;
        private int _gbid_potion_button;
        private List<SkillWithRune> _active_skills = new List<SkillWithRune>();
        private byte[] _skill_slot_ever_assigned;
        private uint _skill_version;
        private List<uint> _boss_kill_flags = new List<uint>();
        private uint _event_flags = 0;
        private uint _skill_kit_version = 0;
        private SavedItemLink _potion_button_item = (SavedItemLink)null;
        private int _main_quest_handicap_snapshot = -1;
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "time_played")]
        public uint time_played
        {
            get => this._time_played;
            set => this._time_played = value;
        }

        [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "activated_waypoints")]
        public uint activated_waypoints
        {
            get => this._activated_waypoints;
            set => this._activated_waypoints = value;
        }

        [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = true, Name = "hireling_saved_data")]
        public PB.Hireling.SavedData hireling_saved_data
        {
            get => this._hireling_saved_data;
            set => this._hireling_saved_data = value;
        }

        [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "last_level_time")]
        public uint last_level_time
        {
            get => this._last_level_time;
            set => this._last_level_time = value;
        }

        [ProtoMember(5, DataFormat = DataFormat.Default, IsRequired = true, Name = "learned_lore")]
        public LearnedLore learned_lore
        {
            get => this._learned_lore;
            set => this._learned_lore = value;
        }

        [ProtoMember(6, DataFormat = DataFormat.Default, IsRequired = true, Name = "saved_conversations")]
        public SavedConversations saved_conversations
        {
            get => this._saved_conversations;
            set => this._saved_conversations = value;
        }

        [ProtoMember(7, DataFormat = DataFormat.FixedSize, Name = "sno_traits")]
        public List<int> sno_traits
        {
            get => this._sno_traits;
            set => this._sno_traits = value;
        }

        [ProtoMember(8, DataFormat = DataFormat.Default, IsRequired = true, Name = "save_point")]
        public SavePointData_Proto save_point
        {
            get => this._save_point;
            set => this._save_point = value;
        }

        [ProtoMember(9, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "gbid_potion_button")]
        public int gbid_potion_button
        {
            get => this._gbid_potion_button;
            set => this._gbid_potion_button = value;
        }

        [ProtoMember(10, DataFormat = DataFormat.Default, Name = "active_skills")]
        public List<SkillWithRune> active_skills
        {
            get => this._active_skills;
            set => this._active_skills = value;
        }

        [ProtoMember(11, DataFormat = DataFormat.Default, IsRequired = true, Name = "skill_slot_ever_assigned")]
        public byte[] skill_slot_ever_assigned
        {
            get => this._skill_slot_ever_assigned;
            set => this._skill_slot_ever_assigned = value;
        }

        [ProtoMember(12, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "skill_version")]
        public uint skill_version
        {
            get => this._skill_version;
            set => this._skill_version = value;
        }

        [ProtoMember(13, DataFormat = DataFormat.TwosComplement, Name = "boss_kill_flags")]
        public List<uint> boss_kill_flags
        {
            get => this._boss_kill_flags;
            set => this._boss_kill_flags = value;
        }

        [ProtoMember(14, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "event_flags")]
        [DefaultValue(0)]
        public uint event_flags
        {
            get => this._event_flags;
            set => this._event_flags = value;
        }

        [ProtoMember(15, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "skill_kit_version")]
        [DefaultValue(0)]
        public uint skill_kit_version
        {
            get => this._skill_kit_version;
            set => this._skill_kit_version = value;
        }

        [ProtoMember(16, DataFormat = DataFormat.Default, IsRequired = false, Name = "potion_button_item")]
        [DefaultValue(null)]
        public SavedItemLink potion_button_item
        {
            get => this._potion_button_item;
            set => this._potion_button_item = value;
        }

        [ProtoMember(17, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "main_quest_handicap_snapshot")]
        [DefaultValue(-1)]
        public int main_quest_handicap_snapshot
        {
            get => this._main_quest_handicap_snapshot;
            set => this._main_quest_handicap_snapshot = value;
        }

        [ProtoMember(18, DataFormat = DataFormat.FixedSize, Name = "cube_powers")]
        public List<int> cube_powers
        {
            get => this._cube_powers;
            set => this._cube_powers = value;
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
