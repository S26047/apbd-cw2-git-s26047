apbd-cw2-git-s26047

# System wypożyczalni sprzętu (C#)



\## Opis projektu



Projekt przedstawia prostą aplikację konsolową napisaną w języku C#, która symuluje działanie uczelnianej wypożyczalni sprzętu.

System umożliwia dodawanie sprzętu i użytkowników, wypożyczanie oraz zwracanie sprzętu, a także generowanie podstawowych raportów.



Celem projektu było nie tylko stworzenie działającej aplikacji, ale również zaprojektowanie jej w sposób zgodny z zasadami programowania obiektowego.



\---



\## Funkcjonalności



Aplikacja umożliwia:



\* dodawanie użytkowników (Student, Employee)

\* dodawanie sprzętu (Laptop, Projector, Camera)

\* wyświetlanie listy sprzętu

\* wyświetlanie dostępnego sprzętu

\* wypożyczanie sprzętu

\* zwrot sprzętu (z naliczeniem kary za opóźnienie)

\* sprawdzanie aktywnych wypożyczeń użytkownika

\* wyświetlanie przeterminowanych wypożyczeń

\* prosty raport stanu systemu



\---



\## Struktura projektu



Projekt został podzielony na kilka głównych części:



\### Models



Zawiera klasy domenowe:



\* `Equipment` (klasa bazowa)

\* `Laptop`, `Projector`, `Camera`

\* `User` (klasa bazowa)

\* `Student`, `Employee`

\* `Loan`



Modele przechowują dane i nie zawierają logiki biznesowej.



\---



\### Services



Zawiera klasę:



\* `RentalService`



Odpowiada ona za całą logikę biznesową, m.in.:



\* wypożyczanie sprzętu

\* sprawdzanie limitów użytkowników

\* naliczanie kar

\* kontrolę dostępności sprzętu



\---



\### Program.cs



Zawiera scenariusz demonstracyjny pokazujący działanie systemu.



\---



\## Decyzje projektowe



\### Podział odpowiedzialności



Zdecydowałem się rozdzielić:



\* modele (dane)

\* logikę biznesową (serwis)

\* warstwę uruchomieniową (Program.cs)



Dzięki temu kod jest bardziej czytelny i łatwiejszy do rozwijania.



\---



\### Dziedziczenie



Zastosowałem dziedziczenie w dwóch miejscach:



\* `Equipment` → różne typy sprzętu

\* `User` → różne typy użytkowników



Pozwoliło to uniknąć powielania kodu i uprościć model.



\---



\### Reguły biznesowe w jednym miejscu



Logika taka jak:



\* limity wypożyczeń

\* naliczanie kar



znajduje się w klasie `RentalService`, co ułatwia jej modyfikację i zmniejsza coupling.



\---



\### Kohezja i coupling



Starałem się:



\* utrzymać wysoką kohezję (każda klasa ma jedną odpowiedzialność)

\* ograniczyć coupling (klasy nie są ze sobą nadmiernie powiązane)



\---



\## Uruchomienie



1\. Otworzyć projekt w Rider / Visual Studio

2\. Zbudować projekt

3\. Uruchomić `Program.cs`



\---



\## Możliwe rozszerzenia



\* zapis danych do pliku JSON

\* interaktywne menu w konsoli

\* bardziej rozbudowane raporty

\* dodanie statusów sprzętu (np. uszkodzony)



\---



\## Autor



Projekt wykonany w ramach zajęć APBD.



