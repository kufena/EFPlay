A simple entity framework example to find some pots and their images - all images and main image - using LINQ to do a left outer join.  I simply wanted to replicate some hand-drawn SQL code to see if it was possible or easy using LINQ.  My conclusion is that it isn't but that I would like to continue to use entity framework core where I can.  I am not entirely sure how entity framework works.  For example, my Pots class has a collection of PotImages but I don't know how to get entity framework to populate that.  I'll keep looking.

Note, at present, Oracle's own EntityFrameworkCore offering doesn't support the version of entity framework core i've used here so we are using the Pomelo.EntityFrameworkCore.MySql nuget package instead.  There is a design package as well.

Here's the left join I was trying to replicate

    MySqlCommand command = new MySqlCommand("SELECT Pots.Id as id, Pots.Potter as potter, Pots.Name as name, Pots.Description as description, Pots.Status as status, PotImages.File as file " +
                                            "FROM Pots LEFT JOIN PotImages ON (PotImages.PotId = Pots.Id AND PotImages.Type = 'main') " +
                                            "WHERE Pots.Potter = 1 AND Pots.Status = 'available'", conn);
                
