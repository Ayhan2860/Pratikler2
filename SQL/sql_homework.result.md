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

- - -
# .Net Core Patikası SQL Lessons 8st Homework Result
- - -
### 1.Let's create a table in your patika.dev_test database with employee name column information id(INTEGER), name(VARCHAR(50)), birthDay(DATE), email(VARCHAR(100))
~~~sql
CREATE DATABASE patika.dev_test;
CREATE TABLE employee 
(
	id SERIAL PRIMARY KEY,
	name VARCHAR(50),
	email VARCHAR(100),
	birthDay DATE
);
~~~

### 2.Let's add 50 pieces of data to the employee table we created using the 'Mockaroo' service.
~~~sql
INSERT INTO employee (NAME, email, birthDay) VALUES ('Shane Courtes', 'scourtes0@usgs.gov', null);
INSERT INTO employee (NAME, email, birthDay) VALUES ('Evania Newlands', 'enewlands1@diigo.com', '1922-07-15');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Trula Skehens', 'tskehens2@wikia.com', '1985-06-13');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Bernard Rene', 'brene3@blogs.com', null);
INSERT INTO employee (NAME, email, birthDay) VALUES ('Aleen Badsworth', 'abadsworth4@ucsd.edu', '1946-11-23');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Sancho Endrighi', 'sendrighi5@rambler.ru', null);
INSERT INTO employee (NAME, email, birthDay) VALUES ('Jena Martschke', 'jmartschke6@dropbox.com', '1987-02-11');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Leanna Langdridge', 'llangdridge7@tumblr.com', '1910-02-08');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Freida Waddam', 'fwaddam8@bloomberg.com', '1921-05-07');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Boonie Gascoigne', 'bgascoigne9@jimdo.com', '1961-04-22');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Athene Barribal', null, '1961-11-04');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Friederike Rumford', 'frumfordb@discuz.net', '1937-02-08');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Godfree Belliard', 'gbelliardc@cargocollective.com', null);
INSERT INTO employee (NAME, email, birthDay) VALUES ('Salomo Mochan', 'smochand@harvard.edu', null);
INSERT INTO employee (NAME, email, birthDay) VALUES ('Alastair Beaten', 'abeatene@dagondesign.com', '1947-07-08');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Garrick Ibberson', 'gibbersonf@amazon.com', '1919-08-03');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Cassandra Anmore', 'canmoreg@newyorker.com', null);
INSERT INTO employee (NAME, email, birthDay) VALUES ('Bone Bernucci', 'bbernuccih@xrea.com', '1955-05-26');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Rahal Woodwin', 'rwoodwini@spotify.com', '1923-04-30');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Grazia Aynsley', 'gaynsleyj@php.net', '1943-08-14');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Eldridge Filson', 'efilsonk@dell.com', '1965-01-20');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Carmencita Sheaber', 'csheaberl@lycos.com', '1996-04-23');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Celestine Mathivon', 'cmathivonm@businesswire.com', '1944-12-26');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Demetris Daingerfield', 'ddaingerfieldn@deliciousdays.com', '1970-06-18');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Delores Harroll', 'dharrollo@ifeng.com', '1909-04-12');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Correy Duchart', 'cduchartp@noaa.gov', '1971-04-10');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Corinna Huke', 'chukeq@plala.or.jp', null);
INSERT INTO employee (NAME, email, birthDay) VALUES ('Lela Vowells', 'lvowellsr@liveinternet.ru', '1952-12-31');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Jaquelin Blackbourn', 'jblackbourns@spotify.com', '1960-08-10');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Kathleen Antyshev', 'kantyshevt@sitemeter.com', '1948-11-15');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Lorne Edgerton', 'ledgertonu@slate.com', '1984-07-14');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Garik Berndtssen', 'gberndtssenv@sciencedirect.com', null);
INSERT INTO employee (NAME, email, birthDay) VALUES ('Pate Baunton', 'pbauntonw@clickbank.net', '1942-03-01');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Christie Hopfer', 'chopferx@indiatimes.com', '1940-06-28');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Idelle Goldsmith', 'igoldsmithy@senate.gov', '1930-11-07');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Livia Giff', 'lgiffz@china.com.cn', '1977-07-17');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Rafaelia Dugan', 'rdugan10@stumbleupon.com', '1926-11-24');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Christel Sarjant', 'csarjant11@purevolume.com', '1920-03-26');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Fredelia Gowry', 'fgowry12@census.gov', '1960-06-10');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Boycie Dufton', null, '1995-01-03');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Heida Ellul', 'hellul14@digg.com', '1967-04-12');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Benedicto Beadham', null, '1981-09-24');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Ellsworth Storrah', 'estorrah16@oakley.com', null);
INSERT INTO employee (NAME, email, birthDay) VALUES ('Sloane Kerwick', 'skerwick17@illinois.edu', '1925-04-23');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Nyssa Profit', 'nprofit18@google.cn', '1989-06-15');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Jacinthe Satterfitt', 'jsatterfitt19@ucoz.com', null);
INSERT INTO employee (NAME, email, birthDay) VALUES ('Onida Shobrook', 'oshobrook1a@meetup.com', '1906-12-05');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Trudy Humphris', 'thumphris1b@ox.ac.uk', '1938-10-27');
INSERT INTO employee (NAME, email, birthDay) VALUES ('Dasie Gladdis', 'dgladdis1c@blogtalkradio.com', null);
INSERT INTO employee (NAME, email, birthDay) VALUES ('Viviene Signore', 'vsignore1d@cnet.com', null);
~~~

### 3.Let's do 5 UPDATE operations that will update the other columns according to each of the columns.
~~~sql
-- update by name
UPDATE employee 
SET 
    name = 'Mustafa Yılmaz',
	birthDay = '1988-07-05',
	email = 'mustafa@gmail.com'
WHERE name = 'Viviene Signore';

-- update by id
UPDATE employee 
SET 
    name = 'Ahmet Karaman',
	birthDay = '1982-10-11',
	email = 'ahmet@gmail.com'
WHERE id = 28;

-- update by email
UPDATE employee 
SET 
    name = 'Fatih Kara',
	birthDay = '1987-09-02',
	email = 'fatih@gmail.com'
WHERE email = 'jsatterfitt19@ucoz.com';

-- update by birthDay 
UPDATE employee 
SET 
    name = 'Gökhan Düdükçü',
	birthDay = '1986-06-11',
	email = 'gokhan@gmail.com'
WHERE birthDay = '1920-03-26';

-- update by birthDay and name
UPDATE employee 
SET 
    name = 'Soner Yıldız',
	birthDay = '1988-04-08',
	email = 'soner@gmail.com'
WHERE birthDay = '1988-04-08' AND name = 'Soner Yıldız'
RETURNING *;
~~~
### 4.Let's do 5 DELETE operations that will delete the relevant row according to each of the columns.
 ~~~sql
-- delete by id
DELETE FROM employee 
WHERE id = 5
RETURNING *;

-- delete by birthDay
DELETE FROM employee 
WHERE birthDay = '1906-12-05'
RETURNING *;

-- delete by name
DELETE FROM employee 
WHERE name = 'Godfree Belliard'
RETURNING *;

-- delete by email
DELETE FROM employee 
WHERE email = 'fgowry12@census.gov'
RETURNING *;

-- Delete data whose name starts with B and ends with e
DELETE FROM employee 
WHERE name LIKE 'B%e'
RETURNING *;
~~~ 
- - -
# .Net Core Patikası SQL Lessons 9st Homework Result
- - -

### 1.Write the INNER JOIN query where we can see the city and country names in the city table and the country table together.
 ~~~sql
 SELECT city.city, country.country FROM city INNER JOIN country ON city.country_id = country.country_id;
 ~~~

### 2.Write the INNER JOIN query where we can see the customer table and the payment_id in the payment table and the first_name and last_name names in the customer table together.
 ~~~sql
 SELECT customer.first_name, customer.last_name, payment.payment_id FROM customer INNER JOIN payment ON customer.customer_id = payment.customer_id;
 ~~~
 
 ### 3.Where the INNER JOIN query where we can see the customer table and the rental_id in the rental table and the first_name and last_name names in the customer table together.
~~~sql
SELECT customer.first_name, customer.last_name, rental.rental_id FROM rental INNER JOIN customer ON  rental.customer_id = customer.customer_id;
~~~









