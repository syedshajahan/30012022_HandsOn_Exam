CREATE DATABASE BookRecomendation;

USE BookRecomendation;


CREATE TABLE Authors(
author_id INT IDENTITY PRIMARY KEY,
author_name VARCHAR(50) NOT NULL
);



CREATE TABLE Books(
book_isbn INT PRIMARY KEY,
title VARCHAR(100) ,
book_edition INT NOT NULL,
author_id INT FOREIGN KEY REFERENCES Authors(author_id) NOT NULL
);

CREATE TABLE Reviews(
book_isbn INT FOREIGN KEY REFERENCES Books(book_isbn),
rating INT NOT NULL,
review VARCHAR(100) NOT NULL
);

INSERT INTO Authors VALUES('Shel Silverstein');
INSERT INTO Authors VALUES('Antoine de Saint');
INSERT INTO Authors VALUES('J.R.R. Tolkien');
INSERT INTO Authors VALUES('Garth Stein');
INSERT INTO Authors VALUES('Sarah Ruhl');

select * from Authors;

INSERT INTO Books VALUES(55201,'Where the Sidewalk Ends',1,1);
INSERT INTO Books VALUES(55202,'The Little Prince',1,2);
INSERT INTO Books VALUES(55203,'The Fellowship of the Ring',1,3);
INSERT INTO Books VALUES(55204,'The Art of Racing in the Rain',1,4);
INSERT INTO Books VALUES(55205,'Smile',1,5);


INSERT INTO Reviews VALUES(55201,4,'A great writer!');
INSERT INTO Reviews VALUES(55201,5,' Excellent Book');
INSERT INTO Reviews VALUES(55202,3,'Easy read. This is just a happy, sweet book');
INSERT INTO Reviews VALUES(55202,4,'Pretty awesome!');
INSERT INTO Reviews VALUES(55202,5,' good reading');
INSERT INTO Reviews VALUES(55203,5,'Must buy book');
INSERT INTO Reviews VALUES(55204,5,'Book Lovers will Love This');
INSERT INTO Reviews VALUES(55204,4,'Fabulous tale');


select title,review,AVG(rating) from Books,Reviews where Books.book_isbn = Reviews.book_isbn and Books.title LIKE '%Little Prince%';

select * from books;

