using System;
using HarmonyLib;
using TownOfUs.Roles;

namespace TownOfUs.NeutralRoles.ShifterMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__18), nameof(IntroCutscene._CoBegin_d__18.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__18 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Shifter))
            {
                var shifter = (Shifter) role;
                shifter.LastShifted = DateTime.UtcNow;
                shifter.LastShifted = shifter.LastShifted.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.ShifterCd);
            }
        }
    }
}