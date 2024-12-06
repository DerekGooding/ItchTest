﻿using static ConsoleHero.ParagraphBuilder;

namespace TextAttempt.Content;

public static class Paragraphs
{
    public static Paragraph Greeting =>
    ClearOnCall().
    Line("Welcome to the North Pole!").
    Line("Would you like a drink?", Color.Bisque).
    Line("This ").Text("is red", Color.Red).Text(" only.").
    GoTo(Menus.MainChamber).
    Immediate();

    public static Paragraph SeeNothing => Line("There is nothing here...").Immediate();

    public static Paragraph Help =>
        Line("Secrets revealed!").
        Line("Enter to continue.").
        GoTo(GlobalSettings.Service.Exit).
        PressToContinue();
}
