# GTA San Andreas - Settings Switcher


[![Github All Releases](https://img.shields.io/github/downloads/Montrii/GTASA-SettingsSwitcher/total.svg)]()
[![Github Forks](https://img.shields.io/github/forks/Montrii/GTASA-SettingsSwitcher)]()
[![Github Stars](https://img.shields.io/github/stars/Montrii/GTASA-SettingsSwitcher)]()
[![Github Issues](https://img.shields.io/github/issues/Montrii/GTASA-SettingsSwitcher)]()

This little program allows you to use multiple Settings within GTA San Andreas.

The idea behind this program is to swap the *gta_sa.set* file, whenever a different executable is being launched,
with the ones you want it to swap.

Now, how does the program seperate between these "versions"?

There are two ways for anyone to know what "game" the executable is executing.

1) We can just look at the file size of the launched process to determine if the game is on v1.00 or v1.01.
2) Whenever MTA or SAMP launch the game, both launchers become the parent process of the game, hence we can simply get the parent process, 
and based on that, we can say who owns that executable.

(For example, Multi Theft Auto.exe executes "proxy_sa.exe" (which is gta_sa.exe), where as samp.exe or advanced processes like sampcmd.exe execute gta_sa.exe)

This in turns allows for save launching of different game folders without the fear of losing your settings entirely (happens under constant v1.00 and v1.01 launching).


Contents
========

* [Versions](#versions)
* [Features](#features)
* [Credits](#credits)





### Features
---



![alt text](https://cdn.discordapp.com/attachments/1003301547540746271/1058873663551717436/Screenshot_518.png)



You can add the script to your Autostart folder, so whenever you start your computer, it launches automatically!

### Versions
---

Displaying the supported versions of the script to this day.

| Name                           | Supported? |
|--------------------------------|------------|
| v1.00 | Yes        |
| v1.01   | Yes  |
| San Andreas: Multiplayer (SAMP)  | Yes  |
| Multi Theft Auto (MTA)   | Yes  |



### Credits
---

Credits go to me, the creator of the project and idea: Montri.   
Credits also go to any future collaborator.

Licensed under MIT License.





