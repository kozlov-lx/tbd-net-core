CREATE TABLE IF NOT EXISTS restaurant
(
    restaurant_id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    name VARCHAR NOT NULL,
    city_id INTEGER NOT NULL REFERENCES city(city_id) ON DELETE CASCADE
);

CREATE UNIQUE INDEX restaurant__name__idx ON restaurant (city_id, lower(name));
