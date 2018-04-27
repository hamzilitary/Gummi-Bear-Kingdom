# Gummi-Bear-Kingdom
Hamza Naeem
Code Review #1 for .NET
Objectives
Phase One Objectives

Can a user add, view, and delete items?
Are form and route helpers present and functioning?
Does the app use a Layout file for styling across the app?
Does the project include a detailed README?
Is the database written code-first, with clear migration instruction?
Phase Two Objectives

Can a user post a review for a product as well as view all reviews for a product? Is the average rating displayed for each product?
Does the landing page contain the top three products?
Does the test project include the required unit tests and do they pass?
Have changes to the database been made using migrations?
Like to haves

Add a Blog section, where contributors may post blog posts discussing chosen topics. Posts should have a title, author, and text-body. The newest blog post should appear at the top of the blog page.
Allow users to add tags to blog posts. Use a many-to-many relationship to do this (each blog can have many tags and each tag can be applied to many blogs).
Allow users to add a picture for a Product. You can use URLs (easier) or pursue research and discover how to include images in your database (harder).
Site Specs
Database

The database should be built code-first. They want to have simple setup on the Gummi Bear Kingdom servers, so I'll need to have a simple database migration set up and ready to run.
UPDATE 4/27/18: The site should have functionality to review products so the database should include a one-to-many relationship between Products and Reviews.
Products: must have a name, cost, and description.
Reviews must have an author, content_body, and rating (1-5).
Migrations are used to update the database from last week.
Landing Page

This is the main page, which includes some information about Gummi Bear Kingdom, and allows access to other areas of the site: An About, and Products Page
The top three products by number of reviews will be listed here.
Products

The Products section will contain a list of products offered by Gummi Bear Kingdom. There will be a few "dummy" products, but not too many.

Products will have a name, cost, and description.
Each product will have its own Details page where its information is displayed as well as its reviews.

Testing

I will use a mock database for testing controller and model functions before using the live test database to test for integration. Required database setup information is below in this README.

The site will include the following functionality and their corresponding tests:

Fully functioning Product model with tests for:

The constructor
Equals()
Method for returning an average rating
Fully functioning Review model with tests for:

The constructor
Equals()
Method for checking if rating is between 1-5,
Method for checking if the Review’s content_body contains less than 255 characters.
Products can be created, retrieved, updated, and removed from the database, as demonstrated by integration tests for:

Create()
Index()
Update()
Delete()
DeleteAll()
Reviews are properly retrieved from and saved to the database with tests for:

Index()
Create()
All controller methods return the correct ActionResult (usually ViewResult or RedirectToActionResult) and Model datatype for each method. With tests for:

GET and POST for each route.
Styling

This should be a well-styled site I'm proud to show potential employers. After core functionality is in place, any extra time will be spent on styling.

If I need inspiration, I will choose a site online with a style I like and build a style for my app based on it. However, I will then include a link to the site your styles are based on here in the README.md.

User Stories
There will ultimately be two levels of user for this site: Administrator and Reader. However, at the outset, it is assumed every user is an Admin to avoid spending time bogged down with authorization programming.

All Users

A user should be able to click on a link on the Landing page that takes them to a page that lists all available Products.
A user should be able to click on each Product and see its Details.
Admin

An admin should be able to add and remove individual Products, as well as delete all Products.
All users are Admin to begin with
