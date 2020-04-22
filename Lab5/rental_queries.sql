-- 3.  Подготовьте SQL запросы для заполнения таблиц данными.#10
INSERT INTO dvd (title, production_year)
VALUES ('Я - легенда', 2007),
       ('Начало', 2010),
       ('127 часов', 2010),
       ('Большой куш', 2000),
       ('Джентельмены', 2020);

INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Tommy', 'Angelo', 'ABC2020', '2020-02-29');

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES (2, 1, '2020-03-01', '2020-05-05'),
       (3, 1, '2020-03-01', '2020-05-05'),
       (5, 1, '2020-03-01', '2020-05-05');
-- 4.  Подготовьте SQL запрос получения списка всех DVD, год выпуска которых 2010, отсортированных в алфавитном порядке по названию DVD. #10

SELECT *
FROM dvd
WHERE production_year = 2010
ORDER BY title ASC;

-- 5.  Подготовьте SQL запрос для получения списка DVD дисков, которые в настоящее время находятся у клиентов. #10

SELECT dvd.*
FROM offer
    LEFT JOIN dvd ON dvd.dvd_id = offer.dvd_id
WHERE CURRENT_DATE BETWEEN offer.offer_date AND offer.return_date;
