from pathlib import Path

readme_content = """# 🧰 Kitbox - Gestion de configuration d’armoires modulaires

Ce projet a pour but de permettre à un client de configurer une armoire composée de casiers (lockers) via une interface graphique (frontend Avalonia) connectée à une API (backend ASP.NET Core).

---

## 📁 Structure du projet


---

## 🖥️ Frontend - Kitbox_app

- Développé en **C# avec Avalonia UI**
- Permet :
  - d’ajouter et supprimer des casiers
  - de configurer chaque casier (dimensions, couleur, portes…)
  - de valider une configuration complète
  - (à venir) afficher un aperçu 3D et gérer la navigation complète

---

## 🌐 Backend - kitboxAPI

- Web API développée en ASP.NET Core
- Connectée à une base de données **MariaDB**
- Gère :
  - les commandes client
  - le stock
  - les fournisseurs
  - les composants

---

## 🚧 Fonctionnalités en développement

- [x] Ajout / suppression de casiers dans l’interface
- [x] Liaison entre frontend et backend
- [ ] Aperçu visuel de l’armoire
- [ ] Authentification des utilisateurs
- [ ] Gestion des commandes et paiements

---

## ✅ Prérequis

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio 2022+ ou Rider]
- [MariaDB](https://mariadb.org/) pour la base de données

---

## 🤝 Collaboration

Ce projet est **initialement personnel**, mais une version est également partagée avec des camarades dans un dépôt séparé. Cette version est la **copie principale** sécurisée.

---

## 🔒 Licence

Projet académique – Non destiné à la production.  
Licence à définir (par défaut : MIT).
"""

readme_path = Path("/mnt/data/README.md")
readme_path.write_text(readme_content, encoding="utf-8")
readme_path
