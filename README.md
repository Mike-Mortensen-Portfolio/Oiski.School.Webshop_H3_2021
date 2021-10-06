# EF Core Webshop

## About The Project
The project and its specifications are defined by the assignment in relation to our lectures on `EF Core` and `Linq`, for which the project is to be handed in as a group project. Our group is formed by **Jasmin Nielsen** and **Mike '_Oiski_' Mortensen**

## Dependencies
- [Microsoft.EntityFramworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/)
- [Microsoft.EntityFrameworkCore.Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/5.0.10)
- [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/5.0.10)

### Terms of Development

- **Specifications**
  - **Frontpage**
    - Forsiden viser et antal produkter med et billede af hver, prisen, navn og en knap til at lægge varen i kurven
    - Der benyttes Paging således at forsiden kun viser et bestemt antal produkter ad gangen. Man kan se at der evt. er flere produkter
    - Der er mulighed for at søge på "Brand" og på "Type" eller lignende
    - Der er også fritekst-søgning
    - Der er mulighed for stigende og faldende sortering
    - Der vises et ikon med en varekurv og et antal varer i kurven. Klikkes på ikonet, vises varekurven
    - Lægges en vare i kurven, vises den opdaterede varekurv
  - **Shop Cart**
    - Varekurven viser en opdateret liste af valgte produkter, med billede, navn, styk-pris, antal (skal kunne ændres) samt linjepriseen.
    - Der skal være en Update knap, som opdaterer priserne hvis man ændrer antallet.
    - Det skal være muligt at fjerne et produkt fra varekurven, hvis man fortryder valget
    - Der skal være en Checkout knap, som fører til Checkout-siden
    - Der skal være en knap, der giver mulighed for at fortsætte med at handle, inden man går til checkout
  - **Checkout**
    - Brugeren skal afgive oplysninger om email, navn, adresse, valg af betalingsmiddel og forsendelse
    - Når brugeren trykke på Køb knappen, skal der udsendes en mail som bekræftelse af købet
  - **Additional Chosen Specifications**
    - Når musen passerer henover et billede af et produkt, fremhæves billedet (evt. med en skygge eller ramme)
    - Mulighed for at logge ind, f.eks. når man går til Checkout. 
    - Hvis brugeren er logget ind, slipper brugeren for at registrere sig igen
    - En Admin side, der giver en administrator en liste over alle produkter og mulighed for at redigere produkterne.

## The program
The assignments states that the following criteria:

**Goal**
> Demonstrate that one can design, program and test a database model that meets the specifications written under _Terms of Development_. The core is to be able to browse through > a collection of shop items, add shop items to a cart, sign up and simulate a purchase.

**Input**
> Input will be provided through a web interface, which is implemented in the second part of the assignment.

**Output**
> Data will be stored in a local SQL Database, which will be controlled and accessed through an EF Core datalayer project.

See the [Wiki](https://github.com/ZhakalenDk/Oiski.School.Wepshop_H3_2021/wiki) for more in depth information about the project.

## Versioning
Versioning is coordinated according to the following template: [_Major_].[_Minor_].[_Path_].\
Each `Feature` must be branched out and developed on an isolated branch and merged back into the `Developer` branch when done.

The syntax for the structure of branch folders must be presented as: [DeveloperName]/[MajorVersion]/[BranchName], where as [BranchName] should be formatted as follows: [Feature]_[SubFeature].\
**Example:**
>**Folder Structure:** _Oiski/v1_ \
>**Branch Name:** _Interface_MainMenu_ \
>**Full Path:** _Oiski/v1/MainMenu_UIOverhaul_

### Change Log
- **[v0.0.0](LinkToVersion)**

## [Oiski.School Namespace Collection](https://github.com/Mike-Mortensen-Portfolio) <-- Click Me
