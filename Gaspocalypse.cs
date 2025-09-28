using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppSystem.Linq;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using GasStationMonkey.Displays.Projectiles;
using Il2Cpp;

namespace GasStationMonkey.Upgrades;

public class Gaspocalyse : ModParagonUpgrade<GasStationMonkey>
{

    public override int Cost => 932210;

    public override string DisplayName => "Gaspocalypse";

    public override string Description => "The craziest gas station of all time!!! Ability: Gas-Mento Exploders: Drop several fiery mento bombs out of the sky, and deal severe damage to bloons on the screen.";

    public override string Icon => "555";

    public override string Portrait => "555";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        projectileModel.GetDamageModel().damage += 85;

        weaponModel.projectile.ApplyDisplay<FireDisplay>();


        //base 555 all stats added automaticlly, ability and multishot added here

        towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 10, 0, 10, null, false, false);


        var ability = Game.instance.model.GetTowerModel("DartlingGunner", 1, 4, 0).GetAbility().Duplicate("RowdyRush");
        ability.cooldown = 40;

        var activate = ability.GetBehavior<ActivateAttackModel>();
        activate.lifespan = 10;

        var Bomb300 = Game.instance.model.GetTowerModel("BombShooter", 3, 0, 0);
        var tornadoTemplate = Bomb300.GetAttackModels()[0];


        var RowdyRushAttack = tornadoTemplate.Duplicate("RowdyRushattack");

        RowdyRushAttack.RemoveFilter<FilterInvisibleModel>();
        RowdyRushAttack.weapons[0].projectile.SetHitCamo(true);


        activate.attacks[0] = RowdyRushAttack;

        var RowdyRushWeapon = RowdyRushAttack.weapons[0];

        RowdyRushWeapon.Rate = 0.25f;
        RowdyRushWeapon.emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 10, null, false, false);

        towerModel.AddBehavior(ability);
        towerModel.GetAbility().icon = GetSpriteReference("ability");

        //ability 2
        var ace2050 = Game.instance.model.GetTowerModel("MonkeyAce", 2, 5, 0);
        var tsarAbility = ace2050.GetBehavior<AbilityModel>();


        var gigantaDrop = tsarAbility.Duplicate("GigantaDrop");
        gigantaDrop.cooldown = 60f;


        var activate2 = gigantaDrop.GetBehavior<ActivateAttackModel>();
        var dropAttack = activate2.attacks[0];


        var w = dropAttack.weapons[0];
        w.rate = 0f;
        w.emission = new ArcEmissionModel("ArcEm", 6, 0, 360f, null, false, false);


        activate2.attacks = new Il2CppReferenceArray<AttackModel>(new[] { dropAttack });


        ace2050.AddBehavior(gigantaDrop);

        towerModel.AddBehavior(gigantaDrop);


// Necromancer attack

        var druid300 = Game.instance.model.GetTowerModel("WizardMonkey", 0, 0, 4);
        var tornadoTpl = druid300.GetAttackModels().First(a => a.name.Contains("Necromancer"));

        var tornadoAttack = tornadoTpl.Duplicate("HairDryer_T5_TornadoAttack");

        tornadoAttack.RemoveFilter<FilterInvisibleModel>();
        tornadoAttack.weapons[0].projectile.SetHitCamo(true);

        var tornadoWeapon = tornadoAttack.weapons[0];

        tornadoWeapon.projectile.pierce = 2000;
        tornadoWeapon.projectile.GetDamageModel().damage = 2001;


        var necroZone = druid300.behaviors.First(b => b.name == "NecromancerZoneModel_").Duplicate("NecroZone_HS");


        towerModel.AddBehavior(tornadoAttack);
        towerModel.AddBehavior(necroZone);
    }
}