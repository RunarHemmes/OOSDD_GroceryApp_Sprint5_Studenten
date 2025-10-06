# Projectstructuur
Er wordt voor dit project gebruik gemaakt van Clean Architecture.
### .App:
Dit zorgt voor alles wat te maken heeft met de User Interface.

### .Core:
Hier bevindt alle logica zich.

### .Core.Data:
Dit is waar de data, of de verbinding met de database zich bevindt.

---

# Branching strategie
### main:
Hier komt de uiteindelijke code te staan.
Het is niet de bedoeling dat hier directe commits features of fixes naar gedaan worden.

### develop:
Hier worden alle features eerst verzameld en samen getest, dan pas kan er met main gemergd worden.

### feature:
Op de feature branches worden de features ontwikkeld en getest, daarna kan er gemergd worden met develop.
De naam van een features branch is altijd als volgt: feature/naam_van_feature

### hotfix:
Op de hotfix branches worden hotfixes gemaakt voor de main en/of develop branch. Deze kunnen na het testen met main en/of develop gemergd worden.

---

# GroceryApp sprint5 Studentversie  
Dit is de startversie voor studenten voor sprint 5.  
 
UC15 Toevoegen THT datum aan product is compleet.  

UC14 Toevoegen prijzen:  
- Prijs toevoegen aan product class en uitbreiden constructor chain.  
- ProductRepository --> prijsveld vullen met waarden.  
- ProductView uitbreiden met kolom voor de prijs (header en inhoud van de tabel).      

UC12 Productcategoriën toevoegen --> zelfstandig uitwerken:  
Ontwerp:
>```mermaid
>classDiagram
>direction LR
>    class Product {
>	    +int Id
>	    +string Name
>	    +int Stock
>	    +DateOnly ShelfLife
>	    +Decimal Price
>   }
>    class ProductCategory {
>	    +int Id
>	    +string Name
>	    +int ProductId
>	    +int CategoryId
>    }
>    class Category {
>	    +int Id
>	    +string Name
>    }
>
>    Product "1" -- "*" ProductCategory
>    ProductCategory "*" -- "1" Category
> ```
Stappenplan:  
- Maak class Category  
- Maak class ProductCategory  
- Maak Interface en Repository voor Category  
- Maak Interface en Repository voor ProductCategory  
- Maak Interface en Service voor Category  
- Maak Interface en Service voor ProductCategory  
- Registreer de gemaakte Repo's en services in MauiProgramm  
- Maak CategoriesViewModel.  
- Maak CategoriesView.  
- Registreer De view en het ViewModel in MauiProgramm.  
- Maak een menu entry in de tabbar in AppShell.xaml en registreer route in AppShell.xaml.cs  
- Maak ProductCategoriesViewModel.  
- Maak ProductCategoriesView.  
- Registreer De view en het ViewModel in MauiProgramm.  
- Zorg dat de ProductCategoriesView gestart kan worden na het klikken op een Category in CategoriesView  
- Registreer route naar ProductCategoriesView in AppShell.xaml.cs  




