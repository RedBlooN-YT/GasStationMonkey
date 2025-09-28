using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Simulation.SMath;


namespace GasStationMonkey.Displays.Projectiles;


public class ChipDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, Name);
    }
}




public class FireDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, Name);
    }
}


public class SodaDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, Name);
    }
}