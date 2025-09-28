using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppSystem.Collections.Generic;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using MelonLoader;

namespace GasStationMonkey.Upgrades.MiddlePath;

public class SuperSodaGigantabomb : ModUpgrade<GasStationMonkey>
{
    public override int Path => MIDDLE;

    public override int Tier => 5;

    public override int Cost => 45200;

    public override string DisplayName => "Super Soda Gigantabomb";

    public override string Description => "The soda bombs are gigantic! Ability: Gigantadrop: He drops a huge soda-mento bomb out of the sky. The aftermath...DESTRUCTION.";

    public override string Icon => "050";

    public override string Portrait => "050";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        weaponModel.rate -= 0.02f;

        projectileModel.GetDamageModel().damage += 5;


        var existingAbilities = towerModel.GetBehaviors<AbilityModel>().ToArray();
        foreach (var abil in existingAbilities)
            towerModel.RemoveBehavior(abil);

        //Ability

        var ability = Game.instance.model.GetTowerModel("DartlingGunner", 1, 4, 0).GetAbility().Duplicate("RowdyRush");
        ability.cooldown = 40;

        var activate = ability.GetBehavior<ActivateAttackModel>();
        activate.lifespan = 10;

        var Bomb300 = Game.instance.model.GetTowerModel("BombShooter", 3, 0, 0);
        var tornadoTemplate = Bomb300.GetAttackModels()[0];


        var tornadoAttack = tornadoTemplate.Duplicate("RowdyRushattack");

        tornadoAttack.RemoveFilter<FilterInvisibleModel>();
        tornadoAttack.weapons[0].projectile.SetHitCamo(true);

        activate.attacks[0] = tornadoAttack;

        var tornadoWeapon = tornadoAttack.weapons[0];

        tornadoWeapon.Rate = 0.25f;
        tornadoWeapon.emission = new ArcEmissionModel("ArcEmissionModel_", 2, 0, 10, null, false, false);

        towerModel.AddBehavior(ability);
        towerModel.GetAbility().icon = GetSpriteReference("ability");

//ability2
        var ability2 = Game.instance.model.GetTowerModel("MonkeyAce", 0, 5, 0).GetAbility().Duplicate("gigantadrop");

        ability2.cooldown = 35;

        towerModel.AddBehavior(ability2);
    }

}