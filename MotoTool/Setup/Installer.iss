; -- MotoTool-Installer.iss  (C) 2019 - 2020 --
; -- This is only for Motorola Moto Devices  --

#define appname "MotoTool"
#define appver "2.0.0.1"
#define appexename "MotoTool.exe"

[Setup]
AppName=MotoTool
AppVersion=2.0.0.1
ArchitecturesAllowed=x64
ArchitecturesInstallIn64BitMode=x64
AppContact=Support
AppCopyright=Copyright (C) 2019 - 2020 Franco28.
AppComments=A NET. Tool for Motorola Moto Devices 
AppPublisher=Franco28
AppPublisherURL=https://github.com/Franco28/MotoTool#getting-started
ChangesAssociations=yes
Compression=lzma2/ultra64
CompressionThreads=2
DefaultDirName={autopf}\MotoTool
DefaultGroupName=MotoTool
InternalCompressLevel=ultra
InfoBeforeFile=changelog.txt
LicenseFile=license.txt
OutputDir=C:\adb\
OutputBaseFilename=MotoTool_v2.0.0.1_Setup
SolidCompression=yes
TouchDate=2020-05-20
UninstallDisplayIcon={app}\moto.ico
UserInfoPage=no
WizardStyle=modern

[Files]
Source: "remove.bat"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "moto.ico"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
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
Source: "flash"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "flash/*"; DestDir: "{app}/flash/"; Flags: ignoreversion recursesubdirs createallsubdirs

Source: "MotorolaDeviceManager_2.5.4.exe"; DestDir: "{app}";

[Icons]
Name: "{group}\MotoTool"; Filename: "{app}\MotoTool.exe"
Name: {group}\MotoTool; Filename: {app}\MotoTool.exe; WorkingDir: {app}; IconFilename: {app}\moto.ico; Comment: "MotoTool"; 
Name: {commondesktop}\MotoTool; Filename: {app}\MotoTool.exe; WorkingDir: {app}; IconFilename: {app}\moto.ico; Comment: "MotoTool";

[Run]
Filename: "{app}\MotorolaDeviceManager_2.5.4.exe"; AfterInstall: AfterInstall; Description: "Install MotorolaDeviceManager_2.5.4"; \
  Flags: postinstall runascurrentuser

[UninstallDelete]
Type: files; Name: "C:\adb"; 
Type: filesandordirs; Name: "C:\adb"
Type: filesandordirs; Name: "C:\Program Files\MotoTool"
Type: filesandordirs; Name: "C:\Program Files\Motorola Mobility LLC"
Type: filesandordirs; Name: "C:\Program Files (x86)\Motorola"

[Code] 
procedure AfterInstall();
begin
  DeleteFile(ExpandConstant('{app}\MotorolaDeviceManager_2.5.4.exe'));
  DeleteFile(ExpandConstant('{app}\remove.bat'));
end;
