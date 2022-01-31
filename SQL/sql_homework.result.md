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

<!-- ~~~sql

~~~ -->
