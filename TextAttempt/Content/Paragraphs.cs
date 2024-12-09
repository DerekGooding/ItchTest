﻿using static ConsoleHero.ParagraphBuilder;

namespace IHeartFunnyReindeer.Content;

public static class Paragraphs
{
    public static Paragraph Greeting =>
    ClearOnCall().
    Line("Welcome to the North Pole!").
    GoTo(Menus.MainChamber).
    Immediate();

    public static Paragraph SeeNothing =>
        Line("There is nothing here...").
        Immediate();

    public static Paragraph Help =>
        Line("Secrets revealed!").
        Line("Enter to continue.").
        GoTo(GlobalSettings.Service.Exit).
        PressToContinue();

    public static Paragraph GetSnow =>
        Line("You bend over and scoop up some snow.").
        GoTo(() =>
        {
            Player.Inventory[Items.Get(Items.ByName.Snow)]++;
            if (Player.Inventory[Items.Get(Items.ByName.Snow)] >= 10)
                Menus.FarmMenu.Call();
        }).
        Immediate();

    public static Paragraph MakeSnowman =>
        Line("The snow in your pockets was melting.").
        Line("With a little effort, you manage to build a snowman.").
        GoTo(() =>
        {
            Player.Inventory[Items.Get(Items.ByName.Snow)] -= 10;
            if (Player.Inventory[Items.Get(Items.ByName.Snow)] < 10)
                Menus.FarmMenu.Call();
            Places.Get(Places.ByName.Farm).AddBuildable(Buildables.Get(Buildables.ByName.Snowman));
        }).
        DelayInSeconds(1);
}
