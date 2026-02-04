; ======================================================================
; Hardware Store Management System - Installer
; Company: Devinfantry
; Target: .NET 8 (Windows Desktop)
; Architecture: x64
; ======================================================================

#define MyAppName "Hardware Store Management System"
#define MyAppVersion "1.5"
#define MyAppPublisher "Devinfantry"
#define MyAppURL "https://www.devinfantry.com"
#define MyAppExeName "Bismillah.exe"

[Setup]
AppId={{05598AA6-35E0-4EF3-9B0C-6360AEB1D321}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}

DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}

UninstallDisplayIcon={app}\{#MyAppExeName}

ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible

DisableProgramGroupPage=yes
PrivilegesRequired=lowest
SolidCompression=yes
WizardStyle=modern
OutputBaseFilename=HardwareStoreSetup_v{#MyAppVersion}

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "Create a &desktop icon"; Flags: unchecked

; ----------------------------------------------------------------------
; Application Files
; ----------------------------------------------------------------------
[Files]
Source: "Bismillah\bin\Release\net8.0-windows\*"; \
    DestDir: "{app}"; \
    Flags: recursesubdirs ignoreversion

; ----------------------------------------------------------------------
; Shortcuts
; ----------------------------------------------------------------------
[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

; ----------------------------------------------------------------------
; Launch App After Install
; ----------------------------------------------------------------------
[Run]
Filename: "{app}\{#MyAppExeName}"; \
    Description: "Launch {#MyAppName}"; \
    Flags: nowait postinstall skipifsilent
