//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FTN {
    using System;
    using FTN;
    
    
    /// A time schedule covering a 24 hour period, with curve data for a specific type of season and day.
    public class SeasonDayTypeSchedule : RegularIntervalSchedule {
        
        /// DayType for the Schedule.
        private DayType cim_DayType;
        
        private const bool isDayTypeMandatory = false;
        
        private const string _DayTypePrefix = "cim";
        
        /// Season for the Schedule.
        private Season cim_Season;
        
        private const bool isSeasonMandatory = false;
        
        private const string _SeasonPrefix = "cim";
        
        public virtual DayType DayType {
            get {
                return this.cim_DayType;
            }
            set {
                this.cim_DayType = value;
            }
        }
        
        public virtual bool DayTypeHasValue {
            get {
                return this.cim_DayType != null;
            }
        }
        
        public static bool IsDayTypeMandatory {
            get {
                return isDayTypeMandatory;
            }
        }
        
        public static string DayTypePrefix {
            get {
                return _DayTypePrefix;
            }
        }
        
        public virtual Season Season {
            get {
                return this.cim_Season;
            }
            set {
                this.cim_Season = value;
            }
        }
        
        public virtual bool SeasonHasValue {
            get {
                return this.cim_Season != null;
            }
        }
        
        public static bool IsSeasonMandatory {
            get {
                return isSeasonMandatory;
            }
        }
        
        public static string SeasonPrefix {
            get {
                return _SeasonPrefix;
            }
        }
    }
}
