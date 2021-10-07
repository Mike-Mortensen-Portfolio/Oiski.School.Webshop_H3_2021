# EF Core Webshop

## About The Project
The project and its specifications are defined by the assignment in relation to our lectures on `EF Core` and `Linq`, for which the project is to be handed in as a group project. Our group is formed by **Jasmin 'Jeongoks' Nielsen** and **Mike '_Oiski_' Mortensen**

## Dependencies
- [Microsoft.EntityFramworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/)
- [Microsoft.EntityFrameworkCore.Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/5.0.10)
- [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/5.0.10)

### Terms of Development

- **Specifications**
  - **Frontpage**
    - Front page shows an amount of product with a picture, the price, the name and a button to place the product in the cart.
    - Paging is used, so that the front page only shows a certain amount of products on each page. Showcase there's more than one product.
    - Search feature where the user has the option to search on "Brand" or "Type" of the product.
    - Search feature with free-text searching.
    - Option to make the filtering of the products shown ASC or DESC.
    - An icon of a cart is shown, as well of the quantity of the products laying in it. If the icon is clicked, it will show the shop cart.
    - If a product is added to the cart, it will be shown on the icon, as well as the updated shop cart.
  - **Shop Cart**
    - The shop cart shows an updated list of chosen products, with picture, name, price per product, quantity (can changes).
    - There needs to be an Update button, which will update the prices if the user changes the quantity already in the cart.
    - It needs to be possible to remove a product from the cart, if the user regrets that choice.
    - There needs to be a Checkout button, which leads to the Checkout-page.
    - There needs to be a button, which gives the user the opportunity to continue shopping, before going to the checkout.
  - **Checkout**
    - The user has to give information about their Email, Name, Address, choice of Payment Method and Delivery type.
    - When the user clicks on the 'Buy' button, they have to receive a mail as a confirmation on their order.
  - **Additional Chosen Specifications**
    - When the mouse hovers over a picture of a product, add some shadow behind it, to highlight it.
    - Opportunity to log in, perhaps when the user is on the Checkout page.
    - If the user is already logged in, then they won't have to write their information again.
    - Make an admin page, giving an administrator a list of all products and the opportunity to update and modify them.

## The program
The assignments states that the following criteria:

**Goal**
> Demonstrate that one can design, program and test a database model that meets the specifications written under _Terms of Development_. The core is to be able to browse through > a collection of shop items, add shop items to a cart, sign up and simulate a purchase.

**Input**
> Input will be provided through a web interface, which is implemented in the second part of the assignment.

**Output**
> Data will be stored in a local SQL Database, which will be controlled and accessed through an EF Core datalayer project.

See the [Wiki](https://github.com/ZhakalenDk/Oiski.School.Wepshop_H3_2021/wiki) for more in depth information about the project.

## Diagrams

### Class Diagram over Entities
![ClassDiagram](./Images/Webshop_ClassDiagram.png)

### Entity Relation Diagram over DB
![ERDiagram](./Images/Webshop_DBDiagram.png)

## Versioning
Versioning is coordinated according to the following template: [_Major_].[_Minor_].[Patch].\
Each `Feature` must be branched out and developed on an isolated branch and merged back into the `Developer` branch when done.

The syntax for the structure of branch folders must be presented as: [MajorVersion]/[DeveloperName]/[BranchName], where as [BranchName] should be formatted as follows: [Feature]_[SubFeature].\
**Example:**
>**Folder Structure:** _v1/Oiski_ \
>**Branch Name:** _Interface_MainMenu_ \
>**Full Path:** _v1/Oiski/MainMenu_UIOverhaul_

### Change Log
- **[v0.0.0](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.Webshop_H3_2021/releases/tag/v0.0.0)**
    - Added
      - Project Solution
      - Console Application Project - _For testing features_
      - Datalayer Class Library project - _The backend stuff (EF Core)_
- **[v0.1.0](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.Webshop_H3_2021/releases/tag/v0.1.0)**
    - **Added**
      - `WebShopContext` with ConnectionString.
    - **Prepared**
      - Properties of `DbSet<>` of Entities.
      - DataSeeding for Initialize of Database.
- **[v0.2.0](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.Webshop_H3_2021/releases/tag/v0.2.0)**
    - **Added**
      - `Customer` class
      - `CustomerLogin` class - _The login Info for a customer_
      - `Order` class
      - `Product` class
      - `ProductImage` class
      - `Type` class - _A product type container (Many to Many)_
    - Modified
      - README file to include a section for diagrams and added class diagram over entities
- **[v0.2.1](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.Webshop_H3_2021/releases/tag/v0.2.1)**
    - **Fixed**
      - Password is now a string as intended
- **[v0.3.0](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.Webshop_H3_2021/releases/tag/v0.3.0)**
    - **Fixed**
      - `ImageID` changed to `ProductImageID`, to create Primary Key.
      - Added a Reference Navigational Property to `Customer` inside of `Order`. 
   

## [Oiski.School Namespace Collection](https://github.com/Mike-Mortensen-Portfolio) <-- Click Me
