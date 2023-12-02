namespace Comet.Game.States
{
    using System;
    using System.Threading.Tasks;
    using Comet.Database.Entities;
    using Comet.Game.Database.Repositories;

    /// <summary>
    /// Character class defines a database record for a player's character. This allows
    /// for easy saving of character information, as well as means for wrapping character
    /// data for spawn packet maintenance, interface update pushes, etc.
    /// </summary>
    public sealed class Character : DbCharacter
    {
        // Fields and properties
        private DateTime LastSaveTimestamp { get; set; }
        private readonly DbCharacter character;
        public byte CurrentLayout
        {
            get => character.ShowType;
            set => character.ShowType = value;
        }

        public ulong Silvers
        {
            get => character?.Silver ?? 0;
            set => character.Silver = value;
        }

        public ushort Speed
        {
            get => character?.Agility ?? 0;
            set => character.Agility = value;
        }

        // public override uint Life
        public uint Life
        {
            get => character.HealthPoints;
            set => character.HealthPoints = Math.Min(MaxLife, value);
        }
        // public override uint MaxLife
        public uint MaxLife
        {
            get
            {
                // if (Transformation != null)
                // {
                //     return (uint)Transformation.MaxLife;
                // }

                var result = (uint)(Vitality * 24);
                result += (uint)((Strength + Speed + Spirit) * 3);
                switch (Profession)
                {
                    case 11:
                        result = (uint)(result * 1.05d);
                        break;
                    case 12:
                        result = (uint)(result * 1.08d);
                        break;
                    case 13:
                        result = (uint)(result * 1.10d);
                        break;
                    case 14:
                        result = (uint)(result * 1.12d);
                        break;
                    case 15:
                        result = (uint)(result * 1.15d);
                        break;
                }

                // for (var pos = ItemPosition.EquipmentBegin;
                //      pos <= ItemPosition.EquipmentEnd;
                //      pos++)
                // {
                //     result += (uint)(UserPackage[pos]?.Life ?? 0);
                // }

                // result += (uint)AstProf.GetPower(AstProfType.Wrangler);
                // result += (uint)Fate.HealthPoints;
                // result += (uint)JiangHu.MaxLife;
                // result += (uint)InnerStrength.MaxLife;
                return result;
            }
        }
        // public override uint Mana
        public uint Mana
        {
            get => character.ManaPoints;
            set => character.ManaPoints = (ushort)Math.Min(MaxMana, value);
        }
        // public override uint MaxMana
        public uint MaxMana
        {
            get
            {
                var result = (uint)(Spirit * 5);
                switch (Profession)
                {
                    case 132:
                    case 142:
                        result *= 3;
                        break;
                    case 133:
                    case 143:
                        result *= 4;
                        break;
                    case 134:
                    case 144:
                        result *= 5;
                        break;
                    case 135:
                    case 145:
                        result *= 6;
                        break;
                }

                // for (var pos = ItemPosition.EquipmentBegin;
                //      pos <= ItemPosition.EquipmentEnd;
                //      pos++)
                // {
                //     result += (uint)(UserPackage[pos]?.Mana ?? 0);
                // }
                // result += (uint)JiangHu.MaxMana;
                return result;
            }
        }
        public ushort PkPoints
        {
            get => character?.KillPoints ?? 0;
            set => character.KillPoints = value;
        }
        public byte Metempsychosis
        {
            get => character?.Rebirths ?? 0;
            set => character.Rebirths = value;
        }
        public uint VipLevel { get; set; }
        public string MateName { get; set; }
        public uint BaseVipLevel => Math.Min(6, Math.Max(0, VipLevel));
        /// <summary>
        /// Instantiates a new instance of <see cref="Character"/> using a database fetched
        /// <see cref="DbCharacter"/>. Copies attributes over to the base class of this
        /// class, which will then be used to save the character from the game world. 
        /// </summary>
        /// <param name="character">Database character information</param>
        public Character(DbCharacter character) 
        {
            this.Identity = character.Identity;
            this.AccountIdentity = character.AccountIdentity;
            this.Name = character.Name;
            this.Mate = character.Mate;
            this.Mesh = character.Mesh;
            this.Hairstyle = character.Hairstyle;
            this.Silver = character.Silver;
            this.ConquerPoints = character.ConquerPoints;
            this.StorageMoney = character.StorageMoney;
            this.Profession = character.Profession;
            this.PreviousProfession = character.PreviousProfession;
            this.FirstProfession = character.FirstProfession;
            this.Rebirths = character.Rebirths;
            this.Level = character.Level;
            this.Experience = character.Experience;
            this.MapID = character.MapID;
            this.X = character.X;
            this.Y = character.Y;
            this.Virtue = character.Virtue;
            this.Strength = character.Strength;
            this.Agility = character.Agility;
            this.Vitality = character.Vitality;
            this.Spirit = character.Spirit;
            this.AttributePoints = character.AttributePoints;
            this.HealthPoints = character.HealthPoints;
            this.ManaPoints = character.ManaPoints;
            this.KillPoints = character.KillPoints;
            this.FirstLogin = character.FirstLogin;
            this.Donation = character.Donation;
            this.LoginTime = character.LoginTime;
            this.LogoutTime = character.LogoutTime;
            this.LogoutTime2 = character.LogoutTime2; // Offline TG
            this.OnlineSeconds = character.OnlineSeconds;
            this.AutoAllot = character.AutoAllot;
            this.MeteLevel = character.MeteLevel;
            this.MeteLevel2 = character.MeteLevel2;
            this.ExpBallUsage = character.ExpBallUsage;
            this.HeavenBlessing = character.HeavenBlessing;
            this.TaskMask = character.TaskMask;
            this.HomeIdentity = character.HomeIdentity;
            this.LockKey = character.LockKey;
            this.AutoExercise = character.AutoExercise;
            this.LuckyTime = character.LuckyTime;
            this.VipValue = character.VipValue;
            this.Business = character.Business;
            this.SendFlowerDate = character.SendFlowerDate;
            this.FlowerRed = character.FlowerRed;
            this.FlowerWhite = character.FlowerWhite;
            this.FlowerOrchid = character.FlowerOrchid;
            this.FlowerTulip = character.FlowerTulip;
            this.OnlineGodExpTime = character.OnlineGodExpTime;
            this.BattleGodExpTime = character.BattleGodExpTime;
            this.MentorOpportunity = character.MentorOpportunity;
            this.MentorUplevTime = character.MentorUplevTime;
            this.MentorAchieve = character.MentorAchieve;
            this.MentorDay = character.MentorDay;
            this.Title = character.Title;
            this.TitleSelect = character.TitleSelect;
            this.AthletePoint = character.AthletePoint;
            this.AthleteHistoryWins = character.AthleteHistoryWins;
            this.AthleteHistoryLoses = character.AthleteHistoryLoses;
            this.AthleteDayWins = character.AthleteDayWins;
            this.AthleteDayLoses = character.AthleteDayLoses;
            this.TeamAthletePoint = character.TeamAthletePoint;
            this.TeamAthleteHistoryWins = character.TeamAthleteHistoryWins;
            this.TeamAthleteHistoryLoses = character.TeamAthleteHistoryLoses;
            this.TeamAthleteDayWins = character.TeamAthleteDayWins;
            this.TeamAthleteDayLoses = character.TeamAthleteDayLoses;
            this.AthleteCurrentHonorPoints = character.AthleteCurrentHonorPoints;
            this.AthleteHistoryHonorPoints = character.AthleteHistoryHonorPoints;
            this.ConquerPointsBound = character.ConquerPointsBound;
            this.QuizPoints = character.QuizPoints;
            this.Nationality = character.Nationality;
            this.Cultivation = character.Cultivation;
            this.StrengthValue = character.StrengthValue;
            this.AstProfCurrent = character.AstProfCurrent;
            this.AstProfRank = character.AstProfRank;
            this.ShowType = character.ShowType;
            this.PkSettings = character.PkSettings;
            this.RidePetPoint = character.RidePetPoint;
            this.ChestPackageSize = character.ChestPackageSize;
            this.Flag = character.Flag;
            this.CultureValue = character.CultureValue;

            // Initialize local properties
            this.LastSaveTimestamp = DateTime.UtcNow;
            this.character = character;
        }

        public async Task SaveAsync(bool force = false)
        {
            DateTime now = DateTime.UtcNow;
            if (force || this.LastSaveTimestamp.AddMilliseconds(CharacterRepository.ThrottleMilliseconds) < now)
            {
                this.LastSaveTimestamp = now;
                await CharacterRepository.SaveAsync(this);
            }
        }
    }

    /// <summary>Enumeration type for body types for player characters.</summary>
    public enum BodyType : ushort
    {
        AgileMale = 1003,
        MuscularMale = 1004,
        AgileFemale = 2001,
        MuscularFemale = 2002
    }

    /// <summary>Enumeration type for base classes for player characters.</summary>
    public enum BaseClassType : ushort
    {
        Trojan = 10,
        Warrior = 20,
        Archer = 40,
        Ninja = 50,
        Taoist = 100
    }
}