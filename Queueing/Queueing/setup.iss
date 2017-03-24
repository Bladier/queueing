; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Queueing System"
#define MyAppVersion "1.0.0.0"
#define MyAppPublisher "Perfecto Group of Companies"
#define MyAppExeName "Queueing.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{C2AF822C-D218-4F45-A19B-0F69F2FEED64}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\que-sys\Queueing System
DefaultGroupName=que-sys\Queueing System
OutputDir=C:\Users\MISGWAPOHON\Desktop
OutputBaseFilename=Queueing-System_Testing
SetupIconFile=C:\Users\MISGWAPOHON\Documents\queueing\Queueing\Queueing\Oxygen-Icons.org-Oxygen-Apps-system-software-update.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\MISGWAPOHON\Documents\queueing\Queueing\Queueing\bin\Debug\Queueing.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\MISGWAPOHON\Documents\queueing\Queueing\Queueing\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKCU; Subkey: "Software\cdt-S0ft"; Flags: uninsdeletekeyifempty
Root: HKCU; Subkey: "Software\cdt-S0ft\Pawnshop"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\cdt-S0ft"; Flags: uninsdeletekeyifempty
Root: HKLM; Subkey: "Software\cdt-S0ft\Pawnshop"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\cdt-S0ft\Pawnshop"; ValueType: string; ValueName: "InstallPath"; ValueData: "{app}"

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

