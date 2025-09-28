using MelonLoader;
using BTD_Mod_Helper;
using GasStationMonkey;
using BTD_Mod_Helper.Api;

[assembly: MelonInfo(typeof(GasStationMonkey.GasStationMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace GasStationMonkey;

public class GasStationMod : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<GasStationMod>("GasStationMonkey loaded!");
        

    }
}