; -- MotoTool-Installer.iss  (C) 2019 - 2020 --
; -- This is only for Motorola Moto Devices  --

#define MyAppName "MotoTool"
#define MyAppName2 "MotoTool_"
#define MyInstallerSuffix "_Setup"
#define MyAppVersion "2.0.0.6"
#define MyAppPublisher "A NET. Tool for Motorola Moto Devices"
#define MyAppURL "https://github.com/Franco28/MotoTool#getting-started-read-all-please"
#define MyAppExeName "MotoTool.exe"
#define MyAppDate "2020-07-03"

[Setup]
AppId= {{17294AE1-9139-424A-8A69-CFD2CA59CFDF}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppComments={#MyAppPublisher}
AppPublisher=Franco28
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
ChangesAssociations=yes
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputBaseFilename={#MyAppName2}{#MyAppVersion}{#MyInstallerSuffix}
Compression=lzma2/ultra64
InternalCompressLevel=ultra
SolidCompression=yes
CompressionThreads=2
ArchitecturesInstallIn64BitMode=x64
WizardImageStretch=True
ArchitecturesAllowed=x64
AppContact=Support
AppCopyright=Copyright (C) 2019 - 2020 Franco28.
UninstallDisplayIcon={app}\moto.ico
TouchDate={#MyAppDate}
UserInfoPage=no
WizardStyle=modern
InfoBeforeFile=changelog.txt
LicenseFile=license.txt
OutputDir=C:\MotoTool\
UninstallDisplayName={#MyAppName}
VersionInfoVersion={#MyAppVersion}

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}";

[Files]
Source: "remove.bat"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "moto.ico"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "unins.ico"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "MotoTool.exe.config"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "MotoTool.exe.manifest"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "MotoTool.exe"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "MotoTool.application"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "MotoToolEngine.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "MotoToolEngine.pdb"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "MotoToolEngine.dll.config"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "AutoUpdater.NET.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "AutoUpdater.NET.pdb"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "AndroidCtrl.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "AndroidCtrl.pdb"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "MaterialSkin.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "Ionic.Zip.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs    
Source: "log4net.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "log4net.config"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs   
Source: "flash"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "flash/*"; DestDir: "{app}/flash/"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "es"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "es/*"; DestDir: "{app}/es/"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "en"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "en/*"; DestDir: "{app}/en/"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "platform-tools/*"; DestDir: "{app}/platform-tools/"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "MotorolaDeviceManager_2.5.4.exe"; DestDir: "{app}";

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Comment: "MotoTool";
Name: "{group}\{cm:ProgramOnTheWeb,{#MyAppName}}"; Filename: "{#MyAppURL}";
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"; IconFilename: "{app}\unins.ico";
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Comment: "MotoTool"; Tasks: desktopicon;

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, "&", "&&")}}"; Flags: nowait postinstall skipifsilent
Filename: "{app}\MotorolaDeviceManager_2.5.4.exe"; AfterInstall: AfterInstall; Description: "Install MotorolaDeviceManager_2.5.4"; Flags: nowait postinstall skipifsilent runascurrentuser

[UninstallDelete]
Type: filesandordirs; Name: "C:\MotoTool";
Type: files; Name: "C:\MotoTool"; 
Type: filesandordirs; Name: "C:\Program Files\MotoTool";
Type: filesandordirs; Name: "C:\Program Files\Motorola Mobility LLC";
Type: filesandordirs; Name: "C:\Program Files (x86)\Motorola";

[Code] 
procedure AfterInstall();
begin
  DeleteFile(ExpandConstant('{app}\MotorolaDeviceManager_2.5.4.exe'));
  DeleteFile(ExpandConstant('{app}\remove.bat'));
end;  