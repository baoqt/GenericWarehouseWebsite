# GenericWarehouseWebsite
Giovanni Garcia

Jack Tran

Bao Tran

Taha Kittani

## COMPE 561 Database website project
Warehouse website for an online retailer.

Not used by general consumer, but by employees and managers to handle their stocks.

Has direct access to database.

## TODO:
1.	Login page
	*	~~Make the home page a login prompt~~
	*   ~~Add some form of authentication like using Google(Mentioned after class)~~
	*	Have different privileges for regular employee and manager
	*	~~Have tables unaccessible unless you log in~~
2.	Links
	*	~~Set up links to better move around the tables~~
3.	Decoration
	*	~~Maybe some pictures~~
	*	Something to make it look a little less basic

Our biggest challenge was figuring out Github and navigating the version control. At one point, one of us made a branch and we had difficulty figuring out how to merge his changes into the master branch, resolving the conflicts. Building off that, we also had some problems in not properly and clearly planning out how each of the members would work on parts of the project, leading to some awkwardness in trying to not break each other’s work. What would benefit us the most was if we had set aside some time to meet after we had gotten through the tutorials ourselves and discussed how we would divide the work among us. The fact that we were learning our way through razor pages at the same time as working on the project together did not make it easy to progress.

We couldn't publish our website. We used the commands:
```C#
    Add-Migration /*Name Here*/ -Context ApplicationDbContext
    Update-Database -Context ApplicationDbContext
```
into the Nuget Package Console to make the database.
