# EntityFramework problem

This is an inheritence problem, for a model-first and then write the code around it EF solution.

The existing database structure has a common Persons table, which is extended by a Sellers and Buyers table.  These extension tables contain properties exclusive for the derived types.  The Persons table contains a ProductId which is a foreign key to the Products table.  With each person being associated with a maximum of one Product (this is an illustration of the problem, so ignore the logic flaw of only being able to buy one product).

In EF, the model matches, with an abstract Person class, and derived Seller and Buyer child classes.

The Product can have one Seller, and Zero to Many Buyers.

I cannot get EF to play ball with this setup.