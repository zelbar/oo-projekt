# StudIS
Repozitorij sadrži projekt/seminar iz Objektnog oblikovanja za grupu **ExceptionCollection**, ak. godina 2016./2017.

## Članovi tima
- Željko Baranek
- *Zlatko Hrastić* (voditelj)
- Josipa Popović
- Matej Peroš

## Alati i tehnologije
Sustav je razvijen koristeći Visual Studio i Android Studio uz sljedeće tehnologije za pojedina sučelja:
- Windows Forms za desktop
- ASP.NET MVC za korisničko web sučelje
- ASP.NET WebAPI2 sučelje za mobilne i ostale klijente
- Android aplikacija

## Upute za pokretanje
### Baza podataka
#### Stvaranje datoteke
Koristi se MSSQL Express Server i file baza podataka naziva ``StudIS_DB.mdf``.
**Datoteku je potrebno ručno stvoriti u putanji
``C:\Users\Public\databases``** (npr. iz Visual Studia, desni klik na projekt i *New -> Item -> Data -> Service-based Database*, nazvati ``StudIS_DB.mdf`` i nakon toga premjestiti u spomenutu putanju).
#### Punjenje baze početnim podacima (*Seed*)
Pokrenuti projekt ``StudIS.DatabaseSeed`` da bi se prazna baza napunila testnim podacima. Ovaj korak izvršiti samo jednom nad istom datotekom baze podataka.
### Desktop sučelje
Pokrenuti projekt ``StudIS.Desktop``.
### Web sučelje
Pokrenuti projekt ``StudIS.Web.Mvc``.
### WebAPI2 sučelje
Pokrenuti projekt ``StudIS.Web.Api``.
