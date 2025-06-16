INSERT INTO customers (first_name, last_name, phone_number) VALUES
('Jan', 'Kowalski', '123456789'),
('Anna', 'Nowak', '987654321');

INSERT INTO tables (number, is_reserved) VALUES
(1, TRUE),
(2, FALSE),
(3, FALSE),
(4, FALSE);

INSERT INTO menu_items (name, price, category, description) VALUES
('Pizza Margherita', 25.00, 'Pizza', 'Klasyczna pizza z sosem pomidorowym i mozzarellą.'),
('Spaghetti Bolognese', 30.00, 'Pasta', 'Makaron z sosem mięsnym, pomidorami i ziołami.'),
('Sałatka Cezar', 18.00, 'Sałatka', 'Sałatka z kurczakiem, grzankami i parmezanem.'),
('Woda mineralna', 5.00, 'Napoje', 'Butelka wody mineralnej 0,5l.');

INSERT INTO orders (date, customer_id, table_id) VALUES
(NOW(), 1, 1);

INSERT INTO order_items (order_id, menu_item_id, price, quantity) VALUES
(1, 1, 25.00, 2),
(1, 4, 5.00, 2);