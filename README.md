# Getting Started

### MotoTool for Motorola Moto Devices (Beckham, Doha, Lake, River, Evert, Sanders, Potter, Lima, Ocean) - (All variants)

### I'm not going to support firmwares like this:
- "XT1684_POTTER_RETEU_**SS**_8.1.0_OPS28.85-17-6-2_cid50_subsidy-DEFAULT_regulatory-DEFAULT_CFC"
- "XT1685_POTTER_RETEU_**DS**_8.1.0_OPS28.85-17-6-2_cid50_subsidy-DEFAULT_regulatory-DEFAULT_CFC"

#### * [Downloads](https://github.com/Franco28/MotoTool#downloads-1) 
#### * [Contact](https://github.com/Franco28/MotoTool#contact) 

## Prerequisites
- You must have NetFramework 4+ installed on your PC * [Net Framework](https://dotnet.microsoft.com/download) 
- Windows 8+ 64 Bits

## Install
- Start the "MotoTool_v1.6.9.9_Setup.exe"
- The installer will create a desktop shortcut and in Windows app will create a folder with the tool inside. 
- When the installer ends, will ask you ~~if you want to launch the Tool and~~ if you want to isntall MotoDrivers. **Please if you dont have _MotoDrivers installed_ or you dont know, _dont uncheck the option_ and let the install do it ~~(WARNING: Uncheck Launch Tool!)~~**
~~NOTE Setup: if you check the box "Launch MotoTool" the Tool will be executed, but setup wont be closed, so restart the Tool for now~~

## How it works
- The installation will create a "MotoTool" shortcut on desktop
- When you launch the Tool on the first time this will:

-- unpack on "C:\adb\" fastboot&adb

-- launch a batch file like this
![Tool Batch](https://github.com/Franco28/MotoTool/blob/master/Screens/remove.png "Tool Batch")
_**You must accept this, because will remove unnecesary Moto Device Manager to save storage! If you don´t accept this, when you start again the Tool on next launch, will be asking you again! so i recommend you to accept it!_**

-- create neccesary folders

-- generate a settings for the Tool. _Be careful with this, if you clear the folders, you will lost, TWRP, Firmware, and the Tool settings_!

- You must have to be enable usb debugging on your device so the Tool can work!, and **_IMPORTANT have Bootloader unlocked_** to use the options like Boot TWRP or flash any Firmware!

- Then you can use any option, remember if you want to download any file, this will check internet connection, if it´s null the tool will reset and restart the Tool!
![Tool Red Error](https://github.com/Franco28/MotoTool/blob/master/Screens/rederror.png "Tool Red Error")

- If you want to boot TWRP, this will be downloaded **_(when download finish, click again the option!)_** and flashed, but remember to _put your device on Bootloader mode_!

- Themes, the default style it´s dark, so the Tool on the first start will be by default dark, if you want to change it go to "Tool Extras" and select light screen, _but be carefoul with your eyes! light Theme it´s so brightness_!

- New OTA´s! Now you can update the Tool! This is beta and i´m testing this yet! but should work for now

- Firmware option, here Tool will load a tone of firmwares of your device, you can select your device channel. This will download the firmware, dont go back to main Tool screen, because download will be stopped, and firmware deleted. When firmware download finish, this will be extracted into a folder and ready to be flashable! remember to go to MotoFlash option, boot your device into bootloader mode and plug it!, Tool will do everything for you!

- If your device its A/B like doha, evert... etc. now you can use the flash twrp otpion and download TWRP-INSTALLER, then if you want to flash it, go to boot twrp option, plug your device, and in new option "Move files to TWRP" you can drag installer and drop it, this will copy the installer into your device internal storage

~~## Previews~~
~~### What is this?
This is a pre-release of the Tool, this have new options and functions than Stable don´t _**(I recommend you to use this Preview, because i fix errors from Stable that i didn´t noticed!)**_, but if you want to use this previews, you are on your own risk of having bugs, and maybe other accidentally errors!~~

## Uninstall
- You can uninstall it now from the Tool, but ensure that all files were removed on "C:\Program Files\MotoTool\" _(I noticed that Tool won´t be removed)_
- Go to Control Panel and look for the MotoTool, select it and uninstall it! **_Be careful with this, because will ask you at the end if you want to remove MotorolaDeviceManager_2.5.4_!** 

## Home Tool
![Home Tool](https://github.com/Franco28/MotoTool/blob/master/Screens/Tool.png "Tool")
![Theme Light](https://github.com/Franco28/MotoTool/blob/master/Screens/ToolLight.png "Theme Light")

## Motorola Firmware Flash 
![Motorola Firmware Flash](https://github.com/Franco28/MotoTool/blob/master/Screens/MotoFlash.png "Motorola Firmware Flash")

## Motorola Stock Debloat 
![Motorola Stock Debloat](https://github.com/Franco28/MotoTool/blob/master/Screens/Debloat.png "Motorola Stock Debloat")
![Motorola Stock Debloat](https://github.com/Franco28/MotoTool/blob/master/Screens/DebloatOthers.png "Motorola Stock Debloat")

## Downloads
![Downloads](https://github.com/Franco28/MotoTool/blob/master/Screens/Download.png "Downloads")

## Firmware Server
![Firmware](https://github.com/Franco28/MotoTool/blob/master/Screens/FirmwaresServer.png "Firmware")

## Tool Updates
![ToolUpdates](https://github.com/Franco28/MotoTool/blob/master/Screens/Updates.png "ToolUpdates")

## Downloads
#### Download MotoTool v1.6.9.9 - Beta (22-04-2020) from here * [MotoTool](https://github.com/Franco28/MotoTool/releases/tag/v1.6.9.9) 
#### Changelog * [Changelog](https://beckhamtool.000webhostapp.com/MotoTool/changelog.txt) 

## Contact 
#### [Telegram](https://t.me/francom28) 
#### [Page](https://beckhamtool.000webhostapp.com/) 

## Built with and needed by
* [Visual Studio 2019](https://visualstudio.microsoft.com/es/free-developer-offers/)
* [MotoToolEngine](https://github.com/Franco28/MotoTool/tree/master/MotoToolEngine)
* [CopyrightTool](https://github.com/Franco28/MotoTool/tree/master/CopyrightBeckham)
* [AndroidLib](https://github.com/Franco28/MotoTool/tree/master/AndroidLib-Stock)
* [Setup](https://github.com/Franco28/MotoTool/tree/master/Setup)

#### Thanks to [regaw_leinad](https://forum.xda-developers.com/showthread.php?t=1512685) for this old lib!
