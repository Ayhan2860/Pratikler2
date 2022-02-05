# .Net Core Patikası SQL Lessons 1st Homework Result
- - -

### 1. Sort the data in the title and description columns in the movie table.
~~~sql
SELECT title, description FROM film;
~~~
### 2. Sort the data in all columns in the movie table with the movie  length greater than 60 and less than 75
~~~sql
SELECT * FROM film WHERE length > 60 AND length < 75;
~~~

### 3. Sort the data in all columns in the movie table with rental_rate 0.99 and replacement_cost 12.99 or 28.99
~~~sql
SELECT * FROM film  WHERE rental_rate = 0.99 AND (replacement_cost = 12.99 OR replacement_cost = 28.99);
~~~
### 4. What is the value in the last_name column of the customer whose value is 'Mary' in the first_name column in the customer table?
~~~sql
SELECT first_name, last_name FROM customer WHERE first_name = 'Mary';
~~~

### 5. Sort the data in the movie table whose length is not greater than 50, but whose rental_rate is not 2.99 or 4.99 
~~~sql
SELECT * FROM film WHERE NOT length > 50 AND NOT (rental_rate = 2.99 OR rental_rate =4.99);
~~~
- - -
# .Net Core Patikası SQL Lessons 2st Homework Result
- - -

### 1. In movie tables, the cost to replace data in all columns is sorted by value greater than 12.99, equal and less than 19.99(BETWEEN - AND example below.)
~~~sql
SELECT * FROM film WHERE replacement_cost BETWEEN 12.99 AND 16.99; 
~~~
### 2. Sort the data in the first_name and last_name columns in the actor table provided that first_name is 'Penelope' or 'Nick' or 'Ed'.(Use the IN operator.)
~~~sql
SELECT first_name, last_name FROM actor WHERE first_name IN ('Penelope', 'Nick', 'Ed');
~~~
### 3. Sort the data in all columns in the movie table with rental_rate 0.99, 2.99, 4.99 AND replacement_cost 12.99, 15.99, 28.99 (Use the IN operator)
~~~sql
SELECT * FROM film WHERE (rental_rate IN (0.99, 2.99, 4.99)) AND (replacement_cost IN (12.99, 15.99, 28.99));
~~~

- - -
# .Net Core Patikası SQL Lessons 3st Homework Result
- - -
### 1. List the country names in the country column of the country table, starting with the 'A' character and ending with the 'a' character.
~~~sql
SELECT * FROM country WHERE country LIKE 'A%a';
~~~
### 2. List the country names in the country column of the country table, consisting of at least 6 characters and ending with the 'n' character.
~~~sql
SELECT * FROM country WHERE LENGTH (country) = 6 AND country LIKE ('%n');
~~~
### 3. In the title column of the movie table, list the movie names that contain at least 4 'T' characters, regardless of upper or lower case letters.
~~~sql
SELECT * FROM film WHERE title ILIKE ('%t%t%t%t%');
~~~
### 4.From the data in all the columns in the movie table, sort the data that starts with the title 'C' character, has a length greater than 90 and a rental_rate of 2,99
~~~sql
SELECT * FROM film WHERE title LIKE ('C%') AND length > 90 AND rental_rate = 2.99;
~~~
- - -
# .Net Core Patikası SQL Lessons 4st Homework Result
- - -
### 1.Sort the different values in the replacement_cost column in the movie table.
~~~sql
SELECT DISTINCT replacement_cost FROM film;
~~~

### 2.How many different data are there in the replacement_cost column in the movie table?
~~~sql
SELECT COUNT(DISTINCT replacement_cost) FROM film;
~~~
### 3.How many of the movie titles in the movie table start with the character T and at the same time the rating is equal to 'G'?
~~~sql
SELECT COUNT(*) FROM film WHERE title LIKE ('T%') AND rating = 'G';
~~~

### 4.How many of the country names (country) in the country table consist of 5 characters?
~~~sql
SELECT COUNT(*) FROM country WHERE  LENGTH(country)  = 5;
~~~
### 5.How many of the city names in the city table end with the character 'R' or 'r'?
~~~sql
SELECT COUNT(*) FROM city WHERE city ILIKE ('%R');
~~~

- - -
# .Net Core Patikası SQL Lessons 5st Homework Result
- - -
### 1.List the 5 longest (length) movies in the movie table and the movie title(title) ends with the 'n' character.
~~~sql
SELECT * FROM film WHERE title LIKE '%n' ORDER BY length DESC LIMIT 5;
~~~
### 2.List the shortest (length) second(6,7,8,9,10) 5 movies (6,7,8,9,10) in the movie table and the movie title ends with the 'n' character.
~~~sql
SELECT * FROM film WHERE title LIKE '%n' ORDER BY length ASC OFFSET 5 LIMIT 5;
~~~
### 3.Sort the first 4 data, provided that store_id is 1 in the descending order according to the last_name column in the customer table.
~~~sql
SELECT * FROM customer  WHERE store_id = 1 ORDER BY last_name DESC LIMIT 4;
~~~
# .Net Core Patikası SQL Lessons 6st Homework Result
### 1.What is the average of the values in the rental_rate column in the movie table?
~~~sql
SELECT ROUND (AVG(rental_rate),4) From film;
~~~
### 2.How many of the movies in the movie table start with the character 'C'?
~~~sql
SELECT COUNT(title) FROM film WHERE title LIKE 'C%';
~~~

### 3.Among the movies in the movie table, how many minutes is the longest (length) movie with a rental_rate equal to 0.99?
~~~sql
SELECT MAX(length) FROM film WHERE rental_rate = 0.99;
~~~
### 4.How many different replacement_cost values are there for the movies longer than 150 minutes in the movie table?
~~~sql
SELECT COUNT (DISTINCT replacement_cost) FROM film WHERE length > 150;
~~~
- - -
# .Net Core Patikası SQL Lessons 7st Homework Result
- - -
### 1.Group the movies in the first movie table according to their rating values
~~~sql
SELECT rating, COUNT(*) FROM film GROUP BY rating;
~~~
### 2.When we group the films in the second film table according to the replacement_cost column, list the replacement_cost value with more than 50 films and the corresponding number of films.
~~~sql
SELECT replacement_cost, COUNT(*) FROM film 
GROUP BY replacement_cost 
HAVING COUNT(*) > 50 
ORDER BY COUNT(*);
~~~
### 3.What are the customer numbers corresponding to the store_id values in the customer table?
~~~sql
SELECT store_id, COUNT(*) FROM customer GROUP BY store_id;
~~~
### 4.After grouping the city data in the city table according to the country_id column, share the country_id information with the highest number of cities and the number of cities.
~~~sql
SELECT country_id, COUNT(*) FROM city
GROUP BY country_id
ORDER BY COUNT(*) DESC
LIMIT 1;
~~~
<!-- ~~~sql

~~~ -->
