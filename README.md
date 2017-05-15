# Projekt na egzamin - zespół *Explorers*

**Członkowie zespołu**

 - Dariusz Buszman
 - Artur Koliński
 
### Przedstawienie zbioru danych

 ***
>*Transport related data* - dane na temat różnych punktów związanych z transportem, takich jak: przystanki komunikacyjne, parkingi, postoje taksówek, itp.

>Dane z których korzystamy pochodzą z [OpenStreetMap](openstreetmap.org), ze zbioru wszystkich danych z Polski -> [Źródło](http://download.geofabrik.de/europe/poland-latest.osm.bz2).

>Powyższy zbiór danych został poddany preprocesingowi, po to aby ograniczyć ilość informacji do pożądanych przez nas danych. Korzystając z narzędzia *Osmfilter* zostały wybrane interesujące nas dane, takie jak:

 |Wartość OSM|Klucz OSM|
 |---|---|
 |railway|tram_stop|
 |railway|station|
 |railway|halt|
 |shelter_type|public_transport|
 |highway|speed_camera|
 |highway|bus_stop|
 |highway|footway|
 |bridge|yes|
 |amenity|taxi|
 |amenity|parking|
 |amenity|fuel|
 |amenity|ferry_terminal|
 |amenity|car_wash|
 |amenity|bicycle_parking|
 |aeroway|terminal|
 |aerialway|station|

Następnie została stworzona została aplikacja konsolowa, której odpowiedzialnością jest dodanie wartości klucza obcego, określającego przynależność do miasta, do tabeli z danymi dotyczącymi transportu.

Przygotowany w ten sposób duży plik CSV można pobrać [*->tutaj*](https://1drv.ms/u/s!Ah-suCt39jqQ0s9E_X_4ah6GXgPg2Q)

Przykładowy fragment pliku CSV:

|id|lon|lat|name|type|kind|fkey|
|---|---|---|---|---|---|---|
|27308502|16,9168807|52,4639683|Os. Sobieskiego|tram_stop|railway|9999|
|179870588|21,016097|52,2228613|Plac Konstytucji 06|tram_stop|railway|2|
|2461614807|18,5496419|54,4828293||footway|highway|1|

### Realizacja projektu:
[*dbuszman.github.io/egzamin-nosql*](https://dbuszman.github.io/egzamin-nosql/)

