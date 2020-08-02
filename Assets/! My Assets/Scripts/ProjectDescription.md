#Projekt Spiderfeed

Ny mapp som heter !My Assests. 
*Animations
	- CharacterAnim
	- HumanAnimController
	- SpiderAnimController
*Scenes 
	- SampleScene
	- Stage1
*Scripts
	- CameraCollision
	CameraController
	CharacterAnimation
	AIController
	HumanAnimController
	SpiderController
* Models
	* Female
	* Male
	* Spider

Import Assets från Assets store
- PB_Spider 
- ReZStudios
- Fantasy Forest Set

Flytta avatarerna i PB_Spider och ReZStudios "Models" till ! My Assets.

Konfiguration Spindeln (PB_SPider). 
Markera mesh i folderstrukturen. I inspektor, klicka "Rig". Ange avataren som "generic" och sätt antal "bone" till 8. 
Konfiguration Människa (ReZStudios). 
Markera mesh i folderstrukturen. I inspektor, klicka "Rig". Ange avataren som "humanoid" och sätt antal "bone" till 4. 

För att kameran ska följa Player. 

Player=> spider => CameraParent => Main Camera

Ljud: 
Importera ljudfiler => assigna "audio source" till gameObject.
Fonter: 
Importera assets från Unity: Honeti- l18N
Countdown klockan har: ~BOWLBYONESC-REGULAR.TTF~
