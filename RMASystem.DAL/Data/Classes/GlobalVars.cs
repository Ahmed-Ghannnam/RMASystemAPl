using RMASystem.DAL;

namespace RMASystem.DAL
{
    public class GlobalVars
    {
        public static string userCode = "Automatic service";
        public static decimal NullNumberValue = -999999999;
    }

    public enum ValueType
    {
        [EnumEngDescription("Free")]
        [EnumArbDescription("مجاني")]
        Free = -2,
        [EnumEngDescription("None")]
        [EnumArbDescription("لا يوجد")]
        None = -1,
        [EnumEngDescription("Value")]
        [EnumArbDescription("قيمة")]
        Value = 0,
        [EnumEngDescription("Percentage")]
        [EnumArbDescription("نسبة")]
        Percentage = 1
    };

}
