# AntiAfkKick
An application, Dalamud and ACT plugin for preventing being auto-kicked from FFXIV due to inactivity.

**Please use responsibly, this is meant to be used for gatherers or if you are waiting for raid/pf/event, not to just afk in limsa dancing**

## Dalamud plugin
Recommended if you are using FFXIV Quick Launcher. Using AntiAfkKick as Dalamud plugin provides advantages of automatically launching together with game and automatic updates. ACT plugin and standalone version must be updated manually if ever needed.

Add my custom repo URL: 

`https://raw.githubusercontent.com/Eternita-S/MyDalamudPlugins/main/pluginmaster.json` 

then install plugin from plugins list.

Detailed instruction available here: https://github.com/Eternita-S/MyDalamudPlugins

## ACT plugin
Download it here: https://github.com/Eternita-S/AntiAfkKick/releases

Then copy it to any convenient folder. Open up ACT, go to "Plugins" tab, then to "Plugin Listing", then click "Browse" button and select DLL file you have just downloaded, and finally click "Add/Enable plugin". Upon doing so ACT may ask you to unblock file. In this case press "Yes".


## Standalone version
Just download it and run it. No configuration needed. To exit, access program's tray icon.

Download link: https://github.com/Eternita-S/AntiAfkKick/releases

## Patrat - Standalone
My tweaks on the app. More features, worse coding. 

###### Features:
  * Random timer between clicks
  * Min Delay options in Windows Notification. 
  * Max Delay options in Windows Notification. 

###### Always On:
  * Select option to Always send keystrokes, even on active windows.

###### Configuration File
  * If you would like to set your own min/max delays easily accessible configuration file.
  
[Patrat - Standalone Installer](https://github.com/patrat46/AntiAfkKick/blob/3ad706e22203df5b51e21ba7b1efa58e5125b47e/Patrat%20-Standalone/InstallAntiAFKKicker.exe)

[Patrat - Standalone 2.0.0.1](https://github.com/patrat46/AntiAfkKick/tree/patrat46-Stand-alone/Patrat%20-Standalone/Build/2.0.0.1)


## How it works?
At set intervals the program checks if the game window has been active within the last minute. If the game window has been idle a left control click is sent. This is enoung to reset the client inactivity timer.

## But you can just open hud layout and you won't be kicked!
Not anymore. With the recent release of 6.0 Square Enix has updated many loop holes that would allow a person to be in active for extended periods of time. This was implemented to help with congestion, as they have been unable to provide reliable service to their entire subscription base.

## Ethical side of the plugin and my personal opinion about auto-kick
Some people question ethical side of this plugin and in general are against circumventing auto-afk kicking. Here is my personal opinion about it and why I think it's OK to do so:
* First of all, many activities in FFXIV are tied to specific time windows. Once you get kicked, you aren't guaranteed that you are going to get back in without queue. Things such as gathering unspoiled and legendary nodes, fishing, waiting for specific party finder to fill or appear, waiting for hunt train require you to be in game. Just imagine that you have to sit out 15 minutes queue after seeing hunt train announcement, best case you'll be able to join it halfway.
* I would understand AFK-kicking if SE was a startup indie company which can legitimately have issues with servers and lack of funding to fix it. Or if game was free. But both statements are not true. Not only SE makes great profit from the game, they are not shy about spending these money for other projects while the one that brings them money clearly requires maintenance. In other words: they ask you to pay for game, then also pay for every month you playing and then they ask you to bear with inconveniences that are directly a result of them using your money for other projects instead of using it to make sure your experience is as uninterruptible as possible and only then using what is left for other projects. This applies not only to queues and afk kick, but for example also to bots, for example they do not put any effort to stop gathering bots that ruin gathering and crafting fun just because they don't want to pay for programmers to write anti-bot checks, to extend their "special task force" or whatever they call their anti-cheat fighting department and pay them more. 
* Based on what I said above, I conclude that I personally have full rights to circumvent afk-kick. Whether you have that right and want to use it or not, is up to you to decide. However, I do ask you to use this tool or any other tool to bypass afk-kick responsible: if you do know that you won't be playing for a good while (while sleeping or at work for example), please do still log out. 


## Patrat's Opinion
I love my characters and want them to be as alive as possible. Early on my characters would find a bed and go to sleep while I was resting. I work them pretty hard and they rarely go offline. Together they work to add entertainment for my community, while one stands guard to ensure security.

I pay for my time like everyone else. This time entitles me to 30, 60, 90 days or a year of services. When they take action against me for using this service by kicking me offline they are taking away the service I paid for without compensating me. My time is not extended when I am offline. My time is not refunded when I am in a queue. We don't pay by minute, the minimum increment we have is the month. If I am AFK for a month, feel free to pause my subscription and kick me offline, when I get back in you can start it back up again.

If you are unable to offer the service I paid for, change the service User Agreement or product description, so I can consider my purchase better. I won't kill my characters because others believe their characters should have priority over my time.




[Final Fantasy Products Page](https://na.finalfantasyxiv.com/product/#usage_fee)

>60-day game time cards and game time codes are available at participating video game retailers. They serve as a payment option that allows players to  - **add 60-days of game time** - to their account at the Standard subscription rate, subject to account limits.
>
>Sixty days of game time will be added to your account once you redeem the game time code on the [Mog Station](http://sqex.to/Msp), the FINAL FANTASY XIV Account Management System. The 20-digit code can be found on the physical card, printed on a purchase receipt, or delivered via the digital retailer.
[User Agreement](https://support.na.square-enix.com/rule.php?id=5382&la=1&tag=users_en)

## Does this count as "Prohibited Activites"

###### Short answer: Yes. 

[Prohibited Activities in Final Fantasy XIV](https://support.na.square-enix.com/faqarticle.php?id=5382&la=1&kid=68216)
> ■Behavior that disrupts the game balance
Square Enix strictly prohibits the use of third-party programs or tools as these disrupt the balance of the game. Third-party programs and tools that permit automated or "absentee" play are prohibited. A Game Master (GM) may speak to players to investigate and confirm "absentee" play, and if the player continues with this behavior, contrary to the GM's instructions, they will be treated as participating in "absentee" play and subject to penalties.
>
>Accordingly, the following activities are prohibited:
>
> - Modifying, analyzing, integrating, and/or reverse-engineering game software or data.
> - Creating, distributing, using, or promoting utilities that interact with the game.

###### Long Answer: Yes, but unlikely to be enforced.

GM's and game development has stated on multiple occassions they do not have plans to monitor software running on a persons computer. They have acknowledged that 3rd party applications are commonly used for parsing and modifying the game. They do not intend to hunt down every person who use 3rd party application and don't want to be petty about it. Keyboard and Mouse Macros have been allowed in multiple forums posts on a case by case basis, the response being ruffly, "Can you do it without the Macro? Does it give you an unfair advantage? and are you the one still playing the game or is it playing itself?(absentee play)". With their posted attitude and videos on mods and 3rd party applications, it appears they are more concerned about how your actions affect other players experiance, this clearly falls under "absentee play", but... it isnt exactly playing is it? So is it absentee play?

## What are the alternatives?

Currently there is no known way to bypass the inactivity kick. To remain online for longer than 30 minutes you need to interact with the game. You can set a timer and click a button. You can also install remote access applications to you commputer and your phone. When you step away for extend periods use your remote access to check in every <30 mins.
