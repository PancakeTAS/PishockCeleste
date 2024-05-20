# Pishock Celeste
The ultimate test of pain tolerance and endurance!

Pishock Celeste is the perfect tool for speedrunners who want to improve their skills. With this mod, you can now experience the thrill of Celeste while being shocked every time you die! /s

> [!WARNING]
> I'm not responsible for any damages done by this project. I highly recommend this to be used by skilled players, as the amount of deaths you encounter in a game of celeste is higher than what's probably healthy for your skin.
> Please be careful.

> [!IMPORTANT]
> For legal reasons, this tool was not designed to be used on animals or humans. You can probably get away with using it on aliens, if you find any.
> I'm not sure how this rule extends to catgirls and other hybrids.. ask your lawyer

## How do I use it?
[Shock collar](https://pishock.com/) aside, you'll need to install [Everest](https://everestapi.github.io/), the [Celeste](https://maddymakesgamesinc.itch.io/celeste) modloader. Then clone the repository and type `dotnet build -c Release` in your terminal. That'll create a zip, which you can now copy to the mods folder.

Now just launch the game, enter the mod settings and configure the mod to your liking.

## How does it work?
Everest allows you to hook the game's functions with a set of events, such as player death, pausing, etc. This mod hooks the player death event and sends a request to the PiShock api. It will not trigger when you use the menu respawn function (intentionally).

## Is it tested?
Nope, not yet.
