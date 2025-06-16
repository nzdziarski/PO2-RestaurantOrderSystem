CREATE TABLE customers (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    phone_number VARCHAR(15) NOT NULL
);

CREATE TABLE tables (
    id SERIAL PRIMARY KEY,
    number INT NOT NULL UNIQUE,
    is_reserved BOOLEAN NOT NULL DEFAULT FALSE
);

CREATE TABLE menu_items (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    price NUMERIC(8,2) NOT NULL,
    category VARCHAR(50) NOT NULL,
    description VARCHAR(500) NOT NULL
);

CREATE TABLE orders (
    id SERIAL PRIMARY KEY,
    date TIMESTAMP NOT NULL DEFAULT NOW(),
    customer_id INT REFERENCES customers(id) ON DELETE SET NULL,
    table_id INT REFERENCES tables(id) ON DELETE CASCADE
);

CREATE TABLE order_items (
    id SERIAL PRIMARY KEY,
    order_id INT REFERENCES orders(id) ON DELETE CASCADE,
    menu_item_id INT REFERENCES menu_items(id),
    price NUMERIC(8,2) NOT NULL,
    quantity INT NOT NULL CHECK (quantity >= 1)
);

CREATE INDEX idx_orders_table_id ON orders(table_id);
CREATE INDEX idx_order_items_order_id ON order_items(order_id);