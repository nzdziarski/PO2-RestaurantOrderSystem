CREATE TABLE customers (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    phone_number VARCHAR(15) NOT NULL
);

CREATE TABLE tables (
    id SERIAL PRIMARY KEY,
    seats INT NOT NULL CHECK (seats >= 1 AND seats <= 4),
    is_available BOOLEAN NOT NULL DEFAULT TRUE
);

CREATE TABLE menu_items (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    price NUMERIC(8,2) NOT NULL,
    category VARCHAR(50) NOT NULL,
    description VARCHAR(500) NOT NULL,
    image_data BYTEA
);

CREATE TABLE orders (
    id SERIAL PRIMARY KEY,
    order_date TIMESTAMP NOT NULL DEFAULT NOW(),
    customer_id INT REFERENCES customers(id) ON DELETE CASCADE,
    table_id INT REFERENCES tables(id) ON DELETE CASCADE
);

CREATE TABLE order_items (
    id SERIAL PRIMARY KEY,
    order_id INT REFERENCES orders(id) ON DELETE CASCADE,
    menu_item_id INT REFERENCES menu_items(id),
    quantity INT NOT NULL CHECK (quantity >= 1)
);