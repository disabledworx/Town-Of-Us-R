using System;
using HarmonyLib;
using TownOfUs.Roles;

namespace TownOfUs.ImpostorRoles.MorphlingMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__18), nameof(IntroCutscene._CoBegin_d__18.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__18 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Morphling))
            {
                var morphling = (Morphling) role;
                morphling.LastMorphed = DateTime.UtcNow;
                morphling.LastMorphed = morphling.LastMorphed.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.MorphlingCd);
            }
        }
    }
}