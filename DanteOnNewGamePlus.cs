using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using dante_on_new_game_plus;
using Il2Cppnewdata_H;

[assembly: MelonInfo(typeof(DanteOnNewGamePlus), "Dante/Raidou on New Game Plus [level 80]", "1.0.0", "Matthiew Purple")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace dante_on_new_game_plus;
public class DanteOnNewGamePlus : MelonMod
{
    // When creating a NG+
    [HarmonyPatch(typeof(dds3GlobalWork), nameof(dds3GlobalWork.NewGame2Pop))]
    private class Patch
    {
        public static void Postfix()
        {
            // If Dante/Raidou not already in party
            foreach (datUnitWork_t work in dds3GlobalWork.DDS3_GBWK.unitwork)
            {
                if (work.id == 192) return; // Does nothing
            }

            // If he's not in the party already, adds him
            datCalc.datAddDevil(192, 0);
        }
    }
}
