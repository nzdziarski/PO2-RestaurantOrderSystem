# Restaurant Order System

System zarządzania zamówieniami w restauracji Język programowania: C# (WinForms) z wykorzystaniem bazy danych PostgreSQL Korzystając z Visual Studio 2022 oraz pgAdmin 4.

## Spis treści

- [Opis projektu](#opis-projektu)
- [Struktura katalogów](#struktura-katalogów)
  - [Database](#database)
  - [Forms](#forms)
  - [Models](#models)
  - [Services](#services)
- [Opis działania](#opis-działania)
- [Instrukcja uruchomienia](#instrukcja-uruchomienia)
- [Autor](#autor)

---

## Opis projektu

Aplikacja służy do zarządzania restauracją: obsługuje zamówienia, stoliki oraz menu. Przechowuje dane w bazie PostgreSQL. Program pozwala na:
- Dodawanie, edycję i usuwanie stolików oraz zamówień
- Zarządzanie pozycjami menu
- Obsługę rezerwacji stolików i przypisywanie do nich zamówień
- Przeglądanie szczegółów zamówienia dla danego stolika

---

## Struktura katalogów

```
RestaurantManagement/
│
├── Database/
│   ├── create_tables.sql
│   └── sample_data.sql
│
├── Forms/
│   ├── MainForm.cs (+Designer, .resx)
│   ├── MenuForm.cs  (+Designer, .resx)
│   ├── OrderForm.cs (+Designer, .resx)
│   ├── TableForm.cs (+Designer, .resx)
│   ├── EditTableForm.cs (+Designer, .resx)
│   ├── EditMenuItemForm.cs (+Designer, .resx)
│   └── OrderDetailsForm.cs (+Designer, .resx)
│
├── Models/
│   ├── Customer.cs
│   ├── MenuItem.cs
│   ├── Order.cs
│   ├── OrderItem.cs
│   └── Table.cs
│
├── Services/
│   ├── CustomerService.cs
│   ├── DatabaseService.cs
│   ├── MenuService.cs
│   ├── OrderService.cs
│   └── TableService.cs
│
└── Program.cs
```

---

### Folder **Database**

**Cel:** Pliki SQL do tworzenia struktury bazy danych i przykładowych danych.

- **create_tables.sql** – Tworzy tabele: customers, tables, menu_items, orders, order_items. Definiuje klucze główne, relacje i indeksy.  
- **sample_data.sql** – Wstawia przykładowe rekordy (klienci, stoliki, menu, zamówienia i pozycje zamówień).

### Folder **Forms**

**Cel:** Okna aplikacji (WinForms) – interfejs użytkownika.

- **MainForm.cs** – Główne okno, wybór funkcji (menu, nowe zamówienie, stoliki), wyświetlanie baneru.
- **MenuForm.cs** – Przeglądanie i zarządzanie pozycjami menu (dodawanie, edycja, usuwanie).
- **OrderForm.cs** – Tworzenie nowego zamówienia, wybór stolika i pozycji z menu, ustalanie ilości.
- **TableForm.cs** – Przeglądanie i zarządzanie stolikami (dodawanie, edycja, usuwanie, podgląd zamówienia).
- **EditTableForm.cs** – Okno do edycji/dodawania stolika (numer, status rezerwacji).
- **EditMenuItemForm.cs** – Okno do edycji/dodawania pozycji menu (nazwa, cena, kategoria, opis).
- **OrderDetailsForm.cs** – Szczegóły i edycja zamówienia przypisanego do stolika.
- Pliki *.Designer.cs oraz *.resx – automatycznie generowane pliki związane z layoutem, tłumaczeniami i zasobami formularzy.

### Folder **Models**

**Cel:** Definicje klas odzwierciedlających tabele bazy danych i strukturę danych aplikacji.

- **Customer.cs** – Klient restauracji (imię, nazwisko, telefon, id).
- **MenuItem.cs** – Pozycja menu (id, nazwa, cena, kategoria, opis).
- **Order.cs** – Zamówienie (id, data, id klienta, id stolika, lista pozycji).
- **OrderItem.cs** – Pozycja zamówienia (id pozycji menu, nazwa, cena, ilość).
- **Table.cs** – Stolik (id, numer, status rezerwacji).

### Folder **Services**

**Cel:** Logika dostępu do bazy oraz operacji biznesowych.

- **DatabaseService.cs** – Zarządza połączeniem z bazą PostgreSQL, wykonywaniem zapytań SQL (ExecuteNonQuery, ExecuteScalar).
- **TableService.cs** – Operacje na stolikach: pobieranie, dodawanie, edycja, usuwanie, sprawdzanie unikalności numeru.
- **MenuService.cs** – Operacje na pozycjach menu: pobieranie, dodawanie, edycja, usuwanie, sprawdzanie unikalności nazw.
- **OrderService.cs** – Operacje na zamówieniach: tworzenie, pobieranie, edycja zamówień i pozycji, usuwanie zamówień oraz pozycji.
- **CustomerService.cs** – Dodawanie nowych klientów.

---

## Opis działania

1. **Główne okno** (MainForm): pozwala przejść do zarządzania menu, stolikami lub tworzenia zamówienia.
2. **Menu** (MenuForm): umożliwia przeglądanie, dodawanie, edycję i usuwanie pozycji menu.
3. **Stoliki** (TableForm): umożliwia zarządzanie stolikami, podgląd rezerwacji oraz szczegółów zamówień.
4. **Nowe zamówienie** (OrderForm): wybór stolika, dodanie pozycji z menu, ustalenie ilości, zapisanie zamówienia.
5. **Szczegóły zamówienia** (OrderDetailsForm): modyfikacja istniejącego zamówienia dla danego stolika.

**Logika biznesowa i dostęp do bazy** realizowane są w folderze `Services`. Dane prezentowane w oknach są pobierane bezpośrednio z bazy lub z lokalnych kolekcji, a aktualizacja (dodanie, edycja, usunięcie) wywołuje odpowiednie metody serwisów.

---

## Instrukcja uruchomienia

1. **Baza danych**
    - Utwórz bazę PostgreSQL o nazwie `RestaurantDB`.
    - W katalogu `Database/` uruchom kolejno:
        - `create_tables.sql` (tworzy strukturę)
        - `sample_data.sql` (przykładowe dane)

2. **Aplikacja**
    - Skonfiguruj połączenie do bazy w pliku `DatabaseService.cs` (domyślnie: host=localhost, port=5433, użytkownik=postgres, hasło=admin).
    - Otwórz projekt w Visual Studio.
    - Zbuduj i uruchom aplikację (`Program.cs` startuje główne okno).

---

## Autor

- Autor: Norbert Zdziarski  

---