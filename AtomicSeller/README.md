# Extranet V4

## Compiler les feuilles de style SCSS
### Visual Studio 2013
https://visualstudiogallery.msdn.microsoft.com/85fa99a6-e4c6-4a1c-9f00-e6a8129b6f4d

### Visual Studio 2015
https://visualstudiogallery.msdn.microsoft.com/3b329021-cd7a-4a01-86fc-714c2d05bb6c
(lire partie Getting started)

## Messages d'information / succès / avertissement...

	FlashMessage.Flash(TempData, new FlashMessage("Vous avez été connecté automatiquement"));

## Confirmation (exemple : suppression)

	<button class="btn btn-danger btn-sm confirmation"
			data-message="Êtes-vous sûr ?"
			data-action="@Url.Action("SupprimerPersonneAutorisee", "Profil", new { @id=1 })">
		<i class="mdi mdi-key-remove"></i> Supprimer personne
	</button>

 -> class "confirmation", attributs data-message et data-action
 -> on utilise un bouton et pas un lien pour éviter le clic droit -> ouvrir dans un nouvel onglet

 ## Model : limiter la longueur d'un string
 
    [StringLength(12)]
    [AdditionalMetadata("StringLength", 12)]
