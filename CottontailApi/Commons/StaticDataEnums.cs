using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottontailApi.Commons
{
    public class StaticDataEnums
    {
        public enum ChampionData
        {
            /// <summary>
            /// The default
            /// </summary>
            basic,

            All,
            Allytips,
            Altimages,
            Blurb,
            Enemytips,
            Image,
            Info,
            Lore,
            Partype,
            Passive,
            Recommended,
            Skins,
            Spells,
            Stats,
            Tags,
        }

        /// <summary>
        /// Enum when requesting data for the Item Static API.
        /// </summary>
        public enum ItemData
        {
            /// <summary>
            /// The default. Resolves to type, version, basic, data, id, name, plaintext, group, and description
            /// </summary>
            Basic,


            All,
            Colloq,
            ConsumeOnFull,
            Consumed,
            Depth,
            Effect,
            From,
            Gold,
            Groups,
            HideFromAll,
            Image,
            InStore,
            Into,
            Maps,
            RequiredChampion,
            SanitizedDescription,
            SpecialRecipe,
            Stacks,
            Stats,
            Tags,
            Tree
        }

        /// <summary>
        /// Enum when requesting data for the Mastery Static API.
        /// </summary>
        public enum MasteryData
        {
            /// <summary>
            /// The default. Resolves to type, version, data, id, name, and description
            /// </summary>
            basic,

            All,
            Image,
            MasteryTree,
            Prereq,
            Ranks,
            SanitizedDescription,
            Tree,
        }

        /// <summary>
        /// Enum when requesting data for the Rune Static API.
        /// </summary>
        public enum RuneData
        {
            /// <summary>
            /// The default. Resolves to type, version, data, id, name, rune, and description
            /// </summary>
            basic,

            All,
            Basic,
            Colloq,
            ConsumeOnFull,
            Consumed,
            Depth,
            From,
            Gold,
            HideFromAll,
            Image,
            InStore,
            Into,
            Maps,
            RequiredChampion,
            SanitizedDescription,
            SpecialRecipe,
            Stacks,
            Stats,
            Tags,
        }

        /// <summary>
        /// Enum when requesting data for the SummonerSpell Static API.
        /// </summary>
        public enum SummonerSpellData
        {
            /// <summary>
            /// The default. Resolves to type, version, data, id, key, name, description, and summonerLevel
            /// </summary>
            basic,

            All,
            Cooldown,
            CooldownBurn,
            Cost,
            CostBurn,
            CostType,
            Effect,
            EffectBurn,
            Image,
            Key,
            Leveltip,
            Maxrank,
            Modes,
            Range,
            RangeBurn,
            Resource,
            SanitizedDescription,
            SanitizedTooltip,
            Tooltip,
            Vars,
        }
    }
}
